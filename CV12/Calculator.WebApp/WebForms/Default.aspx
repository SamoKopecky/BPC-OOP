<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Calculator.WebApp.WebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator service</title>
</head>
<body>
<form id="form" runat="server">
    <div>
        <asp:TextBox runat="server" ID="firstNumber"></asp:TextBox>
        <asp:DropDownList runat="server" ID="operation">
            <asp:ListItem Value="addition">+</asp:ListItem>
            <asp:ListItem Value="subtraction">-</asp:ListItem>
            <asp:ListItem Value="multiplication">*</asp:ListItem>
            <asp:ListItem Value="divison">/</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox runat="server" ID="secondNumber"></asp:TextBox>
        <asp:Button runat="server" ID="submit" OnClick="submit_OnClick" Text="Calculate"/>
    </div>
</form>
</body>
</html>