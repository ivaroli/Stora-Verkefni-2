var has_rated = false;

$(document).ready(function(e) {
    $("#rating").val(0);
    $("#stars span").mouseenter(function(event){
        if(has_rated){
            return;
        }

        var number = parseInt(event.target.id);

        for(var i = 1; i <= number; i++){
            var item = $("#" + i.toString());            
            $(item).removeClass("glyphicon-star-empty").addClass("glyphicon-star");
        }
    });

    $("div#stars").mouseout(function(){
        if(has_rated){
            return;
        }

        for(var i = 1; i <= 5; i++){
            var item = $("#" + i.toString());
            $(item).removeClass("glyphicon-star").addClass("glyphicon-star-empty");
        }
    });

    $("#stars span").click(function(event){
        var rate = parseInt(event.target.id);
        $("#rating").val(rate);
        has_rated = true;
    });
});