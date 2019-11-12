$(document).ready(function () {
    CKEDITOR.replace('txtBlogContent');
    $('#imgThumbnail').click(function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            //code js here
            $('#linkUrlImgThumb').val(fileUrl);
        };
        finder.popup();
    });
});