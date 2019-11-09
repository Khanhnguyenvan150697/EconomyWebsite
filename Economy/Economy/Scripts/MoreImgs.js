$(document).ready(function () {
    CKEDITOR.replace('txtDetail');

    // img1
    $('#selectImg1').off('click').on('click', function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            //code js here
            $('#linkUrlImg1').val(url);
        };
        finder.popup();
    });

    // img2
    $('#selectImg2').off('click').on('click', function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            //code js here
            $('#linkUrlImg2').val(url);
        };
        finder.popup();
    });

    // img3
    $('#selectImg3').off('click').on('click', function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            //code js here
            $('#linkUrlImg3').val(url);
        };
        finder.popup();
    });

    // img4
    $('#selectImg4').off('click').on('click', function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            //code js here
            $('#linkUrlImg4').val(url);
        };
        finder.popup();
    });

    // img5
    $('#selectImg5').off('click').on('click', function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            //code js here
            $('#linkUrlImg5').val(url);
        };
        finder.popup();
    });
});