<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WEB_LAP.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="registr.css">
    <title></title>
</head>
<body>
    <asp:Image ID="Image1" runat="server" Height="100%" ImageUrl="~/Resources/fon1.jpg" Width="100%" CssClass="image" />
    <form id="form1" runat="server">
        
        <asp:Panel ID="Panel1" runat="server" CssClass="registr">
 <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Segoe UI" Font-Size="36" Text="Регистрация" CssClass="lbl_1"></asp:Label>
            <asp:TextBox ID="TextBox1" placeholder="Введите имя" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox2" placeholder="Введите пароль" runat="server"></asp:TextBox>
            
            <asp:Button ID="Button1" runat="server" Text="Войти" CssClass="btn-new" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Авторизация" CssClass="btn-new" OnClick="Button2_Click" />
        </asp:Panel>
       
    </form>
    
</body>
</html>
