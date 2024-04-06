//Store
$('.deleteStore').click(function (e) {
    e.preventDefault();
    var id = $(this).data('id');
    $('#store-to-delete').val(id);
});
$('#btnContinueDelete').click(function () {
    var id = $('#store-to-delete').val();
    if (id != null) {
        $.get("/Store/RemoveStore", { id: id }, function (data) {

            if (data == false) {
                alert("Not Found");
            } else {
                alert("Save Change");
                window.location.href = "/Store/Index";
            }

        });
    }
});


//Item
$('.deleteItem').click(function (e) {
    e.preventDefault();
    var id = $(this).data('id');
    $('#Item-to-delete').val(id);
});
$('#btnContinueDelete').click(function () {
    var id = $('#Item-to-delete').val();
    if (id != null) {
        $.get("/Item/RemoveItem", { id: id }, function (data) {

            if (data == false) {
                alert("Not Found");
            } else {
                alert("Save Change");
                window.location.href = "/Item/Index";
            }

        });
    }
});