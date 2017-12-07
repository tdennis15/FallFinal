function JavaAJAX(movieID) {
    document.getElementById('landing_zone').innerHTML = null;
    console.log(movieID);
    var source = "/Home/MovieResult?id=" + movieID;
 
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: function (data) {
            returnToHTML(data);
        },
        error: function (data) {
            alert("There was an error. Try again please!");
        }
    });
}

function returnToHTML(data) {
    $("#landing_zone").empty();
    $.each(data, function (i, field) {
        $("#landing_zone").append("<p>" + field["A_Name"] + "</p>");
    });
    $("#landing_zone").css("display", "block");
}