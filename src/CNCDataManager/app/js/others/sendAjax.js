//$('#file').change(function () {
//    let file = this.files[0];
//    name = file.name;
//    size = file.size;
//    type = file.type;

//    if (file.name.length < 1) {
//    }
//    else if (file.size > 100000) {
//        alert("The file is too big");
//    }
//    else if (file.type != 'image/png' && file.type != 'image/jpg' && file.type != 'image/gif' && file.type != 'image/jpeg') {
//        alert("The file does not match png, jpg or gif");
//    }
//    else {
//        $('#submit').click(function () {
//            let formData = new FormData($('#ajax-upload-form')[0]);
//            $.ajax({
//                url: 'api/cncdata/UploadImage/',  //server script to process data
//                type: 'POST',
//                xhr: function () {  // custom xhr
//                    myXhr = $.ajaxSettings.xhr();
//                    if (myXhr.upload) { // if upload property exists
//                        myXhr.upload.addEventListener('progress', progressHandlingFunction, false); // progressbar
//                    }
//                    return myXhr;
//                },
//                // Ajax events
//                success: completeHandler = function (data) {
//                    /*
//                    * Workaround for Chrome browser // Delete the fake path
//                    */
//                    if (navigator.userAgent.indexOf('Chrome')) {
//                        var catchFile = $("#file").val().replace(/C:\\fakepath\\/i, '');
//                    }
//                    else {
//                        var catchFile = $("#file").val();
//                    }
//                    var writeFile = $("#file");
//                    writeFile.html(writer(catchFile));
//                    //$("*setIdOfImageInHiddenInput*").val(data.logo_id);
//                },
//                error: errorHandler = function () {
//                    alert("Something went wrong!");
//                },
//                // Form data
//                data: formData,
//                // Options to tell jQuery not to process data or worry about the content-type
//                cache: false,
//                contentType: false,
//                processData: false
//            }, 'json');
//        });
//    }
//});

$(function () {
    $('#button').click(function () {
        var form = document.querySelector('#ajax-upload-form');
        var data = new FormData(form);
        $.ajax({
            url: '../api/cncdata/CNCMachineTypes',
            type: 'POST',
            data: data,
            processData: false,  // tell jQuery not to process the data
            contentType: false   // tell jQuery not to set contentType
        }).done(function (data) {
            var image = $('#upload-image');
            var url = data.ThumbNailUrl;
            image.attr('src', url);
        });
    });
});