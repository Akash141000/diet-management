<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addUserIntake.aspx.cs" MasterPageFile="~/Navigation/userNavigation.master" ClientIDMode="Static" Inherits="DietManagement.User.addUserIntake" %>


<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>User Intake</title>
    <meta
        name="viewport"
        content="width=device-width, initial-scale=1, shrink-to-fit=no" />
   
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContentPlaceHolder">


    <div class="container-fluid img-fluid min-vh-100" style="padding:0px;margin:0px;background-image: url('/Images/Intake.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: 100% 100%">
        <form runat="server">
            
             <div style="background-color: rgba(0,0,0,0.5);height:inherit;width:100%">
            <div class="row  justify-content-around" style="padding-top:5rem">
                




                <div class="col-lg-8 offset-lg-1 justify-content-around my-2 ">
                    <div class="input-group col-lg-9 order-first order-lg-1 ">
                        <asp:TextBox ID="TextBox1" runat="server" class=" form-control " Height="45px" placeholder="Search food">
                        </asp:TextBox>
                        
                        <div class="input-group-btn col-lg-1">
                            <asp:Button ID="SearchFoodBtn" runat="server" data-placement="right" title="Click to Search"  data-toggle="tooltip" class="btn btn-primary  form-control"  Text="Search" OnClick="SearchFoodBtn_Click" />
                                                       <span><asp:Label ID="searchResultLbl" CssClass="text-light" runat="server" Text=""></asp:Label></span>
                            <asp:Button ID="addNewFoodItemBtn" Visible="false" runat="server" data-placement="right" title="Click to add food to database" data-toggle="tooltip" class="btn-primary form-control" Text="Add" PostBackUrl="/User/AddNewFoodItem.aspx" />
                        </div>
                    </div>
                </div>

             
            </div>






            <div class="row  justify-content-around">
                <div class="col-lg-12 col-sm-12">
                    <asp:GridView ID="gridView" runat="server"
                        PageSize="5"
                        OnSelectedIndexChanged="gridView_SelectedIndexChanged" Width="100%"
                        AllowPaging="True" Height="299px" Font-Bold="True" Font-Size="15pt"
                        ForeColor="#333333" CellPadding="4" GridLines="None" Style="margin-right: 0px"
                        ViewStateMode="Enabled" HeaderStyle-CssClass="text-light"
                        OnPageIndexChanging="gridView_Selected" AutoGenerateColumns="false">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkaddNewFoodItemBtn" runat="server" CausesValidation="False" CssClass="btn btn-outline-primary" CommandName="Select" Text="Select"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Food" HeaderText="Food"/>
                            <asp:BoundField DataField="Serving Size" HeaderText="ServingSize" />
                            <asp:BoundField DataField="Protein" HeaderText="Protein" />
                            <asp:BoundField DataField="Carbohydrate" HeaderText="Carbohydrate" />
                            <asp:BoundField DataField="Total_Fat" HeaderText="TotalFat" />
                            <asp:BoundField DataField="Food Type" HeaderText="FoodType" />

                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>



                </div>
            </div>

            <div class="row  justify-content-around mt-2">
                <div class="col-lg-6 text-center">
                    <h3>
                        <asp:Label ID="Label58" runat="server" class="col-lg-3 text-white" Text="Food -"></asp:Label>
                        <asp:Label ID="Label59" runat="server" class="col-lg-3 text-white" Text="Label"></asp:Label>
                    </h3>

                </div>

                <div class="col-lg-4 offset-lg-1">
                    <asp:Button ID="userAddFoodBtn" runat="server" data-placement="top" title="Click Add and keep a track of what you eat" data-toggle="tooltip" class="btn-outline-primary form-control " OnClick="userAddFoodBtn_Click" Text="Add" />
                    <span class="help-block text-white">

                        <asp:Label ID="userAddFoodResultLbl" runat="server" Text="Added Successfully"></asp:Label>


                    </span>
                </div>
            </div>

            <div class="row justify-content-around text-white">
                <div>

                    <div class="col-lg-12  text-center">
                        <h4>
                            <asp:Label ID="nutritionContentLbl" runat="server" Text="Nutrition Content"></asp:Label>
                        </h4>

                    </div>
                </div>
            </div>
            <div class="row justify-content-around text-white mt-2">
                <div class="col-lg-12" style="font-size: 20px">
                    <table class="table table-borderless text-light">
                        <tr style="text-align: center">
                            <td class="style1">
                                <asp:Label ID="carbohydrateLbl" runat="server" Text="Carbohydrate"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label19" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label41" runat="server" Text="g"></asp:Label>
                            </td>
                            <td class="style3">
                                <asp:Label ID="sodiumLbl" runat="server" Text="Sodium"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label34" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label49" runat="server" Text="mg"></asp:Label>
                            </td>
                        </tr>
                        <tr style="text-align: center">
                            <td class="style1">
                                <asp:Label ID="fiberLbl" runat="server" Text="Fiber"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label20" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label42" runat="server" Text="g"></asp:Label>
                            </td>
                            <td class="style3">
                                <asp:Label ID="potassiumLbl" runat="server" Text="Potassium"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label35" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label50" runat="server" Text="mg"></asp:Label>
                            </td>
                        </tr>
                        <tr style="text-align: center">
                            <td class="style1">
                                <asp:Label ID="totalFatLbl" runat="server" Text="Total Fat"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label21" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label43" runat="server" Text="g"></asp:Label>
                            </td>
                            <td class="style3">
                                <asp:Label ID="cholesterolLbl" runat="server" Text="Cholesterol"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label36" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label51" runat="server" Text="mg"></asp:Label>
                            </td>
                        </tr>
                        <tr style="text-align: center">
                            <td class="style1">
                                <asp:Label ID="saturatedFatLbl" runat="server" Text="Saturated Fat"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label22" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label44" runat="server" Text="g"></asp:Label>
                            </td>
                            <td class="style3">
                                <asp:Label ID="vitaminALabel" runat="server" Text="Vitamin A"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label37" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label52" runat="server" Text="RI"></asp:Label>
                            </td>
                        </tr>
                        <tr style="text-align: center">
                            <td class="style1">
                                <asp:Label ID="mononsaturatedFatLbl" runat="server" Text="Mononsaturated Fat"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label23" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label45" runat="server" Text="g"></asp:Label>
                            </td>
                            <td class="style3">
                                <asp:Label ID="vitaminCLbl" runat="server" Text="Vitamin C"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label38" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label53" runat="server" Text="mg"></asp:Label>
                            </td>
                        </tr>
                        <tr style="text-align: center">
                            <td class="style1" style="height: 26px">
                                <asp:Label ID="polyunsaturatedLbl" runat="server" Text="Polyunsaturated"></asp:Label>
                            </td>
                            <td class="style2" style="height: 26px">
                                <asp:Label ID="Label24" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label46" runat="server" Text="g"></asp:Label>
                            </td>
                            <td class="style3" style="height: 26px">
                                <asp:Label ID="calciumLbl" runat="server" Text="Calcium"></asp:Label>
                            </td>
                            <td style="height: 26px">
                                <asp:Label ID="Label39" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label54" runat="server" Text="mg"></asp:Label>
                            </td>
                        </tr>
                        <tr style="text-align: center">
                            <td class="style1">
                                <asp:Label ID="proteinLbl" runat="server" Text="Protein"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:Label ID="Label25" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label47" runat="server" Text="g"></asp:Label>
                            </td>
                            <td class="style3">
                                <asp:Label ID="ironLbl" runat="server" Text="Iron"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label40" runat="server" Text="--"></asp:Label>
                                &nbsp;
                    <asp:Label ID="Label55" runat="server" Text="mg"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>

            </div>
                 </div>

        </form>

    </div>



   <script type="text/javascript">
       $(document).ready(function () {
           $('[data-toggle="tooltip"]').tooltip();
       });
   </script>
</asp:Content>
