﻿
$(function () {
    $("#tblDepartmanlar").DataTable(
        {
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
            }

        });

});

//$("#tblDepartmanlar").on("click", ".btnDepatmanSil",
//    function () {
//        var btn = $(this);
//        bootbox.confirm("Departmanı silmek istediğinize emin misiniz?",
//            function (result) {
//                if (result) {
//                    var id = btn.data("id");
//                    $.ajax({
//                        type: "GET",
//                        url: "/Departman/Sil/" + id,
//                        success: function () {
//                            btn.parent().parent().remove();
//                        }
//                    });

//                }
//            })
//    });
