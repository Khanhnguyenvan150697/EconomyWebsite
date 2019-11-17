$(document).ready(function () {
    $('#btnChooseImg').off('click').on('click', function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            $('#imgAvatar').val(url);
            $('#firgureImg').append('<div><img src="' + url + '" /><a href="#" class="deleteImg" width="100"><i class="fa fa-times" aria-hidden="true"></i></a></div>');
            $('.deleteImg').off('click').on('click', function (e) {
                e.preventDefault();
                $(this).parent().remove();
            });
        };
        finder.popup();
    });
});
