<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="Bookings.aspx.cs" Inherits="content_Bookings" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Bookings
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Bookings</a></li>
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
                                    <h3 class="box-title">Bookings</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="row">
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-yellow"><i class="fa fa-home"></i></span>
                                                <div class="info-box-content">
                                                    <span style="color: #ff6a00">Total Bookings </span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblTotalBookings" runat="server"></asp:Label></span>
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
                                                <span class="info-box-icon bg-maroon-active color-palette"><i class="fa fa-bed"></i></span>
                                                <div class="info-box-content">
                                                    <span style="color: #ff6a00">Total Visiting</span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblotalVisiting" runat="server"></asp:Label></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                            <!-- /.info-box -->
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <a href="#">
                                                <div class="info-box">
                                                    <span class="info-box-icon bg-orange-active color-palette"><i class="fa fa-user-plus"></i></span>

                                                    <div class="info-box-content">
                                                        <span style="color: #ff6a00">Total Signup</span>
                                                        <span class="info-box-number" style="color: #ff6a00">
                                                            <asp:Label ID="lblSignup" runat="server"></asp:Label></span>
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
                                    <h3 class="box-title">Bookings</h3>

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
                                            <div class="col-md-12 col-sm-4 col-xs-12">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search Booking By Mobile No or Name..." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchBooking" class="btn btn-flat" runat="server" OnClick="lbtSearchBooking_Click">
                                                    <i class="fa fa-search"></i></asp:LinkButton>
                                                    </span>
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
                                                    <div class="box-body no-padding   table-responsive  ">
                                                        <div>
                                                            <asp:Repeater ID="rptBooking" runat="server">
                                                                <HeaderTemplate>
                                                                    <table class="table table-bordered table-responsive table-hover">
                                                                        <tr>
                                                                            <th colspan="3" style="text-align: center">WHERE TO VISIT
                                                                            </th>
                                                                            <th colspan="5" style="text-align: center">BOOKED BY DETAILS
                                                                            </th>
                                                                            <th colspan="2" style="text-align: center">ACTION
                                                                            </th>
                                                                        </tr>
                                                                        <tr style="white-space: nowrap">
                                                                            <th>PROPERTY NAME
                                                                            </th>
                                                                            <th>P.G. NAME
                                                                            </th>
                                                                            <th>P.G MOBILE
                                                                            </th>
                                                                            <th>BOOKED BY NAME
                                                                            </th>
                                                                            <th>BOOKED AMOUNT
                                                                            </th>
                                                                            <th>BOOKED DATE
                                                                            </th>
                                                                            <th>BOOKED BY MOBILE
                                                                            </th>
                                                                            <th>BOOKING STATUS
                                                                            </th>
                                                                            <th>Edit
                                                                            </th>
                                                                            <th>Delete
                                                                            </th>
                                                                        </tr>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>

                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label runat="server" ID="Label1" Text='<%#Eval("p_name") %>'></asp:Label>
                                                                        </td>

                                                                        <%-- <td>
                                                                    <asp:Label runat="server" ID="lblp_address" Text='<%#Eval("p_address") %>' Visible="false"></asp:Label>
                                                                </td>--%>
                                                                        <td>
                                                                            <asp:Label runat="server" ID="lblpgm_name" Text='<%#Eval("pgm_name") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label runat="server" ID="lblpgm_mobile" Text='<%#Eval("pgm_mobile") %>'></asp:Label>
                                                                        </td>

                                                                        <td>
                                                                            <asp:Label runat="server" ID="lbls_name" Text='<%#Eval("s_name") %>' ForeColor="#000099"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label runat="server" ID="lblb_amount" Text='<%#Eval("b_amount") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label runat="server" ID="lblv_date" Text='<%#Eval("b_date") %>'></asp:Label>

                                                                        </td>
                                                                        <td>
                                                                            <asp:Label runat="server" ID="lbls_mobile" Text='<%#Eval("s_mobile") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label runat="server" ID="lblb_status" Font-Size="20px" Text='<%#Eval("b_status") %>' ForeColor="#006600"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="Button1" runat="server" Text="Cancel Visit" class="btn-danger" Visible="false" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="Button2" runat="server" Text="Reschedule Visit" class="btn-primary" Visible="false" />
                                                                        </td>

                                                                    </tr>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    </table>
                                                                </FooterTemplate>

                                                            </asp:Repeater>

                                                        </div>
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

