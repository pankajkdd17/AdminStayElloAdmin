<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="UserData.aspx.cs" Inherits="content_UserData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Users Details
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Users Details</a></li>
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
                                    <h3 class="box-title">Users Details</h3>

                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body no-padding">
                                    <div class="pad">
                                        <div class="row">
                                            <div class="col-md-12 col-sm-4 col-xs-12">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search LeaseProperty By Mobile No or Name. Or Email.." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchUsers" class="btn btn-flat" runat="server" OnClick="lbtSearchUsers_Click">
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
                                                                    <div class="pad">
                                                                        <!-- MAP & BOX PANE -->
                                                                        <div class="box box-success  zoomnow">
                                                                            <div class="box-header with-border">
                                                                                <h3 class="box-title">User: 
                                                            <asp:Label runat="server" ID="lbls_name" Text='<%#Eval("s_fullname") %>' ForeColor="#000099"></asp:Label></h3>

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

                                                                                        <!-- Map will be created here -->
                                                                                        <div id="Div2">
                                                                                            <table style="white-space: nowrap">
                                                                                                <tr runat="server" id="rowID">
                                                                                                    <td>Email :</td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="Label1" Text='<%#Eval("s_email") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>Mobile :  </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lblp_address" Text='<%#Eval("s_mobile") %>' ForeColor="#00adef"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>Gender : </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lblpgm_mobile" Text='<%#Eval("s_gender") %>' ForeColor="#00adef"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>Password </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lblpgm_name" Text='<%#Eval("s_password") %>' ForeColor="#00adef"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td>Terms And Condition:   </td>
                                                                                                    <td>
                                                                                                        <asp:Label runat="server" ID="lblb_amount" Text='<%#Eval("s_check") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <tr>
                                                                                                        <td>SignUp Date:   </td>
                                                                                                        <td>
                                                                                                            <asp:Label runat="server" ID="lblv_date" Text='<%#Eval("s_cr_date") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                                    </tr>

                                                                                                    <tr>
                                                                                                        <td>User Type : </td>
                                                                                                        <td>
                                                                                                            <asp:Label runat="server" ID="lbls_mobile" Text='<%#Eval("s_usertype") %>' ForeColor="#00adef"></asp:Label>
                                                                                                        </td>

                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>Is Active : </td>
                                                                                                        <td>
                                                                                                            <asp:Label runat="server" ID="lblb_status" Font-Size="16px" Text='<%#Eval("s_isActive") %>' ForeColor="#00adef"></asp:Label>
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

