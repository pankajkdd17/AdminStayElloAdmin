<%@ Page Title="" Language="C#" MasterPageFile="~/content/admin.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<%@ MasterType VirtualPath="~/content/admin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        .dash {
            color: #00a7d0;
            text-decoration: solid;
            text-align: center;
        }
    </style>
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>HOME
       
                <small></small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
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
                                    <h3 class="box-title">Quick Actions</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">

                                            <div class="info-box">
                                                <span class="info-box-icon bg-aqua-active color-palette"><i class="fa fa-home"></i></span>
                                                <div class="info-box-content">
                                                    <asp:LinkButton ID="lbtnProperties" runat="server" OnClick="lbtnProperties_Click">
                                                <span class="info-box-text dash"><b>Properties</b></span> </asp:LinkButton>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblproperty" runat="server"></asp:Label></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                            <!-- /.info-box -->
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">

                                            <div class="info-box">
                                                <span class="info-box-icon bg-aqua-active color-palette"><i class="fa fa-home"></i></span>
                                                <div class="info-box-content">

                                                    <asp:LinkButton ID="lbtnRooms" runat="server" OnClick="lbtnRooms_Click">
                                                <span class="info-box-text dash"><b>Rooms</b></span> </asp:LinkButton>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblTotalRoom" runat="server"></asp:Label></span>

                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                            <!-- /.info-box -->
                                        </div>

                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">

                                            <div class="info-box">
                                                <span class="info-box-icon bg-aqua-active color-palette"><i class="fa fa-bed"></i></span>
                                                <div class="info-box-content">
                                                    <span class="info-box-text dash"><b>No Of Beds</b></span>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <span style="color: #000; white-space: nowrap">Total Beds</span>
                                                                <span class="info-box-number" style="color: #000">
                                                                    <asp:Label ID="lblTotalBeds" runat="server"></asp:Label></span>

                                                            </td>
                                                            <td>
                                                                <span style="color: #f00">Vacant</span>
                                                                <span class="info-box-number" style="color: #f00">
                                                                    <asp:Label ID="lblBedsVacant" runat="server"></asp:Label></span>

                                                            </td>
                                                            <td>
                                                                <span style="color: #34a507">Occupied</span>
                                                                <span class="info-box-number" style="color: #34a507">
                                                                    <asp:Label ID="lblBedsOccupied" runat="server"></asp:Label></span>

                                                            </td>
                                                        </tr>
                                                    </table>

                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                            <!-- /.info-box -->
                                        </div>
                                        <!-- /.col -->

                                        <!-- fix for small devices only -->
                                        <div class="clearfix visible-sm-block"></div>

                                    </div>
                                    <!-- /.row -->
                                    <div class="row">
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-aqua-active color-palette"><i class="fa fa-user-plus"></i></span>
                                                <div class="info-box-content">
                                                    <asp:LinkButton ID="lbtnTenants" runat="server" OnClick="lbtnTenants_Click">
                                           
                                            <span class="info-box-text dash"><b>Tenants </b></span></asp:LinkButton>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblTotalTenants" runat="server"></asp:Label></span>

                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                            <!-- /.info-box -->
                                        </div>


                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-aqua-active color-palette"><i class="fa fa-comments"></i></span>
                                                <div class="info-box-content">
                                                    <a href="Complaints.aspx">
                                                        <span class="info-box-text dash"><b>Complaints</b></span>
                                                    </a>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <span style="color: #f00">New</span>
                                                                <span class="info-box-number" style="color: #f00">
                                                                    <asp:Label ID="lblNew" runat="server"></asp:Label></span>

                                                            </td>
                                                            <td>
                                                                <span style="color: #b3b507">On going</span>
                                                                <span class="info-box-number" style="color: #b3b507">
                                                                    <asp:Label ID="lblOngoing" runat="server"></asp:Label></span>

                                                            </td>
                                                            <td>
                                                                <span style="color: #34a507">Solved</span>
                                                                <span class="info-box-number" style="color: #34a507">
                                                                    <asp:Label ID="lblSolved" runat="server"> </asp:Label></span>

                                                            </td>
                                                        </tr>
                                                    </table>

                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                            <!-- /.info-box -->
                                        </div>

                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-aqua-active color-palette"><i class="fa fa-user-plus"></i></span>
                                                <div class="info-box-content">

                                                    <asp:LinkButton ID="lbtnUserData" runat="server" OnClick="lbtnUserData_Click">
                                           <span class="info-box-text dash"><b>Sign up </b></span></asp:LinkButton>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblSignup" runat="server"></asp:Label></span>

                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                            <!-- /.info-box -->
                                        </div>

                                        <!-- /.col -->


                                    </div>
                                    <div class="row">
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">

                                            <div class="info-box">
                                                <span class="info-box-icon bg-aqua-active color-palette"><i class="fa fa-rupee"></i></span>

                                                <div class="info-box-content">
                                                    <span class="info-box-text dash"><b>Collection</b></span>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <span style="color: #000">Room Rent</span>
                                                                <span class="info-box-number" style="color: #000">
                                                                    <asp:Label ID="lblroomrent" runat="server"></asp:Label></span>

                                                            </td>
                                                            <td>
                                                                <span style="color: #000">Security Money</span>
                                                                <span class="info-box-number" style="color: #000">
                                                                    <asp:Label ID="lblSecurityMoney" runat="server"></asp:Label></span>

                                                            </td>

                                                        </tr>
                                                    </table>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                            <!-- /.info-box -->
                                        </div>
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">
                                            <div class="info-box">
                                                <span class="info-box-icon bg-aqua-active color-palette"><i class="fa fa-inr"></i></span>
                                                <div class="info-box-content">
                                                    <span class="info-box-text dash"><b>Account</b></span>
                                                    <table>
                                                        <tr>
                                                            <td>

                                                                <asp:LinkButton ID="lbtnDues" runat="server" OnClick="lbtnDues_Click">
                                                                    <span style="color: #ff6a00; white-space: nowrap">Dues (<asp:Label ID="lblcountdues" runat="server"></asp:Label>)</span>
                                                                </asp:LinkButton>
                                                                <span class="info-box-number" style="color: #ff6a00">
                                                                    <asp:Label ID="lblTotalDues" runat="server"></asp:Label></span>

                                                            </td>
                                                            <td>
                                                                <a href="Income.aspx"><span style="color: #083704; white-space: nowrap">Income (<asp:Label ID="lblCountIncome" runat="server"></asp:Label>)</span></a>
                                                                <span class="info-box-number" style="color: #083704">
                                                                    <asp:Label ID="lblTotalIncome" runat="server"> </asp:Label></span>

                                                            </td>
                                                            <td style="visibility: hidden">

                                                                <asp:LinkButton ID="lbtnExpences" runat="server" OnClick="lbtnExpences_Click">
                                                                    <span style="color: #ff6a00; white-space: nowrap">Expense (<asp:Label ID="lblcountExpence" runat="server"></asp:Label>)</span>
                                                                </asp:LinkButton>
                                                                <span class="info-box-number" style="color: #ff6a00">
                                                                    <asp:Label ID="lblTotalExpenses" runat="server"></asp:Label></span>

                                                            </td>
                                                        </tr>
                                                    </table>


                                                </div>
                                            </div>

                                            <!-- /.info-box-content -->

                                            <!-- /.info-box -->
                                        </div>

                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">

                                            <div class="info-box">
                                                <span class="info-box-icon bg-aqua-active color-palette"><i class="fa fa-calendar"></i></span>
                                                <div class="info-box-content">

                                                    <asp:LinkButton ID="lbtnBookings" runat="server" OnClick="lbtnBookings_Click">
                                                <span class="info-box-text dash"><b>Bookings</b></span></asp:LinkButton>
                                                    <span style="color: #ff6a00"></span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblBookings" runat="server"></asp:Label></span>
                                                </div>
                                            </div>

                                            <!-- /.info-box-content -->

                                            <!-- /.info-box -->
                                        </div>
                                    </div>
                                    <div class="row">

                                        <!-- fix for small devices only -->
                                        <div class="clearfix visible-sm-block"></div>
                                        <!-- /.col -->
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">

                                            <div class="info-box">
                                                <span class="info-box-icon bg-aqua-active color-palette"><i class="fa fa-user-plus"></i></span>

                                                <div class="info-box-content">

                                                    <asp:LinkButton ID="lbtnLeads" runat="server" OnClick="lbtnLeads_Click">
                                                <span class="info-box-text dash"><b>Leads </b></span>
                                                    </asp:LinkButton>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lbltotalLeads" runat="server"></asp:Label></span>
                                                </div>
                                                <!-- /.info-box-content -->
                                            </div>

                                            <!-- /.info-box -->
                                        </div>

                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">

                                            <div class="info-box">
                                                <span class="info-box-icon bg-aqua-active color-palette"><i class="fa fa-list"></i></span>
                                                <div class="info-box-content">
                                                    <span class="info-box-text dash"><b>Forms </b></span>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="Label7" runat="server"></asp:Label></span>
                                                </div>
                                            </div>

                                            <!-- /.info-box-content -->

                                            <!-- /.info-box -->
                                        </div>
                                        <div class="col-md-4 col-sm-6 col-xs-12 zoomnow">

                                            <div class="info-box">
                                                <span class="info-box-icon bg-aqua-active color-palette"><i class="fa fa-calendar"></i></span>
                                                <div class="info-box-content">

                                                    <asp:LinkButton ID="lbtnScheduleVisits" runat="server" OnClick="lbtnScheduleVisits_Click">
                                             <span class="info-box-text dash"><b>Schedules </b></span></asp:LinkButton>
                                                    <span class="info-box-number" style="color: #ff6a00">
                                                        <asp:Label ID="lblSchedules" runat="server"></asp:Label></span>
                                                </div>
                                            </div>

                                            <!-- /.info-box-content -->

                                            <!-- /.info-box -->
                                        </div>
                                    </div>

                                </div>

                            </div>
                            <!-- /.box -->
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->

                    <%-- 
            <div class="row">
                <!-- Left col -->
                <div class="col-md-6">
                    <!-- MAP & BOX PANE -->
                    <!-- DONUT CHART -->
                    <div class="box box-danger">
                        <div class="box-header with-border">
                            <h3 class="box-title">Rooms Occupency</h3>

                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                    <i class="fa fa-minus"></i>
                                </button>
                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                            </div>
                        </div>
                        <div class="box-body">
                            <div id="Div6" style="height: 325px;">
                                <canvas id="pieChart" style="height: 300px"></canvas>
                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->

                <div class="col-md-6">
                    <!-- MAP & BOX PANE -->
                    <div class="box box-success">
                        <div class="box-header with-border">
                            <h3 class="box-title">Room No. Wise Occupency :
                                <asp:DropDownList ID="ddlroomNo" runat="server" class="form-controle">
                                </asp:DropDownList>
                            </h3>

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

                                        <div id="Div1" style="height: 325px;">
                                            <canvas id="pieChart1" style="width: 400px"></canvas>
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
           
            <div class="row">
                <!-- Left col -->
                <div class="col-md-6">
                    <!-- MAP & BOX PANE -->
                    <div class="box box-success">
                        <div class="box-header with-border">
                            <h3 class="box-title">Tenants Added Month Wise</h3>

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
                                        <div class="chart" style="height: 325px">
                                            <canvas id="barChart" style="height: 325px"></canvas>
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

                <div class="col-md-6">
                    <!-- MAP & BOX PANE -->
                    <div class="box box-success">
                        <div class="box-header with-border">
                            <h3 class="box-title">Complaints</h3>

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
                                        <div class="chart" style="height: 325px">
                                            <canvas id="pieChart3" style="height: 325px"></canvas>
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
           
            <div class="row">
                <!-- Left col -->
                <div class="col-md-6">
                    <!-- MAP & BOX PANE -->
                    <div class="box box-success">
                        <div class="box-header with-border">
                            <h3 class="box-title">Leads</h3>

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
                                        <div id="Div4" style="height: 325px;">
                                            <canvas id="leads" style="height: 325px"></canvas>
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

                <div class="col-md-6">
                    <!-- MAP & BOX PANE -->
                    <div class="box box-success">
                        <div class="box-header with-border">
                            <h3 class="box-title">Accounting</h3>

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
                                        <div id="Div5" style="height: 325px;">
                                            <canvas id="barChart1" style="height: 324px; width: 350px"></canvas>
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
            </div>--%>
                    <!-- /.row -->
                </section>
                <!-- /.content -->
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- /.content-wrapper -->
    <script>
        $(function () {

            var areaChartData = {
                labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
                datasets: [
                    {
                        label: 'Electronics',
                        fillColor: 'rgba(210, 214, 222, 1)',
                        strokeColor: 'rgba(210, 214, 222, 1)',
                        pointColor: 'rgba(210, 214, 222, 1)',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(220,220,220,1)',
                        data: [65, 59, 80, 81, 56, 55, 40]
                    },
                    {
                        label: 'Digital Goods',
                        fillColor: 'rgba(60,141,188,0.9)',
                        strokeColor: 'rgba(60,141,188,0.8)',
                        pointColor: '#3b8bba',
                        pointStrokeColor: 'rgba(60,141,188,1)',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(60,141,188,1)',
                        data: [28, 48, 40, 19, 86, 27, 90]
                    }
                ]
            }


            //-------------
            //- PIE CHART -
            //-------------
            // Get context with jQuery - using jQuery's .get() method.
            var pieChartCanvas = $('#leads').get(0).getContext('2d')
            var pieChart = new Chart(pieChartCanvas)
            var PieData = [
                {
                    value: 700,
                    color: '#f56954',
                    highlight: '#f56954',
                    label: 'New Leads'
                },
                {
                    value: 500,
                    color: '#00a65a',
                    highlight: '#00a65a',
                    label: 'On going'
                },
                {
                    value: 400,
                    color: '#f39c12',
                    highlight: '#f39c12',
                    label: 'Converted'
                },

            ]
            var pieOptions = {
                //Boolean - Whether we should show a stroke on each segment
                segmentShowStroke: true,
                //String - The colour of each segment stroke
                segmentStrokeColor: '#fff',
                //Number - The width of each segment stroke
                segmentStrokeWidth: 2,
                //Number - The percentage of the chart that we cut out of the middle
                percentageInnerCutout: 50, // This is 0 for Pie charts
                //Number - Amount of animation steps
                animationSteps: 100,
                //String - Animation easing effect
                animationEasing: 'easeOutBounce',
                //Boolean - Whether we animate the rotation of the Doughnut
                animateRotate: true,
                //Boolean - Whether we animate scaling the Doughnut from the centre
                animateScale: false,
                //Boolean - whether to make the chart responsive to window resizing
                responsive: true,
                // Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
                maintainAspectRatio: true,
                //String - A legend template

            }
            //Create pie or douhnut chart
            // You can switch between pie and douhnut using the method below.
            pieChart.Doughnut(PieData, pieOptions)

            //-------------
            //- PIE CHART -
            //-------------
            // Get context with jQuery - using jQuery's .get() method.
            var pieChartCanvas = $('#pieChart').get(0).getContext('2d')
            var pieChart = new Chart(pieChartCanvas)
            var PieData = [
                {
                    value: 700,
                    color: '#f56954',
                    highlight: '#f56954',
                    label: 'Chrome'
                },
                {
                    value: 500,
                    color: '#00a65a',
                    highlight: '#00a65a',
                    label: 'IE'
                },
                {
                    value: 400,
                    color: '#f39c12',
                    highlight: '#f39c12',
                    label: 'FireFox'
                },
                {
                    value: 600,
                    color: '#00c0ef',
                    highlight: '#00c0ef',
                    label: 'Safari'
                },
                {
                    value: 300,
                    color: '#3c8dbc',
                    highlight: '#3c8dbc',
                    label: 'Opera'
                },
                {
                    value: 100,
                    color: '#d2d6de',
                    highlight: '#d2d6de',
                    label: 'Navigator'
                }
            ]
            var pieOptions = {
                //Boolean - Whether we should show a stroke on each segment
                segmentShowStroke: true,
                //String - The colour of each segment stroke
                segmentStrokeColor: '#fff',
                //Number - The width of each segment stroke
                segmentStrokeWidth: 2,
                //Number - The percentage of the chart that we cut out of the middle
                percentageInnerCutout: 50, // This is 0 for Pie charts
                //Number - Amount of animation steps
                animationSteps: 100,
                //String - Animation easing effect
                animationEasing: 'easeOutBounce',
                //Boolean - Whether we animate the rotation of the Doughnut
                animateRotate: true,
                //Boolean - Whether we animate scaling the Doughnut from the centre
                animateScale: false,
                //Boolean - whether to make the chart responsive to window resizing
                responsive: true,
                // Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
                maintainAspectRatio: true,
                //String - A legend template

            }
            //Create pie or douhnut chart
            // You can switch between pie and douhnut using the method below.
            pieChart.Doughnut(PieData, pieOptions)
            //- PIE CHART -
            //-------------
            // Get context with jQuery - using jQuery's .get() method.
            var pieChartCanvas = $('#pieChart1').get(0).getContext('2d')
            var pieChart = new Chart(pieChartCanvas)
            var PieData = [
                {
                    value: 700,
                    color: '#f56954',
                    highlight: '#f56954',
                    label: 'Chrome'
                },
                {
                    value: 500,
                    color: '#00a65a',
                    highlight: '#00a65a',
                    label: 'IE'
                },
                {
                    value: 400,
                    color: '#f39c12',
                    highlight: '#f39c12',
                    label: 'FireFox'
                },
                {
                    value: 600,
                    color: '#00c0ef',
                    highlight: '#00c0ef',
                    label: 'Safari'
                },
                {
                    value: 300,
                    color: '#3c8dbc',
                    highlight: '#3c8dbc',
                    label: 'Opera'
                },
                {
                    value: 100,
                    color: '#d2d6de',
                    highlight: '#d2d6de',
                    label: 'Navigator'
                }
            ]
            var pieOptions = {
                //Boolean - Whether we should show a stroke on each segment
                segmentShowStroke: true,
                //String - The colour of each segment stroke
                segmentStrokeColor: '#fff',
                //Number - The width of each segment stroke
                segmentStrokeWidth: 2,
                //Number - The percentage of the chart that we cut out of the middle
                percentageInnerCutout: 50, // This is 0 for Pie charts
                //Number - Amount of animation steps
                animationSteps: 100,
                //String - Animation easing effect
                animationEasing: 'easeOutBounce',
                //Boolean - Whether we animate the rotation of the Doughnut
                animateRotate: true,
                //Boolean - Whether we animate scaling the Doughnut from the centre
                animateScale: false,
                //Boolean - whether to make the chart responsive to window resizing
                responsive: true,
                // Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
                maintainAspectRatio: true,
                //String - A legend template

            }
            //Create pie or douhnut chart
            // You can switch between pie and douhnut using the method below.
            pieChart.Doughnut(PieData, pieOptions)


            //- PIE CHART -
            //-------------
            // Get context with jQuery - using jQuery's .get() method.
            var pieChartCanvas = $('#pieChart3').get(0).getContext('2d')
            var pieChart = new Chart(pieChartCanvas)
            var PieData = [
                {
                    value: 700,
                    color: '#f56955',
                    highlight: '#f56952',
                    label: 'Chrome'
                },
                {
                    value: 500,
                    color: '#00a65f',
                    highlight: '#00a65f',
                    label: 'IE'
                },
                {
                    value: 400,
                    color: '#f39c12',
                    highlight: '#f39c12',
                    label: 'FireFox'
                },

            ]
            var pieOptions = {
                //Boolean - Whether we should show a stroke on each segment
                segmentShowStroke: true,
                //String - The colour of each segment stroke
                segmentStrokeColor: '#fff',
                //Number - The width of each segment stroke
                segmentStrokeWidth: 1,
                //Number - The percentage of the chart that we cut out of the middle
                percentageInnerCutout: 50, // This is 0 for Pie charts
                //Number - Amount of animation steps
                animationSteps: 100,
                //String - Animation easing effect
                animationEasing: 'easeOutBounce',
                //Boolean - Whether we animate the rotation of the Doughnut
                animateRotate: true,
                //Boolean - Whether we animate scaling the Doughnut from the centre
                animateScale: false,
                //Boolean - whether to make the chart responsive to window resizing
                responsive: true,
                // Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
                maintainAspectRatio: true,
                //String - A legend template

            }
            //Create pie or douhnut chart
            // You can switch between pie and douhnut using the method below.
            pieChart.Doughnut(PieData, pieOptions)
            //-------------
            //- BAR CHART -
            //-------------
            var barChartCanvas = $('#barChart').get(0).getContext('2d')
            var barChart = new Chart(barChartCanvas)
            var barChartData = areaChartData
            barChartData.datasets[1].fillColor = '#00a65a'
            barChartData.datasets[1].strokeColor = '#00a65a'
            barChartData.datasets[1].pointColor = '#00a65a'
            var barChartOptions = {
                //Boolean - Whether the scale should start at zero, or an order of magnitude down from the lowest value
                scaleBeginAtZero: true,
                //Boolean - Whether grid lines are shown across the chart
                scaleShowGridLines: true,
                //String - Colour of the grid lines
                scaleGridLineColor: 'rgba(0,0,0,.05)',
                //Number - Width of the grid lines
                scaleGridLineWidth: 1,
                //Boolean - Whether to show horizontal lines (except X axis)
                scaleShowHorizontalLines: true,
                //Boolean - Whether to show vertical lines (except Y axis)
                scaleShowVerticalLines: true,
                //Boolean - If there is a stroke on each bar
                barShowStroke: true,
                //Number - Pixel width of the bar stroke
                barStrokeWidth: 2,
                //Number - Spacing between each of the X value sets
                barValueSpacing: 5,
                //Number - Spacing between data sets within X values
                barDatasetSpacing: 1,
                //String - A legend template

                //Boolean - whether to make the chart responsive
                responsive: true,
                maintainAspectRatio: true
            }

            barChartOptions.datasetFill = true
            barChart.Bar(barChartData, barChartOptions)
            //-------------
            //- BAR CHART -
            //-------------
            var barChartCanvas = $('#barChart1').get(0).getContext('2d')
            var barChart = new Chart(barChartCanvas)
            var barChartData = areaChartData
            barChartData.datasets[1].fillColor = '#00a65a'
            barChartData.datasets[1].strokeColor = '#00a65a'
            barChartData.datasets[1].pointColor = '#00a65a'
            var barChartOptions = {
                //Boolean - Whether the scale should start at zero, or an order of magnitude down from the lowest value
                scaleBeginAtZero: true,
                //Boolean - Whether grid lines are shown across the chart
                scaleShowGridLines: true,
                //String - Colour of the grid lines
                scaleGridLineColor: 'rgba(0,0,0,.05)',
                //Number - Width of the grid lines
                scaleGridLineWidth: 1,
                //Boolean - Whether to show horizontal lines (except X axis)
                scaleShowHorizontalLines: true,
                //Boolean - Whether to show vertical lines (except Y axis)
                scaleShowVerticalLines: true,
                //Boolean - If there is a stroke on each bar
                barShowStroke: true,
                //Number - Pixel width of the bar stroke
                barStrokeWidth: 2,
                //Number - Spacing between each of the X value sets
                barValueSpacing: 5,
                //Number - Spacing between data sets within X values
                barDatasetSpacing: 1,
                //String - A legend template

                //Boolean - whether to make the chart responsive
                responsive: true,
                maintainAspectRatio: true
            }

            barChartOptions.datasetFill = true
            barChart.Bar(barChartData, barChartOptions)
        })
    </script>

</asp:Content>

