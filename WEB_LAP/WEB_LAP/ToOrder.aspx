<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToOrder.aspx.cs" Inherits="WEB_LAP.ToOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" href="TableStyle1.css">
    <link rel="stylesheet" href="ButtonStyle.css">
     <link rel="stylesheet" href="txtContr.css">
     <link rel="stylesheet" href="Btn_GridView.css">
</head>
<body>
    <form id="form1" runat="server">
<div class="order_textboxes" style="position:relative; margin:0; display: flex; flex-direction: column; height: auto; width: 20%; align-items: center">
    <asp:TextBox ID="TextBox1" runat="server" style="border-radius: 10px;" Width="97%" Height="30px" BorderStyle="None" BackColor="#D8D8D8" Font-Bold="True" Font-Size="Medium" placeholder="Введите номер счёта"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server" style="border-radius: 10px;" Width="97%" Height="30px" BorderStyle="None" BackColor="#D8D8D8" Font-Bold="True" Font-Size="Medium" placeholder="Название товара"></asp:TextBox>
    <asp:TextBox ID="NumericUpDown1" runat="server" style="border-radius: 10px; margin-bottom: 15px" TextMode="Number" Width="97%" Height="30px" BorderStyle="None" BackColor="#D8D8D8" Font-Bold="True" Font-Size="Medium" placeholder="Укажите количество" OnTextChanged="NumericUpDown1_TextChanged"></asp:TextBox>
    <asp:TextBox ID="TextBox3" runat="server" style="border-radius: 10px; margin-bottom: 15px;" Width="97%" Height="30px" BorderStyle="None" BackColor="#D8D8D8" Font-Bold="True" Font-Size="Medium" placeholder="Цена товара"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Заказать" CssClass="btn-new" BorderStyle="None" BorderWidth="0px" width="50%" Height="40px" OnClick="Button1_Click" />
</div>
          <asp:GridView ID="GridView1" runat="server" CssClass="table" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
              <Columns>
                  <asp:CommandField ShowSelectButton="True" SelectText="Выбрать" ButtonType="Button" >
                  <ControlStyle BorderStyle="None" CssClass="btb-control-select-gridview" />
                  </asp:CommandField>
              </Columns>

          </asp:GridView>
    </form>
</body>
</html>
