$(document).ready(function () {
    updateLearnings();
});

function updateLearnings() {
    $.ajax({
        type: "POST",
        async: true,
        url: "/Learnings/LoadRecipientLearnings",
        dataType: "json",
        success: updateLearningsCounter
    });
}

function updateLearningsCounter(data) {
    var counter = document.getElementById('learnings-counter');
    if (counter) {
        counter.innerHTML = '(' + data.count + ')';
    }
}