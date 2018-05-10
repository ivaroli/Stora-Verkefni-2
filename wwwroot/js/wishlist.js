function removeFromList(id){
    $.post("/User/RemoveFromWishlist", {id:id},function(){
        location.reload();
    });
}

$(document).on('click','#wishlist-remove-book',function(event){
    var id = $(event.target).attr("data");
    
    console.log("Removing: " + id);
    removeFromList(id);
});