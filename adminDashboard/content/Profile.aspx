<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="content_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Add Property</h3>
                            <!-- left column -->

                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-10">

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
                                                                <asp:TextBox ID="txtPropertyName" runat="server" MaxLength="200" class="form-control" placeholder="Property Name"></asp:TextBox>

                                                                <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtPropertyName" ErrorMessage="Please enter Property Name"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Address</label>
                                                                <asp:TextBox ID="txtPropertyAddress" runat="server" class="form-control" MaxLength="300" placeholder="Property Address"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqAddress" runat="server" ControlToValidate="txtPropertyAddress" ErrorMessage="Please enter Property Address"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>City</label>
                                                                <asp:TextBox ID="txtCity" runat="server" class="form-control" MaxLength="50" placeholder="City"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqCity" runat="server" ControlToValidate="txtCity" ErrorMessage="Please enter City"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Pin Code</label>
                                                                <asp:TextBox ID="txtpinCode" runat="server" class="form-control" TextMode="Number" onkeypress="if (this.value.length > 5) { return false; }" placeholder="Pin Code"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqPinCode" runat="server" ControlToValidate="txtpinCode" ErrorMessage="Please enter Pin Code"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Map Link</label>
                                                                <asp:TextBox ID="txtMapLink" runat="server" class="form-control" placeholder="Map Link"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqMapLink" runat="server" ControlToValidate="txtMapLink" ErrorMessage="Please enter Map Link"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Manager Name</label>
                                                                <asp:TextBox ID="txtManagerName" runat="server" MaxLength="200" class="form-control" placeholder="Manager Name"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqMang" runat="server" ControlToValidate="txtManagerName" ErrorMessage="Please enter Manager Name"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Manager Phone</label>
                                                                <asp:TextBox ID="txtManagerPhone" runat="server" onkeypress="if (this.value.length > 9) { return false; }" TextMode="Number" class="form-control" placeholder="Manager Phone"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqMobile" runat="server" ControlToValidate="txtManagerPhone" ErrorMessage="Please enter Manager Phone"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Gender That Stay</label>
                                                                <asp:DropDownList ID="ddlGender" runat="server" class="form-control">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Start Price</label>
                                                                <asp:TextBox ID="txtStartPrice" onkeypress="if (this.value.length > 6) { return false; }" TextMode="Number" runat="server" OnTextChanged="txtStartPrice_TextChanged" AutoPostBack="true" class="form-control" placeholder="Start Price"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="reqStartPrice" runat="server" ControlToValidate="txtStartPrice" ErrorMessage="Please enter Start Price"
                                                                    ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Discount Price</label>
                                                                <asp:TextBox ID="txtDiscountPrice" runat="server" ReadOnly="true" class="form-control" placeholder="Start Price"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Discount Percentage</label>
                                                                <asp:TextBox ID="txtDiscountPercentage" OnTextChanged="txtDiscountPercentage_TextChanged" AutoPostBack="true" runat="server" TextMode="Number" onkeypress="if (this.value.length > 2) { return false; }" class="form-control" placeholder="Discount Percentage"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Image 1</label>
                                                                <asp:FileUpload ID="image1" runat="server" class="form-control" />
                                                                <asp:Image ID="Image4" runat="server" Height="125px" Width="120px" />
                                                                <asp:Label ID="lblimg1" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Image 2</label>
                                                                <asp:FileUpload ID="image2" runat="server" class="form-control" />
                                                                <asp:Image ID="Image5" runat="server" Height="125px" Width="120px" />
                                                                <asp:Label ID="lblimg2" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label>Image 3</label>
                                                                <asp:FileUpload ID="image3" runat="server" class="form-control" />
                                                                <asp:Image ID="Image6" runat="server" Height="125px" Width="120px" />
                                                                <asp:Label ID="lblimg3" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                                <!-- /.box-body -->

                                                <div class="box-footer">
                                                    <asp:Button ID="btnSaveChengeProperty" runat="server" class="btn btn-success" Text="Save Change" OnClick="btnSaveChenges_Click" ValidationGroup="save" CausesValidation="true" />
                                                    <asp:Button ID="btnViewProperty" runat="server" class="btn btn-primary" Text="View Property" OnClick="btnViewProperty_Click" CausesValidation="false" />
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.box -->
                                    </section>
                                </div>
                                <div class="col-md-1"></div>
                            </div>

                        </div>
                    </div>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- /.content -->

    <!-- /.content-wrapper -->

</asp:Content>

