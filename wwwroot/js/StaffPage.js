function getBooks(search)
{
    $.post("/Book/Search", {search}, function(result){
    });
}

function getAuthors(search)
{
    $.post("/Authors/Search", {search}, function(result){
    });
}

$(document).ready(function(e) {
    $('#search').on('input',function(e){

    });
});