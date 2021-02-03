<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="Recipt.aspx.cs" Inherits="content_Recipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- Content Wrapper. Contains page content -->
    <script>
        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
    <asp:UpdatePanel ID="updatepnl" runat="server">
        <ContentTemplate>
            <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <section class="content-header">
                    <h1>Recipt
                <small></small>
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>Recipt</a></li>
                        <li class="active">Dashboard</li>
                    </ol>
                </section>
                <!-- Main content -->
                <section class="content">

                    <!-- Main row -->
                    <div class="row">
                        <!-- Left col -->
                        <div class="col-md-12">
                            <!-- MAP & BOX PANE -->
                            <div class="box box-success">
                                <div class="box-header with-border">
                                    <input type="button" onclick="printDiv('printableArea')" class="btn btn-primary" value="Print Recipt" />
                                    <div id="printableArea" class="table-responsive  container-fluid">
                                        <div id="page_1" class="table-responsive">
                                            <div id="id1_2_1">
                                                <p class="p0 ft2">
                                                    <span class="ft1">
                                                        <img src="Logo/LogoOfStayEllo.jpeg" class="img-responsive" width="100" height="100" style="float: left" />
                                                    </span>
                                                </p>
                                            </div>
                                            <div id="id1_1" class="table-responsive">
                                                <p class="p0 ft0" style="margin-left: 48px">
                                                    <asp:Label ID="lblpgNamee" runat="server"></asp:Label>
                                                </p>
                                                <p class="p1 ft1">
                                                    <asp:Label ID="lblpgAddress" runat="server"></asp:Label>
                                                </p>
                                                <p class="p2 ft2" style="margin-left: 47px;"><b>PAYMENT RECEIPT</b></p>
                                            </div>
                                            <div id="id1_2" class="table-responsive">
                                                <div id="id1_2_1">
                                                    <p class="p0 ft2" style="margin-left: 0px">
                                                        <span class="ft1"><b>Receipt No.</b></span>
                                                        <asp:Label ID="lblReciptNo" runat="server"></asp:Label>
                                                    </p>
                                                </div>

                                                <div id="id1_2_2">
                                                    <p class="p0 ft1">
                                                        Date:
                                                <asp:Label ID="lbldateTime" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                            <div id="id1_3" class="table-responsive">
                                                <p class="p3 TenantsDetials">Tenant Details</p>
                                                <table cellpadding="0" cellspacing="0" class="t0">
                                                    <tr>
                                                        <td class="tr0 td0">
                                                            <p class="p4 ft1">Name</p>
                                                        </td>
                                                        <td class="tr0 td1">
                                                            <p class="p5 ft1">Phone</p>
                                                        </td>
                                                        <td class="tr0 td2">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td colspan="2" class="tr0 td3">
                                                            <p class="p7 ft1">Room</p>
                                                        </td>
                                                        <td class="tr0 td4">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td colspan="2" class="tr0 td5">
                                                            <p class="p8 ft1">P.G. Name</p>
                                                        </td>
                                                        <td class="tr0 td6">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr1 td7">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td8">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td9">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td10">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td11">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td12">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td13">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td14">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td15">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr0 td16">
                                                            <p class="p9 ft2">
                                                                <asp:Label ID="lblTenantsName" runat="server"></asp:Label>
                                                            </p>
                                                        </td>
                                                        <td class="tr0 td17">
                                                            <p class="p10 ft2">
                                                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                                            </p>
                                                        </td>
                                                        <td class="tr0 td18">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td19">
                                                            <p class="p11 ft2">
                                                                <asp:Label ID="lblRoomNo" runat="server"></asp:Label>
                                                            </p>
                                                        </td>
                                                        <td class="tr0 td20">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td colspan="3" class="tr0 td21">
                                                            <p class="p12 ft2">
                                                                <asp:Label ID="lblPgName" runat="server"></asp:Label>
                                                            </p>
                                                        </td>
                                                        <td class="tr0 td22">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr1 td7">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td8">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td9">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td10">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td11">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td12">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td13">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td14">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td15">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr2 td23">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr2 td8">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr2 td24">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr2 td10">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr2 td25">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr2 td12">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr2 td13">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr2 td14">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr2 td15">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr0 td26">
                                                            <p class="p7 ft3">Sr. No.</p>
                                                        </td>
                                                        <td class="tr0 td27">
                                                            <p class="p13 ft3">Due Type</p>
                                                        </td>
                                                        <td class="tr0 td28">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td29">
                                                            <p class="p6 ft3">Month</p>
                                                        </td>
                                                        <td class="tr0 td30">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td31">
                                                            <p class="p14 ft3">Particulars</p>
                                                        </td>
                                                        <td class="tr0 td32">
                                                            <p class="p15 ft3">Amount</p>
                                                        </td>
                                                        <td class="tr0 td33">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td34">
                                                            <p class="p6 ft3">Received by</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr1 td35">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td36">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td colspan="2" class="tr1 td37">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td38">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td39">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td40">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td41">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td42">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr0 td43">
                                                            <p class="p16 ft6">
                                                                <asp:Label ID="lblSrNo" runat="server"></asp:Label>
                                                            </p>
                                                        </td>
                                                        <td class="tr0 td44">
                                                            <p class="p17 ft1">
                                                                <asp:Label ID="lblDueType" runat="server"></asp:Label>
                                                            </p>
                                                        </td>
                                                        <td colspan="2" class="tr0 td45">
                                                            <p class="p18 ft1">
                                                                <asp:Label ID="lblDueMonth" runat="server"></asp:Label>
                                                            </p>
                                                        </td>
                                                        <td class="tr0 td20">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td46">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td47">
                                                            <p class="p19 ft1">
                                                                <span class="ft2">₹ </span>
                                                                <asp:Label ID="lblDueAmount" runat="server"></asp:Label>
                                                            </p>
                                                        </td>
                                                        <td class="tr0 td48">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td49">
                                                            <p class="p20 ft1">
                                                                <asp:Label ID="lblDueAmountRecivedBy" runat="server"></asp:Label>
                                                            </p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr1 td50">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td51">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td24">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td10">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td11">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td52">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td53">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td14">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td54">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr3 td55">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr3 td56">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr3 td57">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr3 td58">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr3 td59">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr3 td60">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr3 td61">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr3 td62">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr3 td63">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr0 td64">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td17">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td65">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td19">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td66">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td46">
                                                            <p class="p11 ft1">Sub total</p>
                                                        </td>
                                                        <td class="tr0 td47">
                                                            <p class="p21 ft2">
                                                                <asp:Label ID="lblDueAmountSubTotal" runat="server"></asp:Label>
                                                            </p>
                                                        </td>
                                                        <td class="tr0 td48">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td49">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr1 td67">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td8">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td24">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td10">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td colspan="2" class="tr1 td68">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td53">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td14">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td54">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr0 td69">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td70">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td71">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td72">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td colspan="2" class="tr0 td73">
                                                            <p class="p11 ft1">StayEllo processing charges</p>
                                                        </td>
                                                        <td class="tr0 td74">
                                                            <p class="p19 ft2">₹ <span class="ft1">0</span></p>
                                                        </td>
                                                        <td class="tr0 td75">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td76">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr1 td55">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td56">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td57">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td58">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td colspan="2" class="tr1 td77">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td78">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td62">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td63">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr0 td64">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td17">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td65">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td19">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td colspan="2" class="tr0 td79">
                                                            <p class="p11 ft1">Payment processing charges</p>
                                                        </td>
                                                        <td class="tr0 td47">
                                                            <p class="p19 ft2">₹ <span class="ft1">0</span></p>
                                                        </td>
                                                        <td class="tr0 td48">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td49">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr1 td67">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td8">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td24">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td10">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td25">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td52">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td53">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td14">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td54">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr0 td69">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td70">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td71">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td72">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td80">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td81">
                                                            <p class="p11 ft1">StayEllo credits applied</p>
                                                        </td>
                                                        <td class="tr0 td74">
                                                            <p class="p19 ft2">₹ <span class="ft1">0</span></p>
                                                        </td>
                                                        <td class="tr0 td75">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td76">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr1 td55">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td56">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td57">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td58">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td colspan="2" class="tr1 td77">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td78">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td62">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td63">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr0 td64">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td17">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td65">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td19">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td colspan="2" class="tr0 td79">
                                                            <p class="p11 ft1">Owner discount applied</p>
                                                        </td>
                                                        <td class="tr0 td47">
                                                            <p class="p19 ft2">₹ <span class="ft1">0</span></p>
                                                        </td>
                                                        <td class="tr0 td48">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td49">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr1 td67">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td8">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td24">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td10">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td25">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td52">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td53">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td14">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td54">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr0 td69">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td70">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td71">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td72">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td80">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td81">
                                                            <p class="p11 ft2">Total</p>
                                                        </td>
                                                        <td class="tr0 td74">
                                                            <p class="p21 ft2">
                                                                <asp:Label ID="lblTotalDueAmount" runat="server"></asp:Label>
                                                            </p>
                                                        </td>
                                                        <td class="tr0 td75">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                        <td class="tr0 td76">
                                                            <p class="p6 ft4">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr1 td55">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td56">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td57">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td58">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td59">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td82">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td78">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td62">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                        <td class="tr1 td63">
                                                            <p class="p6 ft5">&nbsp;</p>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <p class="p22 ft2">
                                                    This is a Computer Generated Receipt and do not require any signature.<br />
                                                    Discrepancy if noted , should be informed immediately.
                                                </p>
                                                <p class="p23 ft1">Note:</p>
                                                <p class="p23 ft1">REFUND POLICY:</p>
                                                <p class="p24 ft1">
                                                    <span class="ft7">1.</span><span class="ft8">Security deposit is only refundable if both the condition mentioned below is fulfilled
                                                        <br />
                                                        (a) Minimum LOCK-IN period of 6 months is served. (LOCK-IN period means minimum stay duration at STAYELLO PROPERTY)
                                                        <br />
                                                        (b) One month of notice period. (NOTICE period means informing the STAYELLO MANAGEMENT in written before 1 month of leaving the hostel.</span>
                                                </p>
                                                <p class="p25 ft1"><span class="ft9">2.</span><span class="ft8">For all payments made after 5th day of the month, ₹100 /- fine charge is applicable.</span></p>
                                                <p class="p25 ft1"><span class="ft9">3.</span><span class="ft8">Please visit www.stayello.com for details on refund policy.</span></p>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                            </div>
                        </div>

                    </div>
                    <!-- /.row -->

                </section>
                <!-- /.content -->
            </div>
            <!-- /.content-wrapper -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

