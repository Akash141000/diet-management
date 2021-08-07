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



        <div class="container-fluid img-fluid min-vh-100" style="padding:0px;margin:0px;background-image: url('/Images/diet.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: 100% 100%">
        <form runat="server">
          <div style="background-color: rgba(0,0,0,0.5);height:inherit;width:100%">

            <div class="row col-lg-12 justify-content-around " style="font-size: 20px;padding-top:10rem">
                <div class="col-lg-8 offset-lg-4 text-light">
                    <asp:Label ID="BmiLabel" runat="server" Text="BMI" class=" col-lg-1 m-1"></asp:Label>:
                             <asp:Label ID="bmiValue" runat="server" Text="--" class=" col-lg-2"></asp:Label>

                    <asp:Label ID="foodCategoryLabel" runat="server" Text="Food Catagory -" class=" col-lg-2 offset-lg-1 "></asp:Label>
                    <asp:Label ID="foodCategoryValue" runat="server" Text="Label" class="col-lg-2"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row col-lg-12 justify-content-around" style="font-size: 20px">
                <div class="col-lg-8 offset-lg-4">
                    <asp:Label ID="maintananceCaloriesLabel" runat="server" Text="Maintanance calories:" class="col-lg-2 text-light m-1"></asp:Label>
                    <asp:Label ID="maintananceCaloriesValue" runat="server" Text="--" class="col-lg-1  text-light"></asp:Label>

                    <asp:Button ID="generateDietPlan" runat="server" OnClick="generateDietPlan_Click" class="btn-outline-primary col-lg-5" style="border-radius:5px"
                        Text="Generate Dietplan" />
                </div>
            </div>
            <br />
            <div class="row col-lg-12 justify-content-center text-xl-center  pt-5" style="font-size: 20px">
                <strong>
                    <asp:Label ID="dietPlanLabel" runat="server" Text="DietPlan" class="text-light"></asp:Label>
                </strong>
            </div>
            <br />

            <div class="row col-lg-12 justify-content-center text-xl-center" style="font-size: 20px">
                <div>
                    <strong>
                        <asp:Label ID="breakfastLabel" runat="server" Text="Breakfast" class="text-light text-center "></asp:Label>
                    </strong>
                </div>
            </div>

            <div class="row ">
                <div class=" col-lg-10 offset-lg-1">
                        <asp:GridView ID="breakfastGridView" runat="server" AutoGenerateColumns="False" class="text-dark" PageSize="5" OnSelectedIndexChanged="breakfastGridView_SelectedIndexChanged"
                            Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="Add" ControlStyle-Font-Underline="false" ItemStyle-CssClass="btn btn-outline-primary" >
<ControlStyle Font-Underline="False"></ControlStyle>

<ItemStyle CssClass="btn btn-outline-primary"></ItemStyle>
                                </asp:CommandField>
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
            </div>
            <br />

            <div class="row col-lg-12 justify-content-center text-xl-center" style="font-size: 20px">
                <div>
                    <strong>
                        <asp:Label ID="lunchLabel" runat="server" Text="Lunch" class="text-light  text-center "></asp:Label>
                    </strong>

                </div>
            </div>
            <div class="row ">
                <div class="col-lg-10 offset-lg-1">
                        <asp:GridView ID="lunchGridView" runat="server" AutoGenerateColumns="False"
                            class="text-dark" PageSize="5" OnSelectedIndexChanged="lunchGridView_SelectedIndexChanged"
                            Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                 <asp:CommandField ShowSelectButton="True" SelectText="Add" ControlStyle-Font-Underline="false" ItemStyle-CssClass="btn btn-outline-primary" >
<ControlStyle Font-Underline="False"></ControlStyle>

<ItemStyle CssClass="btn btn-outline-primary"></ItemStyle>
                                 </asp:CommandField>
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
            </div>
            <br />

            <div class="row col-lg-12 justify-content-center text-xl-center" style="font-size: 20px">
                <div>
                    <strong>
                        <asp:Label ID="snackLabel" runat="server" Text="Snack" class="text-light text-center "></asp:Label>
                    </strong>

                </div>
            </div>
            <div class=" row ">
                <div class=" col-lg-10 offset-lg-1">
                        <asp:GridView  ID="snackGridView" runat="server" AutoGenerateColumns="False"
                            class="text-dark" PageSize="5" OnSelectedIndexChanged="snackGridView_SelectedIndexChanged"
                            Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                 <asp:CommandField ShowSelectButton="True" SelectText="Add" ControlStyle-Font-Underline="false" ItemStyle-CssClass="btn btn-outline-primary" >
<ControlStyle Font-Underline="False"></ControlStyle>

<ItemStyle CssClass="btn btn-outline-primary"></ItemStyle>
                                 </asp:CommandField>
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
            </div>
            <br />

            <div class="row col-lg-12 justify-content-center text-xl-center" style="font-size: 20px">
                <div>
                    <strong>
                        <asp:Label ID="dinnerLabel" runat="server" Text="Dinner" class="text-light text-center"></asp:Label>
                    </strong>

                </div>
            </div>
            <div class="row">
                <div class="col-lg-10  offset-lg-1">
                        <asp:GridView ID="dinnerGridView" runat="server" AutoGenerateColumns="False"
                            class="text-dark" PageSize="5" OnSelectedIndexChanged="dinnerGridView_SelectedIndexChanged"
                            Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                  <asp:CommandField ShowSelectButton="True" SelectText="Add" ControlStyle-Font-Underline="false" ItemStyle-CssClass="btn btn-outline-primary" />
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
                </div>
            </div>
            </form>

        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
</asp:Content>
