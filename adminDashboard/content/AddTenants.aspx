<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="AddTenants.aspx.cs" Inherits="content_AddTenants" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Tenants
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Tenants</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <!-- Main content -->
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section class="content">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Add Tenants</h3>
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
                                                                <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter Name"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Mobile No</label>
                                                                <asp:TextBox ID="txtMobileNo" OnTextChanged="txtMobileNo_TextChanged" AutoPostBack="true" runat="server" onkeypress="if (this.value.length > 9) { return false; }" TextMode="Number" class="form-control" placeholder="Mobile No"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqMobileNo" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Please enter Mobile No"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Room No.</label>
                                                                <asp:DropDownList ID="ddlRoomNo" class="form-control" OnSelectedIndexChanged="ddlRoomNo_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Bed Type</label>
                                                                <asp:TextBox ID="txtRoomType" ReadOnly="true" runat="server" class="form-control" placeholder="Bed Type"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Security Money</label>
                                                                <asp:TextBox ID="txtSecurityMoney" onkeypress="if (this.value.length > 6) { return false; }" runat="server" class="form-control" placeholder="Security Money" TextMode="Number"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqtxtSecurityMoney" runat="server" ControlToValidate="txtSecurityMoney" ErrorMessage="Please enter Security Money"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Rent Money</label>
                                                                <asp:TextBox ID="txtRentMoney" TextMode="Number" runat="server" onkeypress="if (this.value.length > 6) { return false; }" class="form-control" placeholder="Rent Money"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqRentMoney" runat="server" ControlToValidate="txtRentMoney" ErrorMessage="Please enter Rent Money"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Date Of Joining</label>
                                                                <asp:TextBox ID="txtDateOfJoining" runat="server" TextMode="Date" class="form-control" placeholder="Date Of Joining"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqDateOfJoining" runat="server" ControlToValidate="txtRentMoney" ErrorMessage="Please enter Date Of Joining"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Rent Date</label>
                                                                <asp:TextBox ID="txtRentDate" runat="server" TextMode="Date" class="form-control" placeholder="Rent Date"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqRentDate" runat="server" ControlToValidate="txtRentDate" ErrorMessage="Please enter Rent Date"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Lockin Period</label>
                                                                <asp:DropDownList ID="ddlLockinPeriod" class="form-control" runat="server">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="reqddlLockinPeriod" runat="server" ControlToValidate="ddlLockinPeriod" ErrorMessage="Please select lockin period"
                                                                    ForeColor="Red" InitialValue="0" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Any Details</label>
                                                                <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" MaxLength="300" class="form-control" placeholder="Details"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->

                                                    <div class="box-footer">
                                                        <asp:Button ID="btnTenants" runat="server" class="btn btn-success" Text="Save Tenants" OnClick="btnTenants_Click" ValidationGroup="save" CausesValidation="true" />
                                                        <asp:Button ID="btnSaveChenges" runat="server" class="btn btn-success" Text="Save Change" OnClick="btnSaveChenges_Click" ValidationGroup="save" CausesValidation="true" />
                                                        <asp:Button ID="btnView" runat="server" class="btn btn-primary" Text="View Tenants" OnClick="btnView_Click" ValidationGroup="save" CausesValidation="false" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.box -->
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

