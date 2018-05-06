$(document).ready(function(e) {
    $("#userimage").click(function(){
        $("#file1").trigger('click');
    });

    $("#file1").change(function(){
        var imageFile = this.files[0];
        var url = window.URL.createObjectURL(imageFile);
        
        $("#userimage").attr("src",url);
    });
});