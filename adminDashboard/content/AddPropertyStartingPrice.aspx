<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="AddPropertyStartingPrice.aspx.cs" Inherits="content_AddPropertyStartingPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Property Strating Price
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Property Strating Price</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <!-- Main content -->
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <section class="content">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Add Property Strating Price</h3>
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
                                                                <label>Property Name</label>
                                                                <asp:DropDownList ID="ddlProperty" class="form-control" GroupName="rb" runat="server"></asp:DropDownList>
                                                                <%--  <asp:RequiredFieldValidator ID="reqRentAmount" runat="server" ControlToValidate="txtPropertName" ErrorMessage="Please enter Name"
                                                            ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>AC / NON-AC</label>
                                                                <asp:CheckBox ID="rdbtnAcNonAC" runat="server" class="form-control" Text="AC / NON-AC" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Type Of Room Sharing</label>
                                                                <asp:TextBox ID="txtRoomSharingType" runat="server" class="form-control" placeholder="Single .."></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqMobileNo" runat="server" ControlToValidate="txtRoomSharingType" ErrorMessage="Please Enter Room Type"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label>Price Start From:</label>
                                                                <asp:TextBox ID="txtStartingPrice" runat="server" min="0" TextMode="Number" onkeypress="if (this.value.length > 9) { return false; }" class="form-control" placeholder="Starting Price"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqPanNo" runat="server" ControlToValidate="txtStartingPrice" ErrorMessage="Please Starting Price"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <!-- /.box-body -->
                                                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                                    <div class="box-footer">

                                                        <asp:Button ID="btnSavePropertyStratingPrice" runat="server" class="btn btn-success" CausesValidation="true" Text="Save Property Strating Price" OnClick="btnSavePropertyStratingPrice_Click" />
                                                        <asp:Button ID="btnSaveChenge" runat="server" CausesValidation="true" class="btn btn-success" Text="Save Change" OnClick="btnSaveChenge_Click" />
                                                        <asp:Button ID="btnViewProperty" runat="server" class="btn btn-primary" CausesValidation="false" Text="View Property Strating Price" OnClick="btnViewProperty_Click" />
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

