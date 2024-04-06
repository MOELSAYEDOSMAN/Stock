function deleteImage(button) {
    var id = $(button).data('id');
    var src = $(button).data('src');
    if (confirm("Are You Sure?")) {
        $.get("/Item/RemoveImage", { id: id, src: src }, function (data) {
            if (data == false || data == null) {
                alert("Not Found");
            } else {
                alert("Save Change");
                alert(data);

                $(button).closest('.d-grid').remove();
            }
        }.bind(button));
    }
}