﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntakeHistory.aspx.cs" MasterPageFile="~/Navigation/userNavigation.master" ClientIDMode="Static" Inherits="DietManagement.User.IntakeHistory" %>




<asp:Content  runat="server" ContentPlaceHolderID="head">
    <title>Intake History</title>
    <meta
        name="viewport"
        content="width=device-width, initial-scale=1, shrink-to-fit=no" />
   

    

</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContentPlaceHolder">

    
    <div class="container-fluid img-fluid min-vh-100" style="margin:0px;padding:0px;background-image: url('/Images/gw.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: 100% 100%">
        <form runat="server">
        
            
            
            <div class="row justify-content-around">
                <div class="col-lg-4 mt-5" style="padding-top:10rem">
                    <div class="form-group row ">
                        <h4> <asp:Label ID="enterDataLbl" runat="server" Text="Enter Date"
                            class="control-label text text-dark col-lg-4"></asp:Label></h4>
                       
                        <div class="input-group col-lg-8">
                            <asp:TextBox ID="dataInput" runat="server" data-placement="right" title="Enter date between last week" data-toggle="tooltip"
                                placeholder="dd-mm-yyyy" class="form-control" TextMode="Date"></asp:TextBox>
                           
                        </div>
                        <strong>
                             <span class="help-block m-2">
                                <asp:RequiredFieldValidator ID="dataRequiredFieldValidator" Display="Dynamic" ControlToValidate="dataInput" runat="server" ErrorMessage="Enter date"></asp:RequiredFieldValidator>
                                <asp:Label ID="invalidDateLbl" runat="server" class="text-dark"></asp:Label>
                                <asp:Label ID="searchResultLbl" runat="server" Class="text-dark"></asp:Label>
                            </span>
                        </strong>
                        
                    </div>
                    <div class="form-group row ">
                        <div class="col-lg-12 mt-2">

                            <asp:Button
                                ID="displayIntakeDataBtn" runat="server"
                                Text="Display" OnClick="displayIntakeDataBtn_Click" data-placement="right" title="Click to Display data" data-toggle="tooltip" class="btn-outline-dark form-control" />
                            <asp:Button runat="server" Visible="false" OnClick="statisticsBtn_Click"
                                ID="statisticsBtn" Text="Statistics"  data-placement="right" title="Click to display Graph" data-toggle="tooltip"
                                class="btn-outline-dark form-control mt-1" />


                        </div>

                    </div>
                </div>
            </div>

            <div class="row  justify-content-around mt-4">
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


            </form>
        </div>

    <%-- script --%>
<script type="text/javascript">
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });
</script>
</asp:Content>
