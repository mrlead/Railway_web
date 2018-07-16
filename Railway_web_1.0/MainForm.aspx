<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="Railway_web_1._0.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="MainForm" runat="server">
        <div style="height: 520px">
            <asp:TextBox ID="tb_from" runat="server" OnTextChanged="tb_from_TextChanged" CssClass="textbox_1" Font-Names="Times New Roman" Font-Size="18pt" Width="200px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tb_to" runat="server" OnTextChanged="tb_to_TextChanged" CssClass="textbox_2" Font-Names="Times New Roman" Font-Size="18pt" Width="200px"></asp:TextBox>
            <br />
            <br />
            <asp:DropDownList ID="cb_from" runat="server" CssClass="cb_from" Font-Names="Vrinda" Font-Size="18pt" Width="225px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="cb_to" runat="server" CssClass="cb_to" Font-Names="Vrinda" Font-Size="18pt" Width="224px">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="bEnter" runat="server" Text="Отобразить расписание" Width="576px" CssClass="button" Font-Bold="False" Font-Italic="False" Font-Names="Vrinda" Font-Size="18pt" />
            <br />
            <br />
            <asp:GridView ID="dg" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" Height="149px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
                <Columns>
                    <asp:BoundField HeaderText="Номер поезда" ReadOnly="True" />
                    <asp:BoundField HeaderText="Пункт отправки" ReadOnly="True" />
                    <asp:BoundField HeaderText="Пункт прибытия" ReadOnly="True" />
                    <asp:BoundField HeaderText="Время отпр." ReadOnly="True" />
                    <asp:BoundField HeaderText="Время приб." ReadOnly="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="#FF9FAB" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <br />
            <asp:GridView ID="dg_1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" Width="580px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" CssClass="table">
                <Columns>
                    <asp:BoundField HeaderText="Пункт" />
                    <asp:BoundField HeaderText="Время приб." />
                    <asp:BoundField HeaderText="Время отпр." />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="#FF9FAB" Font-Bold="True" ForeColor="White" BorderStyle="Groove" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
