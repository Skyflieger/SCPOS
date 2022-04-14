let index = 0;

function addWindow(id, url, title, type){
    jQuery(id).click(function () {
        {
            jQuery.ajax({
                type: "GET",
                url: url,
                data: {
                    id: index,
                    title: title,
                    type: type
                },
                success: function (result) {
                    index += 1;
                    jQuery("#main").append(result);
                },
            });
        }
    });
}