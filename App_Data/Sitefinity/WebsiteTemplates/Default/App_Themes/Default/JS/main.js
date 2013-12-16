$(document).ready(function () {
    var searchBtn = $(".search input[type='submit']");
    var searchBox = $(".search input[type='text']");
    if(searchBtn.length > 0){
        searchBtn.val("");
        searchBox.focus(function () {
            //$(this).css("width","400px");
        });
    }
    
});