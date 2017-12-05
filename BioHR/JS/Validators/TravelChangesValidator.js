$(document).ready(function () {
    $('#form1').bootstrapValidator({
        container: 'tooltip',
        submitButtons: btnSubmit,
        feedbackIcons: {
            valid: 'icon-ok',
            invalid: 'icon-remove',
            validating: 'icon-refresh'
        },
        fields: {
            [tbDateFrom]: {
                group: '.group',
                validators: {
                    notEmpty: {
                        message: 'Tanggal Berangkat Kosong.'
                    }
                }
            },
            [tbDateTo]: {
                validators: {
                    notEmpty: {
                        message: 'Tanggal Selesai Kosong.'
                    },
                    callback: {
                        message: 'Tanggal Selesai Harus Lebih Dari Tanggal Berangkat',
                        callback: function (value, validator) {
                            var start = new Date(Date.parse($(idDateFrom).val()));
                            start.setDate(start.getDate());
                            var endDate = new Date(Date.parse(value));
                            endDate.setDate(endDate.getDate());

                            return endDate >= start;
                        }
                    }
                }
            }
        }
    });
}).on('success.form.bv', function (e) {
    // Prevent submit form
    e.preventDefault();
    $('#formConfirmation').modal('toggle');


});