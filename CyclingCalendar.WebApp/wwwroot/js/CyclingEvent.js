var events = [];

$(document).ready(function () {
    console.log("App Loaded!");
    getEvents();
});

function getEvents() {
    $('#table-events-body').html('');
    $.ajax({
        url: "https://localhost:5001/api/Calendar", success: function (result) {
            events = result;
            result.forEach((r,idx )=> {
                $('#table-events-body')
                    .append('<tr><td>' +
                        (idx + 1) + '</td><td>' +
                        r.description + '</td><td>' +
                    r.date + '</td><td><button class="btn btn-warning" onclick="openEditModal(\'' + r.id + '\')">Edit</button></td><td><button onclick="deleteEvent(\'' + r.id + '\')" class="btn btn-danger">Delete</button></td><tr>')
            });
        }
    });
}

function openEditModal(id) {
    var data = events.filter(function (e) { return e.id === id })[0];

    if (data) {
        $('#newEventName').val(data.description);
        $('#eventId').val(data.id);
        $('#newEventDate').val(new Date(data.date).toLocaleDateString());
    } else {
        $('#newEventName').val('');
        $('#eventId').val('');
        $('#newEventDate').val(new Date().toLocaleDateString())
    }

    $('#eventModal').modal('toggle');
    $('#eventModal').modal('show');
}

function closeModal() {
    $('#eventModal').modal('hide');
}

function addEvent() {
    var data ={
        "id": $('#eventId').val() ? $('#eventId').val(): generateUUID(),
        "date": $('#newEventDate').val(),
        "description": $('#newEventName').val(),
        "active": true
    };

    $.ajax({
        type: $('#eventId').val() ? 'PUT' : 'POST',
        dataType: 'json',
        contentType: 'application/json',
        url: "https://localhost:5001/api/Calendar",
        data: JSON.stringify(data),
        success: function (result) {
            getEvents();
            closeModal();
        },
        error: function () {
            getEvents();
            closeModal();
        }
    });
}

function deleteEvent(id) {
    $.ajax({
        type: 'DELETE',
        dataType: 'json',
        contentType: 'application/json',
        url: "https://localhost:5001/api/Calendar/"+id,
        data: null,
        success: function (result) {
            getEvents();
            closeModal();
        },
        error: function () {
            getEvents();
            closeModal();
        }
    });
}

function generateUUID() {
    var u = '', i = 0;
    while (i++ < 36) {
        var c = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'[i - 1], r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        u += (c == '-' || c == '4') ? c : v.toString(16)
    }
    return u;
}