<%@ Page Title="Config Machine Attendance" Language="C#" MasterPageFile="~/MasterPages/BackEndHorizontal.Master" AutoEventWireup="true" CodeBehind="ConfigMachineAttendance.aspx.cs" Inherits="BioHR.Pages.MachineAttendance.ConfigMachineAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <style type="text/css">
        .gvclass table th {text-align:center;}
    </style>

    <script type="text/javascript">
        function getConfirmation(sender, title, message) {
            $("#spnTitle").text(title);
            $("#spnMsg").text(message);
            $('#modalPopUp').modal('show');
            $('#BottonDelete_Alert').attr('onclick', "$('#modalPopUp').modal('hide');setTimeout(function(){" + $(sender).prop('href') + "}, 50);");
            return false;
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
                <li><a href="#">ESS Management</a></li>
                <li><a href="#">Administrasi Presensi</a></li>
                <li class="active">Config Mesin Presensi</li>
            </ul>
            <!-- END Breadcrumbs -->
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    <span>Config Mesin Presensi</span>
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
                            <div class="col-md-1" style="text-align:right">
                                <asp:Button ID="ButtonAdd" runat="server" Text="Tambah" Class="btn btn-info form-control" OnClick="btnAdd_Click" />
                            </div>

                            <div class="col-md-5">

                            </div>

                            <div class="col-md-3" style="text-align:right">
                                <asp:TextBox ID="tbSearch" runat="server" CssClass="form-control" placeholder="Search" ontextchanged="tbSearch_TextChanged">

                                </asp:TextBox>
                            </div>
                            <div class="col-md-2" style="text-align:right">
                                <asp:DropDownList ID="ddlTipeMesin" runat="server" CssClass="form-control">
                                    <asp:ListItem Enabled="true" Text="Aktif" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Tidak Aktif" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1" style="text-align:left">
                                <asp:LinkButton ID="ButtonSearch" runat="server" CssClass="btn btn-info form-inline" OnClick="btnSearch_Click">
                                    <i class="icon icon-search"></i>
                                </asp:LinkButton>
                            </div>
                            
                        </div>
                    </div>
                    
                    <!--
                    <div class="panel-body">
                        <div id="modalPopUp" class="modal fade" role="dialog">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <h4 class="modal-title">
                                            <span id="spnTitle" style="font:bold">
                                            </span>
                                        </h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>
                                            <span id="spnMsg">
                                            </span>
                                        </p>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="ButtonClose_Alert" runat="server" Text="Tutup" Class="btn btn-default" data-dismiss="modal" />
                                        <asp:Button ID="BottonDelete_Alert" runat="server" Text="Hapus" Class="btn btn-danger" /> 
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    -->


                    <div class="panel-body">
                        <div class="gvclass">
                        <asp:GridView ID="gvConfigMachineAttendance" runat="server" CssClass="table table-strip table-bordered" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" >
                            <HeaderStyle BackColor="#F1F2F7" />
                            <Columns>
                                    <asp:BoundField DataField="MCHNM" HeaderText="Nama Mesin"/>
                                <asp:BoundField DataField="MCHIP" HeaderText="IP Mesin" />
                                <asp:BoundField DataField="MCHPRT" HeaderText="Port Mesin" />
                                <asp:BoundField DataField="GRTYP" HeaderText="Tipe Mesin" />
                                <asp:BoundField DataField="DESCR" HeaderText="Deskripsi Mesin" />
                                <asp:TemplateField HeaderText="Tes Koneksi">
                                    <ItemTemplate>
                                        <div class="=row" style="text-align:center">
                                            <div class="col-md-12">
                                                <asp:LinkButton ID="ButtonTest" runat="server" CssClass="btn btn-info form-inline" OnClick="btnTest_Click">
                                                    <i class="icon icon-signal">&nbsp;Test</i>
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Aksi">
                                    <ItemTemplate>
                                        <div class="row" style="text-align:center">
                                            <div class="col-md-6">
                                                <asp:LinkButton ID="ButtonEdit" runat="server" CssClass="btn btn-warning form-inline" CommandArgument='<%# "id="+Eval("MCHID")+"&name="+Eval("MCHNM")+"&ip="+Eval("MCHIP")+"&port="+Eval("MCHPRT")+"&tipe="+Eval("GRTYP")+"&des="+Eval("DESCR")%>' OnClick="btnEdit_Click" >
                                                     <i class="icon icon-edit">&nbsp;Edit</i>
                                                </asp:LinkButton>

                                                <%-- <asp:Button ID="ButtonEdit" runat="server" CommandArgument='<%# "id="+Eval("MCHID")+"&name="+Eval("MCHNM")+"&ip="+Eval("MCHIP")+"&port="+Eval("MCHPRT")+"&tipe="+Eval("GRTYP")+"&des="+Eval("DESCR")%>' Text="Edit" Class="btn btn-warning btn-xs w-50" OnClick="btnEdit_Click"/> --%>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:LinkButton ID="ButtonDelete" runat="server" CssClass="btn btn-danger form-inline" CommandArgument='<%# Eval("MCHID")%>' OnClick="btnDelete_Click">
                                                    <i class="icon icon-trash">&nbsp;Hapus</i>
                                                </asp:LinkButton>

                                                <%-- <asp:Button ID="ButtonDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%# Eval("MCHID")%>' Text="Hapus" Class="btn btn-danger btn-xs w-50"  /> --%>
                                                 <!-- <asp:Button ID="Button1" runat="server" OnClick="btnDelete_Click" CommandArgument='<%# Eval("MCHID")%>' Text="Hapus" Class="btn btn-danger btn-xs w-50" OnClientClick="return getConfirmation(this, 'PERHATIAN','Apakah anda yakin ingin menghapus?');" /> -->
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