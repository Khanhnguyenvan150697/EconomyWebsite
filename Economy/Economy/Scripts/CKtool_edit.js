$(document).ready(function () {
    CKEDITOR.replace('txtNoidung_edit');
    $('#selectImg_edit').click(function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            //code js here
            $('#linkUrlImg_edit').val(fileUrl);
        };
        finder.popup();
    });
});