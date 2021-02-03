<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="Tenants.aspx.cs" Inherits="content_Tenants" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
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
                    <div class="row">
                        <div class="col-md-12">
                            <div class="box">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Tenants</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="row">
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-yellow"><i class="fa fa-user-plus"></i></span>
                                                <div class="info-box-content">
                                                    <span style="color: #ff6a00">Total Rooms</span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblTotalRooms" runat="server"></asp:Label></span>
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
                                                    <span style="color: #ff6a00">Total Tenants</span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblTotalTenants" runat="server"></asp:Label></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                            <!-- /.info-box -->
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <a href="#">
                                                <div class="info-box">
                                                    <span class="info-box-icon bg-orange-active color-palette"><i class="fa fa-sign-out"></i></span>

                                                    <div class="info-box-content">
                                                        <span style="color: #ff6a00">Total Beds</span>
                                                        <span class="info-box-number" style="color: #ff6a00">
                                                            <asp:Label ID="lblTotalBeds" runat="server"></asp:Label></span>
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
                                    <h3 class="box-title">My Tenants</h3>

                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body no-padding">
                                    <div class="pad">
                                        <div class="row">
                                            <div class="col-md-10 col-sm-4 col-xs-12">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search Tenants By Name No or Mobile or  Room No.." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchTenants" class="btn btn-flat" runat="server" OnClick="lbtSearchTenants_Click">
                                                    <i class="fa fa-search"></i></asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>

                                            <div class="col-md-2 col-sm-2 col-xs-2">
                                                <div class="input-group">
                                                    <asp:LinkButton ID="btnAddNewTenants" runat="server" class="btn btn-success btn-flat " OnClick="btnAddNewTenants_Click"><i class="fa fa-plus">Add New Tenants</i></asp:LinkButton>

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

                                                        <asp:ListView ID="ListView1" runat="server" DataKeyNames="t_id" OnItemCommand="ListView1_ItemCommand">
                                                            <ItemTemplate>
                                                                <div class="col-md-3">
                                                                    <div class="pad">
                                                                        <!-- MAP & BOX PANE -->
                                                                        <div class="box box-info  zoomnow">
                                                                            <div class="box-header with-border">
                                                                                <h3 class="box-title">
                                                                                    <asp:Label runat="server" ID="lblp_name" Text='<%#Eval("t_roomNo") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label></h3>

                                                                                <div class="box-tools pull-right">
                                                                                    <asp:LinkButton ID="lbtnedit" class="btn btn-box-tool" CommandArgument='<%#Eval("t_id")%>' CommandName="Edit" runat="server"><i class="fa fa-pencil-square-o edt " ></i></asp:LinkButton>

                                                                                    <asp:LinkButton ID="lbtnDelete" class="btn btn-box-tool" CommandArgument='<%#Eval("t_id")%>' CommandName="Dlt" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server"><i class="fa fa-trash  dlt"></i></asp:LinkButton>
                                                                                </div>
                                                                            </div>
                                                                            <!-- /.box-header -->
                                                                            <div class="box-body no-padding">
                                                                                <div class="row">
                                                                                    <div class="col-md-3 col-sm-3">

                                                                                        <!-- Map will be created here -->
                                                                                        <div style="min-height: 180px;">
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <td><i class="fa fa-user" style="font-size: 14px;"></i>&nbsp Name </td>
                                                                                                    <td>

                                                                                                        <asp:Label runat="server" ID="lblname" Text='<%#Eval("t_Name") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td><i class="fa fa-mobile" style="font-size: 14px;"></i>&nbsp Mobile </td>
                                                                                                    <td>

                                                                                                        <asp:Label runat="server" ID="Label1" Text='<%#Eval("t_MobileNo") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td><i class="fa fa-bed" style="font-size: 14px;"></i>&nbsp Bed Type </td>
                                                                                                    <td>

                                                                                                        <asp:Label runat="server" ID="lblt_BedsText" Text='<%#Eval("t_BedsText") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <i class="fa fa-rupee" style="font-size: 14px"></i>&nbsp Monthly Rent:
                                                                                                    </td>
                                                                                                    <td>

                                                                                                        <asp:Label runat="server" ID="lblrent" Text='<%#Eval("t_RentMoney") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <i class="fa fa-home" style="font-size: 14px"></i>&nbsp Lockin Period:
                                                                                                    </td>
                                                                                                    <td>

                                                                                                        <asp:Label runat="server" ID="lblt_LockinPeriodText" Text='<%#Eval("t_LockinPeriodText") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td style="text-align: center"><i class="fa fa-rupee" style="font-size: 14px"></i>&nbsp Security Deposit:</td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lblr_SecurityDeposit" Text='<%#Eval("t_SecurityMoney") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>

                                                                                                        <i class="fa fa-calendar" style="font-size: 14px"></i>&nbsp  D.O.J :
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lbldoj" Text='<%#Eval("t_DateOfJoining") %>' ForeColor="#ff0000"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <i class="fa fa-calendar" style="font-size: 14px"></i>&nbsp Rent Dues Date
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lblrentdate" Text='<%#Eval("t_RentDate") %>' ForeColor="#ff0000"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>

                                                                                                        <i class="fa fa-file" style="font-size: 14px"></i>&nbsp KYC Status :
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lblKycStatus" Text='<%#Eval("KycStatus") %>' ForeColor="#00adef" Style="text-transform: uppercase;"></asp:Label>
                                                                                                    </td>

                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>

                                                                                                        <i class="fa fa-file" style="font-size: 14px"></i>&nbsp Bank Status :
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="Label2" Text='<%#Eval("t_BankDetailStatus") %>' ForeColor="#00adef" Style="text-transform: uppercase;"></asp:Label>
                                                                                                    </td>

                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Button ID="btnGetReport" runat="server" Text="Get Report" class="btn btn-primary" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:LinkButton ID="lbtnGetKYC" class="btn btn-info" CommandArgument='<%#Eval("t_id")%>' CommandName="GetKYC" runat="server">Get KYC</asp:LinkButton>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
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
                                    <!-- /.row -->
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

