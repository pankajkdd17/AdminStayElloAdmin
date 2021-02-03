<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="ScheduleVisits.aspx.cs" Inherits="content_ScheduleVisits" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>ScheduleVisits
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>ScheduleVisits</a></li>
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
                                    <h3 class="box-title">ScheduleVisits</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="row">
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-yellow"><i class="fa fa-home"></i></span>
                                                <div class="info-box-content">
                                                    <span style="color: #ff6a00">Total Schedule Visits </span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblTotalScheduleVisits" runat="server"></asp:Label></span>
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
                                                    <span style="color: #ff6a00">Total Bookings</span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblBookings" runat="server"></asp:Label></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                            <!-- /.info-box -->
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <a href="#">
                                                <div class="info-box">
                                                    <span class="info-box-icon bg-orange-active color-palette"><i class="fa fa-building-o"></i></span>

                                                    <div class="info-box-content">
                                                        <span style="color: #ff6a00">Total SignUp</span>
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
                                    <h3 class="box-title">ScheduleVisits</h3>

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
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search Schedule Visits By Name No or Mobile..." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchSchedule" class="btn btn-flat" runat="server" OnClick="lbtSearchSchedule_Click">
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
                                                    <div class="box-body no-padding  ">

                                                        <asp:ListView ID="ListView1" runat="server">
                                                            <ItemTemplate>

                                                                <div class="col-md-4">
                                                                    <div class="pad">
                                                                        <!-- MAP & BOX PANE -->
                                                                        <div class="box box-success  zoomnow">
                                                                            <div class="box-header with-border">
                                                                                <h3 class="box-title">Visitor Name: 
                                                            <asp:Label runat="server" ID="lbls_name" Text='<%#Eval("s_name") %>' ForeColor="#000099"></asp:Label></h3>

                                                                                <div class="box-tools pull-right">
                                                                                    <button type="button" class="btn btn-box-tool">
                                                                                        <i class="fa fa-minus"></i>
                                                                                    </button>
                                                                                    <button type="button" class="btn btn-box-tool"><i class="fa fa-times"></i></button>
                                                                                </div>
                                                                            </div>
                                                                            <!-- /.box-header -->
                                                                            <div class="box-body no-padding">

                                                                                <div class="row">
                                                                                    <div class="col-md-4 col-sm-4">

                                                                                        <!-- Map will be created here -->
                                                                                        <div id="Div2">
                                                                                            <table>

                                                                                                <tr>
                                                                                                    <td style="font-size: 17px; color: red">Where To Visit</td>
                                                                                                </tr>

                                                                                                <tr runat="server" id="rowID">
                                                                                                    <td style="white-space: nowrap">Property Name :</td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="Label1" Text='<%#Eval("p_name") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="white-space: nowrap">Property Address :  </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lblp_address" Text='<%#Eval("p_address") %>' ForeColor="#00adef"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="white-space: nowrap">P.G. Manager Mobile : </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lblpgm_mobile" Text='<%#Eval("pgm_mobile") %>' ForeColor="#00adef"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="white-space: nowrap">P.G. Manager Name </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lblpgm_name" Text='<%#Eval("pgm_name") %>' ForeColor="#00adef"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="font-size: 17px; color: red">Visiting Details</td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="white-space: nowrap">Visiting date:   </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lblv_date" Text='<%#Eval("v_date") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="white-space: nowrap">Visiting Time Slot :   </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lblv_timeslot" Text='<%#Eval("v_timeslot") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="white-space: nowrap">Your Mobile : </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lbls_mobile" Text='<%#Eval("s_mobile") %>' ForeColor="#00adef"></asp:Label>
                                                                                                    </td>

                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td></td>
                                                                                                    <td>
                                                                                                        <asp:Button ID="Button1" runat="server" Text="Cancel Visit" class="btn-danger" Visible="false" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Button ID="Button2" runat="server" Text="Reschedule Visit" class="btn-primary" Visible="false" />
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

