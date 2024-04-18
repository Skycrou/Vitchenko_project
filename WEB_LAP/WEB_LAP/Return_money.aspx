<%@ Page Async="True" Language="C#" AutoEventWireup="true" CodeBehind="Return_money.aspx.cs" Inherits="WEB_LAP.Return_money" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" href="ButtonStyle.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="account_return" style="position: relative; margin: 0; display: flex; flex-direction: column; width: 20%">
        <asp:TextBox ID="txt_address_owner_smart_contract" placeholder="Введите адрес smart-контракта" runat="server" style="border-radius: 10px; margin-bottom: 10px;" Width="100%" BackColor="#D8D8D8" Font-Bold="True" Font-Size="Medium" OnTextChanged="txt_address_owner_smart_contract_TextChanged" BorderStyle="None"></asp:TextBox>
        <asp:TextBox ID="Private_key_onwer" placeholder="Введите секретный ключ счёта" runat="server" style="border-radius: 10px; margin-bottom: 10px;" BackColor="#D8D8D8" Font-Bold="True" Font-Size="Medium" Width="100%" OnTextChanged="Private_key_onwer_TextChanged" BorderStyle="None"></asp:TextBox>
        <asp:TextBox ID="Account_address_owner" placeholder="Введите адрес счёта" runat="server" style="border-radius: 10px; margin-bottom: 10px;" BackColor="#D8D8D8" Font-Bold="True" Font-Size="Medium" Width="100%" OnTextChanged="Account_address_owner_TextChanged" BorderStyle="None"></asp:TextBox>
        <asp:Button ID="Button_Confirm" runat="server" CssClass="btn-new" text="Вывести" OnClick="Button_Confirm_Click" Width="40%" />
        </div>
        <div class="balance_smart" style="position: relative; margin-top: 15px; padding: 0; width: 40%; height: auto; display: flex; flex-direction: row">
            <asp:Label ID="lbl_balance" runat="server" Text="Баланс smart-контракта: "></asp:Label>
        <asp:TextBox ID="txt_balance" runat="server" OnTextChanged="txt_balance_TextChanged"></asp:TextBox>
            <asp:Button ID="refresh_balance" runat="server" Text="Обновить" OnClick="refresh_balance_Click" />
        </div>
    </form>
</body>
</html>
