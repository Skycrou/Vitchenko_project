<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="AnalysisSales.aspx.cs" Inherits="WEB_LAP.AnalysisSales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" href="STYLE__AN.css" />
     <link rel="stylesheet" href="TEXT_BOXES.css" />
    <link rel="stylesheet" href="STYLES_FOR_BUTTON_AN.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainblock">
        <div class="CLASS">
        <asp:Label ID="Label" runat="server" Text="Валовая прибыль"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Реализация продукции"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" CssClass="button-blue" Text="Получить данные" OnClick="Button1_ClickAsync" />
        <asp:Label ID="Label3" runat="server" Text="Валовая рентабельность продукции"></asp:Label>
       
        </div>

         <div class="CLASS1">
             <asp:Label ID="Label4" runat="server" Text="Выручка по факту"></asp:Label>
             <asp:TextBox ID="TextBox4" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
             <asp:Label ID="Label5" runat="server" Text="Кол-во прошедших дней"></asp:Label>
             <asp:TextBox ID="TextBox5" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
             <asp:Label ID="Label12" runat="server" Text="Кол-во оставшихся дней"></asp:Label>
             <asp:TextBox ID="TextBox13" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
             <asp:Button ID="Button2" runat="server" CssClass="button-blue" Text="Получить данные" OnClick="Button2_ClickAsync" />
             <asp:Label ID="Label6" runat="server" Text="Прогноз выручки до конца месяца"></asp:Label>
             <asp:TextBox ID="TextBox6" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
         </div>

             <div class="CLASS2">
             <asp:Label ID="Label9" runat="server" Text="Прогноз выручки до конца месяца"></asp:Label>
             <asp:TextBox ID="TextBox10" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
             <asp:Label ID="Label10" runat="server" Text="Выручка по плану"></asp:Label>
             <asp:TextBox ID="TextBox11" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
             <asp:Button ID="Button4" runat="server" CssClass="button-blue" Text="Получить данные" OnClick="Button4_ClickAsync"/>
             <asp:Label ID="Label11" runat="server" Text="Прогноз выполнения плана"></asp:Label>
             <asp:TextBox ID="TextBox12" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
         </div>

             <div class="CLASS3">
             <asp:Label ID="Label13" runat="server" Text="Кол-во продаж прошлого года"></asp:Label>
             <asp:TextBox ID="TextBox14" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
             <asp:Label ID="Label14" runat="server" Text="Кол-во продаж этого года"></asp:Label>
             <asp:TextBox ID="TextBox15" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
             <asp:Button ID="Button5" runat="server" Text="Получить данные" CssClass="button-blue" OnClick="Button5_ClickAsync"/>
             <asp:Label ID="Label15" runat="server" Text="Анализ продаж (разница)"></asp:Label>
             <asp:TextBox ID="TextBox16" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
         </div>

             <div class="CLASS4">
             <asp:Label ID="Label16" runat="server" Text="Себестоимость"></asp:Label>
             <asp:TextBox ID="TextBox17" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
             <asp:Label ID="Label17" runat="server" Text="Процент наценки"></asp:Label>
             <asp:TextBox ID="TextBox18" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
             <asp:Button ID="Button6" runat="server" CssClass="button-blue" Text="Получить данные" OnClick="Button6_ClickAsync"/>
             <asp:Label ID="Label18" runat="server" Text="Наценка на товар"></asp:Label>
             <asp:TextBox ID="TextBox19" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
         </div>

             <div class="CLASS5">
             <asp:Label ID="Label19" runat="server" Text="Прогноз выручки до конца месяца"></asp:Label>
             <asp:TextBox ID="TextBox20" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
             <asp:Label ID="Label20" runat="server" Text="Выручка по плану"></asp:Label>
             <asp:TextBox ID="TextBox21" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
             <asp:Button ID="Button7" runat="server" CssClass="button-blue" Text="Получить данные" OnClick="Button4_ClickAsync"/>
             <asp:Label ID="Label21" runat="server" Text="Прогноз выполнения плана"></asp:Label>
             <asp:TextBox ID="TextBox22" runat="server" CssClass="TEXT_STYLE"></asp:TextBox>
         </div>
        </div>
        <asp:Button ID="exit" runat="server" Text="Выйти" CssClass="fixed-button" OnClick="exit_Click" />
    </form>
</body>
</html>
