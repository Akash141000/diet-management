<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customDietPlanDisplay.aspx.cs" MasterPageFile="~/Navigation/userNavigation.master" ClientIDMode="Static"
 Inherits="DietManagement.User.customDietPlanDisplay" %>



<asp:Content  runat="server" ContentPlaceHolderID="head">
    <title>Custom DietPlan</title>
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
        
        <div class="container-fluid img-fluid min-vh-100" style="background-image: url('back/diet.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: 100% 100%">
             <div class="row  justify-content-around">
            <div class="col-lg-12  justify-content-end text-dark text-lg-right " style="font-size:20px">
                <span class="fas fa-user">
                    <asp:Label ID="userLoggedLbl" runat="server"></asp:Label>
                </span>
            </div>
        </div>



            <div class="row  justify-content-around">
                <div class="col-lg-8" style="font-size:20px">
                    <div>
                        <ul class="list-group" >
                            <li class="list-group-item">Total Calories:
                                <asp:Label ID="totalCaloriesLbl" runat="server" Text=""></asp:Label>
                            </li>
                            <li class="list-group-item">
                                <asp:Label ID="proteinLbl" runat="server" Text="Protein:"></asp:Label>
                                <asp:Label ID="proteinAmountLbl" runat="server" Text=""></asp:Label>
                            </li>
                            <li class="list-group-item">
                                <asp:Label ID="carbohydrateLbl" runat="server" Text="Carbohydrate:"></asp:Label>
                                <asp:Label ID="carbohydrateAmountLbl" runat="server" Text=""></asp:Label>
                            </li>
                            <li class="list-group-item">
                                <asp:Label ID="fatsLbl" runat="server" Text="Fats:"></asp:Label>
                                <asp:Label ID="fatsAmountLbl" runat="server" Text=""></asp:Label>
                            </li>
                        </ul>
                    </div>

                </div>

            </div>
            <br />
            <div class="row justify-content-around">
                <div class="col-lg-8 justify-content-center">
                    <div class="card card-body " style="font-size:20px">
                        <asp:Label ID="displayMaintananceCaloriesLbl" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>

            </div>
            <br />
            <div class="row justify-content-around">
                <div class="col-lg-8 ">
                    <div class="form-group row">
                        <asp:Button ID="checkBtn" runat="server" Text="Check" class="btn-outline-dark form-control col-lg-4" OnClick="checkBtn_Click" AutoPostBack="false" />
                    
                  
                        <asp:Button ID="removeFoodBtn" runat="server" Text="Remove Food" class="btn-outline-dark form-control col-lg-4"
                            OnClick="removeFoodBtn_Click" />
                    
                   
                        <asp:Button ID="addMoreFoodBtn" runat="server" class="btn-outline-dark form-control col-lg-4" Text="Add Food"
                            OnClick="addMoreFoodBtn_Click" />
                    </div>
                        
                    
                </div>

            </div>
            <br />
            <div class="row justify-content-around">
                <div class="col-lg-8 text-center" style="font-size:20px">
                    <strong>
                         <asp:Label ID="BreakfastLbl" runat="server" Text="Breakfast" ></asp:Label>
                    </strong>
                   
                </div>

            </div>

            <div class="row justify-content-around">
                <div class="col-lg-8">
                    <asp:GridView ID="breakfastGridView" runat="server" AutoGenerateColumns="False"
                        OnRowDeleting="breakfastGridView_OnRowDeleting" OnRowCommand="OnRowDataBound" DataKeyNames="Id"
                        CellPadding="4" ForeColor="Black" PageSize="5"
                        GridLines="Vertical" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                            <asp:BoundField DataField="Food" HeaderText="Food" SortExpression="Food" />
                            <asp:BoundField DataField="Protein" HeaderText="Protein"
                                SortExpression="Protein" />
                            <asp:BoundField DataField="Carbohydrate" HeaderText="Carbohydrate"
                                SortExpression="Carbohydrate" />
                            <asp:BoundField DataField="Total_Fat" HeaderText="Total_Fat"
                                SortExpression="Total_Fat" />
                            <asp:BoundField DataField="Calories" HeaderText="Calories"
                                SortExpression="Calories" />
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
            <div class="row justify-content-around ">
                <div class="col-lg-8 text-center" style="font-size:20px">
                    <strong>
                         <asp:Label ID="lunchLbl" runat="server" Text="Lunch" ></asp:Label>
                    </strong>
                   
                </div>

            </div>

            <div class="row justify-content-around">
                <div class="col-lg-8">
                    <asp:GridView ID="lunchGridView" runat="server" AutoGenerateColumns="False"
                        OnRowDeleting="lunchGridView_OnRowDeleting" OnRowCommand="OnRowDataBound" DataKeyNames="Id"
                        CellPadding="4" ForeColor="Black" PageSize="5"
                        GridLines="Vertical" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                            <asp:BoundField DataField="Food" HeaderText="Food" SortExpression="Food" />
                            <asp:BoundField DataField="Protein" HeaderText="Protein"
                                SortExpression="Protein" />
                            <asp:BoundField DataField="Carbohydrate" HeaderText="Carbohydrate"
                                SortExpression="Carbohydrate" />
                            <asp:BoundField DataField="Total_Fat" HeaderText="Total_Fat"
                                SortExpression="Total_Fat" />
                            <asp:BoundField DataField="Calories" HeaderText="Calories"
                                SortExpression="Calories" />
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
            <div class="row justify-content-around ">
                <div class="col-lg-8 text-center" style="font-size:20px">
                    <strong>
                        <asp:Label ID="snackLbl" runat="server" Text="Snack" ></asp:Label>
                    </strong>
                    
                </div>

            </div>

            <div class="row justify-content-around">
                <div class="col-lg-8">
                    <asp:GridView ID="snackGridView" runat="server" AutoGenerateColumns="False"
                        OnRowDeleting="snackGridView_OnRowDeleting" OnRowCommand="OnRowDataBound" DataKeyNames="Id"
                        CellPadding="4" ForeColor="Black" PageSize="5"
                        GridLines="Vertical" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                            <asp:BoundField DataField="Food" HeaderText="Food" SortExpression="Food" />
                            <asp:BoundField DataField="Protein" HeaderText="Protein"
                                SortExpression="Protein" />
                            <asp:BoundField DataField="Carbohydrate" HeaderText="Carbohydrate"
                                SortExpression="Carbohydrate" />
                            <asp:BoundField DataField="Total_Fat" HeaderText="Total_Fat"
                                SortExpression="Total_Fat" />
                            <asp:BoundField DataField="Calories" HeaderText="Calories"
                                SortExpression="Calories" />
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
            <div class="row justify-content-around ">
                <div class="col-lg-8 text-center" style="font-size:20px">
                    <strong>
                         <asp:Label ID="dinnerLbl" runat="server" Text="Dinner" ></asp:Label>
                    </strong>
                   
                </div>

            </div>

            <div class="row justify-content-around">
                <div class="col-lg-8">
                
                <asp:GridView ID="dinnerGridView" runat="server" CellPadding="4" ForeColor="Black"
                    OnRowDeleting="dinnerGridView_OnRowDeleting" OnRowCommand="OnRowDataBound" DataKeyNames="Id"
                    AutoGenerateColumns="False" PageSize="5"
                    GridLines="Vertical" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                        <asp:BoundField DataField="Food" HeaderText="Food" SortExpression="Food" />
                        <asp:BoundField DataField="Protein" HeaderText="Protein"
                            SortExpression="Protein" />
                        <asp:BoundField DataField="Carbohydrate" HeaderText="Carbohydrate"
                            SortExpression="Carbohydrate" />
                        <asp:BoundField DataField="Total_Fat" HeaderText="Total_Fat"
                            SortExpression="Total_Fat" />
                        <asp:BoundField DataField="Calories" HeaderText="Calories"
                            SortExpression="Calories" />
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

        </div>
        <div>            
        </div>



    <%-- script --%>
<script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
</script>
</asp:Content>