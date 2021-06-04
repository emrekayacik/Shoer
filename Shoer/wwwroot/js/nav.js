$(document).ready(() => {
    $('#navbar-main').show();
});

var lastScrollTop = 0;
$(window).scroll(function (event) {
    var st = $(this).scrollTop();
    if (st > lastScrollTop) {
        $('#navbar-main').hide("slow");

    } else {
        $('#navbar-main').show("slow");
    }
    lastScrollTop = st;
});

goRegister = () => {
    window.location.href = $('#urlRegister').val();
};
goList = () => {
    window.location.href = $('#urlList').val();
};