using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_LAP
{
    public partial class AnalysisSales : System.Web.UI.Page
    {
     
        AnalysisService.AnalysisSalesClient clientAnalysis;
        ExtraCharge.ExtraChargeClient clientCharge;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            clientAnalysis = new AnalysisService.AnalysisSalesClient();
            clientCharge = new ExtraCharge.ExtraChargeClient();
        }

        protected async void Button1_ClickAsync(object sender, EventArgs e)
        {
            string GrossProfit_value = TextBox1.Text.ToString();
            string RealizationProduct_value = TextBox2.Text.ToString();
            //TextBox3.Text = await get_profitabilityAsync(GrossProfit_value, RealizationProduct_value);
        }

        public static async Task<string> get_profitabilityAsync(string GrossProfit_value, string RealizationProduct_value)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp("https://godunovromanmanagerproduct.onrender.com/GrossProfitability?GrossProfit=" + GrossProfit_value.ToString() + "&RealizationProduct=" + RealizationProduct_value.ToString());
            using (WebResponse response = await request.GetResponseAsync())
            {
                string result;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = await reader.ReadToEndAsync();
                return result;
            }

        }

        public static async Task<string> get_revenue_forecast_by_the_end_of_the_monthAsync(int Fact_revenue, int Lasts_days, int Remains_days)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp("https://godunovromanmanagerproduct.onrender.com/Revenue_forecast_by_the_end_of_the_month?Fact_revenue=" + Fact_revenue.ToString() + "&Lasts_days="+ Lasts_days.ToString()+"&Remains_days="+ Remains_days.ToString());
            using (WebResponse response = await request.GetResponseAsync())
            {
                string result;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = await reader.ReadToEndAsync();
                return result;
            }

        }

        public static async Task<string> get_forecast_of_the_implementation_of_the_plan_as_a_percentageAsync(int FORECAST, int Plan_revenue)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp("https://godunovromanmanagerproduct.onrender.com/The_forecast_of_the_implementation_of_the_plan_as_a_percentage?FORECAST=" + FORECAST.ToString()+ "&Plan_revenue="+ Plan_revenue.ToString());
            using (WebResponse response = await request.GetResponseAsync())
            {
                string result;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = await reader.ReadToEndAsync();
                return result;
            }

        }

        public static async Task<string> get_ExtraPriceAsync(int CostPrice, int Percent)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp("https://natsenkanikita.onrender.com/ExtraCharge?CostPrice=" + CostPrice.ToString() + "&Percent=" + Percent.ToString());
            using (WebResponse response = await request.GetResponseAsync())
            {
                string result;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = await reader.ReadToEndAsync();
                return result;
            }

        }

        public static async Task<string> get_Analysis_of_SalesAsync(int LastYear_value, int New_Year_value)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp("https://voloshchuk-nikita.onrender.com/AnlisProdag?sales_LastYear=" + LastYear_value.ToString()+"&sales_NowYear=" + New_Year_value.ToString());
            using (WebResponse response = await request.GetResponseAsync())
            {
                string result;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = await reader.ReadToEndAsync();
                return result;
            }

        }



        //protected void TextBox3_TextChanged(object sender, EventArgs e)
        //{

        //}

        protected async void Button2_ClickAsync(object sender, EventArgs e)
        {
            int Fact_revenue = int.Parse(TextBox4.Text);
            int Lasts_days = int.Parse(TextBox5.Text);
            int Remains_days = int.Parse(TextBox13.Text);
            TextBox6.Text = await get_revenue_forecast_by_the_end_of_the_monthAsync(Fact_revenue, Lasts_days, Remains_days);
        }

        protected async void Button4_ClickAsync(object sender, EventArgs e)
        {
            int FORECAST = int.Parse(TextBox10.Text);
            int Plan_revenue = int.Parse(TextBox11.Text);
            TextBox12.Text = await get_forecast_of_the_implementation_of_the_plan_as_a_percentageAsync(FORECAST, Plan_revenue);
        }

        protected async void Button6_ClickAsync(object sender, EventArgs e)
        {
            int CostPrice = int.Parse(TextBox17.Text);
            int Percent = int.Parse(TextBox18.Text);
            TextBox19.Text = await get_ExtraPriceAsync(CostPrice, Percent);
        }

        protected async void Button5_ClickAsync(object sender, EventArgs e)
        {
            int Last_Year = int.Parse(TextBox14.Text);
            int New_Year = int.Parse(TextBox15.Text);
            TextBox16.Text = await get_Analysis_of_SalesAsync(Last_Year, New_Year);
        }

        protected void exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm1.aspx");
        }
    }
}