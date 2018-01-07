<%@ Page Title="Edit Machine Attendance" Language="C#" MasterPageFile="~/MasterPages/BackEndHorizontal.Master" AutoEventWireup="true" CodeBehind="EditMachineAttendance.aspx.cs" Inherits="BioHR.Pages.MachineAttendance.EditMachineAttendance" %>

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
                <li class="active">Edit Mesin Presensi</li>
            </ul>
            <!-- END Breadcrumbs -->
        </div>
    </div>
    
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                   <span>Edit Mesin Presensi</span> 
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
                                        <asp:ListItem Text="HIT" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container">
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">Deskripsi Mesin</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <asp:TextBox ID="tbDesMesin" TextMode="MultiLine" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container">
                            <div class="col-lg-1 col-md-2 col-md-offset-3 col-sm-1">
                                <asp:Button ID="ButtonBatal" runat="server" Text="Batal" Class="btn btn-danger btn-xxl w-50" OnClick="btnBatal_Click" formnovalidate="true"/>
                            </div>
                            <div class="col-lg-1 col-md-1 col-sm-1">
                                <asp:Button ID="ButtonSimpan" runat="server" Text="Simpan" Class="btn btn-info btn-xxl w-50" OnClick="btnSimpan_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    
</asp:Content>
