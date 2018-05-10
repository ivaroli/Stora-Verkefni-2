function getReviews(callback)
{
    var ids = window.location.href.split('/');
    var id = ids[ids.length - 1];

    $.post("/Books/GetReviews", {bookId: id}, function(result){
        callback(result);
    });
}

function isInCart(callback)
{
    var ids = window.location.href.split('/');
    var id = ids[ids.length - 1];

    $.post("/User/IsInCart", {id: id}, function(result){
        callback(result);
    });
}

function isInWishlist(callback)
{
    var ids = window.location.href.split('/');
    var id = ids[ids.length - 1];

    $.post("/User/IsInWishlist", {id: id}, function(result){
        callback(result);
    });
}

function generateHtml(obj)
{
    var length = Object.keys(obj).length;
    var html = "";

    for(var i = 0; i < length; i++)
    {
        html += "<div class=\"media\">\n";
        html += "<div class=\"media-left media-top\">\n";
        html += "<img src=\"https://www.w3schools.com/bootstrap/img_avatar1.png\" class=\"media-object\" style=\"width:60px\">\n";
        html += "</div>\n";
        html += "<div class=\"media-body\">\n";
        html += "<h4 class=\"media-heading\">" + obj[i].user +  " <small><i>Posted  " + obj[i].time + "</i></small></h4>\n";
        html += "<p>" + obj[i].commentText + "</p>\n";
        html += "</div>\n";
        html += "</div>\n";
    }

    return html;
}

$(document).ready(function(e) {
    isInCart(function(result){
        if(result == true){
            $("#basket-box").css("background-color", "#33b6bc");
            $("#basket-box span").css("color", "white");
        }
    });

    isInWishlist(function(result){
        if(result == true){
            $("#wishlist-box").css("background-color", "#33b6bc");
            $("#wishlist-box span").css("color", "white");
        }
    });

    getReviews(function(result){
        console.log(JSON.stringify(result));
        $(".comments").append(generateHtml(result));
    });

    $("#send-rate").click(function(e){
        console.log("ASDF");
        
        var stars = $("#rating").val();
        var text = $("#comment").val();
        var ids = window.location.href.split('/');
        var id = ids[ids.length - 1];

        console.log(stars + " - " + text);
        
        
        $.post("/Books/AddReview", {rating: stars, comment: text, bookId: id}, function(result){
            location.reload();
        });
    });

    $("#basket-box").click(function(){
        var ids = window.location.href.split('/');
        var id = ids[ids.length - 1];

        var obj = {
            amount: 1,
            UserId : "",
            ExpirationTime : "",
            BookId: id
        };

        console.log(JSON.stringify(obj));
        
        $.post("/User/AddToCart", obj, function(result){
            $("#basket-box").css("background-color", "#33b6bc");
            $("#basket-box span").css("color", "white");
        });
    });

    $("#wishlist-box").click(function(){
        var ids = window.location.href.split('/');
        var id = ids[ids.length - 1];

        var obj = {
            amount: 1,
            UserId : "",
            ExpirationTime : "",
            BookId: id
        };

        console.log(JSON.stringify(obj));
        
        $.post("/User/AddToWishlist", obj, function(result){
            $("#wishlist-box").css("background-color", "#33b6bc");
            $("#wishlist-box span").css("color", "white");
        });
    });
});