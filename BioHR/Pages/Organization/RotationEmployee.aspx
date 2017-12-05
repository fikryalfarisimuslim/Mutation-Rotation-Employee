<%@ Page Title="Rotation Employee" Language="C#" MasterPageFile="~/MasterPages/BackEndHorizontal.Master" AutoEventWireup="true" CodeBehind="RotationEmployee.aspx.cs" Inherits="BioHR.Pages.Organization.RotationEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    
    <style type="text/css">
        
    </style>


    <script type = "text/javascript">
        function getValueTanggalBerlaku() {
            $(document).ready(function () {

                $('#iTanggalBerlaku').daterangepicker({
                    singleDatePicker: true,
                    showDropdowns: true,
                    iTanggalBerlaku: moment()
                });

            });
        }

        function getValueTanggalSK() {
            $(document).ready(function () {

                $('#iTanggalSK').daterangepicker({
                    singleDatePicker: true,
                    showDropdowns: true,
                    iTanggalSK: moment()
                });

            });
        }
        
    </script>
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <!-- CONTENT PAGE START-->
    <div class="row">
        <div class="col-lg-12">
            <!-- BEGIN Breadcrumbs -->
            <ul class="breadcrumb">
                <li>
                    <a href="index.html"><i class="icon-home"></i> Home</a></li>
                <li><a href="#">Company Management</a></li>
                <li><a href="#">Struktur Organisasi</a></li>
                <li class="active">Rotasi Karyawan</li>
            </ul>
            <!-- END Breadcrumbs -->
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    <span>Rotasi Karyawan</span>
                    <div class="tools" style="float: right;">
                        <a href="#box-config" data-toggle="modal" class="config">
                            <i class="icon-cog"></i>
                        </a>
                        <a href="javascript:;" class="reload">
                            <i class="icon-refresh"></i>
                        </a>
                    </div>
                </header>
            </section>

            <section class="panel">
                <header class="panel-heading">
                    <span>SK Rotasi</span>
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
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">NO SK</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <div class="input-group">
                                    <asp:TextBox ID="iNoSK" runat="server" CssClass="form-control" />
                                    
                                    <!-- <input type="text" class="form-control" required="required" id="iNoSK" /> -->
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="btnCekNoSK" runat="server" CssClass="btn btn-danger"  OnClick="getValueNoSK">
                                            <i class="icon-check-sign"></i>
                                        </asp:LinkButton>
                                    </span>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container">
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">Tanggal SK</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <div class="input-group">
                                    <input type="text" class="form-control" id="iTanggalSK" required="required" runat="server" value="" ClientIDMode="Static"/>
                                    <span class="input-group-btn">
                                        <button type="button" class="btn btn-danger date-set" id="btnTanggalSK" runat="server" ClientIDMode="Static" onclick="getValueTanggalSK()">
                                            <i class="icon-calendar">
                                            </i>
                                        </button>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container">
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">Judul SK</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <input type="text" class="form-control" required="required" id="iJudulSK" runat="server" value="Rotasi" disabled="disabled" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container">
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">Pengesah</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <input type="text" class="form-control" required="required" id="iNamaPengesah" runat="server"/>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container">
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">Tanggal Berlaku</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <div class="input-group">
                                    <input type="text" class="form-control" id="iTanggalBerlaku" required="required" runat="server" value="" ClientIDMode="Static"/>
                                    <span class="input-group-btn">
                                        <button type="button" class="btn btn-danger" id="btnTanggalBerlaku" runat="server" ClientIDMode="Static" onclick="getValueTanggalBerlaku()">
                                            <i class="icon-calendar">
                                            </i>
                                        </button>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container">
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">Upload SK</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                               <input type="file" class="form-control" required="required" id="iUploadSK" runat="server"/>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container">
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">Keterangan</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <textarea class="form-control" required="required" id="iKeterangan" rows="3" runat="server" value=""></textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <section class="panel">
                <header class="panel-heading">
                    <span>Data Karyawan</span>
                    <div class="tools" style="float: right;">
                        <a href="javascript:;" class="icon-chevron-down"></a>
                        <a href="javascript:;" class="reload">
                            <i class="icon-refresh"></i>
                        </a>
                    </div>
                </header>
                <div class="panel-body">
                    <div id="accordion" class="panel-group m-bot20">
                        <div class="panel panel-default">
                            <div class="panel-heading" style="background-color:#EC6459">
                                <h4 class="panel-title">
                                    <a href="#collapseOne" data-parent="#accordion" data-toggle="collapse" class="accordion-toggle" style="color:white">
                                        <i class="icon icon-plus-sign" style="float:right;font-size:x-large;margin-top:-5px"></i>
                                        001 Agung
                                    </a>
                                </h4>
                            </div>
                            <div class="panel-collapse collapse" id="collapseOne">
                                <div class="panel-body" style="background-color:#F7F8FC">
                                    <div class="row">
                                        <div class="col-lg-6" style="border-right:solid;border-color:#EC6459;border-width:2px">
                                            <h4 style="text-align:center">
                                                Biodata Karyawan
                                            </h4>
                                            <br/>
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            NIK
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : 001
                                                        </h5>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Nama Lengkap
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : Agung
                                                        </h5>
                                                    </div>
                                                </div>
                                                <br/>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Jabatan Lama
                                                        </h5>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Tempat
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : Pasteur
                                                        </h5>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Unit Kerja
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : IT
                                                        </h5>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Jabatan
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : Kepala Divisi
                                                        </h5>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-6">
                                            <h4 style="text-align:center">
                                                Tujuan Rotasi
                                            </h4>
                                            <br/>
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            NIK/NAMA
                                                        </h5>
                                                        <div class="col-lg-3">
                                                            <select aria-controls="editable-sample" class="form-control">
                                                                <option value="1" selected="selected">002 Fikry</option>
                                                                <option value="2">004 Agung Fikry</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Tempat
                                                        </h5>
                                                        <div class="col-lg-3">
                                                            <input type="text" class="form-control" required="required" id="iTempat" disabled="disabled" value="Pasteur"/>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Unit Kerja
                                                        </h5>
                                                        <div class="col-lg-3">
                                                            <input type="text" class="form-control" required="required" id="iUnitKerja" disabled="disabled" value="SDM"/>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Jabatan
                                                        </h5>
                                                        <div class="col-lg-3">
                                                            <input type="text" class="form-control" required="required" id="iJabatan" disabled="disabled" value="Kepala Divisi"/>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <div class="col-lg-2 col-lg-offset-4" style="text-align:right;">
                                                            <button type="button" class="btn btn-primary">Rotasi</button>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
  
                        <div class="panel panel-default">
                            <div class="panel-heading" style="background-color:#EC6459">
                                <h4 class="panel-title">
                                    <a href="#collapseTwo" data-parent="#accordion" data-toggle="collapse" class="accordion-toggle" style="color:white">
                                        <i class="icon icon-plus-sign" style="float:right;font-size:x-large;margin-top:-5px"></i>
                                        002 Fikry
                                    </a>
                                    </h4>
                            </div>
                            <div class="panel-collapse collapse" id="collapseTwo">
                                <div class="panel-body" style="background-color:#F7F8FC">
                                    <div class="row">
                                        <div class="col-lg-6" style="border-right:solid;border-color:#EC6459;border-width:2px">
                                            <h4 style="text-align:center">
                                                Biodata Karyawan
                                            </h4>
                                            <br/>
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            NIK
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : 002
                                                        </h5>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Nama Lengkap
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : Fikry
                                                        </h5>
                                                    </div>
                                                </div>
                                                <br/>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Jabatan Lama
                                                        </h5>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Tempat
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : Pasteur
                                                        </h5>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Unit Kerja
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : IT
                                                        </h5>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Jabatan
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : Wakil Kepala Divisi
                                                        </h5>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-6">
                                            <h4 style="text-align:center">
                                                Tujuan Rotasi
                                            </h4>
                                            <br/>
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            NIK/NAMA
                                                        </h5>
                                                        <div class="col-lg-3">
                                                            <select aria-controls="editable-sample" class="form-control">
                                                                <option value="1" selected="selected">001 Agung</option>
                                                                <option value="2">004 Agung Fikry</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Tempat
                                                        </h5>
                                                        <div class="col-lg-3">
                                                            <input type="text" class="form-control" required="required" id="iTempat2" disabled="disabled" value="Pasteur"/>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Unit Kerja
                                                        </h5>
                                                        <div class="col-lg-3">
                                                            <input type="text" class="form-control" required="required" id="iUnitKerja2" disabled="disabled" value="SDM"/>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Jabatan
                                                        </h5>
                                                        <div class="col-lg-3">
                                                            <input type="text" class="form-control" required="required" id="iJabatan2" disabled="disabled" value="Wakil Kepala Divisi"/>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <div class="col-lg-2 col-lg-offset-4" style="text-align:right;">
                                                            <button type="button" class="btn btn-primary">Rotasi</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="panel panel-default">
                            <div class="panel-heading" style="background-color:#EC6459">
                                <h4 class="panel-title">
                                    <a href="#collapseThree" data-parent="#accordion" data-toggle="collapse" class="accordion-toggle" style="color:white">
                                        <i class="icon icon-plus-sign" style="float:right;font-size:x-large;margin-top:-5px"></i>
                                        004 Agung Fikry
                                    </a>
                                    </h4>
                            </div>
                            <div class="panel-collapse collapse" id="collapseThree">
                                <div class="panel-body" style="background-color:#F7F8FC">
                                    <div class="row">
                                        <div class="col-lg-6" style="border-right:solid;border-color:#EC6459;border-width:2px">
                                            <h4 style="text-align:center">
                                                Biodata Karyawan
                                            </h4>
                                            <br/>
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            NIK
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : 004
                                                        </h5>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Nama Lengkap
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : Agung Fikry
                                                        </h5>
                                                    </div>
                                                </div>
                                                <br/>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Jabatan Lama
                                                        </h5>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Tempat
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : Pasteur
                                                        </h5>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Unit Kerja
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : IT
                                                        </h5>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Jabatan
                                                        </h5>
                                                        <h5 class="col-lg-3">
                                                            : Staff
                                                        </h5>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-6">
                                            <h4 style="text-align:center">
                                                Tujuan Rotasi
                                            </h4>
                                            <br/>
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            NIK/NAMA
                                                        </h5>
                                                        <div class="col-lg-3">
                                                            <select aria-controls="editable-sample" class="form-control">
                                                                <option value="1" selected="selected">001 Agung</option>
                                                                <option value="2">003 Fikry</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Tempat
                                                        </h5>
                                                        <div class="col-lg-3">
                                                            <input type="text" class="form-control" required="required" id="iTempat3" disabled="disabled" value="Pasteur"/>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Unit Kerja
                                                        </h5>
                                                        <div class="col-lg-3">
                                                            <input type="text" class="form-control" required="required" id="iUnitKerja3" disabled="disabled" value="SDM"/>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <h5 class="col-lg-2 col-lg-offset-1">
                                                            Jabatan
                                                        </h5>
                                                        <div class="col-lg-3">
                                                            <input type="text" class="form-control" required="required" id="iJabatan3" disabled="disabled" value="Staff"/>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="container">
                                                        <div class="col-lg-2 col-lg-offset-4" style="text-align:right;">
                                                            <button type="button" class="btn btn-primary">Rotasi</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                          
                    </div>
                    <div class="row">
                        <div class="col-lg-1 col-lg-offset-5">
                            <button type="button" class="btn btn-danger form-control">Batal</button>
                        </div>
                        <div class="col-lg-1">
                            <button type="button" class="btn btn-primary form-control">Selesai</button>
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
