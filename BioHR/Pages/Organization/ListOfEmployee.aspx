<%@ Page Title="List Of Employee" Language="C#" MasterPageFile="~/MasterPages/BackEndHorizontal.Master" AutoEventWireup="true" CodeBehind="ListOfEmployee.aspx.cs" Inherits="BioHR.Pages.Organization.ListOfEmployee" %>

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
        .dataTables_filter{
            float:right;
            margin-top:-10px;
            margin-right:-13px;
            width:100%;
        }
        .dataTables_filter input{
            max-width:60%;
        }
        
    </style>

    <script type='text/javascript'>
        var index = 1;//index yang dipilih agar tidak redundan
        
        document.onload = onLoad();

        function onLoad() {
            window.localStorage.clear();//clear local storage agar kembali ke posisi awal untuk memilih karyawan
        }
        /*Untuk menutup jendela terpilih*/
        function hideDiv() {
            if (document.getElementById) {
                document.getElementById('div').style.display = 'none';
            }
        }

        /*Memilih Karyawan*/
        function showDiv() {
            if (document.getElementById) {
                //var index = 0;
                document.getElementById('karyawanTerpilih').style.display = 'block';
                $('#daftar-karyawan').find('tr').each(function () {
                    var row = $(this);
                    if (row.find('input[type="checkbox"]').is(':checked')) {
                        var x = 0;
                        var table = document.getElementById("editable-sample2");
                        var rowCount = document.getElementById('editable-sample2').rows.length;
                        var row;
                        var cell1;
                        var cell2;
                        var cell3;
                        var cell4;
                        var cell5;
                        var cell6;
                        $(this).find("td").each(function () {
                            //data[0] = $(this).text();
                            // window.alert(x);

                            if (x == 1) {
                                row = table.insertRow(rowCount);
                                row.id = "row" + index;
                                cell1 = row.insertCell(0);
                                cell2 = row.insertCell(1);
                                cell3 = row.insertCell(2);
                                cell4 = row.insertCell(3);
                                cell5 = row.insertCell(4);
                                cell1.innerHTML = $(this).text();
                            } else if (x == 2) {
                                cell2.innerHTML = $(this).text();
                            } else if (x == 3) {
                                cell3.innerHTML = $(this).text();
                            } else if (x == 4) {
                                cell4.innerHTML = $(this).text();
                                cell5.innerHTML = '<input type="button" value="Hapus" class="btn btn-danger form-control" onclick="deleteRow(' + index + ')"/>';
                                index++;
                                //document.getElementById("daftar-karyawan").deleteRow(index);
                                $(this).closest("tr").remove();
                            }
                            x++;
                        });
                    }
                });
                $("#checkbox").prop("checked", false);
            }
        }


        function deleteRow(rowid) {
            var table = document.getElementById("daftar-karyawan");
            var rowCount = document.getElementById('daftar-karyawan').rows.length;
            var row = table.insertRow(rowCount);
            var cell1 = row.insertCell(0);
            var cell2 = row.insertCell(1);
            var cell3 = row.insertCell(2);
            var cell4 = row.insertCell(3);
            var cell5 = row.insertCell(4);

            var tr = document.getElementById('row' + rowid);
            var td = tr.getElementsByTagName("td");
            for (var i = 0; i < td.length; i++) {
                if (i == 0) {
                    cell1.innerHTML = "<input type='checkbox' class='mail-checkbox'/>";
                    cell2.innerHTML = td[i].innerHTML;
                } else if (i == 1) {
                    cell3.innerHTML = td[i].innerHTML;
                } else if (i == 2) {
                    cell4.innerHTML = td[i].innerHTML;
                } else if (i == 3) {
                    cell5.innerHTML = td[i].innerHTML;
                } else if (i == 4) {

                }
            }
            $('#row' + rowid).remove();
        }

        function checkAll(ele) {
            var checkboxes = document.getElementsByTagName('input');
            if (ele.checked) {
                for (var i = 0; i < checkboxes.length; i++) {
                    if (checkboxes[i].type == 'checkbox') {
                        checkboxes[i].checked = true;
                    }
                }
            } else {
                for (var i = 0; i < checkboxes.length; i++) {
                    
                    if (checkboxes[i].type == 'checkbox') {
                        checkboxes[i].checked = false;
                    }
                }
            }

        }
       
        var UNITKERJA = [];
        var JABATAN = [];
        var NIK = [];
        var NAMA = [];
        function submitPilih() {
            
            
            var e = document.getElementById("cpMainContent_DropDownListSK");
            var strUser = e.options[e.selectedIndex].value;
           
            
            if (strUser == 06) {//mutasi
                $('#editable-sample2').find('tr').each(function () {
                    var row = $(this);
                    //row.find("td").each(function () {
                    if (row.find('td')) {
                        var column = 1;
                        $(this).find("td").each(function () {
                            //window.alert($(this).text());
                            if (column == 1) {
                                UNITKERJA.push($(this).text());
                            } else if (column == 2) {
                                JABATAN.push($(this).text());
                            } else if (column == 3) {
                                NIK.push($(this).text());
                            } else if (column == 4) {
                                NAMA.push($(this).text());
                            }
                            column++;
                        });
                    }
                });
                window.localStorage.setItem("UNITKERJA", JSON.stringify(UNITKERJA)); // Saving
                window.localStorage.setItem("JABATAN", JSON.stringify(JABATAN)); // Saving
                window.localStorage.setItem("NIK", JSON.stringify(NIK)); // Saving
                window.localStorage.setItem("NAMA", JSON.stringify(NAMA)); // Saving
                window.open('MutationEmployee.aspx', '_self', false);
            } else if (strUser == 07) {
                $('#editable-sample2').find('tr').each(function () {
                    var row = $(this);
                    //row.find("td").each(function () {
                    if (row.find('td')) {
                        var column = 1;
                        $(this).find("td").each(function () {
                            //window.alert($(this).text());
                            if (column == 1) {
                                UNITKERJA.push($(this).text());
                            } else if (column == 2) {
                                JABATAN.push($(this).text());
                            } else if (column == 3) {
                                NIK.push($(this).text());
                            } else if (column == 4) {
                                NAMA.push($(this).text());
                            }
                            column++;
                        });
                    }
                });
                window.localStorage.setItem("UNITKERJA", JSON.stringify(UNITKERJA)); // Saving
                window.localStorage.setItem("JABATAN", JSON.stringify(JABATAN)); // Saving
                window.localStorage.setItem("NIK", JSON.stringify(NIK)); // Saving
                window.localStorage.setItem("NAMA", JSON.stringify(NAMA)); // Saving
                window.open('RotationEmployee.aspx', '_self', false);
            }
        }

        function searchFilter() {
            // Declare variables 
            var input, input2, filter, table, tr, td, td2, i, filter2, filter3;
            input = document.getElementById("iSearchNama");
            input2 = document.getElementById("iSearchUnit");
            filter = input.value.toUpperCase();
            filter2 = input2.value.toUpperCase();
            table = document.getElementById("daftar-karyawan");
            tr = table.getElementsByTagName("tr");

            // Loop through all table rows, and hide those who don't match the search query
            for (i = 0; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[4];
                td2 = tr[i].getElementsByTagName("td")[1];
                if (td) {
                    if ((td.innerHTML.toUpperCase().indexOf(filter) > -1) && (td2.innerHTML.toUpperCase().indexOf(filter2) > -1)) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
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

            $('#daftar-karyawan').dataTable({
                "bLengthChange": false,
                "bFilter": true,

                "aLengthMenu": [
                    [5, 15, 20, -1],
                    [5, 15, 20, "All"] // change per page values here
                ],
                // set the initial value
                "iDisplayLength": 10,
                "sDom": "<'row'<'col-lg-6'l><'col-lg-6'f>r>t<'row'<'col-lg-6'i><'col-lg-6'p>>",
                "sPaginationType": "bootstrap",
                "oLanguage": {
                    "sLengthMenu": "_MENU_ records per page",
                    "oPaginate": {
                        "sPrevious": "Prev",
                        "sNext": "Next"
                    }
                },
                "aoColumnDefs": [{
                    'bSortable': false,
                    'aTargets': [0]
                }]
            });
            $('div.dataTables_filter label').contents().first().remove();
            $('div.dataTables_filter input').addClass("form-control pull-right");
            $('div.dataTables_filter input').attr('placeholder', 'Cari Nama / NIK / Jabatan / Unit Kerja');
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
                <li class="active">Daftar Karyawan</li>
            </ul>
            <!-- END Breadcrumbs -->
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    <span>Daftar Karyawan</span>
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

                    <table class="table table-striped table-hover table-bordered" id="daftar-karyawan">
                        <thead>
                            <tr>
                                <th class="inbox-small-cells" style="text-align:center">
                                     <input type="checkbox" class="mail-checkbox" onchange="checkAll(this)" name="chk[]" />
                                </th>
                                <th>Unit Kerja</th>
                                <th>Jabatan</th>
                                <th>NIK</th>
                                <th>Nama</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
                        </tbody>
                    </table>
                    
                    <div class="row">
                        <div class="col-lg-1 col-lg-offset-11" >
                            <button id="select" type="button" class="btn btn-primary form-control" onclick="showDiv()">Pilih</button>
                        </div>
                    </div>

                </div>
            </section>


            <section class="panel">
                <header class="panel-heading">
                    <span>Karyawan Terpilih</span>
                    <div class="tools" style="float: right;">
                        <a href="javascript:;" class="icon-chevron-down"></a>
                        <a href="javascript:;" class="reload">
                            <i class="icon-refresh"></i>
                        </a>
                    </div>
                </header>
                <div class="panel-body" id="karyawanTerpilih" style="display:none;">
                    <table class="table table-striped table-hover table-bordered" id="editable-sample2">
                        <thead>
                            <tr>
                                <th>Unit Kerja</th>
                                <th>Jabatan</th>
                                <th>NIK</th>
                                <th>Nama</th>
                                <th>Aksi</th>
                            </tr>
                        </thead>
                        <tbody>
                            
                        </tbody>
                    </table>

                    <div class="row">
                        <div class="col-lg-3 col-lg-offset-8">
                            <asp:DropDownList CssClass="form-control"  ID="DropDownListSK" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-lg-1">
                            <button type="button" class="btn btn-primary form-control" onclick="submitPilih()">Submit</button>
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
