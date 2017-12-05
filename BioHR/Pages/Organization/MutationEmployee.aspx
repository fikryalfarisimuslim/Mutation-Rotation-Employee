<%@ Page Title="Mutation Employee" Language="C#" MasterPageFile="~/MasterPages/BackEndHorizontal.Master" AutoEventWireup="true" CodeBehind="MutationEmployee.aspx.cs" Inherits="BioHR.Pages.Organization.MutationEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    
    <style type="text/css">
        .dataTables_filter{
            float:right;
            margin-top:-15px;
            margin-right:-13px;
            width:55%;
        }
        .dataTables_filter input{
            max-width:70%;
        }
        .dataTables_length label:empty, .dataTables_filter label:empty {
            display:none !important;
        }

        .dataTables_paginate.paging_bootstrap.pagination {
            margin-right:0px !important;
            margin-top:15px !important;
            margin-bottom:15px !important;
        }

        .adv-table .dataTables_info, .dataTables_paginate {
            padding:0px !important;
        }

        .dataTables_info{
            padding:0px !important;
        }
    </style>


    <script type = "text/javascript">
        var UNITKERJA = JSON.parse(window.localStorage.getItem("UNITKERJA")); // Retrieving
        var JABATAN = JSON.parse(window.localStorage.getItem("JABATAN")); // Retrieving
        var NIK = JSON.parse(window.localStorage.getItem("NIK")); // Retrieving
        var NAMA = JSON.parse(window.localStorage.getItem("NAMA")); // Retrieving
        var i, j, n, x;
        n = NIK.length;
        
        function getValueTanggalSK() {
            $(document).ready(function () {

                $('#iTanggalSK').daterangepicker({
                    singleDatePicker: true,
                    showDropdowns: true,
                    iTanggalSK: moment()
                });

            });
        }

        function getValueTanggalBerlaku() {
            $(document).ready(function () {
                
                $("#iTanggalBerlaku").daterangepicker({
                    singleDatePicker: true,
                    showDropdowns: true,
                    iTanggalBerlaku: moment()
                });

            });
        }

        function showDiv() {
            if (document.getElementById) {
                
                document.getElementById('btnTable').style.display = 'block';
                document.getElementById('tableCek').style.display = 'block';
            }
        }

        function showDiv2() {
            if (document.getElementById) {

                document.getElementById('btnTable2').style.display = 'block';
                document.getElementById('tableCek2').style.display = 'block';
            }
        }

        function showDiv3() {
            if (document.getElementById) {

                document.getElementById('btnTable3').style.display = 'block';
                document.getElementById('tableCek3').style.display = 'block';
            }
        }

        function submitMutasi(noTable) {
            $('#ListEmptyPosition' + noTable).find('tr').each(function () {
                var row = $(this);
                if (row.find('input[type="radio"]').is(':checked')) {
                    var x = 0;
                    var id, namajabatan;
                   
                    $(this).find("td").each(function () {
                        if (x == 1) {
                            id = $(this).text();
                        } else if (x == 2) {
                            namajabatan = $(this).text();
                        } 
                        x++;
                    });
                    window.alert(id + namajabatan);
                }
            });
        }
     

    </script>
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <!-- CONTENT PAGE START-->
    <script type="text/javascript">
       
            $(document).ready(function () {
                for (i = 0; i < n; i++) {
                $('#ListEmptyPosition'+i).dataTable({
                    "bLengthChange": false,
                    "bFilter": true,
                        
                    "aLengthMenu": [
                    [5, 15, 20, -1],
                    [5, 15, 20, "All"] // change per page values here
                    ],

                    // set the initial value
                    "iDisplayLength": 5,
                    //"sDom": "<'row'<'col-lg-6'l><'col-lg-6'f>r>t<'row'<'col-lg-6'i><'col-lg-6'p>>",
                    "sPaginationType": "bootstrap",
                    "oLanguage": {
                        "sLengthMenu": "_MENU_ records per page",
                        "oPaginate": {
                            "sPrevious": "Prev",
                            "sNext": "Next",
                        "sSearch": ""
                        }
                        
                    },
                    "aoColumnDefs": [{
                        'bSortable': false,
                        'aTargets': [0]
                    }]
                });
                //$('div.dataTables_filter label').contents().first().remove();
                $('div.dataTables_filter input').addClass("form-control pull-right");
                $('div.dataTables_filter input').attr('placeholder', 'Cari ID / Jabatan');
                }
            });
       


    </script>

    <div class="row">
        <div class="col-lg-12">
            <!-- BEGIN Breadcrumbs -->
            <ul class="breadcrumb">
                <li>
                    <a href="index.html"><i class="icon-home"></i> Home</a></li>
                <li><a href="#">Company Management</a></li>
                <li><a href="#">Struktur Organisasi</a></li>
                <li class="active">Mutasi Karyawan</li>
            </ul>
            <!-- END Breadcrumbs -->
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    <span>Mutasi Karyawan</span>
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
                    <span>SK Mutasi</span>
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
                                        <asp:LinkButton ID="btnCekNoSK" runat="server" CssClass="btn btn-danger" OnClick="getValueNoSK">
                                            <i class="icon-check-sign"></i>
                                        </asp:LinkButton>
                                    </span>
                                    
                                </div>

                                <!--
                                <br style="display:block"/>
                                
                                <div class="alert alert-success fade in">
                                    <button data-dismiss="alert" class="close close-sm" type="button">
                                        <i class="icon-remove"></i>
                                    </button>
                                </div>
                                -->

                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="container">
                            <label class="control-label col-lg-2 col-lg-offset-1 col-md-2 col-md-offset-1 col-sm-2 col-sm-offset-1">Tanggal SK</label>
                            <div class="col-lg-8 col-md-8 col-sm-8">
                                <div class="input-group">
                                    <input type="text" class="form-control" required="required" id="iTanggalSK" runat="server" value="" ClientIDMode="Static"/>
                                        <span class="input-group-btn">
                                        <button type="button" class="btn btn-danger" id="btnTanggalSK" runat="server" ClientIDMode="Static" onclick="getValueTanggalSK()">
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
                                <input type="text" class="form-control" required="required" id="iJudulSK" runat="server" value="Mutasi" disabled="disabled"/>
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
                                    <input type="text" class="form-control" required="required" id="iTanggalBerlaku" runat="server" value="" ClientIDMode="Static"/>
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
                    <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
                     <script>
                         var KODE = [];
                         var NAMAJABATAN = [];
                         $('#tableHidden').find('tr').each(function () {
                             var row = $(this);
                             //row.find("td").each(function () {
                             if (row.find('td')) {
                                 var column = 1;
                                 $(this).find("td").each(function () {
                                     //window.alert($(this).text());
                                     if (column == 1) {
                                         KODE.push($(this).text());
                                     } else if (column == 2) {
                                         NAMAJABATAN.push($(this).text());
                                     }
                                     column++;
                                 });
                             }
                         });
                         x = KODE.length;
                        </script>
                    <div id="accordion" class="panel-group m-bot20">
                        
                        <script>
                            var wrapper = document.getElementById("accordion");
                            var myHTML = '';
                            for (i = 0; i < n; i++) {
                                
                                myHTML += '                         <div class="panel panel-default">';
                                myHTML += '                            <div class="panel-heading" style="background-color:#EC6459">';
                                myHTML += '                                <h4 class="panel-title">';
                                myHTML += '                                    <a href="#collapse' + i + '" data-parent="#accordion" data-toggle="collapse" class="accordion-toggle" style="color:white">';
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
                                myHTML += '                                                            : '+ UNITKERJA[i];
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
                                //myHTML += '                                                   <div class="container">';
                                myHTML += '                                                        <div class="col-lg-12">';
                                myHTML += '                                                             <table class="table table-hover table-bordered" id="ListEmptyPosition'+i+'" style="background-color:white">';
                                myHTML += '                                                                 <thead>';
                                myHTML += '                                                                     <tr>';
                                myHTML += '                                                                          <th></th>';
                                myHTML += '                                                                          <th>ID</th>';
                                myHTML += '                                                                          <th>Jabatan</th>';
                                myHTML += '                                                                      </tr>';
                                myHTML += '                                                                  </thead>';
                                myHTML += '                                                                  <tbody>';
                                                                                                                for (j = 0; j < x; j++) {
                                myHTML += '                                                                          <tr><td style="text-align:center"><input type="radio" name="radios"/></td><td>' + KODE[j] + '</td>';
                                myHTML += '                                                                          <td>'+NAMAJABATAN[j]+'</td></tr>';
                                                                                                                }
                                myHTML += '                                                                  </tbody>';
                                myHTML += '                                                             </table>';
                                myHTML += '                                                         </div>';
                                //myHTML += '                                                    </div>';
                                myHTML += '                                                </div>';
                                myHTML += '                                            </div>';
                                myHTML += '                                        </div>';
                                myHTML += '                                    </div>';
                                myHTML += '                                    <div class="row" id="btnTable" >';
                                myHTML += '                                        <div class="col-lg-3 col-lg-offset-9" style="text-align:right">';
                                myHTML += '                                            <button type="button" class="btn btn-danger" id="mutasi" onClick="submitMutasi('+i+')">Submit</button>';
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

            <br />
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
