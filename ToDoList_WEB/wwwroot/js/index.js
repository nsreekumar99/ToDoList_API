$(".form-check-input").on("change", function () {
    const id = $(this).closest("li").data("id");
    const isChecked = $(this).is(":checked");
    $.ajax({
        url: updateUrl,
        type: 'POST',
        data: JSON.stringify({ isChecked: isChecked }),
        contentType: "application/json",
        success: function (response) {
            if (response.success) {
                location.reload();
            }
        }
    })
})