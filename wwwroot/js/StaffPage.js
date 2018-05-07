function getBooks(search)
{
    $.post("/Book/Search", {search}, function(result){
        return result;
    });
}

function getAuthors(search)
{
    $.post("/Authors/Search", {search}, function(result){
    });
}

$(document).ready(function(e) {
    $('#search').on('input',function(e){
        var books = getBooks($("#search").val();
        alert(JSON.stringify(books));
    });
});