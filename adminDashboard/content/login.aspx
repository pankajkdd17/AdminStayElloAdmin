<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="content_login" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Stayello | Admin</title>

    <link rel="icon" href="dist/img/faviconLogo.png" type="image/x-icon" />
    <link rel="shortcut icon" href="dist/img/faviconLogo.png" type="image/x-icon" />
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="bower_components/bootstrap/dist/css/bootstrap.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="bower_components/font-awesome/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css" />
    <!-- jvectormap -->
    <link rel="stylesheet" href="bower_components/jvectormap/jquery-jvectormap.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css" />
    <script src="bower_components/jquery/dist/jquery.min.js"></script>
    <link href="toastrAlert/toastr.css" rel="stylesheet" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]-->
    <script src="bower_components/chart.js/Chart.js"></script>
    <script src="bower_components/chart.js/Chart.min.js"></script>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <!--[endif]-->
    <link href="dist/css/customadmin.css" rel="stylesheet" />
    <!-- Google Font -->
    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" />

</head>
<body class="hold-transition login-page">
    <form runat="server" id="form">
        <div class="login-box">
            <div class="login-logo">
                <a href="www.stayello.com"><b>Admin/Staff</b> Login</a>
            </div>
            <!-- /.login-logo -->
            <div class="login-box-body">
                <p class="login-box-msg">Sign in to start your session</p>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="txtmobile" runat="server" onkeypress="if (this.value.length > 9) { return false; }" TextMode="Number" class="form-control" MaxLength="10" placeholder="Mobile No"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmobile" ErrorMessage="Please enter Mobile"
                        ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                    <span class="glyphicon glyphicon-phone form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="txtpass" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqtxtpass" runat="server" ControlToValidate="txtpass" ErrorMessage="Please enter Password"
                        ForeColor="Red" Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                </div>
                <div class="row">
                    <div class="col-xs-4">
                    </div>
                    <!-- /.col -->
                    <div class="col-xs-4">
                        <asp:Button ID="btnLogin" runat="server" ValidationGroup="save" OnClick="btnLogin_Click" Text="Sign In" class="btn btn-primary btn-block btn-flat" />

                    </div>
                    <div class="col-xs-4">
                    </div>
                    <!-- /.col -->
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <asp:Label ID="lblmsg" runat="server" ForeColor="#0033cc"></asp:Label>
                    </div>
                </div>

                <%-- <div class="social-auth-links text-center">
      <p>- OR -</p>
      <a href="#" class="btn btn-block btn-social btn-facebook btn-flat"><i class="fa fa-facebook"></i> Sign in using
        Facebook</a>
      <a href="#" class="btn btn-block btn-social btn-google btn-flat"><i class="fa fa-google-plus"></i> Sign in using
        Google+</a>
    </div>--%>
                <!-- /.social-auth-links -->

                <%--<a href="#">I forgot my password</a><br>
    <a href="register.html" class="text-center">Register a new membership</a>--%>
            </div>
            <!-- /.login-box-body -->
        </div>
        <!-- /.login-box -->

        <!-- jQuery 3 -->
        <script src="../../bower_components/jquery/dist/jquery.min.js"></script>
        <!-- Bootstrap 3.3.7 -->
        <script src="../../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
        <!-- iCheck -->
        <script src="../../plugins/iCheck/icheck.min.js"></script>
        <script>
            $(function () {
                $('input').iCheck({
                    checkboxClass: 'icheckbox_square-blue',
                    radioClass: 'iradio_square-blue',
                    increaseArea: '20%' /* optional */
                });
            });
        </script>
    </form>
</body>
</html>

