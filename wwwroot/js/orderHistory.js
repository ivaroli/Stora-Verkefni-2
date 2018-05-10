function getOrders(callback){
    $.post("/User/GetOrders", {}, function(result){
        callback(result);
    });
}

$(document).ready(function(e) {
    getOrders(function(result){
        console.log(JSON.stringify(result));
        
        var html = "";

        var length = Object.keys(result).length;
        for(var i = 0; i < length; i++){
            html += "<a asp-controller=\"Books\" asp-action=\"Details\" asp-route-id=\""+result[i].orderBook.id+"\"><li class=\"list-group-item\">"+result[i].orderBook.title+"</li></a>\n"
        }

        $(".list-group").append(html);
    });
});