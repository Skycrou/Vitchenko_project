using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WEB_LAP
{
    public partial class Profile : System.Web.UI.Page
    {
        Database database = new Database();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_Status.MaxLength = 200;
            TextBox1.Text = DataBank.password.ToString();
            Label5.Text = DataBank.uname.ToString();
            TextBox1.Visible = false;

            txt_Status.Visible = false;

            
            SqlConnection conn = database.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand($"select profileimage from profiledetail where passw='{TextBox1.Text}'");
            cmd.Connection = conn;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                
                while (dr.Read())
                {
                    try
                    {
                        byte[] imagedata = (byte[])dr["profileimage"];
                        string img = Convert.ToBase64String(imagedata);
                       
                    }
                    catch
                    {
                      //  Response.Write($"<script>alert('Загрузите фото профиля')</script>");
                    }
                    
                }
            }
            conn.Close();
            SqlConnection conn_2 = database.GetConnection();
            conn_2.Open();
            SqlCommand cmd_2 = new SqlCommand($"select coverimage from profiledetail where passw='{TextBox1.Text}'");
            cmd_2.Connection = conn_2;
            SqlDataReader dr_1 = cmd_2.ExecuteReader();

            if (dr_1.HasRows)
            {
                while (dr_1.Read())
                {
                    try
                    {
                        byte[] imagedata = (byte[])dr_1["coverimage"];
                        string img = Convert.ToBase64String(imagedata);

                    }
                    catch
                    {
                     //   Response.Write($"<script>alert('Загрузите обложку')</script>");
                    }
                    
                }
            }
            conn_2.Close();


            SqlConnection conn_1 = database.GetConnection();
            conn_1.Open();
            SqlCommand cmd_1 = new SqlCommand($"select Status from profiledetail where passw='{TextBox1.Text}'");
            cmd_1.Connection = conn_1;
            try
            {
                string t_string = (string)cmd_1.ExecuteScalar();

            }
            catch
            {
               // Response.Write($"<script>alert('Установите свой статус')</script>");
            }

            conn_1.Close();


        }

       

       

        protected void Button2_Click(object sender, EventArgs e)
        {
            /*int imagelen = FileUpload1.PostedFile.ContentLength;
            byte[] Pickbite = new byte[imagelen];
            FileUpload1.PostedFile.InputStream.Read(Pickbite, 0, imagelen);*/
            // Вставляем изображение и идентификатор изображения в базу данных
            SqlConnection conn = database.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand($"update profiledetail set profileimage = @profileimage where passw = '{TextBox1.Text}'");
            cmd.Connection = conn;
           // cmd.Parameters.AddWithValue("@profileimage", Pickbite);
            cmd.ExecuteNonQuery();
            conn.Close();


            SqlConnection conn_1 = database.GetConnection();
            conn_1.Open();
            SqlCommand cmd_1 = new SqlCommand($"select profileimage from profiledetail where passw='{TextBox1.Text}'");
            cmd_1.Connection = conn_1;
            SqlDataReader dr = cmd_1.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    byte[] imagedata = (byte[])dr["profileimage"];
                    string img = Convert.ToBase64String(imagedata);

                }
            }
            conn_1.Close();
        }
       
        protected void btn_UpdateStatus_Click(object sender, EventArgs e)
        {

            txt_Status.Visible = true;



           
        }

        protected void txt_Status_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Auth.aspx");
        }

        protected void btn_Confirmation_Click(object sender, EventArgs e)
        {
            string text_Status = txt_Status.Text.ToString();

            SqlConnection conn = database.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand($"update profiledetail set Status = '{text_Status}' where passw = '{TextBox1.Text}'");
            cmd.Connection = conn;

            cmd.ExecuteNonQuery();
            conn.Close();

           

            SqlConnection conn_1 = database.GetConnection();
            conn_1.Open();
            SqlCommand cmd_1 = new SqlCommand($"select Status from profiledetail where passw='{TextBox1.Text}'");
            cmd_1.Connection = conn_1;
            try
            {
                string t_string = (string)cmd_1.ExecuteScalar();

            }
            catch
            {
               // Response.Write($"<script>alert('Установите свой статус')</script>");
            }

            txt_Status.Visible = false;

            conn_1.Close();
        }

        protected void Update_Cover_Click(object sender, EventArgs e)
        {
 //           int imagelen = FileUpload1.PostedFile.ContentLength;
 //           byte[] Pickbite = new byte[imagelen];
  //          FileUpload1.PostedFile.InputStream.Read(Pickbite, 0, imagelen);
            // Вставляем изображение и идентификатор изображения в базу данных
            SqlConnection conn = database.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand($"update profiledetail set coverimage = @coverimage where passw = '{TextBox1.Text}'");
            cmd.Connection = conn;
  //          cmd.Parameters.AddWithValue("@coverimage", Pickbite);
            cmd.ExecuteNonQuery();
            conn.Close();


            SqlConnection conn_1 = database.GetConnection();
            conn_1.Open();
            SqlCommand cmd_1 = new SqlCommand($"select coverimage from profiledetail where passw='{TextBox1.Text}'");
            cmd_1.Connection = conn_1;
            SqlDataReader dr = cmd_1.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    byte[] imagedata = (byte[])dr["coverimage"];
                    string img = Convert.ToBase64String(imagedata);

                }
            }
            conn_1.Close();
        }

        protected void ManegementProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm1.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Purchase.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ToOrder.aspx");
        }
    }

        
}
    
