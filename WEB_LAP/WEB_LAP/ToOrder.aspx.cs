using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;


namespace WEB_LAP
{
    public partial class ToOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GridView1.DataSource = SELECT_PRODUCT(@"DESKTOP-4FMLIMF\SQLTESTERD", "USERS_IS", "select * from Products");
                GridView1.DataBind();
            }
            catch
            {
                Response.Write($"<script>alert('Данные введены неверно!')</script>");
            }
        }

        public DataTable SELECT_PRODUCT(string DataSource, string InitialCatalog, string QUERY_SQL)
        {
            DataTable dt = new DataTable("TableName2");

            //Инициальзация таблицы вручную
            // dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Clmn1"), new DataColumn("Clmn2"), new DataColumn("Clmn3") });
            // dt.Rows.Add("Hello", name, "Как дела?");
            //// Тут логика получения таблицы из SQL
            string connectionString = $"Data Source={DataSource};Initial Catalog={InitialCatalog};Integrated Security=True";
            string QUERY = string.Format(QUERY_SQL); // Строка запроса SQL. Кстати, считается плохой практикой так передавать параметры.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(QUERY, connection))
                {

                    adapter.Fill(dt);
                    return dt;
                }
            }

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {  
          TextBox2.Text = HttpUtility.HtmlDecode(GridView1.Rows[e.NewSelectedIndex].Cells[3].Text);
          TextBox3.Text = HttpUtility.HtmlDecode(GridView1.Rows[e.NewSelectedIndex].Cells[6].Text);

        }
        public int conclusion_result;
        protected void NumericUpDown1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string quentity = NumericUpDown1.Text.ToString();
                int int_quentity = int.Parse(quentity);
                string price_of_product = TextBox3.Text.ToString();
                string _modifiedString_price_of_product = price_of_product.Substring(0, price_of_product.Length - 4);
                int int_modifiedString_price_of_product = int.Parse(_modifiedString_price_of_product);
                conclusion_result = int_modifiedString_price_of_product * int_quentity;
                string string_conclusion_result = conclusion_result.ToString() + " rub".ToString();
                TextBox3.Text = string_conclusion_result;
            }
            catch
            {
                Response.Write($"<script>alert('Товар не выбран')</script>");
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string contractAbi = @"[
	{
		""inputs"": [],
		""name"": ""payForItem"",
		""outputs"": [],
		""stateMutability"": ""payable"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""constructor""
	},
	{
		""inputs"": [],
		""name"": ""withdrawAll"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""owner"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			}
		],
		""name"": ""payments"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	}
]";
            var account = new Account("0xcd51db45a1d13a592687b1b1526a34ee0ef7be9bb839ebcf365ded95b8768c75"); //адрес аккаунта владельца
            var web3 = new Web3(account, "http://127.0.0.1:7545");

            var contract = web3.Eth.GetContract(contractAbi, "0x135593BfCFb68f93C3355eDB9D176A94F470df4F"); //адрес смарт-контракта
            var address_owner = TextBox1.Text.ToString(); //адрес владельца-клиента
            var payForItemFunction = contract.GetFunction("payForItem");
            var maxFeePerGas = Web3.Convert.ToWei(5, UnitConversion.EthUnit.Gwei); // Установите вашу максимальную комиссию
            var maxPriorityFeePerGas = Web3.Convert.ToWei(1, UnitConversion.EthUnit.Gwei); // Установите вашу максимальную приоритетную комиссию
            var transactionInput = payForItemFunction.CreateTransactionInput(address_owner,
               new Nethereum.Hex.HexTypes.HexBigInteger(90000), new Nethereum.Hex.HexTypes.HexBigInteger(conclusion_result * 10000000000000),
               new Nethereum.Hex.HexTypes.HexBigInteger(maxFeePerGas), new Nethereum.Hex.HexTypes.HexBigInteger(maxPriorityFeePerGas));
            var transactionHash = web3.Eth.Transactions.SendTransaction.SendRequestAsync(transactionInput);

            Response.Write($"<script>alert($'Transaction Hash: { transactionHash}')</script>");

        }

        
    }
}