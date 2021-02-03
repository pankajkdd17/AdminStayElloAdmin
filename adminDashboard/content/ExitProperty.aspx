<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="ExitProperty.aspx.cs" Inherits="content_ExitProperty" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Exit Property
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Exit Property</a></li>
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
                                    <h3 class="box-title">My Exit Property</h3>

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
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search Staff By Mobile No or Name..." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchTenantsexit" class="btn btn-flat" runat="server" OnClick="lbtSearchTenantsexit_Click">
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
                                                                    <asp:GridView ID="GridView1" DataKeyNames="ep_id" runat="server" class="table table-bordered table-hover" AutoGenerateColumns="false">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Property Name">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblep_PropertyName" Text='<%#Eval("ep_PropertyName") %>' ForeColor="#00adef" Font-Size="17px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Room No">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblep_roomNo" Text='<%#Eval("ep_roomNo") %>' ForeColor="#00adef" Font-Size="17px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Name">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblep_tenantsname" Text='<%#Eval("ep_tenantsname") %>' ForeColor="#00adef" Font-Size="17px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Mobile">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbla_crdate" Text='<%#Eval("ep_tenantsmobile") %>' ForeColor="#00adef" Font-Size="17px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Application">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblep_text" Text='<%#Eval("Application") %> ' ForeColor="#00adef" Font-Size="17px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Reason">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbla_crdate" Text='<%#Eval("ep_reason") %>' ForeColor="#00adef" Font-Size="17px"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <%-- <asp:TemplateField HeaderText="Status">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="lbla_crdate" Text='<%#Eval("ep_status") %>' ForeColor="#00adef" Font-Size="17px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>

                                                                            <asp:TemplateField HeaderText="Applied Date">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbla_crdate" Text='<%#Eval("ep_crdate") %>' ForeColor="#00adef" Font-Size="17px"></asp:Label>
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

