/*


$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });

        return false;
    };

    var submitAutocompleteForm = function (event, ui) {

        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    };

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-autocomplete"),
            select: submitAutocompleteForm
        };

        $input.autocomplete(options);
    };

    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-target");
            $(target).replaceWith(data);
        });
        return false;

    };

    $("form[data-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-autocomplete]").each(createAutocomplete);

    $(".main-content").on("click", ".pagedList a", getPage);


});

*/

/*---------------------*/


var autoComp = function () {

    var submitAutocompleteForm = function(event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);
        var $form = $input.parents('form:first');
        $form.submit();
    }
    var createAutocomplete = function () {
        var $input = $(this);
        var options = {
            source: $input.attr('data-elab-autocomplete'),
            select : submitAutocompleteForm
        };
        $input.autocomplete(options);
    };
    $('input[data-elab-autocomplete]').each(createAutocomplete);

}
    

    var frmPost = function(frmId, btnId, postUrl) {
        $(btnId).click(function(e) {
            e.preventDefault();
            var formData = new FormData($(frmId)[0]);
            $.ajax({
                url: postUrl,
                type: 'POST',
                xhr: function() {
                    var myXhr = $.ajaxSettings.xhr();
                    if (myXhr.upload) {
                    }
                    return myXhr;
                },
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                success: function(d) {
                    $.ajax({
                        url: d.redirectUrl,
                        type: 'GET',
                        success: function(q) {
                            $('#list').html(q);
                        }
                    });
                }
            });
        });
    };

    function readfile(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function(e) {
                $('#img-pre').attr('src', e.target.result);
            };
            reader.readAsDataURL(input.files[0]);
        }
    };



    var getPage = function () {
        var $a = $(this);
        var options = {
            url: $a.attr('href'),
            type: 'get'
        };
        $.ajax(options).done(function (data) {
            var target = $a.parents('div.pagedList').attr('data-target');
            $(target).replaceWith(data);
        });
        return false;
    };
    $('.main-content').on('click', '.pagedList a', getPage);
