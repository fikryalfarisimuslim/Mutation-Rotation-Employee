﻿jQuery(document).ready(function () {
    DataTable.init();
});
//$.fn.dataTable.moment('dd mm yyyy');
var DataTable = function () {
    return {
        init: function () {
            $('#gvPresenceData').dataTable({
                 //"responsive" : true,
                // "ajax": "objects.txt",
                //"sAjaxSource": "objects.txt",
                //"ajax": {
                //    async: true,
                //    url: "objects.txt",
                //    data: "{}",
                //    contentType: "application/json; charset=utf-8",
                //    dataType: "json"
                //},
                "aLengthMenu": [
				    [5, 15, 20, -1],
				    [5, 15, 20, "All"] // change per page values here
                ],
                // set the initial value
                "iDisplayLength": 15,
                "sDom": "<'row'<'col-lg-6'l><'col-lg-6'f>r>t<'row'<'col-lg-6'i><'col-lg-6'p>>",
                "sPaginationType": "bootstrap",
                "oLanguage": {
                    "sLengthMenu": "_MENU_ records per page",
                    "oPaginate": {
                        "sPrevious": "Prev",
                        "sNext": "Next"
                    }
                },
                "aaSorting": [],
                "bSort": false
                //"aoColumnDefs": [{ aSort: false, aTargets: [0] }]
                //"aoColumnDefs": [{ aSort: false, aTargets: [0] }]
            });

            $('#gvPresenceData_wrapper .dataTables_filter input').addClass("form-control medium"); // modify table search input
            $('#gvPresenceData_wrapper .dataTables_length select').addClass("form-control xsmall"); // modify table per page dropdown
        }

    };
}();