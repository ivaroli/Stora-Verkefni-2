var selectedItem = "All Genres";
var event = new Event("input");

function createHtml()
{

}

$(document).ready(function() {
    $(".item").click(function(e){
        var text = $(e.target).text();

        $("#search_concept").text(text);
        $("#search_bar").trigger( "input" );
    });
});