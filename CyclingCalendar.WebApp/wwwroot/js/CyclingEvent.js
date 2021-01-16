$(document).ready(function () {
    console.log("App Loaded!");
    getEvents();
});

function getEvents() {
    $('#table-events-body').html('');
    $.ajax({
        url: "https://localhost:5001/api/Calendar", success: function (result) {
            result.forEach((r,idx )=> {
                $('#table-events-body')
                    .append('<tr><td>' +
                        (idx + 1) + '</td><td>' +
                        r.description + '</td><td>' +
                        r.date + '</td><td><i onclick="openEditModal(' + r.id + ')" class="icon-pencil"></i></td><td><i onclick="deleteEvent(\'' + r.id + '\')" class="icon-trash"></i></td><tr>')
            });
        }
    });
}

function addEvent() {
    var data ={
        "id": generateUUID(),
        "date": $('#newEventDate').val(),
        "description": $('#newEventName').val(),
        "active": true
    };

    $.ajax({
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json',
        url: "https://localhost:5001/api/Calendar",
        data: JSON.stringify(data),
        success: function (result) {
            getEvents();
        },
        error: function () {
            getEvents();
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
        },
        error: function () {
            getEvents();
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