<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="AddDues.aspx.cs" Inherits="content_AddDues" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        .checkbox label, .radio label {
            min-height: 20px;
            padding-left: 0px;
            margin-bottom: 0;
            font-weight: 400;
            cursor: pointer;
        }
    </style>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Dues
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Dues</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <!-- Main content -->
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section class="content">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Add Dues</h3>
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
                                                                <label>Payee</label>
                                                                <asp:DropDownList ID="ddlPayee" OnSelectedIndexChanged="ddlPayee_SelectedIndexChanged" AutoPostBack="true" class="form-control" runat="server">
                                                                </asp:DropDownList>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Room No / Mobile </label>
                                                                <asp:TextBox ID="txtRoomNoMobile" runat="server" class="form-control" ReadOnly="true" placeholder="Room No / Mobile" Font-Bold="true" ForeColor="Red"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Dues Type</label>
                                                                <asp:DropDownList ID="ddlDuesType" class="form-control" runat="server" OnSelectedIndexChanged="ddlDuesType_SelectedIndexChanged" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddlDuesType"
                                                                    InitialValue="0" ErrorMessage="Dues Type required" Display="Dynamic" ValidationGroup="due"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Dues Amount</label>
                                                                <asp:TextBox ID="txtDuesAmount" runat="server" class="form-control" TextMode="Number" placeholder="Dues Amount"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqAmount" ControlToValidate="txtDuesAmount" ValidationGroup="due" runat="server" Display="Dynamic" ErrorMessage="Enter dues amount" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Dues Date</label>
                                                                <asp:TextBox ID="txtDuesDate" runat="server" class="form-control" TextMode="Date" placeholder="Dues Date"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqtxtDuesDate" ControlToValidate="txtDuesDate" ValidationGroup="due" runat="server" Display="Dynamic" ErrorMessage="Select dues date" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>dues For Month</label>
                                                                <asp:TextBox ID="txtDuesMonth" runat="server" TextMode="Month" class="form-control" placeholder="Dues Month"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqtxtDuesMonth" ControlToValidate="txtDuesMonth" ValidationGroup="due" runat="server" Display="Dynamic" ErrorMessage="Select dues Month" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label>Remark</label>
                                                                <asp:TextBox ID="txtRemark" runat="server" class="form-control" TextMode="MultiLine" placeholder="Remark"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                                <!-- /.box-body -->

                                                <div class="box-footer">
                                                    <asp:Button ID="btnDues" runat="server" class="btn btn-success" Text="Save Dues" OnClick="btnDues_Click" ValidationGroup="due" CausesValidation="true" />
                                                    <asp:Button ID="btnSaveChenges" runat="server" class="btn btn-success" Text="Save Change" OnClick="btnSaveChenges_Click" ValidationGroup="due" CausesValidation="true" />
                                                    <asp:Button ID="btnViewDues" runat="server" class="btn btn-primary" Text="View dues" OnClick="btnViewDues_Click" CausesValidation="false" />
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

