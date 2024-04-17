using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WEB_LAP
{
    public partial class Registration : System.Web.UI.Page
    {
        Database dataBase = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var user_name = TextBox1.Text.ToString();
            var user_pass = TextBox2.Text.ToString();
            //var user_passport = TextBox3.Text.ToString();
            DataBank.password = user_pass.ToString();
            DataBank.uname = user_name.ToString();
            //DataBank.passport = user_passport.ToString();

            string QUERY = $"insert into profiledetail(passw, username, passport) values('{user_pass}', '{user_name}')";
            SqlCommand command = new SqlCommand(QUERY, dataBase.GetConnection());
            dataBase.openConnection();
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    Response.Write($"<script>alert('Вы успешно зарегистрировались в системе')</script>");
                }
            }
            catch
            {
                Response.Write($"<script>alert('Вы не зарегистрировались')</script>");

            }

            dataBase.closeConnection();

            Response.Redirect("~/Profile.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Auth.aspx");
        }
    }
}