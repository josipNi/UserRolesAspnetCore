// Write your Javascript code.
var setUserData = function (userId, roleId) {
    if (!userId || !roleId) {
        alert('could not get user or role id.');
    }
    var stringified_data = JSON.stringify({
        userId: userId,
        roleId: roleId
    });

    var result = $.ajax({
        type: 'POST',
        url: '/api/roles',
        data: stringified_data,
        success: function (success) {
            alert('success');
        },
        contentType: 'application/json',
        dataType: 'json'
    }).fail(function (errors) { console.log(errors); });

    console.log(result);
};