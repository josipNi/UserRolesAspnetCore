import * as $ from 'jquery';
class UserRoles {
    public setUserData(userId:string, roleId:string):void{
       if (!userId || !roleId)
        alert('could not get user or role id.');

    let stringified_data = JSON.stringify({
        userId: userId,
        roleId: roleId
    });
    let result = $.ajax({
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
}
}