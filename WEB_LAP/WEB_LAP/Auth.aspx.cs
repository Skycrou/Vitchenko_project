using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_LAP
{
    public partial class Auth : System.Web.UI.Page
    {
        Database database = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var user_name = TextBox1.Text.ToString();
            var user_pass = TextBox2.Text.ToString();
            //var user_passport = TextBox3.Text.ToString();

            DataBank.uname = user_name;
            DataBank.password = user_pass;
            //DataBank.passport = user_passport.ToString();



            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select passw, username from profiledetail where passw = '{user_pass}'" +
                $"and username = '{user_name}'";

            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {

                Response.Write($"<script>alert('Вы успешно авторизовали в системе')</script>");
                Response.Redirect("~/Profile.aspx");

            }
            else
            {
                Response.Write($"<script>alert('Вы не авторизовались в системе')</script>");
            }
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registration.aspx");
        }
    }
    
}