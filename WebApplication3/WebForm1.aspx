<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .avatar{
        width: 50px;
        height: 50px;}
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="输入手机号查询" OnClick="Button1_Click"/>
        <table style="text-align:center;border:solid 1px #000000;">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <tr>
                        <td>学生ID</td>
                        <td>学生姓名</td>
                        <td>学生班级</td>
                        <td>班级名称</td>
                        <td>学号</td>
                        <td>性别</td>
                        <td>手机号</td>
                        <td>密码</td>
                        <td>生日</td>
                        <td>省份</td>
                        <td>城市</td>
                        <td>地区</td>
                        <td>详细地址</td>
                        <td>操作</td>
                        <td>头像</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("studentID") %></td>
                        <td><%#Eval("studentName") %></td>
                        <td><%#Eval("classID") %></td>
                        <td><%#Eval("className") %></td>
                        <td><%#Eval("studentNum") %></td>
                        <td><%#Eval("studentSex") %></td>
                        <td><%#Eval("mobile") %></td>
                        <td><%#Eval("password") %></td>
                        <td><%#Eval("birthday") %></td>
                        <td><%#Eval("province") %></td>
                        <td><%#Eval("city") %></td>
                        <td><%#Eval("district") %></td>
                        <td><%#Eval("address") %></td>
                        <td><asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("avatarUrl")%>' CssClass="avatar"/></td>
                        <%--sa=="1"?条件成立的时候:条件不成立的时候--%>
                        <%--<td><%#Eval("IsDelete").ToString()=="false"?"未删除":"已删除"%></td>--%>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">更新</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete">删除</asp:LinkButton>
                        </td>
                        <asp:HiddenField ID="hfStudentId" runat="server" value='<%#Eval("studentID") %>'/>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">插入</asp:LinkButton>
    </div>
</form>
</body>
</html>