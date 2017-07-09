System.register(["jquery"], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var $, UserRoles;
    return {
        setters: [
            function ($_1) {
                $ = $_1;
            }
        ],
        execute: function () {
            UserRoles = (function () {
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
            exports_1("UserRoles", UserRoles);
        }
    };
});
//# sourceMappingURL=site.js.map