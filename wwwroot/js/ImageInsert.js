$(document).ready(function(e) {
    $("#userimage").click(function(){
        $("#file1").trigger('click');
    });

    $("#file1").change(function(){
        var imageFile = this.files[0];
        // get a local URL representation of the image blob
        var url = window.URL.createObjectURL(imageFile);
        // Now use your newly created URL!
        $("#userimage").attr("src",url);
    });
});