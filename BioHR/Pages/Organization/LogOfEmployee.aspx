<%@ Page Title="Log Of Employee" Language="C#" MasterPageFile="~/MasterPages/BackEndHorizontal.Master" AutoEventWireup="true" CodeBehind="LogOfEmployee.aspx.cs" Inherits="BioHR.Pages.Organization.LogOfEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <style type="text/css">
        .gvclass table th {text-align:center;}
        .col-lg-2 label {
            line-height:35px;
            width:100%;
        }
        .col-lg-2 label select {
            float:right;
            margin-left:5px;
            width:60%;
        }

        .dataTables_paginate.paging_bootstrap.pagination {
            margin-right:0px !important;
        }

        .adv-table .dataTables_info, .dataTables_paginate {
            padding:0px !important;
        }

        .dataTables_info{
            padding:0px !important;
        }
    </style>

    <script type = "text/javascript">
        function getValueStartDate() {
            $(document).ready(function () {

                $('#iStartDate').daterangepicker({
                    singleDatePicker: true,
                    showDropdowns: true,
                    iStartDate: moment()
                });

            });
        }

        function getValueEndDate() {
            $(document).ready(function () {

                $('#iEndDate').daterangepicker({
                    singleDatePicker: true,
                    showDropdowns: true,
                    iEndDate: moment()
                });

            });
        }

        function searchKategori() {
            // Declare variables 
            var input, filter, table, tr, td, td2, i, select, filter2;
            input = document.getElementById("iSearchKategori");
            select = document.getElementById("selectNoKategori");

            filter = input.value.toUpperCase();
            filter2 = select.options[select.selectedIndex].value.toUpperCase();

            table = document.getElementById("log-karyawan");
            tr = table.getElementsByTagName("tr");


            if (filter2 == "NO") {
                for (i = 0; i < tr.length; i++) {
                    td = tr[i].getElementsByTagName("td")[1];
                    if (td) {
                        if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                            tr[i].style.display = "";
                        } else {
                            tr[i].style.display = "none";
                        }
                    }

                }
            } else if (filter2 == "KATEGORI") {
                for (i = 0; i < tr.length; i++) {
                    td = tr[i].getElementsByTagName("td")[4];
                    if (td) {
                        if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                            tr[i].style.display = "";
                        } else {
                            tr[i].style.display = "none";
                        }
                    }

                }
            }
        }

        function searchTanggal() {
            // Declare variables 
            var input, input2, filter, filter2, filter3, table, tr, td, td2, i, select;
            input = document.getElementById("iStartDate");
            input2 = document.getElementById("iEndDate");
            select = document.getElementById("selectTanggal");

            filter = input.value.toUpperCase();
            filter2 = input2.value.toUpperCase();
            filter3 = select.options[select.selectedIndex].value.toUpperCase();

            var startDate = filter;
            var parseStartDate = new Date(startDate);

            var endDate = filter2;
            var parseEndDate = new Date(endDate);

            table = document.getElementById("log-karyawan");
            tr = table.getElementsByTagName("tr");

            if (filter3 == "SK") {
                for (i = 0; i < tr.length; i++) {
                    td = tr[i].getElementsByTagName("td")[0];
                    if (td) {
                        var parseTableTanggal = new Date(td.innerHTML);
                        //var tableTanggal = td.innerHTML.split("/");
                        //var parseTableTanggal = new Date(tableTanggal[2], tableTanggal[1] - 1, tableTanggal[0]);
                        if (parseTableTanggal >= parseStartDate && parseTableTanggal <= parseEndDate) {
                            tr[i].style.display = "";
                        } else {
                            tr[i].style.display = "none"
                        }
                    }
                }
            } else if (filter3 == "BERLAKU") {
                for (i = 0; i < tr.length; i++) {
                    td = tr[i].getElementsByTagName("td")[2];
                    if (td) {
                        var parseTableTanggal = new Date(td.innerHTML);
                        //var tableTanggal = td.innerHTML.split("/");
                        //var parseTableTanggal = new Date(tableTanggal[2], tableTanggal[1] - 1, tableTanggal[0]);
                        if (parseTableTanggal >= parseStartDate && parseTableTanggal <= parseEndDate) {
                            tr[i].style.display = "";
                        } else {
                            tr[i].style.display = "none"
                        }
                    }
                }
            }
        }
    </script>
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <!-- CONTENT PAGE START-->

    <script type="text/javascript">
        $(document).ready(function () {

            $('#log-karyawan').dataTable({
                "bLengthChange": false,
                "bFilter": false,


            });
               
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
                <li class="active">Log Karyawan</li>
            </ul>
            <!-- END Breadcrumbs -->
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    <span>Log Karyawan</span>
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
                    <div class="row">
                        <div class="col-lg-2">
                            <input type="text" aria-controls="editable-sample" class="form-control" placeholder="Search" id="iSearchKategori"/>
                        </div>
                        <div class="col-lg-2">
                            <select class="form-control" id="selectNoKategori">
                                <option value="" disabled selected>-- Pilih Kategori --</option>
                                <option value="No">No SK</option>
                                <option value="Kategori">Kategori</option>
                            </select>
                        </div>
                        <div class="col-lg-1" id="btnKategori" onclick="searchKategori()">
                            <button type="button" class="btn btn-primary">Cari</button>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input type="text" class="form-control" id="iStartDate" placeholder="tanggal mulai"/>
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-danger date-set" id="btnStartDate" onclick="getValueStartDate()">
                                        <i class="icon-calendar">
                                        </i>
                                    </button>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input type="text" class="form-control" id="iEndDate" placeholder="tanggal berakhir"/>
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-danger date-set" id="btnEndDate" onclick="getValueEndDate()">
                                        <i class="icon-calendar">
                                        </i>
                                    </button>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <select class="form-control" id="selectTanggal">
                                <option value="" disabled selected>-- Pilih Tanggal --</option>
                                <option value="SK">Tanggal SK</option>
                                <option value="Berlaku">Tanggal Berlaku</option>
                            </select>
                        </div>
                        <div class="col-lg-1" id="btnTanggal" onclick="searchTanggal()">
                            <button type="button" class="btn btn-primary">Cari</button>
                        </div>
                    </div>

                    <br />
                   
                    <table class="table table-striped table-hover table-bordered" id="log-karyawan">
                        <thead>
                            <tr>
                                <th>Tanggal SK</th>
                                <th>No SK</th>
                                <th>Tanggal Berlaku</th>
                                <th>Judul SK</th>
                                <th>Kategori</th>
                                <th>Dokumen SK</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                            <!--
                            <tr class="">
                                <td>04/01/2017</td>
                                <td>A1</td>
                                <td>04/04/2017</td>
                                <td>Mutasi Divisi SDM ke IT </td>
                                <td>Mutasi</td>
                                <td><a class="file" href="javascript:;">SK-A1.pdf</a></td>
                            </tr>
                            <tr class="">
                                <td>03/01/2017</td>
                                <td>A2</td>
                                <td>03/04/2017</td>
                                <td>Rotasi Divisi SDM ke IT </td>
                                <td>Rotasi</td>
                                <td><a class="file" href="javascript:;">SK-A2.pdf</a></td>
                            </tr>
                            <tr class="">
                                <td>02/01/2017</td>
                                <td>A3</td>
                                <td>02/04/2017</td>
                                <td>Rotasi Divisi SDM ke IT </td>
                                <td>Rotasi</td>
                                <td><a class="file" href="javascript:;">SK-A3.pdf</a></td>
                            </tr>
                            <tr class="">
                                <td>01/01/2017</td>
                                <td>A4</td>
                                <td>01/04/2017</td>
                                <td>Mutasi Divisi SDM ke IT </td>
                                <td>Mutasi</td>
                                <td><a class="file" href="javascript:;">SK-A4.pdf</a></td>
                            </tr>
                            -->
                        </tbody>
                    </table>
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

