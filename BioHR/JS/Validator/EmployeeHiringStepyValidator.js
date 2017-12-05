$(document).ready(function() {
    console.log("masuk");
    $('#form1').bootstrapValidator({
            container: 'tooltip',
            submitButtons: '.button-next',
            feedbackIcons: {
                valid: 'icon icon-ok',
                invalid: 'icon icon-remove',
                validating: 'icon icon-refresh'
            },
            fields: {
                [txtNamaPanggilan]: {
                    validators: {
                        notEmpty: {
                            message: 'Nama Panggilan Karyawan Belum Diisi'
                        }
                    }
                },
                [txtTempatLahir]: {
                    validators: {
                        notEmpty: {
                            message: 'Tempat Lahir Karyawan Belum Diisi'
                        }
                    }
                },
                [txtTanggalLahir]: {
                    validators: {
                        notEmpty: {
                            message: 'Tanggal Lahir Karyawan Belum Diisi'
                        }
                    }
                },
                [ddlJenis]: {
                    validators: {
                        notEmpty: {
                            message: 'Jenis Kelamin Karyawan Belum Diisi'
                        }
                    }
                },
                [ddlReligion]: {
                    validators: {
                        notEmpty: {
                            message: 'Agama Karyawan Belum Diisi'
                        }
                    }
                },
                [ddlNationality]: {
                    validators: {
                        notEmpty: {
                            message: 'Kebangsaan Karyawan Belum Diisi'
                        }
                    }
                },
                [ddlMaritalStatus]: {
                    validators: {
                        notEmpty: {
                            message: 'Marital Status Karyawan Belum Diisi'
                        }
                    }
                },
                [txtNomorNPWP]: {
                    validators: {
                        notEmpty: {
                            message: 'Nomor NPWP Belum Diisi'
                        }
                    }
                },
                [txtTanggalNPWP]: {
                    validators: {
                        notEmpty: {
                            message: 'Tanggal NPWP Belum Diisi'
                        }
                    }
                }
            }
    });
//}).on('success.form.bv', function (e) {
//    // Prevent submit form
//    //e.preventDefault();
//    //var $active = $('.wizard .nav-tabs li.active');
//    //$active.next().removeClass('disabled');
//    //var $active = $('.wizard .nav-tabs li.active');
//    //nextTab($active);
//    //$('#cmbModal').modal('toggle');


});