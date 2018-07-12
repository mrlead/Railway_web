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
            <asp:GridView ID="dg" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" Height="149px" OnSelectedIndexChanged="dg_SelectedIndexChanged" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
                <Columns>
                    <asp:BoundField HeaderText="Номер поезда" ReadOnly="True" />
                    <asp:BoundField HeaderText="Пункт отправки" ReadOnly="True" />
                    <asp:BoundField HeaderText="Пункт прибытия" ReadOnly="True" />
                    <asp:BoundField HeaderText="Время отпр." ReadOnly="True" />
                    <asp:BoundField HeaderText="Время приб." ReadOnly="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <br />
            <asp:GridView ID="dg_1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" Width="577px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
                <Columns>
                    <asp:BoundField HeaderText="Пункт" />
                    <asp:BoundField HeaderText="Время приб." />
                    <asp:BoundField HeaderText="Время отпр." />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
