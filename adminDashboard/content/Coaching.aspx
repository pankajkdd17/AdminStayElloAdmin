<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="Coaching.aspx.cs" Inherits="content_Coaching" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Coaching
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Coaching</a></li>
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
                                    <h3 class="box-title">Coaching</h3>
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
                                    <h3 class="box-title">Coaching</h3>

                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body no-padding">
                                    <div class="pad">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-4 col-xs-12">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search Coaching By Mobile No or Name..." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchCoaching" class="btn btn-flat" runat="server" OnClick="lbtSearchCoaching_Click">
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
                                                                    <!-- MAP & BOX PANE -->
                                                                    <div class="box box-success  zoomnowbox">
                                                                        <div class="box-header with-border">
                                                                            <h3 class="box-title">S.No.<asp:Label runat="server" ID="lblp_name" Text='<%#Eval("c_id") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label></h3>

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
                                                                                    <div class="pad">
                                                                                        <!-- Map will be created here -->
                                                                                        <div id="Div2" style="min-height: 190px;">
                                                                                            <table style="text-align: left">

                                                                                                <tr style="white-space: nowrap">
                                                                                                    <td>Coaching Name:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-user" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblBeds" Text='<%#Eval("c_CoachingName") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>Persion Name:</td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-user" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblrent" Text='<%#Eval("c_FullName") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Mobile:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-phone" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblr_c_Mobile" Text='<%#Eval("c_Mobile") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Email:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-envelope" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label1" Text='<%#Eval("c_email") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Designation:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-user" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label2" Text='<%#Eval("c_Designation") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Submited Date:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-calendar" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label3" Text='<%#Eval("c_crdate") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

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

