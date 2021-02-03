<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="ComplaintsMaster.aspx.cs" Inherits="content_ComplaintsMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Complaints Master
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Complaints Master</a></li>
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
                                    <h3 class="box-title">Complaints Master</h3>

                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                            </div>
                        </div>
                    </div>
                    <!-- Main row -->
                    <div class="row">
                        <!-- /.col -->

                        <div class="col-md-4">
                            <!-- MAP & BOX PANE -->
                            <div class="box box-success">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Add Ticket Category</h3>

                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body no-padding">
                                    <div class="row">
                                        <div class="col-md-9 col-sm-8">
                                            <div class="pad">
                                                <!-- Map will be created here -->
                                                <div id="Div2" style="min-height: 500px;"  >
                                                    <div class="box-body" style="width: 143%">
                                                        <div class="form-group">
                                                            <label>Enter Ticket Category Name</label>
                                                            <asp:TextBox ID="txtTicketCategory" runat="server" class="form-control" placeholder="Enter Ticket Category"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtTicketCategory" ErrorMessage="Please Enter Ticket Category"
                                                                ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                        </div>


                                                        <!-- /.box-body -->

                                                        <div class="box-footer">
                                                            <asp:Button ID="btnTicketCategory" runat="server" class="btn btn-success" ValidationGroup="save" Text="Save" OnClick="btnTicketCategory_Click" />
                                                        </div>
                                                        <div class=" container-fluid table-responsive">
                                                            <asp:GridView ID="GridView1" runat="server" class="table table-bordered  table-hover" Width="100%" AutoGenerateColumns="false" DataKeyNames="tc_id" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                                                <Columns>
                                                                    <asp:BoundField DataField="tc_id" HeaderText="S.No." ReadOnly="true" />
                                                                    <asp:BoundField DataField="tc_name" HeaderText="Ticket Category" />
                                                                    <asp:CommandField ShowEditButton="true" />
                                                                    <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="deletebtn" runat="server" CommandName="Delete"
                                                                                Text="Delete" OnClientClick="return confirm('Are you sure?');" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.col -->
                                        <!-- /.col -->
                                    </div>

                                </div>
                            </div>
                        </div>

                        <!-- /.col -->
                        <!-- Left col -->
                        <div class="col-md-4">
                            <!-- MAP & BOX PANE -->
                            <div class="box box-success">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Add New Facing Issue</h3>

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
                                        <div class="col-md-9 col-sm-8">
                                            <div class="pad">
                                                <!-- Map will be created here -->
                                                <div id="world-map-markers" style="min-height: 500px;">
                                                    <div class="box-body" style="width: 143%">

                                                        <div class="form-group">
                                                            <label>Select Ticket Category</label>
                                                            <asp:DropDownList ID="ddlTicketCategory" runat="server" OnSelectedIndexChanged="ddlTicketCategory_SelectedIndexChanged" AutoPostBack="true" class="form-control">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTicketCategory" ErrorMessage="Please Select Ticket Category"
                                                                InitialValue="0" ForeColor="Red" Display="Dynamic" ValidationGroup="isssave"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>Select Ticket Category(On UpDate)</label>
                                                            <asp:DropDownList ID="ddlTicketCategoryUpdate" runat="server" OnSelectedIndexChanged="ddlTicketCategoryUpdate_SelectedIndexChanged"  AutoPostBack="true" class="form-control">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlTicketCategoryUpdate" ErrorMessage="Please Select Ticket Category"
                                                                InitialValue="0" ForeColor="Red" Display="Dynamic" ValidationGroup="isssaveUpdate"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>Facing Issue Name</label>
                                                            <asp:TextBox ID="txtFacingIssueName" runat="server" class="form-control" placeholder="Facing Issue Name"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="reqFacingIssue" runat="server" ControlToValidate="txtFacingIssueName" ErrorMessage="Please Enter Facing Issue Name"
                                                                ForeColor="Red" Display="Dynamic" ValidationGroup="isssave"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <!-- /.box-body -->

                                                        <div class="box-footer">
                                                            <asp:Button ID="btnbtnIssueCategory" runat="server" class="btn btn-success" ValidationGroup="isssave" Text="Save" OnClick="btnbtnIssueCategory_Click" />
                                                             <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" ValidationGroup="isssaveUpdate" Text="Update" OnClick="btnUpdate_Click" />
                                                        </div>
                                                      

                                                    </div>
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
                                    <h3 class="box-title">Facing Issue SubCategory Name</h3>

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
                                        <div class="col-md-9 col-sm-8">
                                            <div class="pad">
                                                <!-- Map will be created here -->
                                                <div id="Div1" style="min-height: 500px;">
                                                    <div class="box-body" style="width: 143%">
                                                        <div class="form-group">
                                                            <label>Select Ticket Category</label>
                                                            <asp:DropDownList ID="ddlTicketCategoryMainissue" runat="server" class="form-control" OnSelectedIndexChanged="ddlTicketCategoryMainissue_SelectedIndexChanged" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTicketCategoryMainissue" ErrorMessage="Please Select Ticket Category"
                                                                InitialValue="0" ForeColor="Red" Display="Dynamic" ValidationGroup="mainissuesave"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>Facing Issue Name</label>
                                                            <asp:DropDownList ID="ddlFacingIssue" runat="server" class="form-control" OnSelectedIndexChanged="ddlFacingIssue_SelectedIndexChanged" AutoPostBack="true" >
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlFacingIssue" ErrorMessage="Please Select Facing Issue Name"
                                                                InitialValue="0" ForeColor="Red" Display="Dynamic" ValidationGroup="mainissuesave"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="form-group">
                                                            <label>Facing Issue Name (Only OnUpdate)</label>
                                                            <asp:DropDownList ID="ddlFacingIssueUpdate" runat="server" class="form-control" OnSelectedIndexChanged="ddlFacingIssueUpdate_SelectedIndexChanged" AutoPostBack="true" >
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlFacingIssue" ErrorMessage="Please Select Facing Issue Name"
                                                                InitialValue="0" ForeColor="Red" Display="Dynamic" ValidationGroup="mainissuesave"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="form-group">
                                                            <label>Facing Issue SubCategory Name</label>
                                                            <asp:TextBox ID="txtFacingIssueSubCategoryName" runat="server" class="form-control" placeholder="Facing Facing Issue SubCategory Name"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFacingIssueSubCategoryName" ErrorMessage="Please Enter Facing Issue SubCategory Name"
                                                                ForeColor="Red" Display="Dynamic" ValidationGroup="mainissuesave"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <!-- /.box-body -->

                                                        <div class="box-footer">
                                                            <asp:Button ID="btnIssueSubCategory" runat="server" class="btn btn-success" ValidationGroup="mainissuesave" Text="Save" OnClick="btnIssueSubCategory_Click" />
                                                             <asp:Button ID="btnUpdateSubcatgory" runat="server" class="btn btn-primary" ValidationGroup="mainissuesave" Text="Update" OnClick="btnUpdateSubcatgory_Click" />
                                                        </div>
                                                    </div>
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

                </section>
                <!-- /.content -->
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- /.content-wrapper -->
</asp:Content>

