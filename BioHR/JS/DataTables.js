jQuery(document).ready(function () {
	DataTable.init();
});

var DataTable = function () {
	return {
		init: function () {
			$('#dataTable').dataTable({
				"responsive" : true,
				"ajax": "objects.txt",
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
				"iDisplayLength": 5,
				"sDom": "<'row'<'col-lg-6'l><'col-lg-6'f>r>t<'row'<'col-lg-6'i><'col-lg-6'p>>",
				"sPaginationType": "bootstrap",
				"oLanguage": {
					"sLengthMenu": "_MENU_ records per page",
					"oPaginate": {
						"sPrevious": "Prev",
						"sNext": "Next"
					}
				},
				"aoColumnDefs": [
				    {
				    	'mData': "namaMaterial",
				    	'aTargets': [0]
				    },
				    {
				    	'mData': "noBatch",
				    	'aTargets': [1]
				    },
				    {
				    	'mData': "gin",
				    	'aTargets': [2]
				    },
				    {
				    	'mData': null,
				    	'aTargets': [3]
				    },
				    {
				    	'mData': null,
				    	'aTargets': [4]
				    },
				    {
				    	'mData': "tglDatang",
				    	'aTargets': [5]
				    },
					{
						'mData': "status",
						'bSortable': false,
						'aTargets': [6],
						'render': function (data, type, full) {
						//'fnRender': function (oObjt, sVal) {
						//'render': function (data, type, full) {
							return '<span class="label label-warning label-mini">' + data + '</span>'
						}
					}
				]
			});

			$('#dataTable_wrapper .dataTables_filter input').addClass("form-control medium"); // modify table search input
			$('#dataTable_wrapper .dataTables_length select').addClass("form-control xsmall"); // modify table per page dropdown
		}

	};
}();