<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayDietPlan.aspx.cs" MasterPageFile="~/Navigation/userNavigation.master" Inherits="DietManagement.User.DisplayDietPlan" %>


<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Display DietPlan</title>
    <meta
        name="viewport"
        content="width=device-width, initial-scale=1, shrink-to-fit=no" />
   
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="container-fluid img-fluid min-vh-100" style="background-image: url('back/diet5.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: 100% 100%">
        <div class="row  justify-content-around">
            <div class="col-lg-12  justify-content-end text-light text-lg-right " style="font-size: 20px">
                <span class="fas fa-user">
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </span>
            </div>
        </div>

        <div class="row offset-lg-2  justify-content-around ">
            <form runat="server">

            
            <div class="col-lg-6 ">
                <asp:Label ID="breakfastLabel" runat="server" Text="Breakfast" Font-Size="20pt" Class="text-center text-light"></asp:Label>
                <br />
                <asp:GridView ID="breakFastGridView" runat="server" ForeColor="Black" PageSize="5" class="text"
                    Width="418px" Font-Bold="True" Font-Size="15px" CellPadding="4"
                    GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
                <br />
            </div>

            <div class="col-lg-6  ">
                <asp:Label ID="lunchLabel" runat="server" Text="Lunch" Font-Size="20pt" Class="text-center text-light"></asp:Label>
                <br />
                <asp:GridView ID="lunchGridView" runat="server" PageSize="5" ForeColor="Black" class="text"
                    Width="420px" Font-Bold="True" Font-Size="15px" CellPadding="4"
                    GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </div>

            <br />
            <div class="col-lg-6 ">
                <asp:Label ID="snackLabel" runat="server" Text="Snack" Font-Size="20pt" Class="text-center text-light"></asp:Label>
                <br />
                <asp:GridView ID="snackGridView" runat="server" PageSize="5" ForeColor="Black" Width="419px" class="text"
                     Font-Bold="True" Font-Size="15px" CellPadding="4"
                    GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </div>
            <br />

            <div class="col-lg-6 ">
                <asp:Label ID="dinnerLabel" runat="server" Text="Dinner" Font-Size="20pt" Class="text-center text-light"></asp:Label>
                <br />
                <asp:GridView ID="dinnerGridView" runat="server" PageSize="5" ForeColor="Black" Width="418px" class="text"
                    Font-Bold="True" Font-Size="15px" CellPadding="4"
                    GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </div>
                </form>
        </div>

    </div>
</asp:Content>
