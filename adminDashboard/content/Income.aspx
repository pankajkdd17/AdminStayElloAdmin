<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="Income.aspx.cs" Inherits="content_Income" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
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
                    <div class="row">
                        <div class="col-md-12">
                            <div class="box">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Income</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="row">
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-yellow"><i class="fa fa-money"></i></span>
                                                <div class="info-box-content">
                                                    <span style="color: #ff6a00">Total Income</span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblTotalIncome" runat="server"></asp:Label></span>
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
                                                    <span style="color: #ff6a00">Total Dues</span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblTotalDues" runat="server"></asp:Label></span>
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
                                                        <span style="color: #ff6a00">Total Expence</span>
                                                        <span class="info-box-number" style="color: #ff6a00">
                                                            <asp:Label ID="lblTotalExpence" runat="server"></asp:Label></span>
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
                                    <h3 class="box-title">My Income</h3>

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
                                            <div class="col-md-12 col-sm-4 col-xs-12">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search Dues By Room No or Mobile No or Name..." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchIncome" class="btn btn-flat" runat="server" OnClick="lbtSearchIncome_Click">
                                                    <i class="fa fa-search"></i></asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-1 col-sm-1 col-xs-1">
                                        </div>
                                        <div class="col-md-4 col-sm-4 col-xs-4">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtMonthfilter" class="form-control" TextMode="Month" OnTextChanged="txtMonthfilter_TextChanged" AutoPostBack="true" placeholder="Get Income By Month" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-7 col-sm-7 col-xs-7">
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="pad">
                                            <div class="col-md-12">
                                                <!-- MAP & BOX PANE -->
                                                <div class="box box-danger ">
                                                    <!-- /.box-header -->
                                                    <div class="box-body no-padding  ">

                                                        <asp:ListView ID="ListView1" runat="server" DataKeyNames="d_id" OnItemCommand="ListView1_ItemCommand">
                                                            <ItemTemplate>

                                                                <div class="col-md-4">
                                                                    <div class="pad">
                                                                        <!-- MAP & BOX PANE -->
                                                                        <div class="box box-success  zoomnow">
                                                                            <div class="box-header with-border">
                                                                                <h3 class="box-title">
                                                                                    <asp:Label runat="server" ID="lbld_PayeeText" Text='<%#Eval("d_PayeeText") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label></h3>

                                                                                <div class="box-tools pull-right">
                                                                                    <asp:LinkButton ID="lbtnedit" class="btn btn-box-tool" CommandArgument='<%#Eval("d_id")%>' CommandName="Edit" runat="server"><i class="fa fa-pencil-square-o edt " ></i></asp:LinkButton>

                                                                                    <asp:LinkButton ID="lbtnDelete" class="btn btn-box-tool" CommandArgument='<%#Eval("d_id")%>' CommandName="Dlt" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server"><i class="fa fa-trash  dlt"></i></asp:LinkButton>
                                                                                </div>
                                                                            </div>
                                                                            <!-- /.box-header -->
                                                                            <div class="box-body no-padding">

                                                                                <div class="row">
                                                                                    <div class="col-md-4 col-sm-4">

                                                                                        <!-- Map will be created here -->
                                                                                        <div id="Div2" style="min-height: 222px;">
                                                                                            <table style="text-align: left">

                                                                                                <tr style="white-space: nowrap">
                                                                                                    <td>Room No:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-home" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblBeds" Text='<%#Eval("d_RoomNo") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>Mobile:</td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-mobile" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblrent" Text='<%#Eval("d_t_Mobile") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>Due Month:</td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-mobile" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label2" Text='<%#Eval("d_DuesMonth") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Dues Type :
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-list" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblr_SecurityDeposit" Text='<%#Eval("d_DuesTypeText") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td>Recived Amount:</td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-rupee" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label1" Text='<%#Eval("d_recivedAmount") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Remark :
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-list" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label4" Text='<%#Eval("d_Remark") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Recived date :
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-calendar" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label5" Text='<%#Eval("d_reciveddate") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>
                                                                                                        <asp:LinkButton ID="lbtnRecivedDue" class="btn btn-inprimaryfo" CommandArgument='<%#Eval("d_id")%>' CommandName="Receipt" runat="server"><i class="fa fa-rupee" > Receipt</i></asp:LinkButton>
                                                                                                    </td>

                                                                                                    <td>
                                                                                                        <asp:LinkButton ID="lbtnDeletee" class="btn btn-danger" CommandArgument='<%#Eval("d_id")%>' CommandName="Dlt" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server" Style="margin-left: 50%"><i class="fa fa-trash"> Delete</i></asp:LinkButton>


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

