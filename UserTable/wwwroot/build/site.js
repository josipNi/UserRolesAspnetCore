"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var $ = require("jquery");
var UserRoles = (function () {
    function UserRoles() {
    }
    UserRoles.prototype.setUserData = function (userId, roleId) {
        if (!userId || !roleId)
            alert('could not get user or role id.');
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
    return UserRoles;
}());
//# sourceMappingURL=site.js.map