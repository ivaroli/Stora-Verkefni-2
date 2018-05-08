function search()
{
    $.post("Home/Search", {}, function(result){
    });
}

$(document).ready(function(e) {
    $('#search_bar').on('input',function(e){
    });
});