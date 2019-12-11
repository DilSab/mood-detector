$(document).ready(function () {
    loadPopUp();
});

function loadPopUp() {
    $.ajax({
        type: "POST",
        async: true,
        url: "/Learnings/LoadPopUp",
        dataType: "json",
        success: showPopUp
    });
}

function showPopUp(data) {
    if (data.count > 3) return;
    if (data.count < 0) {
        alert("You are " + (-data.count) + " days late with your learning")
    }
    else {
        alert("Only " + data.count + " days left for your learning")
    }
}