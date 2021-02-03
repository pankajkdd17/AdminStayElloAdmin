<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="Complaints.aspx.cs" Inherits="content_Complaints" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Complaints
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Complaints</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <!-- Main content -->
                <section class="content">
                    <!-- /.row -->
                    <!-- Main row -->
                    <div class="row">
                        <!-- Left col -->
                        <div class="col-md-12">
                            <!-- MAP & BOX PANE -->
                            <div class="box box-success">
                                <div class="box-header with-border">
                                    <h3 class="box-title">My Complaints</h3>
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
                                        <div class="pad">
                                            <div class="col-md-10 col-sm-4 col-xs-12">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search Complaints By Room No or Mobile No or Name of tenants..." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchComplaints" class="btn btn-flat" runat="server" OnClick="lbtSearchComplaints_Click">
                                                    <i class="fa fa-search"></i></asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-md-2 col-sm-2 col-xs-2">
                                                <div class="input-group">
                                                    <asp:LinkButton ID="btnAddNewComplaints" runat="server" class="btn btn-success btn-flat " OnClick="btnAddNewComplaints_Click"><i class="fa fa-plus">Add New Complaints</i></asp:LinkButton>

                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <!-- Main row -->
                    <div class="row">
                        <!-- /.col -->

                        <div class="col-md-4">
                            <!-- MAP & BOX PANE -->
                            <div class="box box-danger ">
                                <div class="box-header with-border">
                                    <h3 class="box-title">New Complaints</h3>
                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body no-padding bg-red">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12">
                                            <div class="pad">
                                                <!-- Map will be created here -->
                                                <div id="Div2" style="min-height: 500px;">
                                                    <!-- MAP & BOX PANE -->
                                                    <!-- /.box-header -->
                                                    <div class="box-body no-padding">
                                                        <asp:ListView ID="ListView1" DataKeyNames="tc_id" runat="server" OnItemDataBound="ListView1_ItemDataBound">
                                                            <ItemTemplate>
                                                                <div class="row">
                                                                    <div class="pad">
                                                                        <div class="box box-success  zoomnow">
                                                                            <div class="box-header with-border">
                                                                                <h3 class="box-title"></h3>
                                                                                <div class="col-md-12 col-sm-12">
                                                                                    <!-- Map will be created here -->
                                                                                    <div id="Div2" style="min-height: 222px;">
                                                                                        <table style="text-align: left">
                                                                                            <tr style="white-space: nowrap">
                                                                                                <td>Name:
                                                                                                </td>
                                                                                                <td>
                                                                                                    <i class="fa fa-user" style="font-size: 17px"></i>
                                                                                                    <asp:Label runat="server" ID="Label5" Text='<%#Eval("tc_Name") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                    <asp:Label runat="server" ID="lbltc_id" Text='<%#Eval("tc_id") %>' Visible="false"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap">
                                                                                                <td>Room No:
                                                                                                </td>
                                                                                                <td>
                                                                                                    <i class="fa fa-home" style="font-size: 17px"></i>
                                                                                                    <asp:Label runat="server" ID="Label6" Text='<%#Eval("tc_RoomNo") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap">
                                                                                                <td>Mobile:
                                                                                                </td>
                                                                                                <td>
                                                                                                    <i class="fa fa-mobile" style="font-size: 17px"></i>
                                                                                                    <asp:Label runat="server" ID="lbltc_Mobile" Text='<%#Eval("tc_Mobile") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Complaints:</td>
                                                                                            </tr>
                                                                                            <tr>

                                                                                                <td>

                                                                                                    <i class="fa fa-arrow-right "></i>&nbsp<asp:Label runat="server" ID="lblrent" Text='<%#Eval("tc_MainIssueText") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap;">

                                                                                                <td>

                                                                                                    <i class="fa fa-arrow-right "></i>&nbsp 
                                                                                            <asp:Label runat="server" ID="lblr_SecurityDeposit" Text='<%#Eval("tc_issueText") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap;">

                                                                                                <td>

                                                                                                    <i class="fa fa-arrow-right "></i>&nbsp 
                                                                                            <asp:Label runat="server" ID="Label1" Text='<%#Eval("tc_subCatIssueText") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap;">
                                                                                                <td>Description :</td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap;">

                                                                                                <td>

                                                                                                    <asp:Label runat="server" ID="Label2" Text='<%#Eval("tc_message") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td>Status:</td>
                                                                                                <td>
                                                                                                    <asp:DropDownList ID="ddlcomplaints" runat="server" Style="margin-left: -40%; color: #f00" OnSelectedIndexChanged="ddlcomplaints_SelectedIndexChanged1" AutoPostBack="true">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>

                                                                                        </table>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /.col -->
                                                                    <!-- /.col -->
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:ListView>
                                                        <!-- /.row -->
                                                    </div>
                                                    <!-- /.box-body -->
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

                        <!-- /.col -->
                        <!-- Left col -->
                        <div class="col-md-4">
                            <!-- MAP & BOX PANE -->
                            <div class="box box-warning">
                                <div class="box-header with-border">
                                    <h3 class="box-title">On Going Complaints</h3>

                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body no-padding bg-yellow">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12">
                                            <div class="pad">
                                                <div id="Div3" style="min-height: 500px;">
                                                    <!-- MAP & BOX PANE -->
                                                    <!-- /.box-header -->
                                                    <div class="box-body no-padding">
                                                        <asp:ListView ID="ListView2" runat="server" DataKeyNames="tc_id" OnItemDataBound="ListView2_ItemDataBound">
                                                            <ItemTemplate>
                                                                <div class="row">
                                                                    <div class="pad">
                                                                        <div class="box box-success  zoomnow">
                                                                            <div class="box-header with-border">
                                                                                <h3 class="box-title"></h3>
                                                                                <div class="col-md-12 col-sm-12">
                                                                                    <!-- Map will be created here -->
                                                                                    <div id="Div2" style="min-height: 222px;">
                                                                                        <table style="text-align: left">
                                                                                            <tr style="white-space: nowrap">
                                                                                                <td>Name:
                                                                                                </td>
                                                                                                <td>
                                                                                                    <i class="fa fa-user" style="font-size: 17px"></i>
                                                                                                    <asp:Label runat="server" ID="Label5" Text='<%#Eval("tc_Name") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                    <asp:Label runat="server" ID="lbltc_id" Visible="false" Text='<%#Eval("tc_id") %>'></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap">
                                                                                                <td>Room No:
                                                                                                </td>
                                                                                                <td>
                                                                                                    <i class="fa fa-home" style="font-size: 17px"></i>
                                                                                                    <asp:Label runat="server" ID="Label6" Text='<%#Eval("tc_RoomNo") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap">
                                                                                                <td>Mobile:
                                                                                                </td>
                                                                                                <td>
                                                                                                    <i class="fa fa-mobile" style="font-size: 17px"></i>
                                                                                                    <asp:Label runat="server" ID="lbltc_Mobile" Text='<%#Eval("tc_Mobile") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Complaints:</td>
                                                                                            </tr>
                                                                                            <tr>

                                                                                                <td>

                                                                                                    <i class="fa fa-arrow-right "></i>&nbsp<asp:Label runat="server" ID="lblrent" Text='<%#Eval("tc_MainIssueText") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap;">

                                                                                                <td>

                                                                                                    <i class="fa fa-arrow-right "></i>&nbsp 
                                                                                            <asp:Label runat="server" ID="lblr_SecurityDeposit" Text='<%#Eval("tc_issueText") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap;">

                                                                                                <td>

                                                                                                    <i class="fa fa-arrow-right "></i>&nbsp 
                                                                                            <asp:Label runat="server" ID="Label1" Text='<%#Eval("tc_subCatIssueText") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap;">
                                                                                                <td>Description :</td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap;">

                                                                                                <td>

                                                                                                    <asp:Label runat="server" ID="Label2" Text='<%#Eval("tc_message") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                </td>
                                                                                            </tr>


                                                                                            <itemtemplate>
                                                                                    <tr>
                                                                                        <td>Status:</td>
                                                                                           <td><asp:DropDownList ID="ddlcomplaints" runat="server" OnSelectedIndexChanged="ddlcomplaints_SelectedIndexChanged"    AutoPostBack="true"  Style="margin-left: -27% ; color:#ff6a00">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
    </itemtemplate>

                                                                                        </table>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /.col -->
                                                                    <!-- /.col -->
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:ListView>
                                                        <!-- /.row -->
                                                    </div>
                                                    <!-- /.box-body -->
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
                        <!-- /.col -->

                        <div class="col-md-4">
                            <!-- MAP & BOX PANE -->
                            <div class="box box-success">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Resolved Complaints</h3>

                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body no-padding bg-green">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12">
                                            <div class="pad">
                                                <div id="Div1" style="min-height: 500px;">
                                                    <!-- MAP & BOX PANE -->
                                                    <!-- /.box-header -->
                                                    <div class="box-body no-padding">
                                                        <asp:ListView ID="ListView3" runat="server">
                                                            <ItemTemplate>
                                                                <div class="row">
                                                                    <div class="pad">
                                                                        <div class="box box-info  zoomnow">
                                                                            <div class="box-header with-border">
                                                                                <h3 class="box-title"></h3>
                                                                                <div class="col-md-12 col-sm-12">
                                                                                    <!-- Map will be created here -->
                                                                                    <div id="Div2" style="min-height: 222px;">
                                                                                        <table style="text-align: left">
                                                                                            <tr style="white-space: nowrap">
                                                                                                <td>Name:
                                                                                                </td>
                                                                                                <td>
                                                                                                    <i class="fa fa-user" style="font-size: 17px"></i>
                                                                                                    <asp:Label runat="server" ID="Label5" Text='<%#Eval("tc_Name") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap">
                                                                                                <td>Room No:
                                                                                                </td>
                                                                                                <td>
                                                                                                    <i class="fa fa-home" style="font-size: 17px"></i>
                                                                                                    <asp:Label runat="server" ID="Label6" Text='<%#Eval("tc_RoomNo") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap">
                                                                                                <td>Mobile:
                                                                                                </td>
                                                                                                <td>
                                                                                                    <i class="fa fa-mobile" style="font-size: 17px"></i>
                                                                                                    <asp:Label runat="server" ID="lbltc_Mobile" Text='<%#Eval("tc_Mobile") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>Complaints:</td>
                                                                                            </tr>
                                                                                            <tr>

                                                                                                <td>

                                                                                                    <i class="fa fa-arrow-right "></i>&nbsp<asp:Label runat="server" ID="lblrent" Text='<%#Eval("tc_MainIssueText") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap;">

                                                                                                <td>

                                                                                                    <i class="fa fa-arrow-right "></i>&nbsp 
                                                                                            <asp:Label runat="server" ID="lblr_SecurityDeposit" Text='<%#Eval("tc_issueText") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap;">

                                                                                                <td>

                                                                                                    <i class="fa fa-arrow-right "></i>&nbsp 
                                                                                            <asp:Label runat="server" ID="Label1" Text='<%#Eval("tc_subCatIssueText") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap;">
                                                                                                <td>Description :</td>
                                                                                            </tr>
                                                                                            <tr style="white-space: nowrap;">

                                                                                                <td>

                                                                                                    <asp:Label runat="server" ID="Label2" Text='<%#Eval("tc_message") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>

                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td>Status:
                                                                           <asp:Label runat="server" ID="lbltc_status" Text='<%#Eval("tc_status") %>' ForeColor="#009933" Font-Size="17px"></asp:Label>
                                                                                                </td>
                                                                                            </tr>

                                                                                        </table>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <!-- /.col -->
                                                                    <!-- /.col -->
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:ListView>
                                                        <!-- /.row -->
                                                    </div>
                                                    <!-- /.box-body -->
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
                        <!-- /.col -->

                    </div>
                    <!-- /.row -->


                </section>
                <!-- /.content -->
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- /.content-wrapper -->
</asp:Content>

