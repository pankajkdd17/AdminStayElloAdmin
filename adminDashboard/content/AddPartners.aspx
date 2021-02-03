<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="AddPartners.aspx.cs" Inherits="content_AddPartners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Partners
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Partners</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <!-- Main content -->
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section class="content">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Add Partners</h3>
                            <!-- left column -->

                            <div class="row">
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-8">
                                    <section class="content">
                                        <!-- general form elements -->
                                        <div class="box box-primary">
                                            <div class="box-header with-border">
                                                <!-- /.box-header -->
                                                <!-- form start -->
                                                <div class="box-body">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Name</label>
                                                                <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Name"></asp:TextBox>

                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" ValidationGroup="save" runat="server" ErrorMessage="* Please Enter Your full Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName" ValidationExpression="^[a-zA-Z\\s]*$" ErrorMessage="Enter valid  name" Display="Dynamic" ForeColor="Red" ValidationGroup="save" />
                                                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtName" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{3,}$" runat="server" ForeColor="Red" ValidationGroup="save" ErrorMessage="Minimum 3 characters required."></asp:RegularExpressionValidator>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Mobile No</label>
                                                                <asp:TextBox ID="txtMobileNo" runat="server" TextMode="Number" onkeypress="if (this.value.length > 9) { return false; }" class="form-control" placeholder="Mobile No"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqMobileNo" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Please enter Mobile No"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                                    ControlToValidate="txtMobileNo"
                                                                    ValidationExpression="[0-9]{10}" ErrorMessage="Enter only valid phone Number" Display="Dynamic" ForeColor="Red" ValidationGroup="save"></asp:RegularExpressionValidator>

                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Date Of Joining</label>
                                                                <asp:TextBox ID="txtDateOfJoining" runat="server" TextMode="Date" class="form-control" placeholder="Date Of Joining"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqDoj" runat="server" ControlToValidate="txtDateOfJoining" ErrorMessage="Please enter Date Of Joining"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Any Details</label>
                                                                <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" class="form-control" placeholder="Details"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->

                                                    <div class="box-footer">
                                                        <asp:Button ID="btnPartners" runat="server" class="btn btn-success" Text="Save Partners" OnClick="btnPartners_Click" />

                                                        <asp:Button ID="btnSaveChenge" runat="server" class="btn btn-success" Text="Save Change" OnClick="btnSaveChenge_Click" />
                                                        <asp:Button ID="btnViewPartners" runat="server" class="btn btn-primary" Text="View Partners" OnClick="btnViewPartners_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- /.box -->
                                        </div>
                                    </section>
                                </div>
                                <div class="col-md-2">
                                </div>
                            </div>

                        </div>
                    </div>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

