function search(obj, callback)
{
    $.post("Home/Search", obj, function(result){
        callback(result);
    });
}

function createObject()
{
    var obj = {
        Search: $("#search_bar").val(),
        Genre: $("#search_concept").text(),
        Tag: $("#active_tag").text()
    };

    return obj;
}

function generateHtml(obj)
{
    var length = Object.keys(obj).length;
    var html = "";

    for(var i = 0; i < length; i++){
        var item = obj[i];
        html += "<a href=\"/" + item.type + "/Details/" + item.id + "\">\n";
        html += "<div class=\"col-md-4 \">\n";
        html += "<div class=\"book-div-frontpage\">\n";
        html += "<img class=\"book-img\" src=\"" + item.image + "\" alt=\"" + item.name + "\" id=\"book-img\">\n";
        html += "<h3 class=\"book-title frontpage-title\" id=\"book-title\">" + item.name + "</h3>\n";
        html += "</div>\n";
        html += "</div>\n";
        html += "</a>\n";
    }

    return html;
}

$(document).ready(function(e) {
    $('#search_bar').on('input',function(e){
        var obj = createObject();
        console.log(JSON.stringify(obj));

        search(obj, function(result){
            console.log(JSON.stringify(result));
            var html = generateHtml(result);

            $("#main_row a").remove();
            $("#main_row").append(html);
        });
    });
});