<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="FoodMenu.aspx.cs" Inherits="content_FoodMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- Content Wrapper. Contains page content -->
    <style>
        .edt {
            font-size: 17px;
            color: #5d68e1;
        }

        .dlt {
            font-size: 17px;
            color: red;
        }
    </style>


    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Food Menu
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Food Menu</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <!-- Main content -->
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section class="content">
                    <!-- /.row -->
                    <!-- Main row -->
                    <div class="row">
                        <!-- Left col -->
                        <div class="col-md-12">
                            <!-- MAP & BOX PANE -->
                            <div class="box box-success">
                                <div class="box-header with-border">
                                    <h3 class="box-title">My Food Menu</h3>

                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool">
                                        </button>
                                        <button type="button" class="btn btn-box-tool"></i></button>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body no-padding">
                                    <div class="row">
                                        <div class="padd">
                                            <div class="col-md-10 col-sm-4 col-xs-12">
                                                <div class="input-group">
                                                    <input type="text" name="q" class="form-control" placeholder="Search Food Menu..." />
                                                    <span class="input-group-btn">
                                                        <button type="submit" name="search" id="search-btn" class="btn btn-flat">
                                                            <i class="fa fa-search"></i>
                                                        </button>
                                                    </span>
                                                </div>
                                            </div>

                                            <div class="col-md-2 col-sm-2 col-xs-2">
                                                <div class="input-group">
                                                    <asp:LinkButton ID="btnAddNewFoodMenu" runat="server" class="btn btn-success btn-flat " OnClick="btnAddNewFoodMenu_Click"><i class="fa fa-plus">Add New Food Menu</i></asp:LinkButton>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="pad">
                                                        <div class="box box-danger zoomnow">
                                                            <!-- /.box-header -->
                                                            <asp:ListView ID="ListView2" runat="server" DataKeyNames="f_id" OnItemCommand="ListView1_ItemCommand">
                                                                <ItemTemplate>
                                                                    <div class="box-header with-border">
                                                                        <h3 class="box-title">
                                                                            <asp:Label runat="server" ID="lbls_name" Text='<%#Eval("f_WeekdaysText") %>' ForeColor="#000099"></asp:Label></h3>
                                                                        <div class="box-tools pull-right">
                                                                            <asp:LinkButton ID="LinkButton1" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Edit" runat="server"><i class="fa fa-pencil-square-o edt " ></i></asp:LinkButton>

                                                                            <asp:LinkButton ID="LinkButton2" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server"><i class="fa fa-trash  dlt"></i></asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                    <!-- MAP & BOX PANE -->
                                                                    <!-- /.box-header -->
                                                                    <div class="box-body no-padding">
                                                                        <!-- Map will be created here -->
                                                                        <div id="Div2" style="min-height: 222px;">
                                                                            <table>

                                                                                <tr>
                                                                                    <td style="font-size: 17px; color: red"><i class="fa fa-hamburger"></i>BreakFast</td>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_BreakfastTime" Text='<%#Eval("f_BreakfastTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                        To
                                                                                        <asp:Label runat="server" ID="Label3" Text='<%#Eval("f_BreakfastTimeto") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_Breakfast" Text='<%#Eval("f_Breakfast") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                    <td></td>

                                                                                </tr>

                                                                                <tr>
                                                                                    <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Lunch</td>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_LunchTime" Text='<%#Eval("f_LunchTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                        To 
                                                                                        <asp:Label runat="server" ID="Label2" Text='<%#Eval("f_LunchTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="Label1" Text='<%#Eval("f_Lunch") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>


                                                                                <tr>
                                                                                    <td style="font-size: 17px; color: red"><i class="fa fa-cookie-bite"></i>Refreshment</td>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_SnacksTime" Text='<%#Eval("f_SnacksTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                        To 
                                                                                        <asp:Label runat="server" ID="Label4" Text='<%#Eval("f_SnacksTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_Snacks" Text='<%#Eval("f_Snacks") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                    <td></td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Dinner</td>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_DinnarTime" Text='<%#Eval("f_DinnarTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                        To
                                                                                        <asp:Label runat="server" ID="Label5" Text='<%#Eval("f_DinnarTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_Dinnar" Text='<%#Eval("f_Dinner") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                    <td></td>

                                                                                </tr>


                                                                            </table>
                                                                        </div>
                                                                        <!-- /.row -->
                                                                    </div>
                                                                    <!-- /.box-body -->

                                                                </ItemTemplate>
                                                            </asp:ListView>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <!-- MAP & BOX PANE -->
                                                    <div class="pad">
                                                        <div class="box box-danger zoomnow">
                                                            <!-- /.box-header -->
                                                            <asp:ListView ID="ListView3" runat="server" DataKeyNames="f_id" OnItemCommand="ListView1_ItemCommand">
                                                                <ItemTemplate>
                                                                    <div class="box-header with-border">
                                                                        <h3 class="box-title">
                                                                            <asp:Label runat="server" ID="lbls_name" Text='<%#Eval("f_WeekdaysText") %>' ForeColor="#000099"></asp:Label></h3>
                                                                        <div class="box-tools pull-right">
                                                                            <asp:LinkButton ID="LinkButton1" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Edit" runat="server"><i class="fa fa-pencil-square-o edt " ></i></asp:LinkButton>

                                                                            <asp:LinkButton ID="LinkButton2" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server"><i class="fa fa-trash  dlt"></i></asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                    <!-- MAP & BOX PANE -->
                                                                    <!-- /.box-header -->
                                                                    <div class="box-body no-padding">
                                                                        <!-- Map will be created here -->
                                                                        <div id="Div2" style="min-height: 222px;">
                                                                            <table>

                                                                                <tr>
                                                                                    <td style="font-size: 17px; color: red"><i class="fa fa-hamburger"></i>BreakFast</td>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_BreakfastTime" Text='<%#Eval("f_BreakfastTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                        To
                                                                                        <asp:Label runat="server" ID="Label3" Text='<%#Eval("f_BreakfastTimeto") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_Breakfast" Text='<%#Eval("f_Breakfast") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                    <td></td>

                                                                                </tr>

                                                                                <tr>
                                                                                    <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Lunch</td>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_LunchTime" Text='<%#Eval("f_LunchTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                        To 
                                                                                        <asp:Label runat="server" ID="Label2" Text='<%#Eval("f_LunchTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="Label1" Text='<%#Eval("f_Lunch") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>


                                                                                <tr>
                                                                                    <td style="font-size: 17px; color: red"><i class="fa fa-cookie-bite"></i>Refreshment</td>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_SnacksTime" Text='<%#Eval("f_SnacksTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                        To 
                                                                                        <asp:Label runat="server" ID="Label4" Text='<%#Eval("f_SnacksTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_Snacks" Text='<%#Eval("f_Snacks") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                    <td></td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Dinner</td>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_DinnarTime" Text='<%#Eval("f_DinnarTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                        To
                                                                                        <asp:Label runat="server" ID="Label5" Text='<%#Eval("f_DinnarTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_Dinnar" Text='<%#Eval("f_Dinner") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                    <td></td>

                                                                                </tr>


                                                                            </table>
                                                                        </div>
                                                                        <!-- /.row -->
                                                                    </div>
                                                                    <!-- /.box-body -->


                                                                </ItemTemplate>
                                                            </asp:ListView>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <!-- MAP & BOX PANE -->
                                                    <div class="box box-danger zoomnow">
                                                        <!-- /.box-header -->
                                                        <asp:ListView ID="ListView4" runat="server" DataKeyNames="f_id" OnItemCommand="ListView1_ItemCommand">
                                                            <ItemTemplate>
                                                                <div class="box-header with-border">
                                                                    <h3 class="box-title">
                                                                        <asp:Label runat="server" ID="lbls_name" Text='<%#Eval("f_WeekdaysText") %>' ForeColor="#000099"></asp:Label></h3>
                                                                    <div class="box-tools pull-right">
                                                                        <asp:LinkButton ID="LinkButton1" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Edit" runat="server"><i class="fa fa-pencil-square-o edt " ></i></asp:LinkButton>

                                                                        <asp:LinkButton ID="LinkButton2" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server"><i class="fa fa-trash  dlt"></i></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <!-- MAP & BOX PANE -->
                                                                <!-- /.box-header -->
                                                                <div class="box-body no-padding">
                                                                    <!-- Map will be created here -->
                                                                    <div id="Div2" style="min-height: 222px;">
                                                                        <table>

                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-hamburger"></i>BreakFast</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_BreakfastTime" Text='<%#Eval("f_BreakfastTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To
                                                                                    <asp:Label runat="server" ID="Label3" Text='<%#Eval("f_BreakfastTimeto") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_Breakfast" Text='<%#Eval("f_Breakfast") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                <td></td>

                                                                            </tr>

                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Lunch</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_LunchTime" Text='<%#Eval("f_LunchTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To 
                                                                                    <asp:Label runat="server" ID="Label2" Text='<%#Eval("f_LunchTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="Label1" Text='<%#Eval("f_Lunch") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>


                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-cookie-bite"></i>Refreshment</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_SnacksTime" Text='<%#Eval("f_SnacksTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To 
                                                                                    <asp:Label runat="server" ID="Label4" Text='<%#Eval("f_SnacksTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_Snacks" Text='<%#Eval("f_Snacks") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                <td></td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Dinner</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_DinnarTime" Text='<%#Eval("f_DinnarTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To
                                                                                    <asp:Label runat="server" ID="Label5" Text='<%#Eval("f_DinnarTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_Dinnar" Text='<%#Eval("f_Dinner") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                <td></td>

                                                                            </tr>


                                                                        </table>
                                                                    </div>
                                                                    <!-- /.row -->
                                                                </div>
                                                                <!-- /.box-body -->


                                                            </ItemTemplate>
                                                        </asp:ListView>

                                                    </div>
                                                    <!-- /.col -->
                                                    <!-- /.col -->

                                                    <!-- /.box-body -->
                                                </div>
                                            </div>
                                            <div class="row">

                                                <div class="col-md-4">
                                                    <!-- MAP & BOX PANE -->
                                                    <div class="box box-danger zoomnow">
                                                        <!-- /.box-header -->
                                                        <asp:ListView ID="ListView5" runat="server" DataKeyNames="f_id" OnItemCommand="ListView1_ItemCommand">
                                                            <ItemTemplate>
                                                                <div class="box-header with-border">
                                                                    <h3 class="box-title">
                                                                        <asp:Label runat="server" ID="lbls_name" Text='<%#Eval("f_WeekdaysText") %>' ForeColor="#000099"></asp:Label></h3>
                                                                    <div class="box-tools pull-right">
                                                                        <asp:LinkButton ID="LinkButton1" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Edit" runat="server"><i class="fa fa-pencil-square-o edt " ></i></asp:LinkButton>

                                                                        <asp:LinkButton ID="LinkButton2" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server"><i class="fa fa-trash  dlt"></i></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <!-- MAP & BOX PANE -->
                                                                <!-- /.box-header -->
                                                                <div class="box-body no-padding">
                                                                    <!-- Map will be created here -->
                                                                    <div id="Div2" style="min-height: 222px;">
                                                                        <table>

                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-hamburger"></i>BreakFast</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_BreakfastTime" Text='<%#Eval("f_BreakfastTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To
                                                                                    <asp:Label runat="server" ID="Label3" Text='<%#Eval("f_BreakfastTimeto") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_Breakfast" Text='<%#Eval("f_Breakfast") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                <td></td>

                                                                            </tr>

                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Lunch</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_LunchTime" Text='<%#Eval("f_LunchTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To 
                                                                                    <asp:Label runat="server" ID="Label2" Text='<%#Eval("f_LunchTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="Label1" Text='<%#Eval("f_Lunch") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>


                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-cookie-bite"></i>Refreshment</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_SnacksTime" Text='<%#Eval("f_SnacksTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To 
                                                                                    <asp:Label runat="server" ID="Label4" Text='<%#Eval("f_SnacksTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_Snacks" Text='<%#Eval("f_Snacks") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                <td></td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Dinner</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_DinnarTime" Text='<%#Eval("f_DinnarTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To
                                                                                    <asp:Label runat="server" ID="Label5" Text='<%#Eval("f_DinnarTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_Dinnar" Text='<%#Eval("f_Dinner") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                <td></td>

                                                                            </tr>


                                                                        </table>
                                                                    </div>
                                                                    <!-- /.row -->
                                                                </div>
                                                                <!-- /.box-body -->


                                                            </ItemTemplate>
                                                        </asp:ListView>

                                                    </div>
                                                    <!-- /.col -->
                                                    <!-- /.col -->

                                                    <!-- /.box-body -->
                                                </div>
                                                <div class="col-md-4">
                                                    <!-- MAP & BOX PANE -->
                                                    <div class="box box-danger zoomnow">
                                                        <!-- /.box-header -->
                                                        <asp:ListView ID="ListView6" runat="server" DataKeyNames="f_id" OnItemCommand="ListView1_ItemCommand">
                                                            <ItemTemplate>
                                                                <div class="box-header with-border">
                                                                    <h3 class="box-title">
                                                                        <asp:Label runat="server" ID="lbls_name" Text='<%#Eval("f_WeekdaysText") %>' ForeColor="#000099"></asp:Label></h3>
                                                                    <div class="box-tools pull-right">
                                                                        <asp:LinkButton ID="LinkButton1" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Edit" runat="server"><i class="fa fa-pencil-square-o edt " ></i></asp:LinkButton>

                                                                        <asp:LinkButton ID="LinkButton2" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server"><i class="fa fa-trash  dlt"></i></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <!-- MAP & BOX PANE -->
                                                                <!-- /.box-header -->
                                                                <div class="box-body no-padding">
                                                                    <!-- Map will be created here -->
                                                                    <div id="Div2" style="min-height: 222px;">
                                                                        <table>

                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-hamburger"></i>BreakFast</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_BreakfastTime" Text='<%#Eval("f_BreakfastTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To
                                                                                    <asp:Label runat="server" ID="Label3" Text='<%#Eval("f_BreakfastTimeto") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_Breakfast" Text='<%#Eval("f_Breakfast") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                <td></td>

                                                                            </tr>

                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Lunch</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_LunchTime" Text='<%#Eval("f_LunchTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To 
                                                                                    <asp:Label runat="server" ID="Label2" Text='<%#Eval("f_LunchTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="Label1" Text='<%#Eval("f_Lunch") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>


                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-cookie-bite"></i>Refreshment</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_SnacksTime" Text='<%#Eval("f_SnacksTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To 
                                                                                    <asp:Label runat="server" ID="Label4" Text='<%#Eval("f_SnacksTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_Snacks" Text='<%#Eval("f_Snacks") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                <td></td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Dinner</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_DinnarTime" Text='<%#Eval("f_DinnarTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To
                                                                                    <asp:Label runat="server" ID="Label5" Text='<%#Eval("f_DinnarTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_Dinnar" Text='<%#Eval("f_Dinner") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                <td></td>

                                                                            </tr>


                                                                        </table>
                                                                    </div>
                                                                    <!-- /.row -->
                                                                </div>
                                                                <!-- /.box-body -->


                                                            </ItemTemplate>
                                                        </asp:ListView>

                                                    </div>
                                                    <!-- /.col -->
                                                    <!-- /.col -->

                                                    <!-- /.box-body -->
                                                </div>
                                                <div class="col-md-4">
                                                    <!-- MAP & BOX PANE -->
                                                    <div class="box box-danger zoomnow">
                                                        <!-- /.box-header -->
                                                        <asp:ListView ID="ListView7" runat="server" DataKeyNames="f_id" OnItemCommand="ListView1_ItemCommand">
                                                            <ItemTemplate>
                                                                <div class="box-header with-border">
                                                                    <h3 class="box-title">
                                                                        <asp:Label runat="server" ID="lbls_name" Text='<%#Eval("f_WeekdaysText") %>' ForeColor="#000099"></asp:Label></h3>
                                                                    <div class="box-tools pull-right">
                                                                        <asp:LinkButton ID="LinkButton1" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Edit" runat="server"><i class="fa fa-pencil-square-o edt " ></i></asp:LinkButton>

                                                                        <asp:LinkButton ID="LinkButton2" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server"><i class="fa fa-trash  dlt"></i></asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <!-- MAP & BOX PANE -->
                                                                <!-- /.box-header -->
                                                                <div class="box-body no-padding">
                                                                    <!-- Map will be created here -->
                                                                    <div id="Div2" style="min-height: 222px;">
                                                                        <table>

                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-hamburger"></i>BreakFast</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_BreakfastTime" Text='<%#Eval("f_BreakfastTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To
                                                                                    <asp:Label runat="server" ID="Label3" Text='<%#Eval("f_BreakfastTimeto") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_Breakfast" Text='<%#Eval("f_Breakfast") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                <td></td>

                                                                            </tr>

                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Lunch</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_LunchTime" Text='<%#Eval("f_LunchTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To 
                                                                                    <asp:Label runat="server" ID="Label2" Text='<%#Eval("f_LunchTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="Label1" Text='<%#Eval("f_Lunch") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>


                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-cookie-bite"></i>Refreshment</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_SnacksTime" Text='<%#Eval("f_SnacksTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To 
                                                                                    <asp:Label runat="server" ID="Label4" Text='<%#Eval("f_SnacksTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_Snacks" Text='<%#Eval("f_Snacks") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                <td></td>

                                                                            </tr>
                                                                            <tr>
                                                                                <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Dinner</td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_DinnarTime" Text='<%#Eval("f_DinnarTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    To
                                                                                    <asp:Label runat="server" ID="Label5" Text='<%#Eval("f_DinnarTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblf_Dinnar" Text='<%#Eval("f_Dinner") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                <td></td>

                                                                            </tr>


                                                                        </table>
                                                                    </div>
                                                                    <!-- /.row -->
                                                                </div>
                                                                <!-- /.box-body -->


                                                            </ItemTemplate>
                                                        </asp:ListView>

                                                    </div>
                                                    <!-- /.col -->
                                                    <!-- /.col -->

                                                    <!-- /.box-body -->
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="pad">
                                                        <div class="box box-danger zoomnow">
                                                            <!-- /.box-header -->
                                                            <asp:ListView ID="ListView1" runat="server" DataKeyNames="f_id" OnItemCommand="ListView1_ItemCommand">
                                                                <ItemTemplate>
                                                                    <div class="box-header with-border">
                                                                        <h3 class="box-title">
                                                                            <asp:Label runat="server" ID="lbls_name" Text='<%#Eval("f_WeekdaysText") %>' ForeColor="#000099"></asp:Label></h3>
                                                                        <div class="box-tools pull-right">
                                                                            <asp:LinkButton ID="LinkButton1" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Edit" runat="server"><i class="fa fa-pencil-square-o edt " ></i></asp:LinkButton>

                                                                            <asp:LinkButton ID="LinkButton2" class="btn btn-box-tool" CommandArgument='<%#Eval("f_id")%>' CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete ?');" runat="server"><i class="fa fa-trash  dlt"></i></asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                    <!-- MAP & BOX PANE -->
                                                                    <!-- /.box-header -->
                                                                    <div class="box-body no-padding">
                                                                        <!-- Map will be created here -->
                                                                        <div id="Div2" style="min-height: 222px;">
                                                                            <table>

                                                                                <tr>
                                                                                    <td style="font-size: 17px; color: red"><i class="fa fa-hamburger"></i>BreakFast</td>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_BreakfastTime" Text='<%#Eval("f_BreakfastTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                        To
                                                                                        <asp:Label runat="server" ID="Label3" Text='<%#Eval("f_BreakfastTimeto") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_Breakfast" Text='<%#Eval("f_Breakfast") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                    <td></td>

                                                                                </tr>

                                                                                <tr>
                                                                                    <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Lunch</td>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_LunchTime" Text='<%#Eval("f_LunchTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                        To 
                                                                                        <asp:Label runat="server" ID="Label2" Text='<%#Eval("f_LunchTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="Label1" Text='<%#Eval("f_Lunch") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>


                                                                                <tr>
                                                                                    <td style="font-size: 17px; color: red"><i class="fa fa-cookie-bite"></i>Refreshment</td>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_SnacksTime" Text='<%#Eval("f_SnacksTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                        To 
                                                                                        <asp:Label runat="server" ID="Label4" Text='<%#Eval("f_SnacksTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_Snacks" Text='<%#Eval("f_Snacks") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                    <td></td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-size: 17px; color: red"><i class="fa fa-cutlery"></i>Dinner</td>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_DinnarTime" Text='<%#Eval("f_DinnarTime") %>' ForeColor="#0000ff"></asp:Label>
                                                                                        To
                                                                                        <asp:Label runat="server" ID="Label5" Text='<%#Eval("f_DinnarTimeTo") %>' ForeColor="#0000ff"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblf_Dinnar" Text='<%#Eval("f_Dinner") %>' ForeColor="#00adef"></asp:Label></td>
                                                                                    <td></td>

                                                                                </tr>


                                                                            </table>
                                                                        </div>
                                                                        <!-- /.row -->
                                                                    </div>
                                                                    <!-- /.box-body -->


                                                                </ItemTemplate>
                                                            </asp:ListView>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <!-- /.content -->
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- /.content-wrapper -->
</asp:Content>

