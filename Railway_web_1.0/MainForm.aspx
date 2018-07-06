<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="Railway_web_1._0.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #Select1 {
            width: 109px;
        }
        #cb_from {
            width: 104px;
        }
        #cb_to {
            width: 108px;
        }
    </style>
</head>
<body>
    <form id="MainForm" runat="server">
        <div style="height: 520px">
            <asp:TextBox ID="tb_from" runat="server" OnTextChanged="tb_from_TextChanged"></asp:TextBox>
            <asp:TextBox ID="tb_to" runat="server" OnTextChanged="tb_to_TextChanged"></asp:TextBox>
            <br />
            <asp:DropDownList ID="cb_from" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="cb_to" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="bEnter" runat="server" Text="Ввод" Width="228px" />
            <br />
            <br />
            <asp:GridView ID="dg" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="149px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="Номер поезда" ReadOnly="True" />
                    <asp:BoundField HeaderText="Пункт отправки" ReadOnly="True" />
                    <asp:BoundField HeaderText="Пункт прибытия" ReadOnly="True" />
                    <asp:BoundField HeaderText="Время отпр." ReadOnly="True" />
                    <asp:BoundField HeaderText="Время приб." ReadOnly="True" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <br />
            <br />
            <br />
            <asp:GridView ID="dg_1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="553px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="Пункт" />
                    <asp:BoundField HeaderText="Время приб." />
                    <asp:BoundField HeaderText="Время отпр." />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
