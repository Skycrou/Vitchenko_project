using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace WEB_LAP
{
    public partial class Return_money : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Confirm_Click(object sender, EventArgs e)
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
			var account = new Account(Private_key_onwer.Text.ToString()); //private key account owner
			var web3 = new Web3(account, "http://127.0.0.1:7545");

			var contract = web3.Eth.GetContract(contractAbi, txt_address_owner_smart_contract.Text.ToString()); //адрес смарт-контракта
			//var address_owner = "0xA7103bbdE0a71873423dA428b9C022Ca17bC60d7"; //адрес владельца
		 //   var payForItemFunction = contract.GetFunction("payForItem");
		 //   var maxFeePerGas = Web3.Convert.ToWei(5, UnitConversion.EthUnit.Gwei); // Установите вашу максимальную комиссию
			//var maxPriorityFeePerGas = Web3.Convert.ToWei(1, UnitConversion.EthUnit.Gwei); // Установите вашу максимальную приоритетную комиссию
		 //   var transactionInput = payForItemFunction.CreateTransactionInput(address_owner, 
			//	new Nethereum.Hex.HexTypes.HexBigInteger(90000), new Nethereum.Hex.HexTypes.HexBigInteger(1500000000000), 
			//	new Nethereum.Hex.HexTypes.HexBigInteger(maxFeePerGas), new Nethereum.Hex.HexTypes.HexBigInteger(maxPriorityFeePerGas));
			//var transactionHash = await web3.Eth.Transactions.SendTransaction.SendRequestAsync(transactionInput);

			//Console.WriteLine($"Transaction Hash: {transactionHash}");
			// выводим баланс кошелька
			//try
			//{
			//    var walletAddress = "0x779F89A49F623C2616366cBA8025cda97FE8fa34"; //адрес кошелька владельца
			// var balance = web3.Eth.GetBalance.SendRequestAsync(walletAddress);
			//    var balanceInEther = Web3.Convert.FromWei(balance);
			//    Console.WriteLine($"Баланс кошелька {walletAddress}: {balanceInEther} ETH");
			//    Console.ReadLine();
			//}
			//catch (Exception ex)
			//{
			//    Console.WriteLine($"Ошибка: {ex.Message}");
			//    Console.ReadLine();
			//}
			//выводим баланс кошелька

			// Вызываем функцию withdrawAll
			var withdrawAllFunction = contract.GetFunction("withdrawAll");
			var withdrawAllTransactionInput = withdrawAllFunction.CreateTransactionInput(Account_address_owner.Text.ToString());
			var withdrawAllTransactionHash = web3.Eth.Transactions.SendTransaction.SendRequestAsync(withdrawAllTransactionInput);
			Console.WriteLine($"WithdrawAll Transaction Hash: {withdrawAllTransactionHash}");
			Console.WriteLine($"Transaction Hash for withdrawAll: {withdrawAllTransactionHash}");
		}

        protected void txt_address_owner_smart_contract_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Private_key_onwer_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Account_address_owner_TextChanged(object sender, EventArgs e)
        {

        }

        protected async void refresh_balance_Click(object sender, EventArgs e)
        {
			var account = new Account(Private_key_onwer.Text.ToString()); //private key account owner
			var web3 = new Web3(account, "http://127.0.0.1:7545");

		   // выводим баланс кошелька
			try
            {
                var walletAddress = txt_address_owner_smart_contract.Text.ToString(); //адрес кошелька владельца
                var balance = await web3.Eth.GetBalance.SendRequestAsync(walletAddress);
                var balanceInEther = Web3.Convert.FromWei(balance);
				txt_balance.Text = balanceInEther.ToString() + " ETH".ToString();
				Response.Write($"<script>alert($'Баланс кошелька { walletAddress}: { balanceInEther}ETH')</script>");
			}
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.ReadLine();
            }
            //выводим баланс кошелька
        }

        protected void txt_balance_TextChanged(object sender, EventArgs e)
        {

        }
    }
}