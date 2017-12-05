<%@ Page Title="Withdrawal Machine Attendance" Language="C#" MasterPageFile="~/MasterPages/BackEndHorizontal.Master" AutoEventWireup="true" CodeBehind="WithdrawalMachineAttendance.aspx.cs" Inherits="BioHR.Pages.MachineAttendance.WithdrawalMachineAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <style type="text/css">
        .gvclass table th {text-align:center;}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <!-- CONTENT PAGE START-->
    <div class="row">
        <div class="col-lg-12">
            <!-- BEGIN Breadcrumbs -->
            <ul class="breadcrumb">
                <li>
                    <a href="index.html"><i class="icon-home"></i> Home</a></li>
                <li><a href="#">ESS Management</a></li>
                <li><a href="#">Administrasi Presensi</a></li>
                <li class="active">Penarikan Mesin Presensi</li>
            </ul>
            <!-- END Breadcrumbs -->
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    <span>Penarikan Mesin Presensi</span>
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
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <asp:Button ID="ButtonRecallAll" runat="server" Text="Penarikan Semua Mesin" Class="btn btn-info btn-xxl w-50" OnClick="btnRecallAllMachine_Click" />
                            </div>
                            <div class="col-lg-1 col-md-1 col-sm-1">
                                <asp:Button ID="ButtonLog" runat="server" Text="Log Mesin" Class="btn btn-info btn-xxl w-50" OnClick="btnLog_Click"/>
                            </div>
                        </div>
                    </div>

                    <div class="panel-body">
                        <div class="gvclass">
                            <asp:GridView ID="gvWithdrawalMachineAttendance" runat="server" CssClass="table table-strip table-bordered" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
                                <HeaderStyle BackColor="#F1F2F7" />
                                <Columns>
                                    <asp:BoundField DataField="MCHNM" HeaderText="Nama Mesin" />
                                    <asp:BoundField DataField="MCHIP" HeaderText="IP Mesin" />
                                    <asp:BoundField DataField="MCHPRT" HeaderText="Port Mesin" />
                                    <asp:BoundField DataField="CHGDT" HeaderText="Waktu Penarikan" />
                                    <asp:TemplateField HeaderText="Status Penarikan">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Image ID="Image" runat="server" ImageUrl='<%# Eval("img") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Aksi">
                                        <ItemTemplate>
                                            <div class="row" style="text-align:center">
                                                <div class="col-md-12">
                                                    <asp:Button ID="ButtonRecall" runat="server" Text="Penarikan Ulang" Class="btn btn-warning btn-xs w-50" OnClick="btnRecallMachine_Click"/>
                                                </div>
                                            </div>
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
</asp:Content>
