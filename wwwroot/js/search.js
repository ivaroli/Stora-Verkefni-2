var check = "<span class=\"glyphicon glyphicon-ok\"></span>"

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

        if(item.type != "Authors"){
            var stars = "";
            for(var j = 0; j < item.rating; j++){
                stars += "<span class=\"glyphicon glyphicon-star\"> ";
            }

            console.log(stars);
            

            html += "<h5 id=\"stars-book\">Stars: " + stars +"</h5>\n";
            html += "<h5 id=\"book-price\">Price: " + item.price + " euro</h5>\n"
        }

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

$(document).on('click','.sugestion-list li',function(event){
    if(event.target.id == "active_tag"){
        return;
    }

    var current_active_tag = $("#active_tag");

    $(current_active_tag).removeAttr('id');
    $(current_active_tag).removeClass("active");
    $("span.glyphicon-ok").remove();

    event.target.id = "active_tag";
    $(event.target).addClass("active");
    $(event.target).append(check);

    $("#search_bar").trigger( "input" );//
});