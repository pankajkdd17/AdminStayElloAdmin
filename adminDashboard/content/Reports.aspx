<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="dashboard" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <!-- Page Loader -->
            <div class="page-loader-wrapper">
                <div class="loader">
                    <div class="preloader">
                        <div class="spinner-layer pl-red">
                            <div class="circle-clipper left">
                                <div class="circle"></div>
                            </div>
                            <div class="circle-clipper right">
                                <div class="circle"></div>
                            </div>
                        </div>
                    </div>
                    <p>Please wait...</p>
                </div>
            </div>
            <!-- #END# Page Loader -->
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>Reports
       
                <small></small>
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>Reports</a></li>
                        <li class="active">Dashboard</li>
                    </ol>
                </section>
                <!-- Main content -->
                <section class="content">
                    <!-- Main row -->
                    <div class="row">
                        <!-- Left col -->
                        <div class="col-md-12">
                            <!-- MAP & BOX PANE -->
                            <div class="box box-success">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Reports</h3>

                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnDuesReportExport" />
                                    </Triggers>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnIncomeReportExport" />
                                    </Triggers>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnRoomsReportExport" />
                                    </Triggers>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnTenantsReportExport" />
                                    </Triggers>

                                    <ContentTemplate>
                                        <section class="content-fluid">
                                            <div class="container-fluid">
                                                <!-- Widgets -->
                                                <!-- #END# Widgets -->
                                                <!-- CPU Usage -->
                                                <div class="row clearfix">
                                                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                        <div class="card">

                                                            <div class="body">

                                                                <div class="row clearfix">
                                                                    <div class="col-md-4">
                                                                        <div class="input-group">
                                                                            <span class="input-group-addon">
                                                                                <b>GET RECORD BY MONTH</b>
                                                                            </span>
                                                                        </div>
                                                                    </div>
                                                                     <div class="col-md-4">
                                                                        <div class="input-group">
                                                                            <div class="form-line">
                                                                                <asp:TextBox ID="txtMonthfilter" class="form-control" TextMode="Month" OnTextChanged="txtMonthfilter_TextChanged" AutoPostBack="true" placeholder="Get Income By Month" runat="server"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4" style="visibility:hidden">
                                                                        <div class="input-group">
                                                                            <div class="form-line">
                                                                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control" TextMode="Date" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                   
                                                                </div>

                                                                <br />
                                                                <div class="row clearfix">
                                                                    <div class="col-md-3">
                                                                        <div class="input-group">
                                                                            <div>
                                                                                <asp:Button ID="btnTenantsReport" runat="server" Text=" SEARCH TENANTS RECORD" class="btn btn-info m-t-15 waves-effect" OnClick="btnTenantsReport_Click" />
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <div class="input-group">
                                                                            <div>
                                                                                <asp:Button ID="btnDuesReport" runat="server" Text=" SEARCH DUE RECORD" class="btn btn-primary m-t-15 waves-effect" OnClick="btnDuesReport_Click" />
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <div class="input-group">
                                                                            <div>
                                                                                <asp:Button ID="btnIncomeReport" runat="server" Text="SEACRH INCOME RECORD " class="btn btn-success m-t-15 waves-effect" OnClick="btnIncomeReport_Click" />
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                    <div class="col-md-3">
                                                                        <div class="input-group">
                                                                            <div>
                                                                                <asp:Button ID="btnRoomsReport" runat="server" Text=" SEARCH ROOM RECORD" class="btn btn-warning m-t-15 waves-effect" OnClick="btnRoomsReport_Click" />

                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                </div>

                                                                <div class="container-fluid">
                                                                    <div class="row clearfix">
                                                                        <div class="col-md-8">
                                                                        </div>
                                                                        <div class="col-md-4">
                                                                            <div class="input-group">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <td>
                                                                                                <asp:Button ID="btnTenantsReportExport" runat="server" Text="EXPORT TENANTS" class="btn bg-black waves-effect waves-light" OnClick="btnTenantsReportExport_Click" CausesValidation="false" />
                                                                                            </td>
                                                                                            <td>&nbsp&nbsp&nbsp&nbsp</td>
                                                                                            <td>
                                                                                                <asp:Button ID="btnDuesReportExport" runat="server" Text="EXPORT DUES" class="btn bg-black waves-effect waves-light" OnClick="btnDuesReportExport_Click" CausesValidation="false" />
                                                                                            </td>
                                                                                            <td>&nbsp&nbsp&nbsp&nbsp</td>
                                                                                            <td>
                                                                                                <asp:Button ID="btnIncomeReportExport" runat="server" Text="EXPORT INCOME" class="btn bg-black waves-effect waves-light" OnClick="btnIncomeReportExport_Click" CausesValidation="false" />
                                                                                            </td>
                                                                                            <td>&nbsp&nbsp&nbsp&nbsp</td>
                                                                                            <td>
                                                                                                <asp:Button ID="btnRoomsReportExport" runat="server" Text="EXPORT ROOMS" class="btn bg-black waves-effect waves-light" OnClick="btnRoomsReportExport_Click" CausesValidation="false" />
                                                                                            </td>
                                                                                    </tr>

                                                                                </table>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <table>
                                                                        <tr>
                                                                            <asp:Label ID="lblmsg1" runat="server" ForeColor="#ff0000"></asp:Label>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div class="body container-fluid table-responsive">
                                                                    <div id="real_time_chart" class="dashboard-flot-chart">
                                                                        <%--Report Of Due--%>

                                                                        <asp:GridView ID="GridView1" CssClass="table" AutoGenerateColumns="false" runat="server">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="DUE ID">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_id" Text='<%# Bind("d_id") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="PROPERTY NAME">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_prpertyname" runat="server" Text='<%# Bind("d_prpertyname") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="TENANT NAME">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_PayeeText" runat="server" Text='<%# Bind("d_PayeeText") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="TENANT MOBILE">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_t_Mobile" runat="server" Text='<%# Bind("d_t_Mobile") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="ROOM NO">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_RoomNo" runat="server" Text='<%# Bind("d_RoomNo") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DUE TYPE">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_DuesTypeText" runat="server" Text='<%# Bind("d_DuesTypeText") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DUE AMOUNT">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_DuesAmount" runat="server" Text='<%# Bind("d_DuesAmount") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DUE STATUS">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_status" runat="server" Text='<%# Bind("d_status") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DUE REMARK">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_Remark" runat="server" Text='<%# Bind("d_Remark") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="DUE DATE">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_DuesDate" runat="server" Text='<%# Bind("d_DuesDate") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                            </Columns>
                                                                        </asp:GridView>

                                                                        <%--Report Of Income--%>

                                                                        <asp:GridView ID="GridView2" CssClass="table" AutoGenerateColumns="false" runat="server">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="DUE ID">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_id" Text='<%# Bind("d_id") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="PROPERTY NAME">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_prpertyname" runat="server" Text='<%# Bind("d_prpertyname") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="TENANT NAME">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_PayeeText" runat="server" Text='<%# Bind("d_PayeeText") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="TENANT MOBILE">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_t_Mobile" runat="server" Text='<%# Bind("d_t_Mobile") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="ROOM NO">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_RoomNo" runat="server" Text='<%# Bind("d_RoomNo") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DUE TYPE">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_DuesTypeText" runat="server" Text='<%# Bind("d_DuesTypeText") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DUE AMOUNT">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_DuesAmount" runat="server" Text='<%# Bind("d_DuesAmount") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DUE RECIVED AMOUNT">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_recivedAmount" runat="server" Text='<%# Bind("d_recivedAmount") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="due recived date">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_reciveddate" runat="server" Text='<%# Bind("d_reciveddate") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DUE STATUS">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_status" runat="server" Text='<%# Bind("d_status") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DUE REMARK">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_Remark" runat="server" Text='<%# Bind("d_Remark") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                 <asp:TemplateField HeaderText="DUE Month">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_DuesDate" runat="server" Text='<%# Bind("d_DuesMonth") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DUE DATE">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbld_DuesDate" runat="server" Text='<%# Bind("d_DuesDate") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                            </Columns>
                                                                        </asp:GridView>

                                                                        <%--Report Of Rooms--%>
                                                                        <div id="Export" runat="server">
                                                                            <b>
                                                                                <asp:Label ID="lblDate" runat="server"></asp:Label></b>
                                                                            <asp:GridView ID="GridView3" CssClass="table" AutoGenerateColumns="false" runat="server">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="PROPERTY NAME">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblr_PropertyName" Text='<%# Bind("r_PropertyName") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Room No">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblr_id" Text='<%# Bind("r_roomNo") %>' runat="server" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="FLOOR NO">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblr_FloorNoText" runat="server" Text='<%# Bind("r_FloorNoText") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="BED TYPE">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblr_BedsText" runat="server" Text='<%# Bind("r_BedsText") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="ROOM RENT PER BED">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblr_Rent" runat="server" Text='<%# Bind("r_Rent") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="SECURITY DEPOSIT">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblr_SecurityDeposit" runat="server" Text='<%# Bind("r_SecurityDeposit") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="REMARK">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblr_Remark" runat="server" Text='<%# Bind("r_Remark") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>

                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>

                                                                        <%--Report Of Tenants--%>
                                                                        <%--select t_id ,t_mobile , t_PropertyName , t_PropertyVale , t_Name , t_MobileNo , t_RoomNo , t_SecurityMoney ,t_BedsText , t_RentMoney ,convert(varchar , t_DateOfJoining , 103) as t_DateOfJoining, convert(varchar , t_RentDate , 103) as t_RentDate, t_Details , convert(varchar , t_crdate , 103)as t_crdate , t_mdfydate from Tenants--%>
                                                                        <asp:GridView ID="GridView4" CssClass="table" AutoGenerateColumns="false" runat="server">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="TENANTS ID">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblt_id" Text='<%# Bind("t_id") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="PROPERTY NAME">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblt_PropertyName" Text='<%# Bind("t_PropertyName") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="TENANT NAME">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblt_Name" runat="server" Text='<%# Bind("t_Name") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="TENANT MOBILE">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblt_mobile" runat="server" Text='<%# Bind("t_MobileNo") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="ROOM NO">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblt_RoomNo" runat="server" Text='<%# Bind("t_RoomNo") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="RENT MONEY">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblt_RentMoney" runat="server" Text='<%# Bind("t_RentMoney") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="SECURITY MONEY">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblt_SecurityMoney" runat="server" Text='<%# Bind("t_SecurityMoney") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="BED TYPE">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblt_BedsText" runat="server" Text='<%# Bind("t_BedsText") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DATE OF JOINING">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblt_DateOfJoining" runat="server" Text='<%# Bind("t_DateOfJoining") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="RENT DATE">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblt_RentDate" runat="server" Text='<%# Bind("t_RentDate") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="TENANTS ADDED DATE">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblt_crdate" runat="server" Text='<%# Bind("t_crdate") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="OTHER DETAILS">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblt_Details" runat="server" Text='<%# Bind("t_Details") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                            </Columns>
                                                                        </asp:GridView>

                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- #END# CPU Usage -->

                                                </div>
                                        </section>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <!-- /.col -->

                        <!-- /.col -->
                    </div>

                </section>
                <!-- /.content -->
            </div>
            <!-- /.content-wrapper -->

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

