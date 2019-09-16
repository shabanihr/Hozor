$(document).ready(function () {

    //About Uploader
    $('#form_UploadFile').serialize();
    var val = $("#imgEdit").val();
    if (val != "") {
        $('#firstImg').addClass('fileupload-exists').removeClass('fileupload-new');
        $('#showimg').prepend('<img />');
        $('#showimg').children('img').attr('src', val);
    }
    $('#remove').click(function () {
        $('#firstImg').addClass('fileupload-new').removeClass('fileupload-exists');
        $('#showimg').children('img').attr('src', '@Url.Content("~/Uploads/noimage.png")');
    });
});