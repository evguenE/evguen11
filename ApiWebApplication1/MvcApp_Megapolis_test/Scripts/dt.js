$(document).ready(function () {

    $('#example').dataTable({

        language: {
            "lengthMenu": "Показать _MENU_ записей на страницу",
            "info": "Показать _PAGE_ из _PAGES_ страниц",
            "search": "Поиск",
            "infoFiltered": "",
            "paginate": {
                "previous": "предыдущая",
                "next":     "следующая"
            },
            "processing": "<i class='fa fa-spinner fa-spin fa-3x'></i>",
            "emptyTable": "Данных нет в таблице"
        },
        dom: 'Bfrtip',
        buttons: [
              {
                  text: 'Добавить',
                  action: function (e, dt, node, config) {
                      $("#ok").text('Добавить');
                      $("#dialog").dialog({ title: "Добавить запись" });
                      $("#dialog").dialog("open");
                      $("#id").val(0);
                      $("#rout").val("");
                      $("#timeDep").val("");
                      $("#timeArr").val("");
                      $("#stop").val("");
                      $("#action").val("add");
                  }
              }
        ],
        "serverSide": true,
        "search": true,
        "pageLength": 10,
        "render": true,
        ajax: {
            url: "home/dataHandler",
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: function (data) {
                console.log(JSON.stringify(data));
                return data = JSON.stringify(data);
            }
        },
        "processing": true,
        "paging": true,
        "deferRender": true,
        columns: [
        { "data": "Id" },
        { "data": "rout" },
        { "data": "timeDep" },
        { "data": "timeArr" },
        { "data": "stop" },
        { "data": "" }
        ],
        columnDefs: [
             {
                 "targets": [0],
                 "visible": false
             },
            {
                "targets": -1,
                "width": "5%",
                "data": null,
                "sorting": false,
                "defaultContent": "<div align='center'><button type='button' id='edit' class='btn btn-default btn-xs'><span class='glyphicon glyphicon-pencil'></span></button>" +
                                  "<button type='button' id='del'  class='btn btn-default btn-xs'><span class='glyphicon glyphicon-trash'></span></button></div>"
            }
        ]
    });

    //edit
    $('#example tbody').on('click', '#edit', function () {
        $("#ok").text('Изменить');
        $("#dialog").dialog({ title: "Редактировать" });
        $("#dialog").dialog("open");
        var t = $('#example').DataTable();
        id = t.row($(this).parents('tr')).data().Id;

        $("#id").val(id);
        $("#rout").val(t.row($(this).parents('tr')).data().rout);
        $("#timeDep").val(t.row($(this).parents('tr')).data().timeDep);
        $("#timeArr").val(t.row($(this).parents('tr')).data().timeArr);
        $("#stop").val(t.row($(this).parents('tr')).data().stop);
        $("#action").val("update");

    });

    // Удаление
    $('#example tbody').on('click', '#del', function () {
        $("#ok").text('Удалить');
        $("#dialog").dialog({ title: "Хотите удалить запись ?" });
        $("#dialog").dialog("open");
        var t = $('#example').DataTable();
        id = t.row($(this).parents('tr')).data().Id;
        $("#id").val(id);
        $("#rout").val(t.row($(this).parents('tr')).data().rout);
        $("#timeDep").val(t.row($(this).parents('tr')).data().timeDep);
        $("#timeArr").val(t.row($(this).parents('tr')).data().timeArr);
        $("#stop").val(t.row($(this).parents('tr')).data().stop);
        $("#action").val("del");

    });

    $("#dialog").dialog({
        modal: true,
        bgiframe: true,
        width: 570,
        height: 400,
        autoOpen: false,
        dialogClass: 'DialogClass',
        buttons: [{
            id: "ok",
            text: 'Добавить',
            click: function () {
                $.ajax({
                    url: '/home/ActionRecord',
                    type: "POST",
                    data: { id_: $("#id").val(), rout_: $("#rout").val(), timeDep_: $("#timeDep").val(), timeArr_: $("#timeArr").val(), stop_: $("#stop").val(), action: $("#action").val() },
                    success: function (data) {
                        var table = $('#example').DataTable();
                        table.draw();
                    },
                })
                $(this).dialog("close");
            }
        },
        {
            id: "cancel",
            text: 'Отмена',
            click: function () {
                $(this).dialog("close");
            }
        }]
    });
})