<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="AddIncome.aspx.cs" Inherits="content_AddIncome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Income
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Income</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <!-- Main content -->
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section class="content">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Add Income</h3>
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
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label>Reciving Date</label>
                                                                <asp:TextBox ID="txtRecivingDate" runat="server" class="form-control" TextMode="date" placeholder="Reciving Date"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqDate" ControlToValidate="txtRecivingDate" ValidationGroup="recve" runat="server" Display="Dynamic" ErrorMessage="Enter dues reciving date" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label>Dues Amount</label>
                                                                <asp:TextBox ID="txtDuesAmount" runat="server" ReadOnly="true" class="form-control"  placeholder="Dues Amount"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqtxtDuesAmount" ControlToValidate="txtDuesAmount" ValidationGroup="recve" runat="server" Display="Dynamic" ErrorMessage="Enter dues Amount" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ControlToValidate="txtDuesAmount" ErrorMessage="Please Enter Correct Value"
                                                                    ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" runat="server" Display="Dynamic" ForeColor="red" ValidationGroup="recve">
                                                                </asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label>Recived Amount</label>
                                                                <asp:TextBox ID="txtRecivedAmount" runat="server" class="form-control"  placeholder="Dues Amount"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqtxtRecivedAmount" ControlToValidate="txtRecivedAmount" ValidationGroup="recve" runat="server" Display="Dynamic" ErrorMessage="Enter Recive Amount" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ControlToValidate="txtRecivedAmount" ErrorMessage="Please Enter Correct Value"
                                                                    ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" runat="server" ForeColor="red" Display="Dynamic" ValidationGroup="recve">
                                                                </asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label>Payment Mode</label>
                                                                <asp:DropDownList ID="ddlModeOfPayment" runat="server" class="form-control"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlModeOfPayment" ValidationGroup="recve" runat="server" Display="Dynamic" ErrorMessage="Select mode of payment" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                                    <asp:Button ID="btnReciveDue" runat="server" class="btn btn-success" Text="Recive Due" OnClick="btnReciveDue_Click" ValidationGroup="recve" CausesValidation="true" />
                                                     <asp:Button ID="btnUpdateIncome" runat="server" class="btn btn-primary" Text="Update Recive Due" OnClick="btnUpdateIncome_Click" ValidationGroup="recve" CausesValidation="true" />
                                                    <asp:Button ID="btnViewDues" runat="server" class="btn btn-info" Text="View pending Dues" OnClick="btnViewDues_Click" CausesValidation="false" />
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

