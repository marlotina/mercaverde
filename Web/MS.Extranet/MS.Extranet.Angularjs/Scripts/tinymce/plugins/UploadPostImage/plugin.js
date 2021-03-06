tinymce.PluginManager.add("UploadPostImage", function (a, b) {
    a.addButton("UploadPostImage", {
            icon: "image",
            tooltip: "Insert image",
            onclick: function() {
                a.windowManager.open({
                    title: "Insert image33",
                    url: b + "/dialog.html",
                    width: 500,
                    height: 150,
                    buttons: [
                        {
                            text: "Ok",
                            classes: 'widget btn primary first abs-layout-item',
                            onclick: function() {
                                var b = a.windowManager.getWindows()[0];

                                if (b.getContentWindow().document.getElementById('content').value == '') {
                                    alert('Please select a file');
                                    return false;
                                }

                                if (b.getContentWindow().document.getElementById('content').files[0].size > 1000 * 1024) {
                                    alert('Max image file size is 1MB');
                                    return false;
                                }

                                if (b.getContentWindow().document.getElementById('content').files[0].type != "image/jpeg" && b.getContentWindow().document.getElementById('content').files[0].type != "image/jpg" &&
                                    b.getContentWindow().document.getElementById('content').files[0].type != "image/png" && b.getContentWindow().document.getElementById('content').files[0].type != "image/gif") {
                                    alert('Only image file format can be uploaded');
                                    return false;
                                }

                                var data;

                                data = new FormData();
                                data.append('file', b.getContentWindow().document.getElementById('content').files[0]);

                                $.ajax({
                                    url: '/api/Post/UploadImage',
                                    data: data,
                                    processData: false,
                                    contentType: false,
                                    async: false,
                                    type: 'POST',
                                }).done(function(msg) {
                                    var imageAlt = b.getContentWindow().document.getElementById('desc').value;
                                    var imageTag = '<img src="' + msg + '" alt="' + imageAlt + '" style="max-width: 100%;" />';
                                    a.insertContent(imageTag), b.close();

                                }).fail(function(jqXHR, textStatus) {
                                    alert("Request failed: " + jqXH.responseText + " --- " + RtextStatus);
                                });
                            }
                        },
                        {
                            text: "Close",
                            onclick: "close"
                        }
                    ]
                });
            }
        }),
        a.addMenuItem("UploadPostImage", {
            icon: "image",
            text: "Insert image",
            context: "insert",
            prependToContext: !0,
            onclick: function() {
                a.windowManager.open({
                    title: "Insert image",
                    url: b + "/api/Post/UploadImage",
                    width: 500,
                    height: 150,
                    buttons: [
                        {
                            text: "Ok",
                            classes: 'widget btn primary first abs-layout-item',
                            onclick: function() {
                                var b = a.windowManager.getWindows()[0];

                                if (b.getContentWindow().document.getElementById('content').value == '') {
                                    alert('Please select a file');
                                    return false;
                                }

                                if (b.getContentWindow().document.getElementById('content').files[0].size > 1000 * 1024) {
                                    alert('Max image file size is 1MB');
                                    return false;
                                }

                                if (b.getContentWindow().document.getElementById('content').files[0].type != "image/jpeg" && b.getContentWindow().document.getElementById('content').files[0].type != "image/jpg" &&
                                    b.getContentWindow().document.getElementById('content').files[0].type != "image/png" && b.getContentWindow().document.getElementById('content').files[0].type != "image/gif") {
                                    alert('Only image file format can be uploaded');
                                    return false;
                                }

                                var data;

                                data = new FormData();
                                data.append('file', b.getContentWindow().document.getElementById('content').files[0]);

                                $.ajax({
                                    url: '/api/Post/UploadImage',
                                    data: data,
                                    processData: false,
                                    contentType: false,
                                    async: false,
                                    type: 'POST',
                                }).done(function(msg) {
                                    var imageAlt = b.getContentWindow().document.getElementById('desc').value;
                                    var imageTag = '<img src="' + msg + '" alt="' + imageAlt + '" style="max-width: 100%;" />';
                                    a.insertContent(imageTag), b.close();

                                }).fail(function(jqXHR, textStatus) {
                                    alert("Request failed: " + jqXH.responseText + " --- " + RtextStatus);
                                });
                            }
                        }, {
                            text: "Close",
                            onclick: "close"
                        }
                    ]
                });
            }
        });

});