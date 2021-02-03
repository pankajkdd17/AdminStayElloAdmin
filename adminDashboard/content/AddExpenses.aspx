<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="AddExpenses.aspx.cs" Inherits="content_AddExpenses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Expenses
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Expenses</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <!-- Main content -->
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section class="content">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Add Expenses</h3>
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
                                                                <label>Category</label>
                                                                <asp:DropDownList ID="ddlCategory" class="form-control" runat="server">
                                                                </asp:DropDownList>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>&nbsp</label>
                                                                <div class="row">
                                                                    <div class="col-md-6" id="category" runat="server" visible="false">
                                                                        <div class="form-group">
                                                                            <asp:TextBox ID="txtCategory" runat="server" class="form-control" placeholder="Category Name"></asp:TextBox>

                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4" id="btnCate" runat="server" visible="false">
                                                                        <div class="form-group">

                                                                            <asp:Button ID="btnSaveCategory" runat="server" Text="Save" OnClick="btnSaveCategory_Click" class="btn btn-success" />

                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-2" id="btnhide" runat="server" visible="true">
                                                                        <asp:LinkButton ID="lbtnAddCetgory" runat="server" class="btn btn-success" OnClick="btnAddCetgory_Click"><i class="fa fa-plus"> Category</i></asp:LinkButton>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Paid By</label>
                                                                <asp:DropDownList ID="ddlPaidBy" class="form-control" runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Amount</label>
                                                                <asp:TextBox ID="txtAmount" runat="server" TextMode="Number" onkeypress="if (this.value.length > 8) { return false; }" class="form-control" placeholder="Amount"></asp:TextBox>

                                                            </div>
                                                        </div>


                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Paid To</label>
                                                                <asp:TextBox ID="txtPaidTo" runat="server" class="form-control" placeholder="Paid To Name"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Payment Method</label>
                                                                <asp:DropDownList ID="ddlPaymentMethod" class="form-control" runat="server">
                                                                    <asp:ListItem Text="Online" Value="Online"></asp:ListItem>
                                                                    <asp:ListItem Text="offline" Value="offline"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Expense Date</label>
                                                                <asp:TextBox ID="txtExpenseDate" runat="server" TextMode="Date" class="form-control" placeholder="Expenses Date"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Details</label>
                                                                <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" class="form-control" placeholder="Details"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->

                                                    <div class="box-footer">
                                                        <asp:Button ID="btnExpenses" runat="server" class="btn btn-success" Text="Save Expenses" OnClick="btnExpenses_Click" />

                                                        <asp:Button ID="btnSaveChenges" runat="server" class="btn btn-success" Text="Save Change" OnClick="btnSaveChenges_Click" />

                                                        <asp:Button ID="btnViewExpenses" runat="server" class="btn btn-primary" Text="View Expenses" OnClick="btnViewExpenses_Click" />
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

