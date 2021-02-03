<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="LaesProperty.aspx.cs" Inherits="content_LaesProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>LeasProperty
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>LeasProperty</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <!-- Main content -->
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section class="content">
                    <!-- Main row -->
                    <div class="row">
                        <!-- Left col -->
                        <div class="col-md-12">
                            <!-- MAP & BOX PANE -->
                            <div class="box box-success">
                                <div class="box-header with-border">
                                    <h3 class="box-title">LeasProperty</h3>

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
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search LeaseProperty By Mobile No or Name. Or City.." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchLeaseProperty" class="btn btn-flat" runat="server" OnClick="lbtSearchLeaseProperty_Click">
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
                                                                            <h3 class="box-title">S.No.<asp:Label runat="server" ID="lblp_name" Text='<%#Eval("l_id") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label></h3>

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
                                                                                                    <td>Full Name:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-user" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblBeds" Text='<%#Eval("l_FullName") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Mobile:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-phone" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblr_c_Mobile" Text='<%#Eval("l_Mobile") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>City:</td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-home" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="lblrent" Text='<%#Eval("l_City") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>No Of Bed Rooms:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-bed" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label1" Text='<%#Eval("l_NoBedRoom") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>No Of Washrooom:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-bath" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label2" Text='<%#Eval("l_NoOfWashrooom") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>Property Address:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-address-card" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label4" Text='<%#Eval("l_PropertyAddress") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Property Status:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-check-circle" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label5" Text='<%#Eval("l_Status") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Map:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-map-o" style="font-size: 17px"></i>
                                                                                                        <asp:HyperLink ID="HyperLink1" href='<%#Eval("l_Map") %>' ForeColor="#ff0000" Font-Size="17px" runat="server"><i class="fa fa-map-marker" style="font-size:17px" ></i></asp:HyperLink>


                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr style="white-space: nowrap;">
                                                                                                    <td>Applyed Date:
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <i class="fa fa-calendar" style="font-size: 17px"></i>
                                                                                                        <asp:Label runat="server" ID="Label7" Text='<%#Eval("l_crdate") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

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

