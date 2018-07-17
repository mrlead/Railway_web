<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="Railway_web_1._0.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #MainForm {
            height: 600px;
        }
        #cal_1 {
            width: 1263px;
            height: 252px;
        }
        #cal_2 {
            width: 256px;
        }
        #cal_center {
            width: 251px;
        }
    </style>
</head>
<body>
    <form id="MainForm" runat="server">
        <div style="height: 1025px; width: 1264px">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel id="UpdatePanel1" runat="server" RenderMode="Inline">
            <ContentTemplate>
                <fieldset>
               <asp:TextBox ID="tb_from" runat="server" OnTextChanged="tb_from_TextChanged" CssClass="textbox_1" Font-Names="Times New Roman" Font-Size="18pt" Width="200px" AutoPostBack="True" ClientIDMode="Static" ></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tb_to" runat="server" OnTextChanged="tb_to_TextChanged" CssClass="textbox_2" Font-Names="Times New Roman" Font-Size="18pt" Width="200px" AutoPostBack="True" ClientIDMode="Static"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;<br />
            <br />
            <asp:DropDownList ID="cb_from" runat="server" CssClass="cb_from" Font-Names="Vrinda" Font-Size="18pt" Width="225px" AutoPostBack="True" OnSelectedIndexChanged="cb_from_SelectedIndexChanged" ClientIDMode="Static">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="cb_to" runat="server" CssClass="cb_to" Font-Names="Vrinda" Font-Size="18pt" Width="224px" AutoPostBack="True" OnSelectedIndexChanged="cb_to_SelectedIndexChanged" ClientIDMode="Static">
            </asp:DropDownList>
                        <br />
            <br />
            <asp:Button ID="bEnter" runat="server" Text="Отобразить расписание" Width="576px" CssClass="button" Font-Bold="False" Font-Italic="False" Font-Names="Vrinda" Font-Size="18pt" OnClick="bEnter_Click" />
            <br />
            <br />
                    <asp:UpdatePanel id="UpdatePanel2" runat="server" RenderMode="Inline">
            <ContentTemplate>
            <asp:GridView ID="dg" runat="server" CellPadding="4" ForeColor="Black" Height="149px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" OnSelectedIndexChanging="dg_SelectedIndexChanging" AutoGenerateSelectButton="True" CssClass="table" Font-Names="Times New Roman" ShowHeaderWhenEmpty="True" Width="1258px" OnSelectedIndexChanged="dg_SelectedIndexChanged">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="#F8363C" Font-Bold="True" ForeColor="Black" Font-Names="Times New Roman" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
                </ContentTemplate>
        </asp:UpdatePanel>
                            &nbsp;<br />
                            <asp:Label ID="label3" runat="server"></asp:Label>
            <br />
                    <asp:UpdatePanel id="UpdatePanel4" runat="server" RenderMode="Inline">
            <ContentTemplate>
            <asp:GridView ID="dg_1" runat="server" CellPadding="4" ForeColor="Black" Width="1259px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" CssClass="table" Font-Names="Times New Roman" ShowHeaderWhenEmpty="True" Height="149px">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="#F72125" Font-Bold="True" ForeColor="Black" BorderStyle="Groove" Font-Names="Times New Roman" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
                 </ContentTemplate>
        </asp:UpdatePanel>
                </fieldset>
                <br />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
            
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="container">
                  <div class="box">
                    <div>
                        &nbsp;<asp:Calendar ID="date_low" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="300px" CssClass="calendar" OnSelectionChanged="date_low_SelectionChanged">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                    <DayStyle BackColor="#CCCCCC" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="#E9211F" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                    <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    </asp:Calendar>
                        &nbsp;&nbsp;
                    </div>
                    <div aria-disabled="False">
                        <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click1" Text="Сегодня" />
                      </div>
                    <div>&nbsp;<asp:Calendar ID="date_high" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="300px" CssClass="calendar" OnSelectionChanged="date_high_SelectionChanged">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                    <DayStyle BackColor="#CCCCCC" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="#E9211F" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                    <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    </asp:Calendar></div>
                  </div>
                </div>
                    </ContentTemplate>
        </asp:UpdatePanel>
                &nbsp;
    </div>
    </form>
</body>
</html>
