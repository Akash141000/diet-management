<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewFoodItem.aspx.cs" MasterPageFile="~/Navigation/userNavigation.master" ClientIDMode="Static" Inherits="DietManagement.User.AddNewFoodItem" %>




<asp:Content  runat="server" ContentPlaceHolderID="head">
    <title>Add NewFood</title>
    <meta
        name="viewport"
        content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    


    

</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContentPlaceHolder">

    


        <div class="container-fluid img-fluid min-vh-100"style="background-image: url('/Images/gw.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: 100% 100%">
            <div class="row pad justify-content-around">
                <form runat="server">
                <div class="col-lg-4 ">
                    <div class="card-transparent">
                        <div class="card-header">
                            <h3>Nutrition Content</h3>

                        </div>
                        <div class="card-body">
                            <div class="form-group row">
                                <asp:Label ID="Label1" runat="server" class="col-lg-4" Text="Name"></asp:Label>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="TextBox1" runat="server" data-placement="right" title="Enter name of the food" data-toggle="tooltip" class="form-control"></asp:TextBox>
                                    <span class="help-block">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required!"
                                            ControlToValidate="TextBox1" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:Label ID="Label7" runat="server" ForeColor="White"></asp:Label>
                                    </span>
                                </div>
                            </div>
                     <br />
                            <div class="form-group row">
                                <asp:Label ID="Label2" runat="server" class="col-lg-4" Text="Protein"></asp:Label>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="TextBox2" data-placement="right" title="Enter amount of protein" data-toggle="tooltip" class="form-control" runat="server"></asp:TextBox>
                                    <span class="help-block">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required!"
                                            ControlToValidate="TextBox2" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="Rx1" runat="server"
                                            ControlToValidate="TextBox2" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                            ErrorMessage="Enter valid values" ForeColor="Black"></asp:RegularExpressionValidator>
                                    </span>
                                </div>
                            </div>

                            <div class="form-group row">
                                <asp:Label ID="Label3" runat="server" class="col-lg-4" Text="Carbohydrate"></asp:Label>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="TextBox3" data-placement="right" title="Enter amount of Carbohydrate" data-toggle="tooltip" runat="server" class="form-control"></asp:TextBox>
                                    <span class="help-block">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required!"
                                            ControlToValidate="TextBox3" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="Rx2" runat="server"
                                            ControlToValidate="TextBox3" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                            ErrorMessage="Enter valid values" ForeColor="Black"></asp:RegularExpressionValidator>
                                    </span>
                                </div>
                            </div>

                            <div class="form-group row">
                                <asp:Label ID="Label4" runat="server" class="col-lg-4" Text="Total Fat"></asp:Label>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="TextBox4" data-placement="right" title="Enter amount of Total Fat" data-toggle="tooltip" class="form-control" runat="server"></asp:TextBox>
                                    <span class="help-block">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required!"
                                            ControlToValidate="TextBox4" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="Rx3" runat="server"
                                            ControlToValidate="TextBox4" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                            ErrorMessage="Enter valid values" ForeColor="Black"></asp:RegularExpressionValidator>
                                    </span>
                                </div>
                            </div>

                            <div class="form-group row">
                                <asp:Label ID="Label6" runat="server" class="col-lg-4" Text="Serving Size"></asp:Label>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="TextBox5" data-placement="right" title="Enter the quantity of food" data-toggle="tooltip" class="form-control" runat="server"></asp:TextBox>
                                    <span class="help-block">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5"
                                            ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                            ControlToValidate="TextBox5" ValidationExpression="^(?=.*[a-zA-Z])[0-9a-zA-Z-/\\\s]{4,25}$"
                                            ErrorMessage="Enter valid values" ForeColor="Black"></asp:RegularExpressionValidator>
                                    </span>
                                </div>
                            </div>

                            <div class="form-group row">
                                <asp:Button ID="Button1" runat="server" data-placement="right" title="Click to Add to database" data-toggle="tooltip" class="btn-outline-dark form-control" Text="Save" OnClick="Button1_Click" />
                                <span class="help-block">
                                    <asp:Label ID="Label5" runat="server" ForeColor="White"></asp:Label>
                                </span>
                            </div>
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