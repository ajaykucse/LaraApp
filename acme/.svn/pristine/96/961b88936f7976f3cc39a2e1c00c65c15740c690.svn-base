$('body').on('click', '.mylayoutpage', function (e) {

    //e.preventDefault();

    //$(this).attr('data-target', '#myFormModal');
    //$(this).attr('data-toggle', 'modal');
    ////$("#txtTag").val("NEW");
    ////var tableId = $("#" + e.target.id).find('table:first').attr("id");

    //console.log(e.target.id);
    //$(this).attr('href');
    //-------- ONE PAGE APPLICATION --------
    $("#mylayoutpage").empty();
    $.ajax({
        url: $(this).attr('url'),
        datatype: "json",
        type: "post",
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#mylayoutpage").html(data);
        },
        error: function (xhr) {
            alert('error');
        }
    });
});
$('body').on('click', '.mypartialpage', function (e) {
    $.ajax({
        url: $(this).attr('url'),
        datatype: "json",
        type: "post",
        contenttype: 'application/json; charset=utf-8',
        async: true,
        success: function (data) {
            $("#mymodels").html(data);
            $("#myFormModal").modal('show');
            $('#SpnTag').text("EDIT");
        },
        error: function (xhr) {
            alert('error');
        }
    });
});

$("#myFormModal").on('hidden.bs.modal', function () {
    $('#mymodels', this).empty();
});

$('body').confirmation({
    rootSelector: 'body',
    selector: '[data-toggle=confirmation]'
});

$(document).ready(function () {
    //---------- FOR BOOTSTRAP TOOLTIP -----------
    $('[data-toggle="tooltip"]').tooltip();

    $('body').on('click', '#btnMasterSave,#btnMasterSaveClose', function (e) {
        $("#btnMasterSave,#btnMasterSaveClose").prop("disabled", true);
        var formData = {
            Tag: $('#TxtTag').val(),
            AccountGrpId: $('#TxtId').val(),
            AccountGrpDesc: $('#TxtDescription').val(),
            AccountGrpShortName: $('#TxtShortName').val(),
            GrpType: $('#CmbType').val(),
            PrimaryGrp: $('#CmbPrimaryGroup').val(),
            Schedule: $('#TxtSchedule').val(),
            Status: $('#CbActive').is(":checked") ? true : false,
            EnterBy:'san',
            Gadget:"Web"
        };
        $.ajax({
            url: '/master/SaveAccountGroup',
            datatype: "json",
            type: "post",
            contenttype: 'application/json; charset=utf-8',
            data: formData,
            async: true,
            success: function (data) {
                $("#btnMasterSave,#btnMasterSaveClose").prop("disabled", false);
                $('#lblmessage').show();
                $("#lblmessage").removeClass();
                if ($(data).text() !== '') {
                    $("#lblmessage").text("Data successfully saved.");
                    $('#lblmessage').addClass('alert alert-success');
                    $("#lblmessage").fadeTo(1000, 500).slideUp(500, function () {
                        $("#lblmessage").slideUp(500);
                    });
                    $("#TxtDescription").val('');
                    $("#TxtShortName").val('');
                    $("#TxtSchedule").val('99');
                }
                else {
                    $("#lblmessage").text("Eerror occurred during data submission.");
                    $('#lblmessage').addClass('alert alert-danger');
                }
                $("#TxtDescription").focus();
            },
            error: function (xhr) {
                alert('error');
            }
        });
    });
});

$('body .modal').on('shown.bs.modal', function (e) {
    if ($('#TxtTag').val() === "NEW") {
        $('#btnMasterSave').css("display","inline");
    }
    else {
        $('#btnMasterSave').css("display","none");
    }
    $('#' + $(this).attr('id')).find(':input[type=text]').not(':input[readonly]').filter(':visible:first').focus();
    var id = $('#' + $(this).attr('id')).find(':input[type=text]').not(':input[readonly]').filter(':visible:first').attr('id');
});