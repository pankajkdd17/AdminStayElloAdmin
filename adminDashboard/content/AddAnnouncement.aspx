<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="AddAnnouncement.aspx.cs" Inherits="content_AddAnnouncement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Add Announcement</h3>
                            <!-- left column -->

                            <div class="row">
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-8">
                                    <section class="content">
                                        <!-- general form elements -->
                                        <div class="box box-primary">
                                            <div class="box-header with-border">
                                                <!-- /.box-header -->
                                                <!-- form start -->
                                                <div class="box-body">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Announcement To (Optional)</label>
                                                                <asp:DropDownList ID="ddlAnnouncementTo" runat="server" OnSelectedIndexChanged="ddlAnnouncementTo_SelectedIndexChanged" AutoPostBack="true" class="form-control"></asp:DropDownList>


                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Announcement To Mobile</label>
                                                                <asp:TextBox ID="txtAnnouncementToMobile" ReadOnly="true" runat="server" class="form-control" placeholder="Mobile"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label>Announcement</label>
                                                                <asp:TextBox ID="txtAnnouncement" TextMode="MultiLine" runat="server" class="form-control" placeholder="Announcement No"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                    </div>


                                                    <!-- /.box-body -->

                                                    <div class="box-footer">
                                                        <asp:Button ID="btnAddAnnouncement" runat="server" class="btn btn-success" Text="Save Announcement" OnClick="btnAddAnnouncement_Click" />

                                                        <asp:Button ID="btnSaveChenges" runat="server" class="btn btn-success" Text="Save Change" OnClick="btnSaveChenges_Click" />
                                                        <asp:Button ID="btnViewAnnouncement" runat="server" class="btn btn-primary" Text="View Announcement" OnClick="btnViewAnnouncement_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- /.box -->
                                        </div>
                                    </section>
                                </div>
                                <div class="col-md-2">
                                </div>
                            </div>

                        </div>
                    </div>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

