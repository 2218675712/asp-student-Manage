﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication3.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        label{
            width:100px;
            height:24px;
            display:block;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <asp:HiddenField ID="HiddenField1" Value="" runat="server"/>
        <label>学生姓名：</label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Label ID="Label1" runat="server" Text=""></asp:Label>

        <label>班级Id：</label>

        <%-- <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> --%>
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>


        <label>学号：</label>

        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>

        <label>性别：</label>

        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

        <label>手机号：</label>

        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>

        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

        <label>登录密码：</label>

        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>

        <label>生日：</label>

        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>

        <label>省份：</label>

        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>

        <label>城市：</label>

        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>

        <label>地区：</label>

        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>

        <label>详细地址：</label>

        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
        <br/>
        <label >学生头像：</label>
        <asp:FileUpload runat="server" ID="FileUpload1"/>
        <asp:Button ID="Button2" runat="server" Text="上传" OnClick="Button2_Click"/>
        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
        <asp:Image ID="Image1" runat="server" Height="50px" Width="50px"/>
        
        <br>
        <asp:Button ID="Button1" runat="server" Text="确定" CommandName="Insert" OnClick="Button1_Click"/>
        <br/>

    </div>
</form>
</body>
</html>