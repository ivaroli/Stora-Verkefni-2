function getBooks(search, callback)
{
    $.post("/Books/Search", {searchInput: search}, function(result){
        callback(result);
    });
}

function getAuthors(search, callback)
{
    $.post("/Authors/Search", {searchInput: search}, function(result){
        callback(result);
    });
}

function generate_html(obj){
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

function generate_Author_html(obj){
    var length = Object.keys(obj).length
    for(var i = 0; i < length; i++)
    {
        var item = obj[i];
        var html = "<tr class=\"tableRow\">\n";
        html += "<td class=\"col-1\"><span class=\"glyphicon glyphicon-user\"></span>" + item.name + "</td>\n";
        html += "<td class=\"col-2\">" + item.id + "</td>\n";
        html += "<td class=\"col-3\"><span class=\"glyphicon glyphicon-pencil icon\"></span></td>\n";
        html += "<td class=\"col-4\"><span class=\"glyphicon glyphicon-remove\"></span></td>\n";
        html += "</tr>\n";
        $("#staff_books").append(html);
    }
}

function createBookInput(){
    var obj = {
        Title: $("#title").val(),
        Genre: $("#genre").val(),
        Description: $("#description").val(),
        AuthorId: parseInt($("#authorId").val()),
        Image: $("#image").val(),
        Rating: parseInt($("#rating").val())
    };

    return obj;
}

$(document).ready(function(e) {
    $('#search').on('input',function(e){
        $(".tableRow").remove();
        getBooks($("#search").val(), function(result){
            generate_html(result);
        });
        getAuthors($("#search").val(), function(result){
            generate_Author_html(result);
        });
    });

    $("#add_book_btn").click(function(){
        var obj = createBookInput();
        $.post("/Books/AddBook", obj, function(result){
            $('#addModal').modal('hide');
        });
    });
});