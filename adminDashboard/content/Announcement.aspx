<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="Announcement.aspx.cs" Inherits="content_Announcement" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Announcement
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Announcement</a></li>
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
                                    <h3 class="box-title">Announcement</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="row">
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-yellow"><i class="fa fa-money"></i></span>
                                                <div class="info-box-content">
                                                    <span style="color: #ff6a00">Total Announcement </span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblTotalAnnouncement" runat="server" Text="Label"></asp:Label>
                                                    </span>
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
                                                    <span style="color: #ff6a00">User Announcement </span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblUserAnnouncement" runat="server"></asp:Label></span>
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
                                                        <span style="color: #ff6a00">All user Announcement </span>
                                                        <span class="info-box-number" style="color: #ff6a00">
                                                            <asp:Label ID="lblAlluserAnnouncement" runat="server"></asp:Label></span>
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
                                    <h3 class="box-title">My Announcement</h3>

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
                                            <div class="col-md-9 col-sm-4 col-xs-12">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search Announcement By Mobile No or Name..." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchAnouncement" class="btn btn-flat" runat="server" OnClick="lbtSearchAnouncement_Click">
                                                    <i class="fa fa-search"></i></asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>

                                            <div class="col-md-2 col-sm-2 col-xs-2">
                                                <div class="input-group">
                                                    <asp:LinkButton ID="btnAddNewAnnouncement" runat="server" class="btn btn-success btn-flat " OnClick="btnAddNewAnnouncement_Click"><i class="fa fa-plus">Add New Announcement</i></asp:LinkButton>

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
                                                        <div class="row">
                                                            <div class="col-md-12 col-sm-12">
                                                                <!-- Map will be created here -->
                                                                <div id="Div2" style="min-height: 200px;" class="container-fluid table-responsive">
                                                                    <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand" DataKeyNames="a_id" runat="server" class="table table-bordered table-hover" AutoGenerateColumns="false">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="SR.NO">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbla_id" Text='<%#Eval("a_id") %>' ForeColor="#ff0000" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Mobile No">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbla_mobile" Text='<%#Eval("a_mobile") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Announcement To">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbla_Text" Text='<%#Eval("a_Text") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Announcement Details">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbla_Details" Text='<%#Eval("a_Details") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Date">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbla_crdate" Text='<%#Eval("a_crdate") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>


                                                                            <asp:TemplateField HeaderText="Edit">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbtnedit" class="btn btn-box-tool" CommandArgument='<%#Eval("a_id")%>' CommandName="Edit" runat="server"><i class="fa fa-pencil-square-o edt " ></i></asp:LinkButton>

                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Delete">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbtnDelete" class="btn btn-box-tool" CommandArgument='<%#Eval("a_id")%>' CommandName="Dlt" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server"><i class="fa fa-trash  dlt"></i></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>


                                                                </div>
                                                            </div>
                                                            <!-- /.col -->
                                                        </div>

                                                        <!-- /.row -->

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

