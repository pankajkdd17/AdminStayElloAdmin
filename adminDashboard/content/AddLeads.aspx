<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="AddLeads.aspx.cs" Inherits="content_AddLeads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Leads
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Leads</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <!-- Main content -->
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section class="content">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Add Leads</h3>
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
                                                                <label>Name</label>
                                                                <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter Name"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Mobile No</label>
                                                                <asp:TextBox ID="txtMobileNo" runat="server" TextMode="Number" onkeypress="if (this.value.length > 9) { return false; }" class="form-control" placeholder="Mobile No"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqMobileNo" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Please enter Mobile"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Parent Name.</label>
                                                                <asp:TextBox ID="txtParentName" runat="server" class="form-control" placeholder="Parent Name"></asp:TextBox>
                                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Please enter Mobile"   
ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator> --%>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Parent Mobile</label>
                                                                <asp:TextBox ID="txtParentMobile" runat="server" TextMode="Number" onkeypress="if (this.value.length > 9) { return false; }" class="form-control" placeholder="Parent Mobile"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="reqMobile" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Please enter Mobile"   
ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator> --%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Amount Recieved</label>
                                                                <asp:TextBox ID="txtAmountRecieved" onkeypress="if (this.value.length > 6) { return false; }" runat="server" TextMode="Number" class="form-control" placeholder="Amount Recieved"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqAmountRecieved" runat="server" ControlToValidate="txtAmountRecieved" ErrorMessage="Please enter Amount Recieved"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Gender</label>
                                                                <asp:DropDownList ID="ddlGender" runat="server" class="form-control">
                                                                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                                                    <asp:ListItem Text="Transgender" Value="Transgender"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Rent Amount</label>
                                                                <asp:TextBox ID="txtRentAmount" runat="server" onkeypress="if (this.value.length > 6) { return false; }" TextMode="Number" class="form-control" placeholder="Rent Amount"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqRentAmount" runat="server" ControlToValidate="txtRentAmount" ErrorMessage="Please enter Rent Amount"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Room type preferred</label>
                                                                <asp:DropDownList ID="ddlRoomtypepreferred" runat="server" class="form-control">
                                                                    <asp:ListItem Text="single" Value="single"></asp:ListItem>
                                                                    <asp:ListItem Text="double" Value="double"></asp:ListItem>
                                                                    <asp:ListItem Text="Triple" Value="Triple"></asp:ListItem>
                                                                    <asp:ListItem Text="Four Seater" Value="Four Seater"></asp:ListItem>
                                                                    <asp:ListItem Text="Five Seater" Value="Five Seater"></asp:ListItem>
                                                                    <asp:ListItem Text="Six Seater" Value="Six Seater"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label>Facilities Provided</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <div class="checkbox">
                                                                    <label class="chb">
                                                                        <asp:CheckBox ID="chbAC" class="form-control" runat="server" Text="AC" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <div class="checkbox">
                                                                    <label class="chb">
                                                                        <asp:CheckBox ID="chbVentilation" class="form-control" runat="server" Text="Ventilation" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <div class="checkbox">
                                                                    <label class="chb">
                                                                        <asp:CheckBox ID="chbWashroom" class="form-control" runat="server" Text="Washroom" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <div class="checkbox">
                                                                    <label class="chb" style="white-space: nowrap">
                                                                        <asp:CheckBox ID="chbLargeRoom" class="form-control" runat="server" Text="Large Room" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <div class="checkbox">
                                                                    <label class="chb">
                                                                        <asp:CheckBox ID="chbBalcony" class="form-control" runat="server" Text="Balcony" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <div class="checkbox">
                                                                    <label style="white-space: nowrap">
                                                                        <asp:CheckBox ID="chbCornerRoom" class="form-control" runat="server" Text="Corner Room" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">

                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Status</label>
                                                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control">
                                                                    <asp:ListItem Text="Personally met" Value="Personally met"></asp:ListItem>
                                                                    <asp:ListItem Text="Talked on call" Value="Talked on call"></asp:ListItem>
                                                                    <asp:ListItem Text="Visit done" Value="Visit done"></asp:ListItem>
                                                                    <asp:ListItem Text="Property shortlist" Value="Property shortlist"></asp:ListItem>
                                                                    <asp:ListItem Text="Visit schedule" Value="Visit schedule"></asp:ListItem>
                                                                    <asp:ListItem Text="Token collected" Value="Token collected"></asp:ListItem>
                                                                    <asp:ListItem Text="Security deposit taken" Value="Security deposit taken"></asp:ListItem>
                                                                    <asp:ListItem Text="Room alloted" Value="Room alloted"></asp:ListItem>
                                                                    <asp:ListItem Text="Required follow up" Value="Required follow up"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Comments</label>
                                                                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" class="form-control" placeholder="Comments"></asp:TextBox>


                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->

                                                    <div class="box-footer">
                                                        <asp:Button ID="btnLeads" runat="server" class="btn btn-success" Text="Save Leads" OnClick="btnLeads_Click" ValidationGroup="save" />

                                                        <asp:Button ID="btnSaveChenges" runat="server" class="btn btn-success" Text="Save Change" OnClick="btnSaveChenges_Click" ValidationGroup="save" />
                                                        <asp:Button ID="btnViewLeads" runat="server" class="btn btn-primary" Text="View Leads" OnClick="btnViewLeads_Click" />
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

