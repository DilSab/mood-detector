$(document).ready(function () {
    setInterval("updateMessage()", 10000);
    updateMessage();
});

function updateMessage() {
    $.ajax({
        type: "POST",
        async: true,
        url: "/Messenger/LoadRecipientGlobalMessages",
        dataType: "json",
        success: updateCounter
    });
}

function updateCounter(data) {
    var counter = document.getElementById('message-counter');
    if (counter) {
        messageCount = data.count;
        counter.innerHTML = '(' + data.count + ')';
    }
}