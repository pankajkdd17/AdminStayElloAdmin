<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="kycDetails.aspx.cs" Inherits="content_kycDetails" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My KYC Details
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>KYC Details</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <!-- Main content -->
                <section class="content">
                    <!-- Main row -->
                    <div class="row">
                        <!-- Left col -->
                        <div class="col-md-12">
                            <!-- MAP & BOX PANE -->
                            <div class="box box-success">
                                <div class="box-header with-border">
                                    <h3 class="box-title">My KYC Details</h3>

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
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search kyc By Mobile No or Name..." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchKYC" class="btn btn-flat" runat="server" OnClick="lbtSearchKYC_Click">
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
                                                        <div class="row">
                                                            <div class="col-md-12 col-sm-12">
                                                                <!-- Map will be created here -->
                                                                <div id="Div2" style="min-height: 300px;" class="container-fluid table-responsive">
                                                                    <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand" DataKeyNames="k_id" runat="server" class="table table-bordered table-hover" AutoGenerateColumns="false">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="SR.NO">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbla_id" Text='<%#Eval("k_id") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Name">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbls_fullname" Text='<%#Eval("s_fullname") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Mobile">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbls_mobile" Text='<%#Eval("s_mobile") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Docs Name">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblk_docsName" Text='<%#Eval("k_docsName") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Name On Docs">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblk_NameOnDocs" Text='<%#Eval("k_NameOnDocs") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Docs ID No ">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbll_Gender" Text='<%#Eval("k_docsIdNo") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Docs Front View.">
                                                                                <ItemTemplate>

                                                                                    <asp:LinkButton ID="lnkDownloadFront" Text="Download Front" CommandArgument='<%# Eval("k_id") %>' runat="server" CommandName="DownloadFront"></asp:LinkButton>

                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Docs Back View">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkDownloadBack" Text="Download Back" CommandArgument='<%# Eval("k_id") %>' runat="server" CommandName="DownloadBack"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Uploded Date">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblk_cr_date" Text='<%#Eval("k_cr_date") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
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

