$(document).ready(function () {
	
 $('.xxx tbody').scroll(function (e) {
        $('.xxx thead').css("left", -$("tbody").scrollLeft());
    });

    $('[data-toggle="tooltip"]').tooltip();
    //-------- BIND DATATABLE JQUERY ----------
    if ($('#myJqueryDataTable').length > 0) {
        $("#myJqueryDataTable").append($('<tfoot />').append($("#myJqueryDataTable thead tr").clone()));
        $('#myJqueryDataTable tfoot th').each(function (i) {
            var title = $('#myJqueryDataTable thead th').eq($(this).index()).text();
            if (title !== "#") {
                $(this).html('<input type="text" placeholder="' + title + '" class="txtDataTableSearch" />');
            }
        });

        var table = $('#myJqueryDataTable').DataTable({
            colReorder: true,
            "autoWidth": false,
            "pageLength": 50,
            dom: '<"datatabletoolbar">Bfrtip',
            buttons: [
                {
                    text: 'ADD NEW',
                    action: function (e, dt, node, config) {
                        $.ajax({
                            url: '/master/frmaccountgroup',
                            datatype: "json",
                            type: "post",
                            contenttype: 'application/json; charset=utf-8',
                            async: true,
                            success: function (data) {
                                $("#mymodels").html(data);
                                $("#myFormModal").modal('show');
                                $('#SpnTag').text("NEW");
                            },
                            error: function (xhr) {
                                alert('error');
                            }
                        });
                    }
                },
                {
                    extend: 'copy',
                    exportOptions: {
                        columns: ':visible'
                    },
                },
                {
                    extend: 'excel',
                    exportOptions: {
                        columns: ':visible'
                    },
                    title: 'Tender Notice List'
                },
                {
                    extend: 'pdf',
                    exportOptions: {
                        columns: ':visible'
                    },
                    title: 'Tender Notice Lis'
                },
                {
                    extend: 'print',
                    title: 'Tender Notice Lis',
                    exportOptions: {
                        columns: ':visible'
                    },
                    customize: function (win) {
                        $(win.document.body).find('table').addClass('display').css('font-size', '9px');
                        $(win.document.body).find('tr:nth-child(odd) td').each(function (index) {
                            $(this).css('background-color', '#D0D0D0');
                        });
                        $(win.document.body).find('h1').css({ "text-align": "center", "font-size": "15px", "font-weight": "bold" });
                    }
                },
                'colvis'
            ],
            "columnDefs": [{
                "targets": '_all',
                "createdCell": function (td, cellData, rowData, row, col) {
                    $(td).css('padding', '5px 5px 5px 5px');
                }
            }]
        });
        $("div.datatabletoolbar").html('<h4>' + $('#myJqueryDataTable').attr('title')+'</h4>');
        $("#myJqueryDataTable").width("100%");

        $("#myJqueryDataTable tfoot input").on('keyup change', function () {
            table
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });
        //-------- BIND DATATABLE JQUERY ----------
    }
});