<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="HomeSlider.aspx.cs" Inherits="content_HomeSlider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>My Slider
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Slider</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Add Slider Image</h3>
                    <!-- left column -->

                    <div class="row">
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-8">
                            <section class="content">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="Upload Image" CssClass="col-md-2 control-label"></asp:Label>
                                        <div class="col-md-3">
                                            <asp:FileUpload ID="image1" runat="server" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                runat="server" ErrorMessage="This field is required" ControlToValidate="image1" CssClass="text-danger"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-3 col-md-offset-2">
                                            <asp:Button ID="btnUpload" runat="server" Text="Uplaod Images" CssClass="btn btn-primary btn-group-lg" OnClick="btnUpload_Click" />
                                            <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>

                </div>
            </div>
        </section>
    </div>
</asp:Content>

