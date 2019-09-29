

var idItem;
function DeleteItem(id) {
    idItem = id;
    $("#myModal").modal();
}

function deleteOk() {
    $.get("/Admin/Notifications/Delete/" + idItem,
        function () {
            $("#myModal").modal('hide');
            $("#record_" + idItem).hide('slow');
        });
}


$(document).ready(function () {

    // create DatePicker from input HTML element
    $("#endDate").kendoDatePicker();
    $("#startDate").kendoDatePicker();
});