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

function update(){
    getBooks("", function(result){
        $(".tableRow").remove();
        generate_html(result);
    });
}

function generate_html(obj){
    var length = Object.keys(obj).length;
    for(var i = 0; i < length; i++)
    {
        var item = obj[i];
        var html = "<tr class=\"tableRow\">\n";
        html += "<td class=\"col-1\">" + item.title + "</td>\n";
        html += "<td class=\"col-2\">" + item.id + "</td>\n";
        html += "<td class=\"col-3\"><span class=\"glyphicon glyphicon-pencil icon\"></span></td>\n";
        html += "<td class=\"col-4\" id=\"book-" + item.id +"\"><span class=\"glyphicon glyphicon-remove\"></span></td>\n";
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
        html += "<td class=\"col-4\" id=\"author-" + item.id +"\"><span class=\"glyphicon glyphicon-remove\"></span></td>\n";
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
        Rating: parseInt($("#rating").val()),
        Price: $("#price").val(),
        Tag: $("#tag").val()
    };

    return obj;
}

function createAuthorInput(){
    var obj = {
        Name: $("#author_name").val(),
        Description: $("#author_description").val(),
        Image: $("#author_image").val()
    };

    return obj;
}

function removeBook(ID)
{
    $.post("/Books/RemoveBook", {id: ID}, function(result){
    });
}

function removeAuthor(ID)
{
    $.post("/Authors/RemoveAuthor", {id: ID}, function(result){
    });
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
        console.log(JSON.stringify(obj));
        
        $.post("/Books/AddBook", obj, function(result){
            $('#addModal').modal('hide');
        });
    });

    $("#add_author_btn").click(function(){
        var obj = createAuthorInput();
        alert(JSON.stringify(obj));
        $.post("/Authors/AddAuthor", obj, function(result){
            $('#addAuthorModal').modal('hide');
        });
    });
});

$(document).on('click','td.col-4',function(event){
    if(!confirm("Are you sure?")){
        return;
    }

    var clickeElement = $(event.target);
    if(event.target.id == "" || event.target.id == undefined){
        clickeElement = $(event.target).parent();
    }

    var type = clickeElement.attr('id').split("-")[0];
    var id = clickeElement.attr('id').split("-")[1];

    if(type == "book"){
        removeBook(parseInt(id));
    }
    else{
        alert("removing author");
        removeAuthor(parseInt(id));
    }

    update();
});