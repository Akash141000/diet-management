<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserIntakeGraph.aspx.cs" MasterPageFile="~/Navigation/userNavigation.master" ClientIDMode="Static" Inherits="DietManagement.User.UserIntakeGraph" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>UserIntake Graph</title>
    <meta
        name="viewport"
        content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="../Bootstrap-5/css/bootstrap.min.css" rel="stylesheet" />
    <script
        async="async"
        defer="defer"
        src="../Bootstrap-5/css/js/bootstrap.bundle.min.js"></script>




</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContentPlaceHolder">


    <div style="float: right">
        <span class="fas fa-user">
            <asp:Label ID="Label1" runat="server"
                ForeColor="White" Style="float: right"></asp:Label>
        </span>
    </div>

    <div class="container padd justify-content-center min-vh-100">
        <div class="row cust justify-content-around  ">
            <div class="col-lg-12 ">

                <asp:Chart runat="server" CanResize="true" CssClass="table  table-bordered table-condensed table-responsive" Height="410px" Width="1000px" ID="Chart1">
                    <Series>
                        <asp:Series Name="Main" ChartArea="ChartArea1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
               


            </div>
        </div>
    </div>



    <script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
</asp:Content>
