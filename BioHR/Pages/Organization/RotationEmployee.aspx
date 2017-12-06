<%@ Page Title="Rotation Employee" Language="C#" MasterPageFile="~/MasterPages/BackEndHorizontal.Master" AutoEventWireup="true" CodeBehind="RotationEmployee.aspx.cs" Inherits="BioHR.Pages.Organization.RotationEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    
    <style type="text/css">
        
    </style>


    <script type = "text/javascript">
        var UNITKERJA = JSON.parse(window.localStorage.getItem("UNITKERJA")); // Retrieving
        var JABATAN = JSON.parse(window.localStorage.getItem("JABATAN")); // Retrieving
        var NIK = JSON.parse(window.localStorage.getItem("NIK")); // Retrieving
        var NAMA = JSON.parse(window.localStorage.getItem("NAMA")); // Retrieving
        var i, j, n, x;

        /*Jika data gak ada yang di pilih*/
        
        try {
            
            n = NIK.length;
     
        }
        catch (err) {
            window.open('ListOfEmployee.aspx', '_self', false);
            window.alert("Pilih karyawan terlebih dahulu");
        }

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


        function changeRotation(x) {
            
            var selectedValue = x.options[x.selectedIndex].value;
            var iUnitKerja = "iUnitKerja" + tempSetInputID;
            var iJabatan = "iJabatan" + tempSetInputID;
            document.getElementById(iUnitKerja).value = UNITKERJA[selectedValue];
            document.getElementById(iJabatan).value = JABATAN[selectedValue];

            //window.alert(selectedValue);
        }

        /*untuk mengetahui bagian colapse mana yang akan di Set input text Unitkerja dan jabatan*/
        var tempSetInputID;
        function getInputID(i) {
            tempSetInputID = i;
            //window.alert(i);
        }

        /*on Close page*/
       // window.onbeforeunload = onClose();

        function onClose() {
            window.localStorage.clear();//clear local storage agar kembali ke posisi awal untuk memilih karyawan

            return null;
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
                               <asp:FileUpload ID="FileUpload2" runat="server" required="required" CssClass="form-control" />
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
                    <div class="form-group">
                        <div class="container">
                            <div class="col-lg-2 col-lg-offset-9" style="text-align:right">
                                <asp:Button ID="btnSK" runat="server" Text="Submit SK" CssClass="btn btn-primary form-inline" OnClick="BtnSK_OnClick"/>
                                <!--
                                <button type="button" class="btn btn-primary form-inline">Submit SK</button>
                                -->
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

                        <script>
                            var wrapper = document.getElementById("accordion");
                            var myHTML = '';
                            for (i = 0; i < n; i++) {

                                myHTML += '                         <div class="panel panel-default">';
                                myHTML += '                            <div class="panel-heading" style="background-color:#EC6459">';
                                myHTML += '                                <h4 class="panel-title">';
                                myHTML += '                                    <a href="#collapse' + i + '" data-parent="#accordion" onclick="getInputID('+i+')" data-toggle="collapse" class="accordion-toggle" style="color:white">';
                                myHTML += '                                        <i class="icon icon-plus-sign" style="float:right;font-size:x-large;margin-top:-5px"></i>';
                                myHTML += '                                        ' + NIK[i] + " - " + NAMA[i];
                                myHTML += '                                        ';
                                myHTML += '                                    </a>';
                                myHTML += '                                </h4>';
                                myHTML += '                            </div>';
                                myHTML += '                            <div class="panel-collapse collapse" id="collapse' + i + '">';
                                myHTML += '                                <div class="panel-body" style="background-color:#F7F8FC">';
                                myHTML += '                                    <div class="row">';
                                myHTML += '                                        <div class="col-lg-6">';
                                myHTML += '                                            <h4 style="text-align:center">';
                                myHTML += '                                                Biodata Karyawan';
                                myHTML += '                                            </h4>';
                                myHTML += '                                            <br/>';
                                myHTML += '                                            <div class="row">';
                                myHTML += '                                                <div class="form-group">';
                                myHTML += '                                                    <div class="container">';
                                myHTML += '                                                        <h5 class="col-lg-2 col-lg-offset-1">';
                                myHTML += '                                                            NIK';
                                myHTML += '                                                        </h5>';
                                myHTML += '                                                        <h5 class="col-lg-3">';
                                myHTML += '                                                            : ' + NIK[i];
                                myHTML += '                                                        </h5>';
                                myHTML += '                                                    </div>';
                                myHTML += '                                                </div>';
                                myHTML += '                                                <div class="form-group">';
                                myHTML += '                                                    <div class="container">';
                                myHTML += '                                                        <h5 class="col-lg-2 col-lg-offset-1">';
                                myHTML += '                                                            Nama Lengkap';
                                myHTML += '                                                        </h5>';
                                myHTML += '                                                        <h5 class="col-lg-3">';
                                myHTML += '                                                            : ' + NAMA[i];
                                myHTML += '                                                        </h5>';
                                myHTML += '                                                    </div>';
                                myHTML += '                                                </div>';
                                myHTML += '                                                <br/>';
                                myHTML += '                                                <div class="form-group">';
                                myHTML += '                                                    <div class="container">';
                                myHTML += '                                                        <h5 class="col-lg-2 col-lg-offset-1">';
                                myHTML += '                                                            Jabatan Lama';
                                myHTML += '                                                        </h5>';
                                myHTML += '                                                    </div>';
                                myHTML += '                                                </div>';
                                myHTML += '                                                <div class="form-group">';
                                myHTML += '                                                    <div class="container">';
                                myHTML += '                                                        <h5 class="col-lg-2 col-lg-offset-1">';
                                myHTML += '                                                            Unit Kerja';
                                myHTML += '                                                        </h5>';
                                myHTML += '                                                        <h5 class="col-lg-3">';
                                myHTML += '                                                            : ' + UNITKERJA[i];
                                myHTML += '                                                        </h5>';
                                myHTML += '                                                    </div>';
                                myHTML += '                                                </div>';
                                myHTML += '                                                <div class="form-group">';
                                myHTML += '                                                    <div class="container">';
                                myHTML += '                                                        <h5 class="col-lg-2 col-lg-offset-1">';
                                myHTML += '                                                            Jabatan';
                                myHTML += '                                                        </h5>';
                                myHTML += '                                                        <h5 class="col-lg-3">';
                                myHTML += '                                                            : ' + JABATAN[i];
                                myHTML += '                                                        </h5>';
                                myHTML += '                                                    </div>';
                                myHTML += '                                                </div>';
                                myHTML += '                                            </div>';
                                myHTML += '                                        </div>';
                                myHTML += ''
                                myHTML += '                                        <div class="col-lg-6" style="border-left:solid;border-color:#EC6459;border-width:2px">';
                                myHTML += '                                            <h4 style="text-align:center">';
                                myHTML += '                                                Tujuan Mutasi';
                                myHTML += '                                            </h4>';
                                myHTML += '                                            <br/>';
                                myHTML += '                                            <div class="row">';
                                myHTML += '                                                <div class="form-group">';
                                myHTML += '                                                   <div class="container">';
                                myHTML += '                                                        <div class="col-lg-12">';
                                myHTML += '					                                            <div class="row">';
                                myHTML += '						                                            <div class="form-group">';
                                myHTML += '							                                            <div class="container">';
                                myHTML += '							                                            	<h5 class="col-lg-2 col-lg-offset-1">';
                                myHTML += '							                                            		NIK/Nama Lengkap';
                                myHTML += '							                                            	</h5>';
                                myHTML += '							                                            	<div class="col-lg-3">';
                                myHTML += '									                                            <select id="selectRotation'+i+'" onchange="changeRotation(this);" aria-controls="editable-sample" class="form-control">';
                                                                                                                            var stats = 0;
                                                                                                                            var temp;
                                                                                                                            for (j = 0; j < n; j++) {
                                                                                                                                if (NIK[j] != NIK[i]) {
                                                                                                                                    if (stats == 0) {//untuk mengambil data pertama yang di select dan di tampilkan di unit kerja dan jabatan
                                                                                                                                        temp = j;
                                                                                                                                        stats++;
                                                                                                                                    }
                                myHTML += '										                                           <option value="'+j+'" selected="selected">' + NIK[j] + " - " + NAMA[j]+'</option>';
                                                                                                                                }
                                                                                                                            }
                                myHTML += '									                                             </select>';
                                myHTML += '								                                            </div>';
                                myHTML += '							                                            </div>';
                                myHTML += '						                                            </div>';
                                myHTML += '						                                            <div class="form-group">';
                                myHTML += '						                                        	    <div class="container">';
                                myHTML += '							                                        	    <h5 class="col-lg-2 col-lg-offset-1">';
                                myHTML += '							                                        		    Unit Kerja';
                                myHTML += '							                                        	    </h5>';
                                myHTML += '								                                            <div class="col-lg-3">';
                                myHTML += '								                                        	    <input type="text" class="form-control" required="required" id="iUnitKerja'+i+'" disabled="disabled" value="' + UNITKERJA[temp] + '"/>';
                                myHTML += '							                                        	    </div>';
                                myHTML += '						                                        	    </div>';
                                myHTML += '						                                            </div>';
                                myHTML += '						                                            <div class="form-group">';
                                myHTML += '							                                            <div class="container">';
                                myHTML += '							                            	                <h5 class="col-lg-2 col-lg-offset-1">';
                                myHTML += '									                                            Jabatan';
                                myHTML += '								                                            </h5>';
                                myHTML += '								                                            <div class="col-lg-3">';
                                myHTML += '								                                        	    <input type="text" class="form-control" required="required" id="iJabatan' + i + '" disabled="disabled" value="' + JABATAN[temp] + '"/>';
                                myHTML += '								                                            </div>';
                                myHTML += '							                                            </div>';
                                myHTML += '						                                            </div>';
                                myHTML += '					                                            </div>';
                                myHTML += '                                                         </div>';
                                myHTML += '                                                    </div>';
                                myHTML += '                                                </div>';
                                myHTML += '                                            </div>';
                                myHTML += '                                        </div>';
                                myHTML += '                                    </div>';
                                myHTML += '                                    <div class="row" id="btnTable" >';
                                myHTML += '                                        <div class="col-lg-3 col-lg-offset-9" style="text-align:right">';
                                myHTML += '                                            <button type="button" class="btn btn-primary" id="mutasi" onClick="submitMutasi(' + i + ')">Submit Rotasi</button>';
                                myHTML += '                                        </div>';
                                myHTML += '                                    </div>';
                                myHTML += '                                </div>';
                                myHTML += '                            </div>';
                                myHTML += '                        </div>';

                            }
                            wrapper.innerHTML = myHTML

                        </script>
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
