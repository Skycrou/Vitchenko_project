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
    public partial class Purchase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = SELECT_PRODUCT(@"DESKTOP-DIO3QU7\SQLTESTERD", "BD_N_time", "select * from Sales");
            GridView1.DataBind();
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
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Если вы хотите фильтровать данные на основе какого-то условия, то это можно сделать здесь.
            // Пример: показывать только строки, где значение в столбце "ColumnName1" равно определенному значению.

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView rowView = (DataRowView)e.Row.DataItem;
                string value = rowView["Passport"].ToString();

                // Пример фильтрации
                if (value == DataBank.passport.ToString())
                {
                    // Оставляем строку видимой
                    e.Row.Visible = true;
                }
                else
                {
                    // Скрываем строку
                    e.Row.Visible = false;
                }
            }
        }
    }
}