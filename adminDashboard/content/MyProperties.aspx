<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="MyProperties.aspx.cs" Inherits="content_MyProperties" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        .BorderBox {
            border: 1px solid;
            padding: 10px;
            box-shadow: 5px 2px 2px 10px #888888;
        }

            .BorderBox.hover {
                box-shadow: 5px 2px 2px 10px #888888;
            }
    </style>
    <!-- Content Wrapper. Contains page content -->
    <style>
       
    </style>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Properties
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Properties</a></li>
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
                                    <h3 class="box-title">Properties</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="row">
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <a href="MyProperties.aspx">
                                                <div class="info-box">
                                                    <span class="info-box-icon bg-yellow"><i class="fa fa-home"></i></span>
                                                    <div class="info-box-content">
                                                        <span style="color: #ff6a00">Total PG </span>
                                                        <span class="info-box-number" style="color: #ff6a00">
                                                            <asp:Label ID="lblproperty" runat="server">

                                                            </asp:Label></span>
                                                    </div>
                                                </div>
                                            </a>
                                            <!-- /.info-box-content -->
                                            <!-- /.info-box -->
                                        </div>
                                        <!-- /.col -->

                                        <!-- fix for small devices only -->
                                        <div class="clearfix visible-sm-block"></div>
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <a href="Rooms.aspx">
                                                <div class="info-box">
                                                    <span class="info-box-icon bg-maroon-active color-palette"><i class="fa fa-bed"></i></span>
                                                    <div class="info-box-content">
                                                        <span style="color: #ff6a00">Total Room</span>
                                                        <span class="info-box-number" style="color: #ff6a00">
                                                            <asp:Label ID="lblTotalRoom" runat="server"></asp:Label></span>
                                                    </div>
                                                    <!-- /.info-box-content -->
                                                </div>
                                            </a>
                                            <!-- /.info-box -->
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <a href="Tenants.aspx">
                                                <div class="info-box">
                                                    <span class="info-box-icon bg-orange-active color-palette"><i class="fa fa-user-plus"></i></span>

                                                    <div class="info-box-content">
                                                        <span style="color: #ff6a00">Total Tenants</span>
                                                        <span class="info-box-number" style="color: #ff6a00">
                                                            <asp:Label ID="lblTotalTenants" runat="server"></asp:Label></span>
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
                                    <h3 class="box-title">My Properties</h3>

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
                                            <div class="col-md-10 col-sm-4 col-xs-12">
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtSearch" class="form-control" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" placeholder="Search Property By Name No or id..." runat="server"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lbtSearchProperty" class="btn btn-flat" runat="server" OnClick="lbtSearchProperty_Click">
                                                    <i class="fa fa-search"></i></asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>

                                            <div class="col-md-2 col-sm-2 col-xs-2">
                                                <div class="input-group">
                                                    <asp:LinkButton ID="btnAddNewProperties" runat="server" class="btn btn-success btn-flat " OnClick="btnAddNewProperties_Click"><i class="fa fa-plus">Add New Properties</i></asp:LinkButton>

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

                                                        <asp:ListView ID="ListView1" runat="server" DataKeyNames="p_id" OnItemCommand="ListView1_ItemCommand">
                                                            <ItemTemplate>

                                                                <div class="col-md-3">
                                                                    <div class="pad">
                                                                        <!-- MAP & BOX PANE -->
                                                                        <div class="box box-success  zoomnow" style="width: 103%">
                                                                            <div class="box-header with-border">
                                                                                <h3 class="box-title">
                                                                                    <asp:Label runat="server" ID="lblp_name" Text='<%#Eval("p_id") %>' ForeColor="#ff0000" Font-Size="17px"></asp:Label></h3>

                                                                                <div class="box-tools pull-right">
                                                                                    <asp:LinkButton ID="lbtnedit" class="btn btn-box-tool" CommandArgument='<%#Eval("p_id")%>' CommandName="Edit" runat="server"><i class="fa fa-pencil-square-o edt " ></i></asp:LinkButton>

                                                                                    <asp:LinkButton ID="lbtnDelete" class="btn btn-box-tool" CommandArgument='<%#Eval("p_id")%>' CommandName="Dlt" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server"><i class="fa fa-trash  dlt"></i></asp:LinkButton>
                                                                                </div>
                                                                            </div>
                                                                            <!-- /.box-header -->
                                                                            <div class="box-body no-padding">

                                                                                <div class="row">
                                                                                    <div class="col-md-3 col-sm-3">

                                                                                        <!-- Map will be created here -->
                                                                                        <div id="Div2" style="min-height: 222px; margin-top: -42px">
                                                                                            <table>

                                                                                                <tr>
                                                                                                    <td style="width: 25%; height: 25%; padding-right: 0%; padding-left: 0%;">
                                                                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#"https://admin.stayello.com/"+Eval("p_image1Path")%>' Height="225" Width="225" />

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <b>
                                                                                                            <asp:Label runat="server" ID="Label1" Text='<%#Eval("p_name") %>' ForeColor="#00adef"></asp:Label>
                                                                                                            (<asp:Label runat="server" ID="lblgender" Text='<%#Eval("p_gender") %>' ForeColor="#000099"></asp:Label>)
                                                                                                        </b>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:HyperLink ID="HyperLink1" Text='<%#Eval("p_address") %>' runat="server" Width="200">Address</asp:HyperLink>
                                                                                                        <asp:HyperLink ID="HyperLink2" href='<%#Eval("p_maplink") %>' runat="server"><i class="fa fa-map-marker" style="color:red;  font-size:20px"></i></asp:HyperLink>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td><i class="fa fa-rupee" style="font-size: 20px"></i>:
                                                                <asp:Label runat="server" ID="lblpgm_name" Text='<%#Eval("p_discountprice") %>' ForeColor="#cc0000" Font-Size="25px"></asp:Label>

                                                                                                        <asp:Label runat="server" ID="lblb_status" Text='<%#Eval("p_StartPrice") %>' ForeColor="green" Style="text-decoration-line: line-through;"></asp:Label>


                                                                                                        <asp:Label runat="server" ID="lblb_amount" Text='<%#Eval("p_DicountPercent") %>' ForeColor="#00adef"></asp:Label>%

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Button ID="btnPeople" runat="server" Text="People" OnClick="btnPeople_Click" class="btn btn-primary" />&nbsp  &nbsp  &nbsp &nbsp  &nbsp  &nbsp &nbsp  &nbsp  &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp  
                                                                           
                                                                                <asp:Button ID="btnRoom" runat="server" Text="Room" OnClick="btnRoom_Click" class="btn btn-primary" /></td>
                                                                                                </tr>
                                                                                                <br />

                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Button ID="btnAccounts" runat="server" Text="Accounts" OnClick="btnAccounts_Click" class="btn btn-primary" />&nbsp  &nbsp  &nbsp &nbsp  &nbsp  &nbsp 
                                                                           
                                                                                <asp:Button ID="btnComplaints" runat="server" OnClick="btnComplaints_Click" Text="Complaints" class="btn btn-primary" /></td>
                                                                                                </tr>
                                                                                                <br />

                                                                                                <tr>
                                                                                                    <td>&nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp &nbsp  &nbsp  &nbsp
                                                                            <asp:Button ID="btnDashboard" runat="server" Text="Dashboard" OnClick="btnDashboard_Click" class="btn btn-primary" /></td>
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

                                    <%--   <div class="row">
                                <div class="padd">
                                    <div class="col-md-12">
                                        <!-- MAP & BOX PANE -->
                                        <div class="box box-danger ">
                                             <h3 class="box-title"> </h3>
                                                                    <div class="box-tools pull-right">
                                                                       </div>
                                            <!-- /.box-header -->
                                            <div class="box-body no-padding  ">

                                                <asp:ListView ID="ListView1" runat="server" DataKeyNames="p_id"   OnItemCommand="ListView1_ItemCommand" >
                                                    <ItemTemplate>

                                                        <div class="col-md-3  zoomnow">
                                                            <table>

                                                                <tr>
                                                                    <td style="width: 25%; height: 25%; padding-right: 1%; padding-left: 0%;">

                                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("p_image1Path")%>' Height="225" Width="225" />

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <b>
                                                                            <asp:Label runat="server" ID="lblp_name" Text='<%#Eval("p_name") %>' ForeColor="#00adef"></asp:Label>
                                                                            (<asp:Label runat="server" ID="lblgender" Text='<%#Eval("p_gender") %>' ForeColor="#000099"></asp:Label>)
                                                                        </b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:HyperLink ID="HyperLink1" Text='<%#Eval("p_address") %>' runat="server" Width="200">Address</asp:HyperLink>
                                                                        <asp:HyperLink ID="HyperLink2" href='<%#Eval("p_maplink") %>' runat="server"><i class="fa fa-map-marker" style="color:red;  font-size:20px"></i></asp:HyperLink>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td><i class="fa fa-rupee" style="font-size: 20px"></i>:
                                                                <asp:Label runat="server" ID="lblpgm_name" Text='<%#Eval("p_discountprice") %>' ForeColor="#cc0000" Font-Size="25px"></asp:Label>

                                                                        <asp:Label runat="server" ID="lblb_status" Text='<%#Eval("p_StartPrice") %>' ForeColor="green" Style="text-decoration-line: line-through;"></asp:Label>


                                                                        <asp:Label runat="server" ID="lblb_amount" Text='<%#Eval("p_DicountPercent") %>' ForeColor="#00adef"></asp:Label>%

                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnPeople" runat="server" Text="People" OnClick="btnPeople_Click" class="btn btn-primary" />&nbsp  &nbsp  &nbsp &nbsp  &nbsp  &nbsp &nbsp  &nbsp  &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp  
                                                                           
                                                                                <asp:Button ID="btnRoom" runat="server" Text="Room" OnClick="btnRoom_Click" class="btn btn-primary" /></td>
                                                                </tr>
                                                                <br />

                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnAccounts" runat="server" Text="Accounts" OnClick="btnAccounts_Click" class="btn btn-primary" />&nbsp  &nbsp  &nbsp &nbsp  &nbsp  &nbsp 
                                                                           
                                                                                <asp:Button ID="btnComplaints" runat="server" OnClick="btnComplaints_Click" Text="Complaints" class="btn btn-primary" /></td>
                                                                </tr>
                                                                <br />

                                                                <tr>
                                                                    <td>&nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp &nbsp  &nbsp  &nbsp
                                                                            <asp:Button ID="btnDashboard" runat="server" Text="Dashboard" OnClick="btnDashboard_Click" class="btn btn-primary" /></td>
                                                                </tr>
                                                            </table>
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
                            </div>--%>

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

