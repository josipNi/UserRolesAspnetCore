// Write your Javascript code.
var setUserData = function (userId, roleId, event, elId) {
    console.log(elId);
    event.preventDefault();
    console.log(event);
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
        success: function (data) {
            console.log(data);
            console.log('success');
            setChecked(elId);
        },
        contentType: 'application/json',

    }).fail(function (errors) { console.log(errors); });

    console.log(result);
};
var setChecked = function (elId) {
    var el = $("#" + elId);
    if (el.is(":checked"))
        el.prop("checked", false);
     else
        el.prop("checked", true);
    
};