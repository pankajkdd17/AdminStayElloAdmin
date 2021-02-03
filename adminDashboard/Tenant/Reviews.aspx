<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="Reviews.aspx.cs" Inherits="Tenant_Reviews" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Reviews Record
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Reviews</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <!-- Main content -->
        <asp:UpdatePanel ID="updatepnl" runat="server">
             <Triggers>
                <asp:PostBackTrigger ControlID="btnExportExcel" />
            </Triggers>
            <ContentTemplate>
                <section class="content">
                    <!-- Main row -->
                    <div class="row">
                        <!-- Left col -->
                        <div class="col-md-12">
                            <!-- MAP & BOX PANE -->
                            <div class="box box-success">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Reviews</h3>

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
                                            <div class="col-md-12 col-sm-6 col-xs-12">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search tenants Review  By Room No or Mobile No or Name..." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchReview" class="btn btn-flat" runat="server" OnClick="lbtSearchReview_Click">
                                                    <i class="fa fa-search"></i></asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="padd">
                                            <div class="col-md-2 col-sm-2 col-xs-2">
                                                <div class="input-group">
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="btnExportExcel" class="btn btn-primary" runat="server" Text="EXPORT REVIEW" OnClick="btnExportExcel_Click">
                                                        </asp:LinkButton>
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
                                                                    <asp:GridView ID="gvReview" runat="server" class="table table-striped table-no-bordered table-hover" CellSpacing="0" Width="100%" Style="width: 100%" AutoGenerateColumns="false">
                                                                        <Columns>

                                                                            <%--//tfb_PropertyName,tfb_PropertyVale,tfb_Name,tfb_RoomNo,--%>
                                                                            <asp:TemplateField HeaderText="SR.NO.">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblp_name" Text='<%#Eval("tfb_id") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="PROPERTY NAME">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbltfb_PropertyName" Text='<%#Eval("tfb_PropertyName") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="TENANT NAME">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbltfb_Name" Text='<%#Eval("tfb_Name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="ROOM NO">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbltfb_RoomNo" Text='<%#Eval("tfb_RoomNo") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="FOOD">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbltfb_rdbfoodText" Text='<%#Eval("tfb_rdbfoodText") %>' Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="ATMOSPHERE">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbltfb_rdbATMOSPHEREText" Text='<%#Eval("tfb_rdbATMOSPHEREText") %>' Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="STAFF BEHAVIOUR">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbltfb_rdbSTAFFBEHAVIOURText" Text='<%#Eval("tfb_rdbSTAFFBEHAVIOURText") %>' Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="WIFI CONNECTIVITY">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbltfb_rdbWIFICONNECTIVITYText" Text='<%#Eval("tfb_rdbWIFICONNECTIVITYText") %>' Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="RECOMMEND">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbltfb_rdbRECOMMENDText" Text='<%#Eval("tfb_rdbRECOMMENDText") %>' Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="POINTS OF IMPROVEMENTS">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbltfb_POINTSOFIMPROVEMENTS" Text='<%#Eval("tfb_POINTSOFIMPROVEMENTS") %>' Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="WORDS OF APPRECIATION">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbltfb_WORDSOFAPPRECIATION" Text='<%#Eval("tfb_WORDSOFAPPRECIATION") %>' Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="DATE">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="Label5" Text='<%#Eval("tfb_crdate") %>' Style="white-space: nowrap"></asp:Label>
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

