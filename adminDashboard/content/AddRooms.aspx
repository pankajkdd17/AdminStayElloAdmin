<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="AddRooms.aspx.cs" Inherits="content_AddRooms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        .checkbox label, .radio label {
            min-height: 20px;
            padding-left: 0px;
            margin-bottom: 0;
            font-weight: 400;
            cursor: pointer;
        }
    </style>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Rooms
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Rooms</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <!-- Main content -->
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section class="content">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Add Rooms</h3>
                            <!-- left column -->

                            <div class="row">
                                <div class="col-md-6">
                                    <section class="content">
                                        <!-- general form elements -->
                                        <div class="box box-primary">
                                            <div class="box-header with-border">
                                                <h4 class="box-title text-success" style="text-decoration: underline">Add Single Rooms</h4>
                                                <!-- /.box-header -->
                                                <!-- form start -->
                                                <div class="box-body">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Room No.</label>
                                                                <asp:TextBox ID="txtRoomNo" OnTextChanged="txtRoomNo_TextChanged" AutoPostBack="true" runat="server" TextMode="Number" onkeypress="if (this.value.length > 4) { return false; }" class="form-control" placeholder="Room No."></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqRoomNo" runat="server" ControlToValidate="txtRoomNo" ErrorMessage="Please Enter Room No."
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Floor No.</label>
                                                                <asp:DropDownList ID="ddlFloorNo" class="form-control" runat="server" OnSelectedIndexChanged="ddlFloorNo_SelectedIndexChanged" AutoPostBack="true">
                                                                </asp:DropDownList>

                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Beds</label>
                                                                <asp:DropDownList ID="ddlBeds" class="form-control" runat="server">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlBeds"
                                                                    InitialValue="0" ErrorMessage="Bed Type required" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Rent</label>
                                                                <asp:TextBox ID="txtRent" runat="server" class="form-control" onkeypress="if (this.value.length > 5) { return false; }" TextMode="Number" placeholder="Rent price"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqrent" runat="server" ControlToValidate="txtRent" ErrorMessage="Please enter Rent Price"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Security Deposit</label>
                                                                <asp:TextBox ID="txtSecurityDeposit" TextMode="Number" onkeypress="if (this.value.length > 5) { return false; }" runat="server" class="form-control" placeholder="Security Deposit"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqSecurityDeposit" runat="server" ControlToValidate="txtSecurityDeposit" ErrorMessage="Please enter Security Deposit"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Remark</label>
                                                                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" class="form-control" placeholder="Remark"></asp:TextBox>
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
                                                                        <asp:CheckBox ID="chbNonAC" class="form-control" runat="server" Text="Non-AC" />
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


                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <div class="checkbox">
                                                                    <label class="chb" style="white-space: nowrap">
                                                                        <asp:CheckBox ID="chbLargeRoom" class="form-control" runat="server" Text="Large Room" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
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
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <div class="checkbox">
                                                                    <label style="white-space: nowrap">
                                                                        <asp:CheckBox ID="chbWifi" class="form-control" runat="server" Text="WiFi" />
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- /.box-body -->

                                                <div class="box-footer">
                                                    <asp:Button ID="btnSingleRooms" runat="server" class="btn btn-success" Text="Save Single Room" OnClick="btnSingleRooms_Click" ValidationGroup="save" />

                                                    <asp:Button ID="btnUpdateRooms" runat="server" class="btn btn-success" Text="Save Change" OnClick="btnUpdateRooms_Click" ValidationGroup="save" />

                                                    <asp:Button ID="btnViewRooms" runat="server" class="btn btn-primary" Text="View Rooms" OnClick="btnViewRooms_Click" CausesValidation="false" />
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.box -->
                                    </section>
                                </div>
                                <div class="col-md-6">
                                    <section class="content">
                                        <!-- general form elements -->
                                        <div class="box box-primary">
                                            <div class="box-header with-border">
                                                <h4 class="box-title text-success" style="text-decoration: underline">Add Multiple Rooms</h4>
                                                <!-- /.box-header -->
                                                <!-- form start -->
                                                <div class="box-body">
                                                    <div class="row">
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>Floor 0</label>
                                                                <asp:TextBox ID="txt0Floor" runat="server" class="form-control" placeholder="Total Rooms"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>Floor 1st</label>
                                                                <asp:TextBox ID="txt1Floor" runat="server" class="form-control" placeholder="Total Rooms"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>Floor 2nd</label>
                                                                <asp:TextBox ID="txt2Floor" runat="server" class="form-control" placeholder="Total Rooms"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>Floor 3rd</label>
                                                                <asp:TextBox ID="txt3Floor" runat="server" class="form-control" placeholder="Total Rooms"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>Floor 4th</label>
                                                                <asp:TextBox ID="txt4Floor" runat="server" class="form-control" placeholder="Total Rooms"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>Floor 5th</label>
                                                                <asp:TextBox ID="txt5Floor" runat="server" class="form-control" placeholder="Total Rooms"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>Floor 6th</label>
                                                                <asp:TextBox ID="txt6Floor" runat="server" class="form-control" placeholder="Total Rooms"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>Floor 7th</label>
                                                                <asp:TextBox ID="txt7Floor" runat="server" class="form-control" placeholder="Total Rooms"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>Floor 8th</label>
                                                                <asp:TextBox ID="txt8Floor" runat="server" class="form-control" placeholder="Total Rooms"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>Floor 9th</label>
                                                                <asp:TextBox ID="txt9Floor" runat="server" class="form-control" placeholder="Total Rooms"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>Floor 10th</label>
                                                                <asp:TextBox ID="txt10Floor" runat="server" class="form-control" placeholder="Total Rooms"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->

                                                    <div class="box-footer">
                                                        <asp:Button ID="btnSaveMultipleRooms" runat="server" class="btn btn-primary" Text="Save Multiple Rooms" OnClick="btnSaveMultipleRooms_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- /.box -->
                                        </div>
                                    </section>
                                </div>

                            </div>

                        </div>
                    </div>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

