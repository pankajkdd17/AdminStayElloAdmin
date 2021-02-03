<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="AddStaffs.aspx.cs" Inherits="content_AddStaffs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Staffs
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Staffs</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <!-- Main content -->
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section class="content">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Add Staffs</h3>
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

                                                                <asp:RequiredFieldValidator ID="reqRentAmount" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter Name"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Mobile No</label>
                                                                <asp:TextBox ID="txtMobileNo" runat="server" TextMode="Number" onkeypress="if (this.value.length > 9) { return false; }" class="form-control" placeholder="Mobile No"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqMobileNo" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Please enter Mobile No"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Adhaar No</label>
                                                                <asp:TextBox ID="txtAdhaarNo" runat="server" TextMode="Number" onkeypress="if (this.value.length > 11) { return false; }" class="form-control" placeholder="Adhaar No"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqAdhar" runat="server" ControlToValidate="txtAdhaarNo" ErrorMessage="Please enter Adhaar No"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>PAN No.</label>
                                                                <asp:TextBox ID="txtPanNo" runat="server" onkeypress="if (this.value.length > 9) { return false; }" class="form-control" placeholder="Details"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqPanNo" runat="server" ControlToValidate="txtPanNo" ErrorMessage="Please enter PAN Card No"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Full Address</label>
                                                                <asp:TextBox ID="txtFullAddress" runat="server" TextMode="MultiLine" class="form-control" placeholder="Full Address"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqFullAddress" runat="server" ControlToValidate="txtFullAddress" ErrorMessage="Please enter Full Address"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Date Of Joining</label>
                                                                <asp:TextBox ID="txtDateOfJoining" runat="server" TextMode="Date" class="form-control" placeholder="Date Of Joining"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqDateOfJoining" runat="server" ControlToValidate="txtDateOfJoining" ErrorMessage="Please enter Date Of Joining"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Password</label>
                                                                <asp:TextBox ID="txtpass" runat="server" TextMode="Password" class="form-control" placeholder="Password"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpass" ErrorMessage="Please enter password"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Confirm password</label>
                                                                <asp:TextBox ID="txtPasswordConfirm" runat="server" class="form-control" placeholder="Confirm Password"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPasswordConfirm" ErrorMessage="Please enter Password Confirm"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="CompareValidator1" runat="server"
                                                                    ControlToValidate="txtPasswordConfirm"
                                                                    CssClass="ValidationError"
                                                                    ControlToCompare="txtpass"
                                                                    ErrorMessage="No Match"
                                                                    ToolTip="Password must be the same" />
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <!-- /.box-body -->
                                                    <asp:Label ID="lblmessage" runat="server"></asp:Label>

                                                    <div class="box-footer">


                                                        <asp:Button ID="btnStaffs" runat="server" class="btn btn-success" CausesValidation="true" Text="Save Staffs" OnClick="btnStaffs_Click" />
                                                        <asp:Button ID="btnSaveChenge" runat="server" CausesValidation="true" class="btn btn-success" Text="Save Change" OnClick="btnSaveChenge_Click" />

                                                        <asp:Button ID="btnViewStaff" runat="server" class="btn btn-primary" CausesValidation="false" Text="View Staffs" OnClick="btnViewStaff_Click" />
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

