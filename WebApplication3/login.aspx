<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication3.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <label>手机号：</label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br/>
        <label>密码：</label><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br/>
        <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click"/>
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
</form>
</body>
</html>