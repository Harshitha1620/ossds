<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StopSale.aspx.cs" Inherits="Admin_Cropsale" %>

<%@ Register TagPrefix="footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Online Subsidy Seed Distribution System</title>
    <link href="../layout/styles/layout.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../layout/scripts/jquery.min.js"></script>
    <script type="text/javascript">
        history.pushState(null, null, 'Cropsale.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'Cropsale.aspx');
        });

        function SelectAllCheckboxes1(chk) {

            $('#<%=GVsale.ClientID%>').find("input:checkbox").each(function () {
                if (this != chk) {
                    this.checked = chk.checked;
                }
            });
        }

        $(".cbChild").change(function () {
            var all = $('.cbChild');
            if (all.length === all.find(':checked').length) {
                $(".cbAll").attr("checked", true);
            } else {
                $(".cbAll").attr("checked", false);
            }
        });

        function SelectAllCheckboxes(chk) {

            $('#<%=Gvsalestock.ClientID%>').find("input:checkbox").each(function () {
                if (this != chk) {
                    this.checked = chk.checked;
                }
            });
        }

        $("#chkAl").change(function () {
            var all = $('#chkAl');
            if (all.length === all.find(':checked').length) {
                $("#chkSel").attr("checked", true);
            } else {
                $("#chkSel").attr("checked", false);
            }
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper row1">
        <header id="header">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/header.png" />
        </header>
        <menu:menu ID="menu" runat="server" />
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="wrapper row2">
        <main class="hoc container clear">
        <div class="borderedbox">
            <span style="float: left;">
                <img src="../images/14.gif" alt="Log" />
                Logged in As ::&nbsp;
                <asp:Label ID="lblUsrName" runat="server"></asp:Label>:: </span><span style="float: right;">
                    Date::<asp:Label ID="lblDate" runat="server"></asp:Label>
                </span>
            <br />
        </div>
        <div id="comments">
            <br />
            <fieldset>
                <h2>
                    Issue Stop Sale ( Current Season )</h2>
                <br />
                <div class="one_half first">
                    <asp:GridView ID="GVsale" runat="server" AutoGenerateColumns="False" CssClass="grid">
                        <Columns>
                            <asp:TemplateField HeaderText="Crop Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblcropcode" Visible="false" runat="server" Text='<%# Bind("CropCode") %>'></asp:Label>
                                    <asp:Label ID="lblCpnm" runat="server" Text='<%# Bind("CropName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Select">
                                <HeaderTemplate>
                                    <input id="chkAll" class="cbAll" onclick="javascript:SelectAllCheckboxes1(this);"
                                        runat="server" type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelct" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="one_full">
                        <asp:Button ID="btn_Save" runat="server" Text="Issue Stop Sale" OnClick="btn_Save_Click" />
                        <asp:HiddenField runat="server" ID="hf" />
                    </div>
                </div>
                <div class="one_half">
                    <asp:GridView ID="Gvsalestock" runat="server" AutoGenerateColumns="False" CssClass="grid">
                        <Columns>
                            <asp:TemplateField HeaderText="Crop Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblcropcode" Visible="false" runat="server" Text='<%# Bind("CropCode") %>'></asp:Label>
                                    <asp:Label ID="lblCpnm" runat="server" Text='<%# Bind("CropName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stop Sale Issued">
                                <ItemTemplate>
                                    <asp:Label ID="lblstsale" runat="server" Text='<%# Bind("stpSale") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Select">
                                <HeaderTemplate>
                                    <input id="chkAl" onclick="javascript:SelectAllCheckboxes(this);" runat="server"
                                        type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSel" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="Button1" runat="server" Text="Remove Stop Sale" OnClick="Button1_Click" />
                </div>
            </fieldset>
        </div>
    </div>
    </div> </main> </div>
    <div class="wrapper row4 bgded overlay">
        <footer:footer ID="footer1" runat="server" />
    </div>
    <a id="backtotop" href="#top"><i class="fa fa-chevron-up"></i></a>
    <script type="text/javascript" src="../layout/scripts/jquery.min.js"></script>
    <script type="text/javascript" src="../layout/scripts/jquery.backtotop.js"></script>
    <script type="text/javascript" src="../layout/scripts/jquery.mobilemenu.js"></script>
    </form>
</body>
</html>
