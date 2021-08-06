<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Navigation/userNavigation.master" CodeBehind="CreateDietPlan.aspx.cs" Inherits="DietManagement.User.CreateDietPlan" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Create DietPlan</title>
    <meta
        name="viewport"
        content="width=device-width, initial-scale=1, shrink-to-fit=no" />
   
   
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div style="color: #000000">
        <style type="text/css">
            .hidden {
                display: none;
            }
        </style>



        <div class="container-fluid img-fluid min-vh-100 " style="background-image: url('/Images/diet.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: 100% 100%">
        <form runat="server">
            <div class="row  justify-content-around">
                <div class="col-lg-12  justify-content-end text-dark text-lg-right" style="font-size: 20px">
                    <span class="fas fa-user">
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                    </span>
                </div>
            </div>


            <div class="row col-lg-12 justify-content-around" style="font-size: 20px">
                <div class="col-lg-8 offset-lg-4 text-dark">
                    <asp:Label ID="BmiLabel" runat="server" Text="BMI" class=" col-lg-1"></asp:Label>:
                             <asp:Label ID="bmiValue" runat="server" Text="--" class=" col-lg-2"></asp:Label>

                    <asp:Label ID="foodCategoryLabel" runat="server" Text="Food Catagory -" class=" col-lg-2 offset-lg-1 "></asp:Label>
                    <asp:Label ID="foodCategoryValue" runat="server" Text="Label" class="col-lg-2"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row col-lg-12 justify-content-around" style="font-size: 20px">
                <div class="col-lg-8 offset-lg-4">
                    <asp:Label ID="maintananceCaloriesLabel" runat="server" Text="Maintanance calories" class="col-lg-2 text-dark"></asp:Label>
                    <asp:Label ID="maintananceCaloriesValue" runat="server" Text="--" class="col-lg-1  text-dark"></asp:Label>

                    <asp:Button ID="generateDietPlan" runat="server" OnClick="generateDietPlan_Click" class="btn-outline-dark col-lg-5"
                        Text="Generate Dietplan" />
                </div>
            </div>
            <br />
            <div class="row col-lg-12 justify-content-center" style="font-size: 20px">
                <strong>
                    <asp:Label ID="dietPlanLabel" runat="server" Text="DietPlan" class="text-dark"></asp:Label>
                </strong>
            </div>
            <br />

            <div class="row col-lg-12 justify-content-center" style="font-size: 20px">
                <div>
                    <strong>
                        <asp:Label ID="breakfastLabel" runat="server" Text="Breakfast" class="text-dark text-center "></asp:Label>
                    </strong>
                </div>
            </div>

            <div class="row ">
                <div class=" col-lg-10 offset-lg-1">
                        <asp:GridView ID="breakfastGridView" runat="server" AutoGenerateColumns="False"
                            AutoGenerateSelectButton="True" class="text-dark" PageSize="5" OnSelectedIndexChanged="breakfastGridView_SelectedIndexChanged"
                            Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Food" HeaderText="Food" SortExpression="Food" />
                                <asp:BoundField DataField="Serving_Size" HeaderText="Serving_Size" SortExpression="Serving_Size" />
                                <asp:BoundField DataField="Protein" HeaderText="Protein" SortExpression="Protein" />
                                <asp:BoundField DataField="Carbs" HeaderText="Carbs" SortExpression="Carbs" />
                                <asp:BoundField DataField="Fat" HeaderText="Fat" SortExpression="Fat" />
                                <asp:BoundField DataField="Calories" HeaderText="Calories" SortExpression="Calories" />
                                <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time"
                                    ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>

                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                        </asp:GridView>
                    

                </div>
            </div>
            <br />

            <div class="row col-lg-12 justify-content-center" style="font-size: 20px">
                <div>
                    <strong>
                        <asp:Label ID="lunchLabel" runat="server" Text="Lunch" class="text-dark  text-center "></asp:Label>
                    </strong>

                </div>
            </div>
            <div class="row ">
                <div class="col-lg-10 offset-lg-1">
                        <asp:GridView ID="lunchGridView" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True"
                            class="text-dark" PageSize="5" OnSelectedIndexChanged="lunchGridView_SelectedIndexChanged"
                            Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Food" HeaderText="Food" SortExpression="Food" />
                                <asp:BoundField DataField="Serving_Size" HeaderText="Serving_Size" SortExpression="Serving_Size" />
                                <asp:BoundField DataField="Protein" HeaderText="Protein" SortExpression="Protein" />
                                <asp:BoundField DataField="Carbs" HeaderText="Carbs" SortExpression="Carbs" />
                                <asp:BoundField DataField="Fat" HeaderText="Fat" SortExpression="Fat" />
                                <asp:BoundField DataField="Calories" HeaderText="Calories" SortExpression="Calories" />
                                <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time"
                                    ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>

                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                        </asp:GridView>
                    

                </div>
            </div>
            <br />

            <div class="row col-lg-12 justify-content-center" style="font-size: 20px">
                <div>
                    <strong>
                        <asp:Label ID="snackLabel" runat="server" Text="Snack" class="text-dark text-center "></asp:Label>
                    </strong>

                </div>
            </div>
            <div class=" row ">
                <div class=" col-lg-10 offset-lg-1">
                        <asp:GridView  ID="snackGridView" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True"
                            class="text-dark" PageSize="5" OnSelectedIndexChanged="snackGridView_SelectedIndexChanged"
                            Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Food" HeaderText="Food" SortExpression="Food" />
                                <asp:BoundField DataField="Serving_Size" HeaderText="Serving_Size" SortExpression="Serving_Size" />
                                <asp:BoundField DataField="Protein" HeaderText="Protein" SortExpression="Protein" />
                                <asp:BoundField DataField="Carbs" HeaderText="Carbs" SortExpression="Carbs" />
                                <asp:BoundField DataField="Fat" HeaderText="Fat" SortExpression="Fat" />
                                <asp:BoundField DataField="Calories" HeaderText="Calories" SortExpression="Calories" />
                                <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time"
                                    ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>

                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                        </asp:GridView>

                </div>
            </div>
            <br />

            <div class="row col-lg-12 justify-content-center" style="font-size: 20px">
                <div>
                    <strong>
                        <asp:Label ID="dinnerLabel" runat="server" Text="Dinner" class="text-dark text-center"></asp:Label>
                    </strong>

                </div>
            </div>
            <div class="row">
                <div class="col-lg-10  offset-lg-1">
                        <asp:GridView ID="dinnerGridView" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True"
                            class="text-dark" PageSize="5" OnSelectedIndexChanged="dinnerGridView_SelectedIndexChanged"
                            Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Food" HeaderText="Food" SortExpression="Food" />
                                <asp:BoundField DataField="Serving_Size" HeaderText="Serving_Size" SortExpression="Serving_Size" />
                                <asp:BoundField DataField="Protein" HeaderText="Protein" SortExpression="Protein" />
                                <asp:BoundField DataField="Carbs" HeaderText="Carbs" SortExpression="Carbs" />
                                <asp:BoundField DataField="Fat" HeaderText="Fat" SortExpression="Fat" />
                                <asp:BoundField DataField="Calories" HeaderText="Calories" SortExpression="Calories" />
                                <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time"
                                    ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                                    <HeaderStyle CssClass="hidden"></HeaderStyle>

                                    <ItemStyle CssClass="hidden"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                        </asp:GridView>
                </div>
            </div>
            </form>

        </div>
    </div>

</asp:Content>
