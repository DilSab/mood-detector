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
        success: dataReceived
    });
}

// callback function is called, when data is recevied
function dataReceived(data, textStatus, jqXHR) {
    // your data is in data.d
    var counter = document.getElementById('message-counter');
    counter.innerHTML = '(' + data.count + ')';
}