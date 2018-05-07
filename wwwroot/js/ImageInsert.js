function insert()
{
    var obj = {
        FirstName: $("#fname").val(),
        LastName: $("#lname").val(),
        Country: $("#country").val(),
        City: $("#city").val(),
        Address: $("#address").val()
    }

    $.post("/User/Details", obj, function(result){
    });
}

$(document).ready(function(e) {
    $("#userimage").click(function(){
        $("#file1").trigger('click');
    });

    $("#file1").change(function(){
        var imageFile = this.files[0];
        var url = window.URL.createObjectURL(imageFile);
        
        $("#userimage").attr("src",url);
    });

    $("#save_btn").click(function(){
        insert();
    });
});