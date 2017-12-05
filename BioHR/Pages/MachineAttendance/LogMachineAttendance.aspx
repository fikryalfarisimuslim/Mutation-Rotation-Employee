<%@ Page Title="Log Machine Attendance" Language="C#" MasterPageFile="~/MasterPages/BackEndHorizontal.Master" AutoEventWireup="true" CodeBehind="LogMachineAttendance.aspx.cs" Inherits="BioHR.Pages.MachineAttendance.LogMachineAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    
    <style type="text/css">
        .gvclass table th {
            text-align: center;
        }
    </style>

    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <style type="text/css">
        .demo { position: relative; }
        .demo i {
            position: absolute; bottom: 10px; right: 24px; top: auto; cursor: pointer;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {

            $('#startDate').daterangepicker({
                singleDatePicker: true,
                showDropdowns: true,
                startDate: moment()
            });

            $('#endDate').daterangepicker({
                singleDatePicker: true,
                showDropdowns: true,
                startDate: moment()
            });

          });
      </script>
    
    
    <!-- CONTENT PAGE START-->
    <div class="row">
        <div class="col-lg-12">
            <!-- BEGIN Breadcrumbs -->
            <ul class="breadcrumb">
                <li><a href="index.html"><i class="icon-home"></i> Home</a></li>
                <li><a href="#">ESS Management</a></li>
                <li><a href="#">Administrasi Presensi</a></li>
                <li><a href="#">Penarikan Mesin Presensi</a></li>
                <li class="active">Log Mesin Presensi</li>
            </ul>
            <!-- END Breadcrumbs -->
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    <span>Log Mesin Presensi</span>
                    <div class="tools" style="float: right;">
                        <a href="#box-config" data-toggle="modal" class="config">
                            <i class="icon-cog"></i>
                        </a>
                        <a href="javascript:;" class="reload">
                            <i class="icon-refresh"></i>
                        </a>
                    </div>
                </header>

        

     
                <div class="panel-body">
          
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Button ID="ButtonWithdrawal" runat="server" Text="Penarikan Mesin" Class="btn btn-info btn-xxl w-50" OnClick="btnWithdrawal_Click"/>
                            </div>

                            
                            <div class="col-md-2 demo">
                                
                            </div>
                            

                            <div class="col-md-3">
                                <asp:TextBox ID="tbSearch" runat="server" CssClass="form-control" placeholder="Search">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="startDate" runat="server" class="form-control" placeholder="Tanggal Dimulai" ClientIDMode="Static">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="endDate" runat="server" class="form-control" placeholder="Tanggal Berakhir" ClientIDMode="Static">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-1" style="text-align:center">
                                <asp:LinkButton ID="ButtonSearch" runat="server" CssClass="btn btn-info form-inline" OnClick="btnSearch_Click">
                                    <i class="icon icon-search"></i>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class="panel-body">
                        <div class="gvclass">
                            <asp:GridView ID="gvLogMachineAttendance" runat="server" CssClass="table table-strip table-bordered" AutoGenerateColumns="false" ShowHeaderWhenEmpty="True" AllowPaging="true" OnPageIndexChanging="OnPagingLogMachine">
                                <HeaderStyle BackColor="#F1F2F7" />
                                <Columns>
                                    <asp:BoundField DataField="MCHNM" HeaderText="Nama Mesin"/>
                                    <asp:BoundField DataField="MCHIP" HeaderText="IP Mesin" />
                                    <asp:BoundField DataField="MCHPRT" HeaderText="Port Mesin" />
                                    <asp:BoundField DataField="CHGDT" HeaderText="Waktu Penarikan" />
                                    <asp:TemplateField HeaderText="Status Penarikan">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Image ID="Image" runat="server" ImageUrl='<%# Eval("img") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                </div>
            </section>
        </div> <!-- END OF col-lg-12 -->
    </div> <!-- END OF ROW -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScriptLibContent" runat="server">
    <!-- FOR TABLE -->
    <script type="text/javascript" src='<%: ResolveClientUrl("~/JS/TableScript/data-tables/jquery.dataTables.js") %>'></script>
    <script type="text/javascript" src='<%: ResolveClientUrl("~/JS/TableScript/data-tables/DT_bootstrap.js") %>'></script>

    
    
    <!-- END FOR TABLE -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpScriptContent" runat="server">
    <script type="text/javascript" src='<%: ResolveClientUrl("~/JS/DataTable/DataTables-ApprovalList.js") %>'></script>

    <!--
    <script type="text/javascript" src="../../JS/DatePicker/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="../../JS/DatePicker/moment.js"></script>
    <script type="text/javascript" src="../../JS/DatePicker/daterangepicker.js"></script>

    <link href="../../JS/DatePicker/bootstrap.min.css" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" media="all" href="../../JS/DatePicker/daterangepicker.css" />
    -->
    
    <!--
    <link href="../../JS/DatePicker/jquery-ui.css" rel="stylesheet"/>
    <script type="text/javascript" src="../../JS/DatePicker/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="../../JS/DatePicker/jquery-ui.js"></script>
    -->

    <!--
    <link rel="stylesheet" href="../../CSS/bootstrap.min.css" />
    <link rel="stylesheet" href="../../JS/DatePicker/bootstrap-datepicker3.standalone.css" />

    <script type="text/javascript" src="../../JS/DatePicker/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="../../JS/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../JS/DatePicker/bootstrap-datepicker.min.js"></script>
    -->

</asp:Content>