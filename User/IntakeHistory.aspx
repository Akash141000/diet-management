<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntakeHistory.aspx.cs" MasterPageFile="~/Navigation/userNavigation.master" ClientIDMode="Static" Inherits="DietManagement.User.IntakeHistory" %>




<asp:Content  runat="server" ContentPlaceHolderID="head">
    <title>BMI</title>
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

    
    <div class="container-fluid img-fluid min-vh-100" style="background-image: url('back/gw.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: 100% 100%">
        <div class="row  justify-content-around">
            <div class="col-lg-12  justify-content-end text-dark text-lg-right " style="font-size:20px">
                <span class="fas fa-user">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </span>
            </div>
            </div>

            <div class="row  justify-content-around ">
                <div class="col-lg-4  ">
                    <div class="form-group row ">
                        <h4> <asp:Label ID="enterDataLbl" runat="server" Text="Enter Date"
                            class="control-label text text-dark col-lg-4"></asp:Label></h4>
                       
                        <div class="input-group col-lg-8">
                            <asp:TextBox ID="dataInput" runat="server" data-placement="right" title="Enter date between last week" data-toggle="tooltip"
                                placeholder="dd-mm-yyyy" class="form-control" TextMode="Date"></asp:TextBox>
                            <span class="help-block">
                                <asp:Label ID="invalidDateLbl" runat="server" class="text-dark"></asp:Label>
                                <asp:Label ID="searchResultLbl" runat="server" Class="text-dark"></asp:Label>
                            </span>
                        </div>
                    </div>
                    <div class="form-group row ">
                        <div class="col-lg-12">

                            <asp:Button
                                ID="displayIntakeDataBtn" runat="server"
                                Text="Display" OnClick="displayIntakeDataBtn_Click" data-placement="right" title="Click to Display data" data-toggle="tooltip" class="btn-outline-dark form-control" />
                            <asp:Button runat="server" OnClick="statisticsBtn_Click"
                                ID="statisticsBtn" Text="Statistics"  data-placement="right" title="Click to display Graph" data-toggle="tooltip"
                                class="btn-outline-dark form-control" />



                        </div>

                    </div>
                </div>
            </div>

            <div class="row  justify-content-around">
                <div class="col-lg-8 offset-lg-2">
                    <asp:GridView ID="displayIntakeGridView" runat="server" Class="text-dark" PageSize="5"
                        Width="683px" BackColor="White"
                        BorderColor="#999999" BorderWidth="1px" Cellding="3"
                        GridLines="Vertical" BorderStyle="Solid" ForeColor="Black">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black"
                            HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" ForeColor="White" Font-Bold="True" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </div>
            </div>




        </div>

    <%-- script --%>
<script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
</script>
</asp:Content>
