<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WEB_LAP.WebForm1" %>

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
       <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>

        <div class="buttons" style="position:relative; width:84%; height: 46px; margin-top: 20px;">
        <asp:Button ID="Button1" CssClass="btn-new" runat="server" OnClick="Button1_Click" Text="Все товары" Height="40px" Width="84px" />
        <asp:Button ID="Button2" CssClass="btn-new" runat="server" OnClick="Button2_Click" Text="Добавить" Height="40px" Width="84px" />
        <asp:Button ID="Button3" CssClass="btn-new" runat="server" OnClick="Button3_Click" Text="Удалить" Height="40px" Width="84px" />
        <asp:Button ID="Button4" CssClass="btn-new" runat="server" OnClick="Button4_Click" Text="Продажи" Height="40px" Width="84px" />
        <asp:Button ID="Button5" CssClass="btn-new" runat="server" Text="Возврат" Height="40px" Width="84px" OnClick="Button5_Click" />
        <asp:Button ID="Button6" CssClass="btn-new" runat="server" Text="Информацих продаж" Height="40px" Width="150px" OnClick="Button6_Click" />
        <asp:Button ID="btnUpload" CssClass="btn-new" runat="server" Text="Загрузить XML" Height="40px" Width="150px" OnClick="btnUpload_Click" />
        <asp:Button ID="Button8" CssClass="btn-new" runat="server" Text="Экспорт XML" Height="40px" Width="150px" OnClick="Button8_Click" />
        <asp:Button ID="Button9" CssClass="btn-new" runat="server" Text="Экспорт JSON"  style="margin-top: 20px; height:40px; width: 150px;" OnClick="Button9_Click" />
        <asp:Button ID="Button10" CssClass="btn-new" runat="server" Text="Импорт JSON" style="margin-top: 20px; height:40px; width: 150px;" OnClick="Button10_Click" />
        <asp:Button ID="Button11" CssClass="btn-new" runat="server" Text="Выход" Height="40px" Width="84px" OnClick="Button11_Click" />

        </div>

        <div class="txt_for_conncetion_withDatabase">
            <asp:Label ID="Label20" runat="server" Text="Имя сервера"></asp:Label>
        <asp:TextBox ID="txt_DataSource" runat="server"></asp:TextBox>
             <asp:Label ID="Label21" runat="server" Text="Название базы данных"></asp:Label>
            <asp:TextBox ID="txt_Initial_Catalog" runat="server"></asp:TextBox>
         </div>
             

        <asp:Panel ID="Panel1" runat="server" Width="250px" CssClass="text_c">
             <asp:Label ID="Label1" runat="server" Text="Код товара" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
             <asp:Label ID="Label2" runat="server" Text="Название" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
             <asp:Label ID="Label3" runat="server" Text="Количество" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Описание" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="Цена" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>  
        </asp:Panel>
        
        <asp:Panel ID="Panel2" CssClass="text_s" Width="250px" runat="server">
            <asp:Label ID="Label7" runat="server" Text="Имя" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="Фамилия" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <asp:Label ID="Label9" runat="server" Text="Паспортные данные" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <asp:Label ID="Label10" runat="server" Text="Дата продажи" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            <asp:Label ID="Label11" runat="server" Text="Код товара" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            <asp:Label ID="Label12" runat="server" Text="Количество" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
        </asp:Panel>

       
        

        
        

       

       
        

        
        

        <asp:Panel ID="Panel3" CssClass="text_r" Width="250px" runat="server">
            <asp:Label ID="Label14" runat="server" Text="Имя" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
            <asp:Label ID="Label15" runat="server" Text="Фамилия" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
            <asp:Label ID="Label16" runat="server" Text="Паспотные данные" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
            <asp:Label ID="Label17" runat="server" Text="Дата возврата" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
            <asp:Label ID="Label18" runat="server" Text="Код продукта" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
            <asp:Label ID="Label19" runat="server" Text="Количество" Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
        </asp:Panel>
        
          
        
         <asp:GridView ID="GridView3" CssClass="table" runat="server" OnRowDeleting="GridView3_RowDeleting" OnRowCancelingEdit="GridView3_RowCancelingEdit" OnRowEditing="GridView3_RowEditing" OnRowUpdating="GridView3_RowUpdating" OnSelectedIndexChanging="GridView3_SelectedIndexChanging">
             <Columns>
                  <asp:TemplateField>
                        <ItemTemplate>
                <asp:CheckBox ID="CheckBox3" runat="server" OnCheckedChanged="CheckBox3_CheckedChanged" />
                             </ItemTemplate>
                    </asp:TemplateField>
                 <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                 <ControlStyle BorderStyle="None" CssClass="btb-control-delete-gridview" />
                 </asp:CommandField>
                 <asp:CommandField ButtonType="Button" ShowSelectButton="True">
                 <ControlStyle BorderStyle="None" CssClass="btb-control-select-gridview" />
                 </asp:CommandField>
                 <asp:CommandField ButtonType="Button" ShowEditButton="True">
                 <ControlStyle BorderStyle="None" CssClass="btb-control-edit-gridview" />
                 </asp:CommandField>
             </Columns>
        </asp:GridView>
      
        

        
   
        
        
        
   
        
         
        <asp:GridView ID="GridView2" CssClass="table" runat="server" OnRowDeleting="GridView2_RowDeleting" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" OnSelectedIndexChanging="GridView2_SelectedIndexChanging">
            <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
               <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged" />
                             </ItemTemplate>
                    </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" >
                <ControlStyle BorderStyle="None" CssClass="btb-control-delete-gridview" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" >
                <ControlStyle BorderStyle="None" CssClass="btb-control-select-gridview" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Button" ShowEditButton="True" >
                <ControlStyle BorderStyle="None" CssClass="btb-control-edit-gridview" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>

       
        
        <div>
            <asp:GridView ID="GridView1" CssClass="table" runat="server" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                           <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" HeaderText="Удалить" ShowDeleteButton="True" DeleteText="Удалить">
                    <ControlStyle BorderStyle="None" CssClass="btb-control-delete-gridview" />
                    </asp:CommandField>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button">
                    <ControlStyle BorderStyle="None" CssClass="btb-control-select-gridview" />
                    </asp:CommandField>

                    
                    <asp:CommandField ShowEditButton="True" ButtonType="Button" >

                    
                    <ControlStyle BorderStyle="None" CssClass="btb-control-edit-gridview" />
                    </asp:CommandField>

                    
                </Columns>
               
            </asp:GridView>

            <asp:GridView ID="GridView4" CssClass="table" runat="server" AutoGenerateColumns="true">
                </asp:GridView>
        </div>
        

    </form>
</body>
</html>
