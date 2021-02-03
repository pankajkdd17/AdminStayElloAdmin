<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="BankDetails.aspx.cs" Inherits="content_BankDetails" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Bank Details
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Bank Details</a></li>
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
                                    <h3 class="box-title">My Bank Details</h3>

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
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search Bank Details By Mobile No or Name A/C no..." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchBank" class="btn btn-flat" runat="server" OnClick="lbtSearchBank_Click">
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
                                                                    <asp:GridView ID="GridView1" DataKeyNames="b_id" runat="server" class="table table-bordered table-hover" AutoGenerateColumns="false">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="SR.NO">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbla_id" Text='<%#Eval("b_id") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Name">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbll_Name" Text='<%#Eval("s_fullname") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Mobile No">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbls_mobile" Text='<%#Eval("s_mobile") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Bank Name">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbll_Gender" Text='<%#Eval("b_Name") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Account Holder Name">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblb_AccountHolderName" Text='<%#Eval("b_AccountHolderName") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Bank Account No">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lbll_AmountRecieved" Text='<%#Eval("b_AccountNo") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Bank IFSC Code">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblb_IfscCode" Text='<%#Eval("b_IfscCode") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Bank Branch">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblb_branch" Text='<%#Eval("b_branch") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Updated date">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" ID="lblb_branch" Text='<%#Eval("b_cr_date") %>' ForeColor="#333333" Font-Size="17px" Style="white-space: nowrap"></asp:Label>
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

