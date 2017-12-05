<%@ Page Title="Add Machine Attendance" Language="C#" MasterPageFile="~/MasterPages/BackEndHorizontal.Master" AutoEventWireup="true" CodeBehind="AddMachineAttendance.aspx.cs" Inherits="BioHR.Pages.MachineAttendance.AddMachineAttendance1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <link href='<%: ResolveClientUrl("~/Assets/uploadify/uploadify.css") %>' rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <!-- CONTENT PAGE START-->
    <!-- BEGIN Error Panel -->
    <div class="alert alert-block alert-danger fade in" runat="server" id="divFailureMessage" Visible="False">
        <button data-dismiss="alert" class="close close-sm" type="button">
            <i class="icon-remove"></i>
        </button>
        <h4>
            <i class="icon-warning-sign"></i>
            Error !
        </h4>
        <asp:Label runat="server" ID="lbFailureMessage"></asp:Label>
    </div>
    <!-- END Error Panel -->
    <!-- BEGIN Info Panel -->
    <div class="alert alert-block alert-info fade in" runat="server" id="divInfoMessage" Visible="False">
        <button data-dismiss="alert" class="close close-sm" type="button">
            <i class="icon-remove"></i>
        </button>
        <h4>
            <i class="icon-info-sign"></i>
            Info Message !
        </h4>
        <asp:Label runat="server" ID="lbInfoMessage"></asp:Label>
    </div>
    <!-- END Info Panel -->

    <div class="row">
        <div class="col-lg-12">
            <!-- BEGIN Breadcrumbs -->
            <ul class="breadcrumb">
                 <li>
                    <a href="index.html"><i class="icon-home"></i> Home</a></li>
                <li><a href="#">ESS Management</a></li>
                <li><a href="#">Administrasi Presensi</a></li>
                <li><a href="#">Config Mesin Presensi</a></li>
                <li class="active">Tambah Mesin Presensi</li>
            </ul>
            <!-- END Breadcrumbs -->
        </div>
    </div>
    
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                   <span>Tambah Mesin Presensi</span> 
                    <div class="tools" style="float: right;">
                        <a href="javascript:;" class="icon-chevron-down"></a>
                        <a href="javascript:;" class="reload">
                            <i class="icon-refresh"></i>
                        </a>
                    </div>
                </header>
                <div class="panel-body form-horizontal">
                    <div class="form-group">
                        <div class="container">
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">Nama Mesin</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <asp:TextBox ID="tbNamaMesin" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container">
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">IP Mesin</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <asp:TextBox ID="tbIpMesin" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container">
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">Port Mesin</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <asp:TextBox ID="tbPortMesin" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container">
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">Tipe Mesin</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <asp:DropDownList ID="ddlTipeMesin" runat="server" CssClass="form-control">
                                        <asp:ListItem Enabled="true" Text="S2K" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="MTX Amano" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container">
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">Deskripsi Mesin</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <asp:TextBox ID="tbDesMesin" TextMode="MultiLine" runat="server" CssClass="form-control" Rows="3" required="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container" style="text-align:center">
                                <div class="col-md-3">

                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="ButtonBatal" runat="server" Text="Batal" Class="btn btn-danger form-control" OnClick="btnBatal_Click" formnovalidate="true"/>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="ButtonSimpan" runat="server" Text="Simpan" Class="btn btn-info form-control" OnClick="btnSimpan_Click" />
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="ButtonTest" runat="server" Text="Tes Koneksi" Class="btn btn-success form-control" OnClick="btnTest_Click"/>
                                </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    
</asp:Content>
