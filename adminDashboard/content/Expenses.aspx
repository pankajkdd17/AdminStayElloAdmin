<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="Expenses.aspx.cs" Inherits="content_Expenses" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
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
                    <div class="row">
                        <div class="col-md-12">
                            <div class="box">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Expenses</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="row">
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-yellow"><i class="fa fa-money"></i></span>
                                                <div class="info-box-content">
                                                    <span style="color: #ff6a00">Total Expenses Added </span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblTotalExpences" runat="server"></asp:Label></span>
                                                </div>
                                            </div>
                                            <!-- /.info-box-content -->

                                            <!-- /.info-box -->
                                        </div>
                                        <!-- /.col -->

                                        <!-- fix for small devices only -->
                                        <div class="clearfix visible-sm-block"></div>
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-maroon-active color-palette"><i class="fa fa-check"></i></span>
                                                <div class="info-box-content">
                                                    <span style="color: #ff6a00">Total Dues Clear</span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblClearDues" runat="server"></asp:Label></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                            <!-- /.info-box -->
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <a href="#">
                                                <div class="info-box">
                                                    <span class="info-box-icon bg-orange-active color-palette"><i class="fa fa-clock-o"></i></span>

                                                    <div class="info-box-content">
                                                        <span style="color: #ff6a00">Total Dues Pending</span>
                                                        <span class="info-box-number" style="color: #ff6a00">
                                                            <asp:Label ID="lblPendingDues" runat="server"></asp:Label></span>
                                                    </div>
                                                    <!-- /.info-box-content -->
                                                </div>
                                                <!-- /.info-box -->
                                            </a>
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                </div>

                            </div>
                            <!-- /.box -->
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->

                    <!-- Main row -->
                    <div class="row">
                        <!-- Left col -->
                        <div class="col-md-12">
                            <!-- MAP & BOX PANE -->
                            <div class="box box-success">
                                <div class="box-header with-border">
                                    <h3 class="box-title">My Expenses</h3>

                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body no-padding">
                                    <div class="row">
                                        <div class="padd">
                                            <div class="col-md-10 col-sm-4 col-xs-12">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search Expences By Name..." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchExpences" class="btn btn-flat" runat="server" OnClick="lbtSearchExpences_Click">
                                                    <i class="fa fa-search"></i></asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>

                                            <div class="col-md-2 col-sm-2 col-xs-2">
                                                <div class="input-group">
                                                    <asp:LinkButton ID="btnAddNewExpenses" runat="server" class="btn btn-success btn-flat " OnClick="btnAddNewExpenses_Click"><i class="fa fa-plus">Add New Expenses</i></asp:LinkButton>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="pad">
                                            <div class="col-md-12">
                                                <!-- MAP & BOX PANE -->
                                                <div class="box box-danger ">
                                                    <!-- /.box-header -->
                                                    <div class="box-body no-padding  ">

                                                        <asp:ListView ID="ListView1" runat="server" DataKeyNames="e_id" OnItemCommand="ListView1_ItemCommand">
                                                            <ItemTemplate>
                                                                <div class="col-md-4">
                                                                    <!-- MAP & BOX PANE -->
                                                                    <div class="box box-success  zoomnowbox">
                                                                        <div class="box-header with-border">
                                                                            <h3 class="box-title">S.No:
                                                                        <asp:Label runat="server" ID="lblp_name" Text='<%#Eval("e_id") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label></h3>
                                                                            <div class="box-tools pull-right">
                                                                                <asp:LinkButton ID="lbtnedit" class="btn btn-box-tool" CommandArgument='<%#Eval("e_id")%>' CommandName="Edit" runat="server"><i class="fa fa-pencil-square-o edt " ></i></asp:LinkButton>

                                                                                <asp:LinkButton ID="lbtnDelete" class="btn btn-box-tool" CommandArgument='<%#Eval("e_id")%>' CommandName="Dlt" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server"><i class="fa fa-trash  dlt"></i></asp:LinkButton>
                                                                            </div>
                                                                        </div>
                                                                        <!-- /.box-header -->
                                                                        <div class="box-body no-padding">

                                                                            <div class="row">
                                                                                <div class="col-md-4 col-sm-4">
                                                                                    <div class="pad">
                                                                                        <!-- Map will be created here -->
                                                                                        <div id="Div2" style="min-height: 190px;">
                                                                                            <table style="text-align: left">

                                                                                                <tr style="white-space: nowrap">
                                                                                                    <td>Category:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-list" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblc_FullName" Text='<%#Eval("e_CategoryText") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>Amount:</td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-rupee" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblc_Mobile" Text='<%#Eval("e_Amount") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Paid By:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-user" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblc_email" Text='<%#Eval("e_PaidBytext") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Paid To:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-user" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblc_Applyfor" Text='<%#Eval("e_PaidTo") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Payment Method:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-rupee" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label1" Text='<%#Eval("e_PaymentMethod") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Expense Date:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-calendar" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label2" Text='<%#Eval("e_ExpenseDate") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Any Details:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-list" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label3" Text='<%#Eval("e_Details") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>

                                                                                            </table>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <!-- /.col -->
                                                                                <!-- /.col -->
                                                                            </div>

                                                                            <!-- /.row -->
                                                                        </div>
                                                                        <!-- /.box-body -->
                                                                    </div>
                                                                </div>

                                                            </ItemTemplate>
                                                        </asp:ListView>

                                                    </div>
                                                    <!-- /.col -->
                                                    <!-- /.col -->

                                                    <!-- /.box-body -->
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->
                            </div>
                        </div>

                    </div>
                    <!-- /.row -->

                </section>
                <!-- /.content -->
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- /.content-wrapper -->
</asp:Content>

