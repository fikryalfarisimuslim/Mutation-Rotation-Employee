$("#tbExpenseByAdmin").maskMoney();
$("#tbDailyCost").maskMoney('mask');
if ($("#hdnTravelType").val() == "PDLN") {
    $("#kurs").show();
    $($("#rblInn input")[0]).attr("disabled", true);
    $($("#rblInn input")[1]).attr("disabled", true);
    $($("#rblInn input")[0]).prop("checked", true);
};

function GetCheckboxCombination() {
    var result = "";
    $.each($("input[type='checkbox']"), function () {
        if ($(this).is(':checked'))
            result += $(this).val();
        else
            result += '0';
    });
    return result;
}
var dailyCost = 0;
function GetDailyCost() {
    $.ajax({
        'async': false,
        type: "POST",
        url: "TravelChanges.aspx/GetTravelDailyCost",
        data: "{ beginDate: '" + $('.dp6').val() + "',travelType: '" + hdnTravelType + "',travelCode: '" + $("#hdnDocumentCode").val() + "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            dailyCost = data.d;
        },
        failure: function () {
            alert("Failed!");
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return dailyCost;
};
var percentageCost = '{ "percentage": "1" }';
function GetPercentageCost() {
    $.ajax({
        'async': false,
        type: "POST",
        url: "TravelChanges.aspx/GetPercentageCost",
        data: "{ beginDate: '" + $('.dp6').val() + "',travelType: '" + hdnTravelType + "',combination: '" + GetCheckboxCombination() + "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            percentageCost = data.d;
        },
        failure: function () {
            alert("Failed!");
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    return percentageCost;
};
var start = $('.dp6').datepicker({
    format: 'dd-mm-yyyy'
}).on('changeDate', function (ev) {
    start.hide();
    $('.dp7')[0].focus();
    if ($('.dp7').val() != "") {
        $('#form1').data('bootstrapValidator').revalidateField(tbDateFrom);
        $('#form1').data('bootstrapValidator').revalidateField(tbDateTo);
        var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
        var dayCount = Math.round((end.date.valueOf() - ev.date.valueOf()) / (oneDay)) + 1;
        $('#daysCount').text(dayCount + " hari");
    }
    if ($('#form1').data('bootstrapValidator').isValid()) {
        if ($('.dp7').val() != "") {
            var dayCount = $('#daysCount').text().split(' ');
            var cost = GetDailyCost();
            cost = $.parseJSON(cost);
            cost = cost["dailyCost"] * dayCount[0];
            $("#hdnDailyCost").val(cost);
            percentage = GetPercentageCost();
            percentage = $.parseJSON(percentage);
            percentage = percentage["percentage"];
            percentage = percentage * cost
            $('#tbDailyExpense').text(percentage);
            $('#tbDailyExpense').maskMoney('mask');
            $('#tbDailyExpense').click();
            //$('#pvCost').show();
        }
    }
}).data('datepicker');

var end = $('.dp7').datepicker({
    format: 'dd-mm-yyyy'
}).on('changeDate', function (ev) {
    end.hide();
    var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
    var dayCount = Math.round((ev.date.valueOf() - start.date.valueOf()) / (oneDay)) + 1;
    $('#daysCount').text(dayCount + " hari");
    $('#form1').data('bootstrapValidator').revalidateField(tbDateFrom);
    $('#form1').data('bootstrapValidator').revalidateField(tbDateTo);
    if ($('#form1').data('bootstrapValidator').isValid()) {
        if ($('.dp6').val() != "") {
            console.log('masuk');
            var cost = GetDailyCost();
            cost = $.parseJSON(cost);
            cost = cost["dailyCost"] * dayCount;
            $("#hdnDailyCost").val(cost);
            
            percentage = GetPercentageCost();
            percentage = $.parseJSON(percentage);
            percentage = percentage["percentage"];
            percentage = percentage * cost
            $('#tbDailyExpense').val(percentage);
            $('#tbDailyExpense').maskMoney('mask');
            $('#tbDailyExpense').click();
        }
    }
}).data('datepicker');

$("#btnCopy").click(function () {
    $("#tbExpenseByAdmin").val($('#tbDailyExpense').val());
    $('#tbExpenseByAdmin').maskMoney('mask');
    $("#tbExpenseByAdmin").click();
    return false;
});
$('[data-toggle="tooltip"]').tooltip();
$("input[type='checkbox']").change(function () {
    var percentage = 1;
    $('#form1').data('bootstrapValidator').revalidateField(tbDateFrom);
    $('#form1').data('bootstrapValidator').revalidateField(tbDateTo);
    if ($('.dp6').val() != "" && $('.dp7').val() != "") {
        percentage = GetPercentageCost();
        percentage = $.parseJSON(percentage);
        percentage = percentage["percentage"];
        
    }
    var cost = $("#hdnDailyCost").val();
    percentage = percentage * cost
    $('#tbDailyExpense').val(percentage);
    $('#tbDailyExpense').maskMoney('mask');
    $('#tbDailyExpense').click();
    //$('#pvCost').show();
});
$("input[type='radio']").change(function () {
    var travelCode = $("input[type='radio']:checked").val() + $("#hdnDocumentCode").val().substring(1);
    $("#hdnDocumentCode").val(travelCode)
    if ($('.dp6').val() != "" && $('.dp7').val() != "") {
        $('#form1').data('bootstrapValidator').revalidateField(tbDateFrom);
        $('#form1').data('bootstrapValidator').revalidateField(tbDateTo);
        var dayCount = $('#daysCount').text().split(' ')[0];
        var cost = GetDailyCost();
        cost = $.parseJSON(cost);
        cost = cost["dailyCost"] * dayCount;
        $("#hdnDailyCost").val(cost);
                
        percentage = GetPercentageCost();
        percentage = $.parseJSON(percentage);
        percentage = percentage["percentage"];
        percentage = percentage * cost;
        $('#tbDailyExpense').val(percentage);
        $('#tbDailyExpense').maskMoney('mask');
        $('#tbDailyExpense').click();
        
    }
});
$(document).ready(function () {
    $('td.day.active').click();
});