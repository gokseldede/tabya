function Delete(url, id) {
    swal({
        title: "Silme İşlemi !",
        text: " Kaydınızı Silmek istediğinize emin misiniz?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Evet",
        closeOnConfirm: false,
        cancelButtonText: "Hayır"
    },
        function () {
            $.ajax({
                type: 'POST',
                url: url + id,
                success: function (result) {
                    debugger;
                    if (result.result === true) {
                        swal("Silindi!", " Kaydınız başarıyla silindi", "success");
                        $("#a_" + id).fadeOut(2000);
                    } else {
                        console.log("Silinemedi");
                    }
                }
            });
        });
}

function Status(url, id, status) {
    swal({
        title: "Aktifleştirme İşlemi !",
        text: " Kaydı " + ($(status).data("status") === "True" ? "pasifleştirmek" : "aktifleştirmek") + " istediğinize emin misiniz?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Evet",
        closeOnConfirm: false,
        cancelButtonText: "Hayır"
    },
        function () {
            $.ajax({
                type: 'POST',
                url: url + id,
                success: function (result) {
                    debugger;
                    if (result.result === true) {
                        $("#b_" + id).empty();
                        $("#b_" + id).data("status", result.status);
                        if (result.status === true) {
                            swal("Bilgi", "Kayıt Aktifleştirildi.", "success");
                            $("#b_" + id).append("<span class='btn btn-info btn-sm'>Aktif</span>");
                        } else {
                            swal("Bilgi", "Kayıt pasifleştirildi.", "success");
                            $("#b_" + id).append("<span class='btn btn-default btn-sm'>Pasif</span>");
                        }
                    } else {
                        swal("Uyarı", "Kayıt " + ($(status).data("status") === "True" ? "pasifleştirilemedi" : "aktifleştirilemedi") + ".", "warning");
                    }

                }
            });
        });
}

function Vitrin(url, id, status) {
    swal({
        title: "Vitrine Ekleme İşlemi !",
        text: " Kayıdı " + ($(status).data("status") === "True" ? "vitrinden kaldırmak" : "vitrine eklemek") + " istediğinize emin misiniz?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Evet",
        closeOnConfirm: false,
        cancelButtonText: "Hayır"
    },
        function () {
            $.ajax({
                type: 'POST',
                url: url + id,
                success: function (result) {
                    if (result.result === true) {
                        $("#c_" + id).empty();
                        $("#c_" + id).data("status", result.status);
                        if (result.status === true) {
                            swal("Bilgi", "Kayıt vitrine eklendi.", "success");
                            $("#c_" + id).append("<span class='btn btn-info btn-sm'>Vitrine Eklendi</span>");
                        } else {
                            swal("Bilgi", "Kayıt vitrinden kaldırıldı.", "success");
                            $("#c_" + id).append("<span class='btn btn-default btn-sm'>Vitrine Ekle</span>");
                        }
                    }
                    else {
                        swal("Uyarı", "Kayıt " + ($(status).data("status") === "True" ? "vitrinden kaldırılamadı!!!" : "vitrine eklenilmedi!!!") + "", "warning");
                    }
                }

            });
        });
}

function DeleteFile(url, item) {
    swal({
        title: "Fotoğraf Silme İşlemi !",
        text: "Fotorafı silmek istediğinizden emin misiniz?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Evet",
        closeOnConfirm: false,
        cancelButtonText: "Hayır"
    },
        function () {
            $.ajax({
                url: url,
                type: 'POST'
            }).done(function (data) {
                if (data.Result === true) {
                    $(item).closest('li').remove();
                    swal("Bilgi", "Fotoğraf silindi", "success");
                } else if (data.Result.Message) {
                    swal("Bilgi", "Fotoğraf silinemedi. Bilgi: " + data.Result.Message, "success");
                }
            }).fail(function () {
                swal("Uyarı", "Fotoğraf silme işlemi sırasında hata oluştu!!!", "warning");
            });
        });
}