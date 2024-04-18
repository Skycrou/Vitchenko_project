<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="WEB_LAP.Purchase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="TableStyle1.css">
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" CssClass="table" runat="server" OnRowDataBound="GridView1_RowDataBound">

        </asp:GridView>
    </form>
</body>
</html>
