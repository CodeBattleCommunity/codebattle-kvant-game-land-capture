var url = 'api/v1/';

function EditUser(userEmail) {
    $.ajax({
        url: url,
        contentType: "application/json",
        method: "PUT",
        data: JSON.stringify({
            Email : userEmail,
        }),
    })
}