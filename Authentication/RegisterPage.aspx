<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" MasterPageFile="~/Navigation/Navigation.master" Inherits="DietManagement.RegisterPage" %>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div>
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <link href="../Bootstrap-5/css/bootstrap.min.css" rel="stylesheet" />
        <script async="async" defer="defer" src="../Bootstrap-5/css/js/bootstrap.bundle.min.js"></script>
    </div>

    <div class="container-fluid img-fluid min-vh-100" style="background-image: url('../Images/r3.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: 100% 100%">
        <div class="row pad justify-content-around text-light">
            <div class="col-lg-4 col-sm-12">
                <form runat="server" class="card-transparent">
                    <div class="card-header ">
                        <h2>Registration</h2>
                    </div>
                    <div class="form-group row ">
                        <asp:Label ID="fullNameLabel" runat="server" class="col-lg-4" Text="Name"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="fullNameInput" data-placement="right" title="Enter only alphabets" data-toggle="tooltip" runat="server"
                                placeholder=" Full name" class="form-control"></asp:TextBox>
                            <span class="help-block">
                                <asp:RequiredFieldValidator ID="fullNameRequiredValidator" runat="Server" ControlToValidate="fullNameInput" Display="Dynamic"
                                    Text="Required!" />

                                <asp:RegularExpressionValidator ID="fullNameRegex" runat="server" ControlToValidate="fullNameInput"
                                    ValidationExpression="^[a-zA-Z\s]+$"
                                    ErrorMessage="Invalid Input!" Display="Dynamic"></asp:RegularExpressionValidator>
                            </span>

                        </div>
                    </div>

                    <div class="form-group row">
                        <asp:Label ID="genderLabel" runat="server" class="col-lg-4" Text="Gender"></asp:Label>
                        <div class="col-lg-8">
                            <asp:DropDownList ID="genderTypeSelected" runat="server"
                                class="form-control">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>



                        </div>
                    </div>


                    <div class="form-group row">
                        <asp:Label ID="emailIdLabel" runat="server" class="col-lg-4" Text="Email id"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="emailIdInput" runat="server"
                                placeholder="abc@gmail.com" class="form-control"></asp:TextBox>
                            <span class="help-block">
                                <asp:RequiredFieldValidator ID="emailIdRequiredValidator" runat="server" ControlToValidate="emailIdInput"
                                    ErrorMessage="Required!" Display="Dynamic"></asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="emailIdRegex" runat="server" ControlToValidate="emailIdInput"
                                    ErrorMessage="Invalid email!"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    Display="Dynamic"></asp:RegularExpressionValidator>
                            </span>

                        </div>
                    </div>

                    <div class="form-group row">
                        <asp:Label ID="usernameLabel" runat="server" class="col-lg-4" Text="Username"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="usernameInput" class="form-control" data-placement="right" title="Username must be minimum 6 characters,atleast 1 number." data-toggle="tooltip" runat="server"></asp:TextBox>
                            <span class="help-block">
                                <asp:RequiredFieldValidator ID="usernameInputRequiredValidator" runat="server" ControlToValidate="usernameInput"
                                    ErrorMessage="Required!" Display="Dynamic"></asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="usernameInputRegex" runat="server" ControlToValidate="usernameInput"
                                    ErrorMessage="Invalid Username!"
                                    ValidationExpression="[0-9a-zA-Z]{6,}" Display="Dynamic"></asp:RegularExpressionValidator>

                                <asp:Label ID="usernameResult" runat="server" Text=""></asp:Label>
                            </span>
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label ID="passwordLabel" runat="server" class="col-lg-4" Text="Password"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="passwordInput" data-placement="right" title="Password must contain Minimum 8 characters,at least 1 uppercase,lowercase letter,number and 1 special character" data-toggle="tooltip" runat="server" TextMode="Password"
                                class="form-control"></asp:TextBox>

                            <span class="help-block">
                                <asp:RequiredFieldValidator ID="passwordInputRequiredValidator" runat="server" ControlToValidate="passwordInput"
                                    ErrorMessage="Required!" Display="Dynamic"></asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="passwordInputRegex" runat="server" ControlToValidate="passwordInput"
                                    ErrorMessage="Invalid Password!"
                                    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!/\\#^%*?&])[A-Za-z\d@$!#/\\%*?&]{8,}$"
                                    Display="Dynamic"></asp:RegularExpressionValidator>
                            </span>

                        </div>
                    </div>

                    <div class="form-group row">
                        <asp:Label ID="confirmPasswordLabel" runat="server" class="col-lg-4" Text="Confirm Password"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="confirmPasswordInput" data-placement="right" title="Confirm Password" data-toggle="tooltip" runat="server" TextMode="Password"
                                class="form-control"></asp:TextBox>
                            <span class="help-block">
                                <asp:CompareValidator ID="passwordInputCompareValidator" runat="Server" ControlToCompare="confirmPasswordInput"
                                    ControlToValidate="passwordInput" Operator="Equal" Text="Passwords must match!"
                                    Type="String" Display="Dynamic" />
                            </span>

                        </div>
                    </div>

                    <div class="form-group row justify-content-around">
                        <asp:Button ID="registrationSubmit" runat="server" OnClick="registrationSubmit_Click" data-placement="right" title="Click to Register" data-toggle="tooltip"
                            Text="Register" class="btn-outline-dark form-control" />
                        <span class="help-block">
                            <asp:Label ID="registrationResult" runat="server" Text=""></asp:Label>
                        </span>

                    </div>
                </form>

            </div>
        </div>
    </div>

</asp:Content>

