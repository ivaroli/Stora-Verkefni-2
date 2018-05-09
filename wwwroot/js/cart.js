function removeFromCart(id){
    $.post("/User/RemoveFromCart", {id:id},function(){
        location.reload();
    });
}

$(document).on('click','#remove-icon',function(event){
    var id = $(event.target).attr("data");
    
    console.log("Removing: " + id);
    removeFromCart(id);
});