$(document).ready(function () {
    CKEDITOR.replace('txtNoidung');
    $('#selectImg').click(function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            //code js here
            $('#linkUrlImg').val(fileUrl);
        };
        finder.popup();
    });
});