function Delete(url, id) {
    swal({
        title: "Silme İşlemi !",
        text: " Kaydınızı Silmek istediğinize emin misiniz?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Evet",
        closeOnConfirm: false,
        cancelButtonText: "Hayır",
    },
    function () {
        $.ajax({
            type: 'POST',
            url: url + id,
            success: function () {
                swal("Silindi!", " Kaydınız başarıyla silindi", "success");

                $("#a_" + id).fadeOut(2000);
            }
        })

    });

}

function Status(url, id) {
    $.ajax({
        type: 'POST',
        url: url + id,
        success: function (result) {
            debugger;
            if (result.result == true) {
                if (result.status == false) {
                    $("#b_" + id).empty();
                    $("#b_" + id).append("<span class='btn btn-info btn-sm'>Aktif</span>")

                }
                else {
                    $("#b_" + id).empty();
                    $("#b_" + id).append("<span class='btn btn-default btn-sm'>Pasif</span>")
                }
            }
        }
    })

}

function Vitrin(url, id) {
    $.ajax({
        type: 'POST',
        url: url + id,
        success: function (result) {

            if (result == true) {
                $("#c_" + id).empty();
                $("#c_" + id).append("<span class='btn btn-info btn-sm'>Vitrine Eklendi</span>")

            }
            else {
                $("#c_" + id).empty();
                $("#c_" + id).append("<span class='btn btn-default btn-sm'>Vitrine Ekle</span>")
            }
        }

    })

}


$('.deleteItem').click(function (e) {
    e.preventDefault();
    var $ctrl = $(this);
    if (confirm('Dosyayı silmek istiyor musunuz?')) {
        $.ajax({
            url: '/Admin/AdDetails/DeleteFile',
            type: 'POST',
            data: { id: $(this).data('id') }
        }).done(function (data) {
            if (data.Result == "OK") {
                $ctrl.closest('li').remove();
            }
            else if (data.Result.Message) {
                alert(data.Result.Message);
            }
        }).fail(function () {
            alert("Silme işleminde hata oluştu.");
        })

    }
});

$('.deleteIteml').click(function (e) {
    e.preventDefault();
    var $ctrl = $(this);
    if (confirm('Dosyayı silmek istiyor musunuz?')) {
        $.ajax({
            url: '/Admin/Land/DeleteFile',
            type: 'POST',
            data: { id: $(this).data('id') }
        }).done(function (data) {
            if (data.Result == "OK") {
                $ctrl.closest('li').remove();
            }
            else if (data.Result.Message) {
                alert(data.Result.Message);
            }
        }).fail(function () {
            alert("Silme işleminde hata oluştu.");
        })

    }
});

$('.deleteItemw').click(function (e) {
    e.preventDefault();
    var $ctrl = $(this);
    if (confirm('Dosyayı silmek istiyor musunuz?')) {
        $.ajax({
            url: '/Admin/Workplace/DeleteFile',
            type: 'POST',
            data: { id: $(this).data('id') }
        }).done(function (data) {
            if (data.Result == "OK") {
                $ctrl.closest('li').remove();
            }
            else if (data.Result.Message) {
                alert(data.Result.Message);
            }
        }).fail(function () {
            alert("Silme işleminde hata oluştu.");
        })

    }
});

$('.deleteItemb').click(function (e) {
    e.preventDefault();
    var $ctrl = $(this);
    if (confirm('Dosyayı silmek istiyor musunuz?')) {
        $.ajax({
            url: '/Admin/Building/DeleteFile',
            type: 'POST',
            data: { id: $(this).data('id') }
        }).done(function (data) {
            if (data.Result == "OK") {
                $ctrl.closest('li').remove();
            }
            else if (data.Result.Message) {
                alert(data.Result.Message);
            }
        }).fail(function () {
            alert("Silme işleminde hata oluştu.");
        })

    }
});

$('.deleteItemp').click(function (e) {
    e.preventDefault();
    var $ctrl = $(this);
    if (confirm('Dosyayı silmek istiyor musunuz?')) {
        $.ajax({
            url: '/Admin/Projects/DeleteFile',
            type: 'POST',
            data: { id: $(this).data('id') }
        }).done(function (data) {
            if (data.Result == "OK") {
                $ctrl.closest('li').remove();
            }
            else if (data.Result.Message) {
                alert(data.Result.Message);
            }
        }).fail(function () {
            alert("Silme işleminde hata oluştu.");
        })

    }
});
