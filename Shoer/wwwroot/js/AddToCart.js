
var doPost = (id) => {
    $.ajax({
        url: '/Cart/AddToCart',
        data: {
            'Id': id
        },
        type: "post",
        cache: false,
        success: function (result) {
            if (result) {
                toastr.success("Succesfully added to Cart.");
            }
            else {
                alert(result.Message);
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });
};