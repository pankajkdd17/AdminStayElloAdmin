<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="AddFoodMenu.aspx.cs" Inherits="content_AddFoodMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Add Food Menu</h3>
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
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label>Weekdays</label>
                                                                <asp:DropDownList ID="ddlWeekdays" class="form-control" OnSelectedIndexChanged="ddlWeekdays_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                                    <asp:ListItem Text="Sunday" Value="Sunday"></asp:ListItem>
                                                                    <asp:ListItem Text="Monday" Value="Monday"></asp:ListItem>
                                                                    <asp:ListItem Text="Tuesday" Value="Tuesday"></asp:ListItem>
                                                                    <asp:ListItem Text="Wednesday" Value="Wednesday"></asp:ListItem>
                                                                    <asp:ListItem Text="Thursday" Value="Thursday"></asp:ListItem>
                                                                    <asp:ListItem Text="Friday" Value="Friday"></asp:ListItem>
                                                                    <asp:ListItem Text="Saturday" Value="Saturday"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="reqddlWeekdays" runat="server" ControlToValidate="ddlWeekdays" ErrorMessage="select enter Weekdays"
                                                                    ForeColor="Red" Display="Dynamic" InitialValue="0" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Breakfast</label>
                                                                <asp:TextBox ID="txtBreakfast" runat="server" class="form-control" placeholder="Breakfast"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqBreakfast" runat="server" ControlToValidate="ddlWeekdays" ErrorMessage="Please Enter Breakfast"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>From</label>
                                                                <asp:TextBox ID="txtBreakfastTime" runat="server" class="form-control" TextMode="Time" placeholder="Breakfast Time From "></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqBreakfastTime" runat="server" ControlToValidate="txtBreakfastTime" ErrorMessage="Please Enter Breakfast Time"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>To</label>
                                                                <asp:TextBox ID="txtBreakfastTimeTo" runat="server" class="form-control" TextMode="Time" placeholder="Breakfast Time To "></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBreakfastTimeTo" ErrorMessage="Please Enter Breakfast Time to"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Lunch</label>
                                                                <asp:TextBox ID="txtLunch" runat="server" class="form-control" placeholder="Lunch"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqLunch" runat="server" ControlToValidate="txtLunch" ErrorMessage="Please Enter Lunch"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>From</label>
                                                                <asp:TextBox ID="txtLunchTime" runat="server" class="form-control" TextMode="Time" placeholder="Lunch Time From"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqLunchTime" runat="server" ControlToValidate="txtLunchTime" ErrorMessage="Please Enter Lunch Time From"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>To</label>
                                                                <asp:TextBox ID="txtLunchTimeTo" runat="server" class="form-control" TextMode="Time" placeholder="Lunch Time To"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLunchTime" ErrorMessage="Please Enter Lunch Time To"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Tea</label>
                                                                <asp:TextBox ID="txtSnacks" runat="server" class="form-control" placeholder="Snacks"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqSnacks" runat="server" ControlToValidate="txtSnacks" ErrorMessage="Please Enter Snacks"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>From</label>
                                                                <asp:TextBox ID="txtSnacksTime" runat="server" class="form-control" TextMode="Time" placeholder="Snacks Time From"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqSnacksTime" runat="server" ControlToValidate="txtSnacksTime" ErrorMessage="Please Enter Snacks Time From"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>To</label>
                                                                <asp:TextBox ID="txttxtSnacksTimeTo" runat="server" class="form-control" TextMode="Time" placeholder="Snacks Time"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttxtSnacksTimeTo" ErrorMessage="Please Enter Snacks Time"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Dinner</label>
                                                                <asp:TextBox ID="txtDinner" runat="server" class="form-control" placeholder="Dinner"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ReqDinnar" runat="server" ControlToValidate="txtDinner" ErrorMessage="Please Enter Dinner"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>From</label>
                                                                <asp:TextBox ID="txtDinnarTime" runat="server" class="form-control" placeholder="Dinner Time To" TextMode="Time"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqDinnarTime" runat="server" ControlToValidate="txtDinnarTime" ErrorMessage="Please Enter Dinner Time To"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label>To</label>
                                                                <asp:TextBox ID="txtDinnerTimeTo" runat="server" class="form-control" placeholder="Dinner Time To" TextMode="Time"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDinnarTime" ErrorMessage="Please Enter Dinner Time To"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.box-body -->

                                                    <div class="box-footer">
                                                        <asp:Button ID="btnFoodMenu" runat="server" class="btn btn-success" Text="Save" OnClick="btnFoodMenu_Click" />
                                                        <asp:Button ID="btnSaveChengeFoodMenu" runat="server" class="btn btn-success" Text="Save Change" OnClick="btnSaveChengeFoodMenu_Click" />

                                                        <asp:Button ID="btnViewFoodMenu" runat="server" class="btn btn-primary" Text="View Food Menu" OnClick="btnViewFoodMenu_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.box -->
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

