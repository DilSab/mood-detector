$(document).ready(function () {
    setInterval("updateMessage()", 5000);
    updateMessage();
});

function updateMessage() {
    $.ajax({
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        url: "/Messenger/LoadRecipientGlobalMessages",
        success: updateCounter
    });
}

function updateCounter(data) {
    var counter = document.getElementById('message-counter');
    if (counter) {
        counter.innerHTML = '(' + data.count + ')';
    }
}