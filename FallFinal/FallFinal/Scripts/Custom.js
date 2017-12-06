function JavaAjax(ItemID) {

    document.getElementById('bid').innerHTML = null;

    var source = "/Home/BidResult?id=" + ItemID;

    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: function (data) {
            returnToHTML(data);
        },
        error: function (data) {
            alert("there was an error");
        }
    });

    function returnToHTML(data) {
        $("#bid").empty();
        $.each(data, function (i, field) {
            $("#bid").append("<p>" + field["Price"] + " by " + field["Buyer_Name"] + field["Bid_Time" + "</p>");
        });
        $("#bid").css("display", "block");
    }
}