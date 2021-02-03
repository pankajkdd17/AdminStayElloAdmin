<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="Rooms.aspx.cs" Inherits="content_Rooms" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Rooms
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Rooms</a></li>
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
                                    <h3 class="box-title">Rooms</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="row">
                                        <!-- /.col -->
                                        <div class="col-md-3 col-sm-6 col-xs-12 zoomnow">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-yellow"><i class="fa fa-home"></i></span>
                                                <div class="info-box-content">
                                                    <span style="color: #ff6a00">Total Rooms </span>
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
                                        <div class="col-md-3 col-sm-6 col-xs-12 zoomnow">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-red-active color-palette"><i class="fa fa-bed"></i></span>
                                                <div class="info-box-content">
                                                    <span style="color: #f00">Vacent</span>
                                                    <span class="info-box-number" style="color: #f00">
                                                        <asp:Label ID="lblVacent" runat="server"></asp:Label></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                            <!-- /.info-box -->
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-md-3 col-sm-6 col-xs-12 zoomnow">
                                            <a href="#">
                                                <div class="info-box">
                                                    <span class="info-box-icon bg-orange-active color-palette"><i class="fa fa-building-o"></i></span>

                                                    <div class="info-box-content">
                                                        <span style="color: #808080">Semi Occupied</span>
                                                        <span class="info-box-number" style="color: #808080">
                                                            <asp:Label ID="lblSemiOccupied" runat="server"></asp:Label></span>
                                                    </div>
                                                    <!-- /.info-box-content -->
                                                </div>
                                                <!-- /.info-box -->
                                            </a>
                                        </div>
                                        <div class="col-md-3 col-sm-6 col-xs-12 zoomnow">
                                            <a href="#">
                                                <div class="info-box">
                                                    <span class="info-box-icon bg-green-active color-palette"><i class="fa fa-building-o"></i></span>

                                                    <div class="info-box-content">
                                                        <span style="color: #0a4b05">Fully Occupied</span>
                                                        <span class="info-box-number" style="color: #0a4b05">
                                                            <asp:Label ID="lblFull" runat="server"></asp:Label></span>
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
                                    <h3 class="box-title">Rooms</h3>

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
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search Rooms By Room No or id..." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchRooms" class="btn btn-flat" runat="server" OnClick="lbtSearchRooms_Click">
                                                    <i class="fa fa-search"></i></asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>

                                            <div class="col-md-2 col-sm-2 col-xs-2">
                                                <div class="input-group">
                                                    <asp:LinkButton ID="btnAddNewRooms" runat="server" class="btn btn-success btn-flat " OnClick="btnAddNewRooms_Click"><i class="fa fa-plus">Add New Rooms</i></asp:LinkButton>


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

                                                        <asp:ListView ID="ListView1" DataKeyNames="r_id" OnItemCommand="ListView1_ItemCommand" runat="server">
                                                            <ItemTemplate>

                                                                <div class="col-md-3">
                                                                    <div class="pad">
                                                                        <!-- MAP & BOX PANE -->
                                                                        <div class="box box-success  zoomnow">
                                                                            <div class="box-header with-border">
                                                                                <h3 class="box-title">
                                                                                    <asp:Label runat="server" ID="lblp_name" Text='<%#Eval("r_roomNo") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label></h3>

                                                                                <div class="box-tools pull-right">
                                                                                    <asp:LinkButton ID="lbtnedit" class="btn btn-box-tool" CommandArgument='<%#Eval("r_id")%>' CommandName="Edit" runat="server"><i class="fa fa-pencil-square-o edt " ></i></asp:LinkButton>

                                                                                    <asp:LinkButton ID="lbtnDelete" class="btn btn-box-tool" CommandArgument='<%#Eval("r_id")%>' CommandName="Dlt" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server"><i class="fa fa-trash  dlt"></i></asp:LinkButton>
                                                                                </div>
                                                                            </div>
                                                                            <!-- /.box-header -->
                                                                            <div class="box-body no-padding">

                                                                                <div class="row">
                                                                                    <div class="col-md-3 col-sm-3">

                                                                                        <!-- Map will be created here -->
                                                                                        <div id="Div2" style="min-height: 222px;">
                                                                                            <table style="text-align: left">

                                                                                                <tr style="white-space: nowrap">
                                                                                                    <td>Beds Capacity:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-bed" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblBeds" Text='<%#Eval("r_BedsText") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>Rent Price:</td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-rupee" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblrent" Text='<%#Eval("r_Rent") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Security Deposit:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-rupee" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblr_SecurityDeposit" Text='<%#Eval("r_SecurityDeposit") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="white-space: nowrap">Facilities Provided:</td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>


                                                                                                        <asp:Label runat="server" ID="lblr_Ac" Text='<%#Eval("r_Ac") %>' ForeColor="#00adef"></asp:Label>
                                                                                                    </td>
                                                                                                    <td>


                                                                                                        <asp:Label runat="server" ID="lblr_WiFi" Text='<%#Eval("r_WiFi") %>' ForeColor="#00adef"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>


                                                                                                        <asp:Label runat="server" ID="lblr_Washroom" Text='<%#Eval("r_Washroom") %>' ForeColor="#00adef"></asp:Label>
                                                                                                    </td>
                                                                                                    <td style="white-space: nowrap">

                                                                                                        <asp:Label runat="server" ID="lblr_LargeRoom" Text='<%#Eval("r_LargeRoom") %>' ForeColor="#00adef"></asp:Label>
                                                                                                </tr>
                                                                                                <tr>

                                                                                                    <td>

                                                                                                        <asp:Label runat="server" ID="lblr_Balcony" Text='<%#Eval("r_Balcony") %>' ForeColor="#00adef"></asp:Label>
                                                                                                    </td>
                                                                                                    <td>


                                                                                                        <asp:Label runat="server" ID="lblr_CornerRoom" Style="white-space: nowrap" Text='<%#Eval("r_CornerRoom") %>' ForeColor="#00adef"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Button ID="btnAddTenants" runat="server" Text="Add Tenants" class="btn btn-primary" OnClick="btnAddTenants_Click" /></td>
                                                                                                    <td>
                                                                                                        <asp:Button ID="btnViewTenants" runat="server" Text="View Tenants" class="btn btn-info" OnClick="btnViewTenants_Click" /></td>
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

