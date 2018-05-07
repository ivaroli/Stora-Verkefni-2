function getBooks(search, callback)
{
    $.post("/Books/Search", {searchInput: search}, function(result){
        callback(result);
    });
}

function getAuthors(search)
{
    $.post("/Authors/Search", {search}, function(result){
    });
}

function generate_html(obj){
    $(".tableRow").remove();
    var length = Object.keys(obj).length
    for(var i = 0; i < length; i++)
    {
        var item = obj[i];
        var html = "<tr class=\"tableRow\">\n";
        html += "<td class=\"col-1\">" + item.title + "</td>\n";
        html += "<td class=\"col-2\">" + item.id + "</td>\n";
        html += "<td class=\"col-3\"><span class=\"glyphicon glyphicon-pencil icon\"></span></td>\n";
        html += "<td class=\"col-4\"><span class=\"glyphicon glyphicon-remove\"></span></td>\n";
        html += "</tr>\n";
        $("#staff_books").append(html);
    }
}

$(document).ready(function(e) {
    $('#search').on('input',function(e){
        var books = getBooks($("#search").val(), function(result){
            generate_html(result);
        });
    });
});