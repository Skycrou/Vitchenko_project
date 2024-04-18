using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using ClosedXML.Excel;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Formatting = Newtonsoft.Json.Formatting;

namespace WEB_LAP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
      
      //  public IWcfInterface MyWcfConnection { set; get; }
     


        //private void Connect()
        //{
        //    const string addr = @"http://localhost:12344/MyBestWcfService.svc"; // Адрес сервиса
        //    Uri tcpUri = new Uri(addr);
        //    EndpointAddress address = new EndpointAddress(tcpUri, EndpointIdentity.CreateSpnIdentity("Server"));

        //    BasicHttpBinding basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.None); //HTTP!
        //    //NetTcpBinding netTcpBinding = new NetTcpBinding(SecurityMode.None);

        //    // Ниже строки для того, чтоб пролазили таблицы развером побольше
        //    basicHttpBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
        //    basicHttpBinding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
        //    basicHttpBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
        //    basicHttpBinding.MaxBufferPoolSize = long.MaxValue;
        //    basicHttpBinding.MaxReceivedMessageSize = int.MaxValue;

        //    ChannelFactory<IWcfInterface> factory = new ChannelFactory<IWcfInterface>(basicHttpBinding, address);
        //    this.MyWcfConnection = factory.CreateChannel(); // Создаём само подключение
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
          /* this.Connect();*/ // Коннектимся
                           //  dt1 = this.MyWcfConnection.GetTableByName("select * from Products");
                           // GridView1.AutoGenerateSelectButton = true;

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;

            
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            GridView2.Visible = false;
            GridView1.Visible = true;
            GridView3.Visible = false;

            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text !="")
            {
                try
                {
                    GridView1.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Products");

                    GridView1.DataBind();
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }
               
            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
            
            
        }
        //FUNCTIONS AND METHODS FOR WEB-SITE
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

        public void WCF_SEND_TO_SQL(string DataSource, string InitialCatalog, string Code_of_product, string Title_of_product, int Quentity, string AdditionalInf_of_product, string coast)
        {
            DataTable dt = new DataTable("TableName3");

            string connectionString = $"Data Source='{DataSource}';Initial Catalog='{InitialCatalog}';Integrated Security=True";
            string QUERY = $"insert into Products(Code_Product, Title, Quentity, Additional, Coast) values('{Code_of_product}', '{Title_of_product}', '{Quentity}', '{AdditionalInf_of_product}', '{coast}')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(QUERY, connection))
                {
                    adapter.Fill(dt);
                }
            }


        }

        public void WCF_SENDING_TO_SALES(string DataSource, string InitialCatalog, string name, string surname, string passport, string date, string Code_product, string quentity_product)
        {
            DataTable dt = new DataTable("TableName5");
            string connectionString = $"Data Source='{DataSource}';Initial Catalog='{InitialCatalog}';Integrated Security=True";
            string QUERY_J = $"insert into Sales(Name, Surname, Passport, Date_of_sale, Product_code, Quentity_pr) values('{name}', '{surname}', '{passport}', '{date}', '{Code_product}', '{quentity_product}')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(QUERY_J, connection))
                {
                    adapter.Fill(dt);
                }
            }

        }

        public void WCF_SENDING_TO_RETURNS(string DataSource, string InitialCatalog, string name, string surname, string passport, string date, string Code_product, string quentity_product)
        {
            DataTable dt = new DataTable("TableName5");
            string connectionString = $"Data Source='{DataSource}';Initial Catalog='{InitialCatalog}';Integrated Security=True";
            string QUERY_J = $"insert into Returns(Name, Surname, Passport, Return_date, Product_code, Quentity_pr) values('{name}', '{surname}', '{passport}', '{date}', '{Code_product}', '{quentity_product}')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(QUERY_J, connection))
                {
                    adapter.Fill(dt);
                }
            }

        }

        public void DELETE_SQL_WCF(string DataSource, string InitialCatalog, int ID)
        {
            DataTable dt = new DataTable("TableName4");
            string connectionString = $"Data Source={DataSource};Initial Catalog='{InitialCatalog}';Integrated Security=True";
            string QUERY = $"delete from Products where ID = '{ID}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(QUERY, connection))
                {
                    adapter.Fill(dt);
                }
            }


        }

        public void DELETE_FROM_SALES(string DataSource, string InitialCatalog, int id_sale)
        {
            DataTable dt = new DataTable("TableName4");
            string connectionString = $"Data Source='{DataSource}';Initial Catalog='{InitialCatalog}';Integrated Security=True";
            string QUERY = $"delete from Sales where ID = '{id_sale}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(QUERY, connection))
                {
                    adapter.Fill(dt);
                }
            }
        }

        public void DELETE_FROM_Returns(string DataSource, string InitialCatalog, int id_return)
        {
            DataTable dt = new DataTable("TableName4");
            string connectionString = $"Data Source='{DataSource}';Initial Catalog='{InitialCatalog}';Integrated Security=True";
            string QUERY = $"delete from Returns where ID = '{id_return}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(QUERY, connection))
                {
                    adapter.Fill(dt);
                }
            }

        }

        public void WCF_UPDATE_IN_SQL(string DataSource, string InitialCatalog, int ID, string Code_of_product, string Title_of_product, string Quentity, string AdditionalInf_of_product, string Price)
        {
            DataTable dt = new DataTable("TableName4");
            string connectionString = $"Data Source='{DataSource}';Initial Catalog='{InitialCatalog}';Integrated Security=True";
            string QUERY = $"update Products set Code_Product = '{Code_of_product}', Title = '{Title_of_product}', Quentity = '{Quentity}', Additional = '{AdditionalInf_of_product}', Coast = '{Price}' where ID = {ID} ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(QUERY, connection))
                {
                    adapter.Fill(dt);
                }
            }


        }

        public void DELETE_SQL_WCF_Sales(string DataSource, string InitialCatalog, int ID)
        {
            DataTable dt = new DataTable("TableName4");
            string connectionString = $"Data Source='{DataSource}';Initial Catalog='{InitialCatalog}';Integrated Security=True";
            string QUERY = $"delete from Sales where ID = '{ID}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(QUERY, connection))
                {
                    adapter.Fill(dt);
                }
            }


        }

        public void UPDATE_in_SALES(string DataSource, string InitialCatalog, int ID, string name, string surname, string passport, string date_of_sale, string Product_code, string Quentity_pr)
        {
            DataTable dt = new DataTable("TableName4");
            string connectionString = $"Data Source='{DataSource}';Initial Catalog='{InitialCatalog}';Integrated Security=True";
            string QUERY = $"update Sales set Name = '{name}', Surname = '{surname}', Passport = '{passport}', Date_of_sale = '{date_of_sale}', Product_code = '{Product_code}', Quentity_pr = '{Quentity_pr}' where ID = '{ID}' ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(QUERY, connection))
                {
                    adapter.Fill(dt);
                }
            }
        }

        public void UPDATE_IN_RETURNS(string DataSource, string InitialCatalog, int ID, string name, string surname, string passport, string return_date, string Product_code, string Quentity_pr)
        {
            DataTable dt = new DataTable("TableName4");
            string connectionString = $"Data Source='{DataSource}';Initial Catalog='{InitialCatalog}';Integrated Security=True";
            string QUERY = $"update Returns set Name = '{name}', Surname = '{surname}', Passport = '{passport}', Return_date = '{return_date}', Product_code = '{Product_code}', Quentity_pr = '{Quentity_pr}' where ID = '{ID}' ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(QUERY, connection))
                {
                    adapter.Fill(dt);
                }
            }


        }
        //FUNCTIONS AND METHODS FOR WEB-SITE
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (GridView1.Visible == true)
            {
                string txt1 = TextBox1.Text.ToString();
                string txt2 = TextBox2.Text.ToString();
                int txt3 = int.Parse(TextBox3.Text.ToString());
                string txt4 = TextBox4.Text.ToString();
                string txt5 = TextBox5.Text.ToString();

                if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
                {
                    try
                    {
                        WCF_SEND_TO_SQL(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), txt1, txt2, txt3, txt4, txt5);
                        GridView1.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Products");
                        GridView1.DataBind();
                    }
                    catch
                    {
                        Response.Write($"<script>alert('Данные введены неверно!')</script>");
                    }
                }
                else
                {
                    Response.Write($"<script>alert('Укажите данные!')</script>");
                }


                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
                GridView2.Visible = false;
                GridView1.Visible = true;
                GridView3.Visible = false;
            }
            else if (GridView2.Visible == true)
            {
                string txt1 = TextBox7.Text.ToString();
                string txt2 = TextBox8.Text.ToString();
                string txt3 = TextBox9.Text.ToString();
                string txt4 = TextBox10.Text.ToString();
                string txt5 = TextBox11.Text.ToString();
                string txt6 = TextBox12.Text.ToString();

                if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
                {
                    try
                    {
                        WCF_SENDING_TO_SALES(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), txt1, txt2, txt3, txt4, txt5, txt6);
                        GridView2.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Sales");
                        GridView2.DataBind();
                    }
                    catch
                    {
                        Response.Write($"<script>alert('Данные введены неверно!')</script>");
                    }
                    
                }
                else
                {
                    Response.Write($"<script>alert('Укажите данные!')</script>");
                }

               

                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;
                GridView2.Visible = true;
                GridView1.Visible = false;
                GridView3.Visible = false;
            }
            else if (GridView3.Visible == true)
            {
                string txt1 = TextBox14.Text.ToString();
                string txt2 = TextBox15.Text.ToString();
                string txt3 = TextBox16.Text.ToString();
                string txt4 = TextBox17.Text.ToString();
                string txt5 = TextBox18.Text.ToString();
                string txt6 = TextBox19.Text.ToString();

                if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
                {
                    try
                    {
                        WCF_SENDING_TO_RETURNS(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), txt1, txt2, txt3, txt4, txt5, txt6);
                        GridView3.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Returns");
                        GridView3.DataBind();
                    }
                    catch
                    {
                        Response.Write($"<script>alert('Данные введены неверно!')</script>");
                    }

                }
                else
                {
                    Response.Write($"<script>alert('Укажите данные!')</script>");
                }

               

                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = true;
                GridView2.Visible = false;
                GridView1.Visible = false;
                GridView3.Visible = true;

            }
            

           

        }
       
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    if (GridView1.Visible == true)
                    {
                        int id = -1;
                        for (int i = 0; i < GridView1.Rows.Count; i++)
                        {
                            CheckBox chkSelect = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                            if (chkSelect.Checked == true)
                            {
                                id = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
                                DELETE_SQL_WCF(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), id);
                            }
                        }
                        GridView1.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Products");
                        GridView1.DataBind();
                    }
                    else if (GridView2.Visible == true)
                    {
                        int id = -1;
                        for (int i = 0; i < GridView2.Rows.Count; i++)
                        {
                            CheckBox chkSelect = (CheckBox)GridView2.Rows[i].FindControl("CheckBox2");
                            if (chkSelect.Checked == true)
                            {
                                id = Convert.ToInt32(GridView2.Rows[i].Cells[4].Text);
                                DELETE_FROM_SALES(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), id);
                            }
                        }
                        GridView2.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Sales");
                        GridView2.DataBind();

                    }
                    else if (GridView3.Visible == true)
                    {
                        int id = -1;
                        for (int i = 0; i < GridView3.Rows.Count; i++)
                        {
                            CheckBox chkSelect = (CheckBox)GridView3.Rows[i].FindControl("CheckBox3");
                            if (chkSelect.Checked == true)
                            {
                                id = Convert.ToInt32(GridView3.Rows[i].Cells[4].Text);
                                DELETE_FROM_Returns(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), id);
                            }
                        }
                        GridView3.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Returns");
                        GridView3.DataBind();

                    }

                    if (GridView1.Visible == true)
                    {
                        Panel1.Visible = true;
                        Panel2.Visible = false;
                        Panel3.Visible = false;

                    }
                    else if (GridView2.Visible == true)
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = true;
                        Panel3.Visible = false;
                    }
                    else if (GridView3.Visible == true)
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = true;
                    }
                    else
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = false;

                    }
                }

                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");

                }
            } 
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }
           
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    int id_for_delete = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[4].Text.ToString());
                    DELETE_SQL_WCF(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), id_for_delete);

                    GridView1.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Products");
                    GridView1.DataBind();
                    // Response.Write($"<script>alert('{id}')</script>");
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    GridView2.Visible = false;
                    GridView1.Visible = true;
                    GridView3.Visible = false;
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }

            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

       

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    if (GridView1.Visible == true)
                    {
                        Panel1.Visible = true;
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                    }
                    else
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                    }

                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }
            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }
            

        }
        public string IDENTIFICATION = "";
        public string TXT1 = "";
        public string TXT2 = "";
        public string TXT3 = "";
        public string TXT4 = "";
        public string TXT5 = "";
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if(txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    TextBox1.Text = HttpUtility.HtmlDecode(GridView1.Rows[e.NewSelectedIndex].Cells[5].Text);
                    TextBox2.Text = HttpUtility.HtmlDecode(GridView1.Rows[e.NewSelectedIndex].Cells[6].Text);
                    TextBox3.Text = HttpUtility.HtmlDecode(GridView1.Rows[e.NewSelectedIndex].Cells[7].Text);
                    TextBox4.Text = HttpUtility.HtmlDecode(GridView1.Rows[e.NewSelectedIndex].Cells[8].Text);
                    TextBox5.Text = HttpUtility.HtmlDecode(GridView1.Rows[e.NewSelectedIndex].Cells[9].Text);
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }
            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }
            

            

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if(txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    int ID = Convert.ToInt32(((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text);
                    string Code_product = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
                    string Title = ((TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0]).Text;
                    string Quentity = ((TextBox)GridView1.Rows[e.RowIndex].Cells[7].Controls[0]).Text;
                    string Additional = ((TextBox)GridView1.Rows[e.RowIndex].Cells[8].Controls[0]).Text;
                    string Price = ((TextBox)GridView1.Rows[e.RowIndex].Cells[9].Controls[0]).Text;
                    //Response.Write($"<script>alert('{ID}')</script>");
                    WCF_UPDATE_IN_SQL(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), ID, Code_product, Title, Quentity, Additional, Price);
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    GridView2.Visible = false;
                    GridView1.Visible = true;
                    GridView3.Visible = false;
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");

                }
            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try 
                {
                    GridView1.EditIndex = e.NewEditIndex;
                    GridView1.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Products");
                    GridView1.DataBind();

                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    GridView2.Visible = false;
                    GridView1.Visible = true;
                    GridView3.Visible = false;
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }
            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

          
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    GridView1.EditIndex = -1;
                    GridView1.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Products");
                    GridView1.DataBind();

                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    GridView2.Visible = false;
                    GridView1.Visible = true;
                    GridView3.Visible = false;
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }

            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    GridView1.Visible = false;
                    GridView3.Visible = false;
                    GridView2.Visible = true;
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                    GridView2.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Sales");
                    GridView2.DataBind();
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }

            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           

            
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    int id_for_delete = Convert.ToInt32(GridView2.Rows[e.RowIndex].Cells[4].Text.ToString());
                    DELETE_SQL_WCF_Sales(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), id_for_delete);

                    GridView2.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Sales");
                    GridView2.DataBind();
                    // Response.Write($"<script>alert('{id_for_delete}')</script>");
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                    GridView2.Visible = true;
                    GridView1.Visible = false;
                    GridView3.Visible = false;
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }

            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

        protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                    GridView2.Visible = true;
                    GridView1.Visible = false;
                    GridView3.Visible = false;
                    TextBox7.Text = HttpUtility.HtmlDecode(GridView2.Rows[e.NewSelectedIndex].Cells[5].Text);
                    TextBox8.Text = HttpUtility.HtmlDecode(GridView2.Rows[e.NewSelectedIndex].Cells[6].Text);
                    TextBox9.Text = HttpUtility.HtmlDecode(GridView2.Rows[e.NewSelectedIndex].Cells[7].Text);
                    TextBox10.Text = HttpUtility.HtmlDecode(GridView2.Rows[e.NewSelectedIndex].Cells[8].Text);
                    TextBox11.Text = HttpUtility.HtmlDecode(GridView2.Rows[e.NewSelectedIndex].Cells[9].Text);
                    TextBox12.Text = HttpUtility.HtmlDecode(GridView2.Rows[e.NewSelectedIndex].Cells[10].Text);
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }

            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    GridView2.EditIndex = e.NewEditIndex;
                    GridView2.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Sales");
                    GridView2.DataBind();

                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                    GridView2.Visible = true;
                    GridView1.Visible = false;
                    GridView3.Visible = false;
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }

            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if(txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    GridView2.EditIndex = -1;
                    GridView2.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Sales");
                    GridView2.DataBind();

                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                    GridView2.Visible = true;
                    GridView1.Visible = false;
                    GridView3.Visible = false;
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }

            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    int ID = Convert.ToInt32(((TextBox)GridView2.Rows[e.RowIndex].Cells[4].Controls[0]).Text);
                    string Name = ((TextBox)GridView2.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
                    string Surname = ((TextBox)GridView2.Rows[e.RowIndex].Cells[6].Controls[0]).Text;
                    string Passport = ((TextBox)GridView2.Rows[e.RowIndex].Cells[7].Controls[0]).Text;
                    string Date_of_sale = ((TextBox)GridView2.Rows[e.RowIndex].Cells[8].Controls[0]).Text;
                    string Product_code = ((TextBox)GridView2.Rows[e.RowIndex].Cells[9].Controls[0]).Text;
                    string Quentity_pr = ((TextBox)GridView2.Rows[e.RowIndex].Cells[10].Controls[0]).Text;
                    //Response.Write($"<script>alert('{ID}')</script>");
                    UPDATE_in_SALES(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), ID, Name, Surname, Passport, Date_of_sale, Product_code, Quentity_pr);

                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                    GridView2.Visible = true;
                    GridView1.Visible = false;
                    GridView3.Visible = false;
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }

            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    GridView3.Visible = true;
                    GridView3.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Returns");
                    GridView3.DataBind();
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }

            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }


          
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if(txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    int id_for_delete = Convert.ToInt32(GridView3.Rows[e.RowIndex].Cells[4].Text.ToString());
                    DELETE_FROM_Returns(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), id_for_delete);

                    GridView3.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Returns");
                    GridView3.DataBind();
                    // Response.Write($"<script>alert('{id}')</script>");
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    GridView3.Visible = true;
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }
            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

        protected void GridView3_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    GridView3.Visible = true;
                    TextBox14.Text = HttpUtility.HtmlDecode(GridView3.Rows[e.NewSelectedIndex].Cells[5].Text);
                    TextBox15.Text = HttpUtility.HtmlDecode(GridView3.Rows[e.NewSelectedIndex].Cells[6].Text);
                    TextBox16.Text = HttpUtility.HtmlDecode(GridView3.Rows[e.NewSelectedIndex].Cells[7].Text);
                    TextBox17.Text = HttpUtility.HtmlDecode(GridView3.Rows[e.NewSelectedIndex].Cells[8].Text);
                    TextBox18.Text = HttpUtility.HtmlDecode(GridView3.Rows[e.NewSelectedIndex].Cells[9].Text);
                    TextBox19.Text = HttpUtility.HtmlDecode(GridView3.Rows[e.NewSelectedIndex].Cells[10].Text);

                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }
            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    GridView3.EditIndex = e.NewEditIndex;
                    GridView3.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Returns");
                    GridView3.DataBind();

                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    GridView3.Visible = true;
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }
            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    GridView3.EditIndex = -1;
                    GridView3.DataSource = SELECT_PRODUCT(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), "select * from Returns");
                    GridView3.DataBind();

                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    GridView3.Visible = true;
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }

            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    int ID = Convert.ToInt32(((TextBox)GridView3.Rows[e.RowIndex].Cells[4].Controls[0]).Text);
                    string Name = ((TextBox)GridView3.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
                    string Surname = ((TextBox)GridView3.Rows[e.RowIndex].Cells[6].Controls[0]).Text;
                    string Passport = ((TextBox)GridView3.Rows[e.RowIndex].Cells[7].Controls[0]).Text;
                    string Date_of_sale = ((TextBox)GridView3.Rows[e.RowIndex].Cells[8].Controls[0]).Text;
                    string Product_code = ((TextBox)GridView3.Rows[e.RowIndex].Cells[9].Controls[0]).Text;
                    string Quentity_pr = ((TextBox)GridView3.Rows[e.RowIndex].Cells[10].Controls[0]).Text;
                    //Response.Write($"<script>alert('{ID}')</script>");
                    UPDATE_IN_RETURNS(txt_DataSource.Text.ToString(), txt_Initial_Catalog.Text.ToString(), ID, Name, Surname, Passport, Date_of_sale, Product_code, Quentity_pr);

                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    GridView2.Visible = false;
                    GridView1.Visible = false;
                    GridView3.Visible = true;
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }

            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    if (GridView2.Visible == true)
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = true;
                        Panel3.Visible = false;
                    }
                    else
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                    }
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }

            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_DataSource.Text != "" && txt_Initial_Catalog.Text != "")
            {
                try
                {
                    if (GridView3.Visible == true)
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = true;
                    }
                    else
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                    }
                }
                catch
                {
                    Response.Write($"<script>alert('Данные введены неверно!')</script>");
                }
            }
            else
            {
                Response.Write($"<script>alert('Укажите данные!')</script>");
            }

           
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AnalysisSales.aspx");
        }

       
        public string fileXMLName = "";
        DataTable dataTable1 = new DataTable("MyTable");
        DataTable dataTable2 = new DataTable("MyTable");
        DataTable dataTable3 = new DataTable("MyTable");
        protected void Button8_Click(object sender, EventArgs e)
        {
            if (GridView1.Visible == true && GridView2.Visible == false && GridView3.Visible == false)
            {
                
                // Создаем новый DataSet
                DataSet dataSet = new DataSet("MyDataSet");

                // Создаем DataTable с именем "MyTable" выше в public


                // Добавляем столбцы в DataTable
                dataTable1.Columns.Add("ID", typeof(int));
                dataTable1.Columns.Add("Code_Product", typeof(string));
                dataTable1.Columns.Add("Title", typeof(string));
                dataTable1.Columns.Add("Quentity", typeof(int));
                dataTable1.Columns.Add("Additional", typeof(string));
                dataTable1.Columns.Add("Coast", typeof(string));

                // Добавляем строки в DataTable
                //  dataTable.Rows.Add(1, "872", "Good bed", 53, "Good sofa", "50 000");

                int rows_count = GridView1.Rows.Count;
                //  Response.Write($"<script>alert('{rows_count}')</script>");
                for (int x = 0; x < rows_count; x++)
                {
                    // Считываем строки из GridView1
                    string first = HttpUtility.HtmlDecode(GridView1.Rows[x].Cells[4].Text);
                    int first_int = int.Parse(first);
                    string second = HttpUtility.HtmlDecode(GridView1.Rows[x].Cells[5].Text);
                    string third = HttpUtility.HtmlDecode(GridView1.Rows[x].Cells[6].Text);
                    string fourth = HttpUtility.HtmlDecode(GridView1.Rows[x].Cells[7].Text);
                    int fourth_int = int.Parse(fourth);
                    string fifth = HttpUtility.HtmlDecode(GridView1.Rows[x].Cells[8].Text);
                    string sixth = HttpUtility.HtmlDecode(GridView1.Rows[x].Cells[9].Text);
                    // Добавляем строки в DataTable
                    dataTable1.Rows.Add(first_int, second, third, fourth_int, fifth, sixth);
                }
                // Добавляем DataTable в DataSet
                dataSet.Tables.Add(dataTable1);
                GridView1.DataSource = dataSet;
                GridView1.DataBind();
                //dataSet.WriteXml(@"C:\Users\Admin\Desktop\XML_exported_products.xml");
                dataSet.WriteXml(Server.MapPath(@"~\XML_exported_products.xml"));
            }
            else if (GridView1.Visible == false && GridView2.Visible == true && GridView3.Visible == false)
            {
                // Создаем новый DataSet
                DataSet dataSet = new DataSet("MyDataSet");

                // Создаем DataTable с именем "MyTable" выше в public


                // Добавляем столбцы в DataTable
                dataTable2.Columns.Add("ID", typeof(int));
                dataTable2.Columns.Add("Name", typeof(string));
                dataTable2.Columns.Add("Surname", typeof(string));
                dataTable2.Columns.Add("Passport", typeof(string));
                dataTable2.Columns.Add("Date_of_sale", typeof(string));
                dataTable2.Columns.Add("Product_code", typeof(string));
                dataTable2.Columns.Add("Quentity_pr", typeof(string));

                // Добавляем строки в DataTable
                //  dataTable.Rows.Add(1, "872", "Good bed", 53, "Good sofa", "50 000");

                int rows_count = GridView2.Rows.Count;
                //  Response.Write($"<script>alert('{rows_count}')</script>");
                for (int x = 0; x < rows_count; x++)
                {
                    // Считываем строки из GridView1
                    string first = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[4].Text);
                    int first_int = int.Parse(first);
                    string second = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[5].Text);
                    string third = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[6].Text);
                    string fourth = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[7].Text);
                    string fifth = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[8].Text);
                    string sixth = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[9].Text);
                    string seventh = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[10].Text);
                    // Добавляем строки в DataTable
                    dataTable2.Rows.Add(first_int, second, third, fourth, fifth, sixth, seventh);
                }
                // Добавляем DataTable в DataSet
                dataSet.Tables.Add(dataTable2);
                GridView2.DataSource = dataSet;
                GridView2.DataBind();
                //dataSet.WriteXml(@"C:\Users\Admin\Desktop\XML_exported_products.xml");
                dataSet.WriteXml(Server.MapPath(@"~\XML_exported_sales.xml"));
            }
            else if (GridView1.Visible == false && GridView2.Visible == false && GridView3.Visible == true)
            {
                // Создаем новый DataSet
                DataSet dataSet = new DataSet("MyDataSet");

                // Создаем DataTable с именем "MyTable" выше в public


                // Добавляем столбцы в DataTable
                dataTable3.Columns.Add("ID", typeof(int));
                dataTable3.Columns.Add("Name", typeof(string));
                dataTable3.Columns.Add("Surname", typeof(string));
                dataTable3.Columns.Add("Passport", typeof(string));
                dataTable3.Columns.Add("Return_date", typeof(string));
                dataTable3.Columns.Add("Product_code", typeof(string));
                dataTable3.Columns.Add("Quentity_pr", typeof(string));

                // Добавляем строки в DataTable
                //  dataTable.Rows.Add(1, "872", "Good bed", 53, "Good sofa", "50 000");

                int rows_count = GridView3.Rows.Count;
                //  Response.Write($"<script>alert('{rows_count}')</script>");
                for (int x = 0; x < rows_count; x++)
                {
                    // Считываем строки из GridView1
                    string first = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[4].Text);
                    int first_int = int.Parse(first);
                    string second = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[5].Text);
                    string third = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[6].Text);
                    string fourth = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[7].Text);
                    string fifth = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[8].Text);
                    string sixth = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[9].Text);
                    string seventh = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[10].Text);
                    // Добавляем строки в DataTable
                    dataTable3.Rows.Add(first_int, second, third, fourth, fifth, sixth, seventh);
                }
                // Добавляем DataTable в DataSet
                dataSet.Tables.Add(dataTable3);
                GridView3.DataSource = dataSet;
                GridView3.DataBind();
                //dataSet.WriteXml(@"C:\Users\Admin\Desktop\XML_exported_products.xml");
                dataSet.WriteXml(Server.MapPath(@"~\XML_exported_returns.xml"));
            }
           



        }

    
        
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile && Path.GetExtension(FileUpload1.FileName).Equals(".xml", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(FileUpload1.PostedFile.InputStream);

                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(new XmlNodeReader(xmlDoc));
                   
                    GridView4.DataSource = dataSet;
                    GridView4.DataBind();
                }
                catch (Exception ex)
                {
                    // Обработка ошибок при загрузке и обработке XML-файла
                    // В данном случае, вы можете вывести сообщение об ошибке
                    Response.Write($"Ошибка: {ex.Message}");
                }
            }
            else
            {
                Response.Write("Выберите корректный XML-файл для загрузки.");
            }
        }

        DataTable dataTable4 = new DataTable("MyTable");
        DataTable dataTable5 = new DataTable("MyTable");
        DataTable dataTable6 = new DataTable("MyTable");
        protected void Button9_Click(object sender, EventArgs e)
        {
            if (GridView1.Visible == true)
            {
                Response.Write($"<script>alert('рабоатет grid_1')</script>");
                // Создаем новый DataSet
                DataSet dataSet = new DataSet("MyDataSet");

                // Создаем DataTable с именем "MyTable" выше в public


                // Добавляем столбцы в DataTable
                dataTable4.Columns.Add("ID", typeof(int));
                dataTable4.Columns.Add("Code_Product", typeof(string));
                dataTable4.Columns.Add("Title", typeof(string));
                dataTable4.Columns.Add("Quentity", typeof(int));
                dataTable4.Columns.Add("Additional", typeof(string));
                dataTable4.Columns.Add("Coast", typeof(string));

                // Добавляем строки в DataTable
                //  dataTable.Rows.Add(1, "872", "Good bed", 53, "Good sofa", "50 000");

                int rows_count = GridView1.Rows.Count;
                //  Response.Write($"<script>alert('{rows_count}')</script>");
                for (int x = 0; x < rows_count; x++)
                {
                    // Считываем строки из GridView1
                    string first = HttpUtility.HtmlDecode(GridView1.Rows[x].Cells[4].Text);
                    int first_int = int.Parse(first);
                    string second = HttpUtility.HtmlDecode(GridView1.Rows[x].Cells[5].Text);
                    string third = HttpUtility.HtmlDecode(GridView1.Rows[x].Cells[6].Text);
                    string fourth = HttpUtility.HtmlDecode(GridView1.Rows[x].Cells[7].Text);
                    int fourth_int = int.Parse(fourth);
                    string fifth = HttpUtility.HtmlDecode(GridView1.Rows[x].Cells[8].Text);
                    string sixth = HttpUtility.HtmlDecode(GridView1.Rows[x].Cells[9].Text);
                    // Добавляем строки в DataTable
                    dataTable4.Rows.Add(first_int, second, third, fourth_int, fifth, sixth);
                }
                // Добавляем DataTable в DataSet
                dataSet.Tables.Add(dataTable4);
                GridView1.DataSource = dataSet;
                GridView1.DataBind();
                //dataSet.WriteXml(@"C:\Users\Admin\Desktop\XML_exported_products.xml");
               
                // Сериализация DataTable в JSON
                string json = DataTableToJson(dataTable4);
                // Путь к файлу JSON
                string filePath = Server.MapPath(@"~\JSONProducts.json");
                // Запись JSON-данных в файл
                WriteJsonToFile(json, filePath);
            }
            else if (GridView2.Visible == true)
            {
                Response.Write($"<script>alert('рабоатет grid_2')</script>");
                // Создаем новый DataSet
                DataSet dataSet = new DataSet("MyDataSet");

                // Создаем DataTable с именем "MyTable" выше в public


                // Добавляем столбцы в DataTable
                dataTable5.Columns.Add("ID", typeof(int));
                dataTable5.Columns.Add("Name", typeof(string));
                dataTable5.Columns.Add("Surname", typeof(string));
                dataTable5.Columns.Add("Passport", typeof(string));
                dataTable5.Columns.Add("Date_of_sale", typeof(string));
                dataTable5.Columns.Add("Product_code", typeof(string));
                dataTable5.Columns.Add("Quentity_pr", typeof(string));

                // Добавляем строки в DataTable
                //  dataTable.Rows.Add(1, "872", "Good bed", 53, "Good sofa", "50 000");

                int rows_count = GridView2.Rows.Count;
                //  Response.Write($"<script>alert('{rows_count}')</script>");
                for (int x = 0; x < rows_count; x++)
                {
                    // Считываем строки из GridView1
                    string first = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[4].Text);
                    int first_int = int.Parse(first);
                    string second = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[5].Text);
                    string third = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[6].Text);
                    string fourth = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[7].Text);
                    string fifth = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[8].Text);
                    string sixth = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[9].Text);
                    string seventh = HttpUtility.HtmlDecode(GridView2.Rows[x].Cells[10].Text);
                    // Добавляем строки в DataTable
                    dataTable5.Rows.Add(first_int, second, third, fourth, fifth, sixth, seventh);
                }
                // Добавляем DataTable в DataSet
                dataSet.Tables.Add(dataTable5);
                GridView2.DataSource = dataSet;
                GridView2.DataBind();
                //dataSet.WriteXml(@"C:\Users\Admin\Desktop\XML_exported_products.xml");

                // Сериализация DataTable в JSON
                string json = DataTableToJson(dataTable5);
                // Путь к файлу JSON
                string filePath = Server.MapPath(@"~\JSONSales.json");
                // Запись JSON-данных в файл
                WriteJsonToFile(json, filePath);
            }
            else if (GridView3.Visible == true)
            {
                Response.Write($"<script>alert('рабоатет grid_3')</script>");
                // Создаем новый DataSet
                DataSet dataSet = new DataSet("MyDataSet");

                // Создаем DataTable с именем "MyTable" выше в public


                // Добавляем столбцы в DataTable
                dataTable6.Columns.Add("ID", typeof(int));
                dataTable6.Columns.Add("Name", typeof(string));
                dataTable6.Columns.Add("Surname", typeof(string));
                dataTable6.Columns.Add("Passport", typeof(string));
                dataTable6.Columns.Add("Return_date", typeof(string));
                dataTable6.Columns.Add("Product_code", typeof(string));
                dataTable6.Columns.Add("Quentity_pr", typeof(string));

                // Добавляем строки в DataTable
                //  dataTable.Rows.Add(1, "872", "Good bed", 53, "Good sofa", "50 000");

                int rows_count = GridView3.Rows.Count;
                //  Response.Write($"<script>alert('{rows_count}')</script>");
                for (int x = 0; x < rows_count; x++)
                {
                    // Считываем строки из GridView1
                    string first = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[4].Text);
                    int first_int = int.Parse(first);
                    string second = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[5].Text);
                    string third = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[6].Text);
                    string fourth = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[7].Text);
                    string fifth = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[8].Text);
                    string sixth = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[9].Text);
                    string seventh = HttpUtility.HtmlDecode(GridView3.Rows[x].Cells[10].Text);
                    // Добавляем строки в DataTable
                    dataTable6.Rows.Add(first_int, second, third, fourth, fifth, sixth, seventh);
                }
                // Добавляем DataTable в DataSet
                dataSet.Tables.Add(dataTable6);
                GridView3.DataSource = dataSet;
                GridView3.DataBind();
               
                // Сериализация DataTable в JSON
                string json = DataTableToJson(dataTable6);
                // Путь к файлу JSON
                string filePath = Server.MapPath(@"~\JSONReturn.json");
                // Запись JSON-данных в файл
                WriteJsonToFile(json, filePath);
            }
        }
        static void WriteJsonToFile(string json, string filePath)
        {
            // Записываем JSON-данные в файл
            File.WriteAllText(filePath, json);
        }
        static string DataTableToJson(DataTable dataTable)
        {
            // Используем метод SerializeObject из библиотеки Newtonsoft.Json
            return JsonConvert.SerializeObject(dataTable, Formatting.Indented);
        }

       
        protected void Button10_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile && Path.GetExtension(FileUpload1.FileName).Equals(".json", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    // Путь к вашему JSON-файлу
                    string jsonFilePath = Server.MapPath(FileUpload1.FileName);


                    // Чтение JSON-файла
                    string jsonData = System.IO.File.ReadAllText(jsonFilePath);

                    // Десериализация JSON в список словарей
                    List<Dictionary<string, object>> data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonData);

                    // Создание таблицы данных и добавление столбцов
                    DataTable table = new DataTable();
                    if (data.Count > 0)
                    {
                        foreach (var key in data[0].Keys)
                        {
                            table.Columns.Add(key);
                        }
                    }

                    // Заполнение таблицы данными
                    foreach (var item in data)
                    {
                        DataRow row = table.NewRow();
                        foreach (var key in item.Keys)
                        {
                            row[key] = item[key];
                        }
                        table.Rows.Add(row);
                    }

                    // Привязка данных к GridView
                    GridView4.DataSource = table;
                    GridView4.DataBind();
                }
                catch (Exception ex)
                {
                    // Обработка ошибок при загрузке и обработке XML-файла
                    // В данном случае, вы можете вывести сообщение об ошибке
                    Response.Write($"Ошибка: {ex.Message}");
                }
            }
            else
            {
                Response.Write("Выберите корректный XML-файл для загрузки.");
            }

            


        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Profile.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Return_money.aspx");
        }
    }

    
}