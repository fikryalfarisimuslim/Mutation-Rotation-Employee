<%@ Page Title="Request for Approval" Language="C#" MasterPageFile="~/MasterPages/BackEndHorizontal.Master" AutoEventWireup="true" CodeBehind="RequestApprovalList.aspx.cs" Inherits="BioHR.Pages.Approval.RequestApprovalList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <!-- CONTENT PAGE START-->
    <div class="row">
        <div class="col-lg-12">
            <!-- BEGIN Breadcrumbs -->
            <ul class="breadcrumb">
                <li>
                    <a href="index.html"><i class="icon-home"></i> Home</a></li>
                <li><a href="#">Approval</a></li>
                <li class="active">List Approval Request</li>
            </ul>
            <!-- END Breadcrumbs -->
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    <span>List Permohonan Persetujuan</span>
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
                    <asp:GridView runat="server" ID="gvApprovalList" ClientIDMode="Static" CssClass="table table-striped table-bordered table-hover " OnPreRender="gvApprovalList_OnPreRender" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataSourceID="sdsApprovalDocument">
                        <Columns>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbDocid" ClientIDMode="Static" Text='<%# Eval("DOCID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbDocty" ClientIDMode="Static" Text='<%# Eval("DOCCD") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BEGDA" HeaderText="Tanggal Pengajuan" SortExpression="BEGDA" DataFormatString="{0:d}"></asp:BoundField>
                            <asp:BoundField DataField="PERNR" HeaderText="NIK" SortExpression="PERNR"></asp:BoundField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <i class="icon-user"></i> Nama
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbName" ClientIDMode="Static" Text='<%# Eval("CNAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PRPOS" HeaderText="Posisi" SortExpression="POSPR"/>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <i class="icon-sitemap"></i> Unit
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbUnit" ClientIDMode="Static" Text='<%# Eval("PRORG") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <i class="icon-book"></i>  Jenis Permohonan
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbDocumentType" ClientIDMode="Static" CssClass='<%# GetLabelClass(Eval("DOCCD")) %>' Text='<%# Eval("DOCTY") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DOCDSC" HeaderText="Keterangan"/>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="hlReviewDocument" ClientIDMode="Static" CssClass="btn btn-primary btn-xs w-24 tooltips" NavigateUrl='<%# GetReviewLink(Eval("DOCID"), Eval("DOCCD"), Eval("DOCURL")) %>' data-placement="top" data-toggle="tooltip" data-original-title="Review the Document"><i class="icon-edit"></i></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center">Tidak ada dokumen untuk di setujui</div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="sdsApprovalDocument" ConnectionString='<%$ ConnectionStrings:BioHRConnectionString %>' SelectCommand="bioHR.sp_WF_GET_DocumentsToApproved" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:SessionParameter SessionField="biofarma_userid" DefaultValue="" Name="pPERNR" Type="String"/>
                            <asp:SessionParameter SessionField="biofarma_positionid" DefaultValue="" Name="pPOSID" Type="String"/>
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <table class="table table-strip table-bordered table-hover" id="dataTable">
                        <thead>
                            <tr>
                                <th><i class="icon-bullhorn"></i> Tanggal </th>
                                <th><i class="icon-bullhorn"></i> NIK </th>
                                <th><i class="icon-bullhorn"></i> Nama </th>
                                <th><i class="icon-bullhorn"></i> Posisi </th>
                                <th><i class="icon-bullhorn"></i> Unit </th>
                                <th><i class=" icon-edit"></i> Jenis Permohonan </th>
                                <th><!-- <i class="icon-link"></i> Action --></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <a href="#">01/09/2014</a>
                                </td>
                                <td>K460</td>
                                <td>Awwal Mulyana</td>
                                <td>Karyawan Kontrak</td>
                                <td>System Development</td>
                                <td><span class="label label-primary label-mini">Absensi</span></td>
                                <td>
                                    <button class="btn btn-info btn-xs w-24"><i class="icon-edit"></i></button>
                                    <!-- <button class="btn btn-primary btn-xs"><i class="icon-pencil"></i></button>
                                        <button class="btn btn-danger btn-xs"><i class="icon-trash "></i></button> -->
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="#"> 02/09/2014 </a>
                                </td>
                                <td>K460</td>
                                <td>Awwal Mulyana</td>
                                <td>Karyawan Kontrak</td>
                                <td>System Development</td>
                                <td><span class="label label-primary label-mini">Absensi</span></td>
                                <td>
                                    <button class="btn btn-info btn-xs w-24"><i class="icon-edit"></i></button>
                                    <!-- <button class="btn btn-primary btn-xs"><i class="icon-pencil"></i></button>
                                        <button class="btn btn-danger btn-xs"><i class="icon-trash "></i></button> -->
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="#"> 03/09/2014 </a>
                                </td>
                                <td>K469</td>
                                <td>Allan Prakosa</td>
                                <td>Karyawan Kontrak</td>
                                <td>System Development</td>
                                <td><span class="label label-warning label-mini">Sakit</span></td>
                                <td>
                                    <button class="btn btn-warning btn-xs w-24"><i class="icon-edit"></i></button>
                                    <!-- <button class="btn btn-primary btn-xs"><i class="icon-pencil"></i></button>
                                        <button class="btn btn-danger btn-xs"><i class="icon-trash "></i></button> -->
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="#"> 04/09/2014 </a>
                                </td>
                                <td>K459</td>
                                <td>Ahmad Fauzi</td>
                                <td>Karyawan Kontrak</td>
                                <td>Infrastructure</td>
                                <td><span class="label label-primary label-mini">Absensi</span></td>
                                <td>
                                    <button class="btn btn-info btn-xs w-24"><i class="icon-edit"></i></button>
                                    <!-- <button class="btn btn-primary btn-xs"><i class="icon-pencil"></i></button>
                                        <button class="btn btn-danger btn-xs"><i class="icon-trash "></i></button> -->
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="#"> 04/09/2014 </a>
                                </td>
                                <td>K459</td>
                                <td>Ahmad Fauzi</td>
                                <td>Karyawan Kontrak</td>
                                <td>Infrastructure</td>
                                <td><span class="label label-danger label-mini">Ijin Keluar</span></td>
                                <td>
                                    <button class="btn btn-danger btn-xs w-24"><i class="icon-edit"></i></button>
                                    <!-- <button class="btn btn-primary btn-xs"><i class="icon-pencil"></i></button>
                                        <button class="btn btn-danger btn-xs"><i class="icon-trash "></i></button> -->
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="#"> 04/09/2014 </a>
                                </td>
                                <td>K459</td>
                                <td>Ahmad Fauzi</td>
                                <td>Karyawan Kontrak</td>
                                <td>Infrastructure</td>
                                <td><span class="label label-danger label-mini">Ijin Sakit</span></td>
                                <td>
                                    <button class="btn btn-danger btn-xs w-24"><i class="icon-edit"></i></button>
                                    <!-- <button class="btn btn-primary btn-xs"><i class="icon-pencil"></i></button>
                                        <button class="btn btn-danger btn-xs"><i class="icon-trash "></i></button> -->
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="#"> 02/09/2014 </a>
                                </td>
                                <td>K460</td>
                                <td>Awwal Mulyana</td>
                                <td>Karyawan Kontrak</td>
                                <td>System Development</td>
                                <td><span class="label label-primary label-mini">Absensi</span></td>
                                <td>
                                    <button class="btn btn-info btn-xs w-24"><i class="icon-edit"></i></button>
                                    <!-- <button class="btn btn-primary btn-xs"><i class="icon-pencil"></i></button>
                                        <button class="btn btn-danger btn-xs"><i class="icon-trash "></i></button> -->
                                </td>
                            </tr>
                            <!-- INSERT REST TABLE HERE -->
                            <!-- ** 1 ** -->
                            <!-- END INSERT -->
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
