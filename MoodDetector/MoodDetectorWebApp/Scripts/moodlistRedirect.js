$(function () {
    $("#show-moodlist-btn").click(function (event) {
        event.preventDefault();
        inputValue = $("#user-id-input").val();
        if ($.isNumeric(inputValue)) {
            window.location.href = "@Url.Action("GetMoodList", "Mood")" + "/" + $("#user-id-input").val();
        }
    });
});