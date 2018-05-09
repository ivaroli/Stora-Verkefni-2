function removeFromCart(id){
    $.post("/User/RemoveFromCart", {id:id},function(){
        location.reload();
    });
}

$(document).ready(function(e){
    $("#remove-icon").click(function(event){
        var id = $(event.target).attr("data");
        
        console.log("Removing: " + id);
        removeFromCart(id);
    });
});