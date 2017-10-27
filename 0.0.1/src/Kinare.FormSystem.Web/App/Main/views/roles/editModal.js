(function () {
    angular.module('app').controller('app.views.roles.editModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.role', 'id',
        function ($scope, $uibModalInstance, roleService, id) {
            var ctrl = this;

            ctrl.role = {};
            ctrl.permissions = [];

            var setAssignedPermissions = function (role, permissions) {
                for (var i = 0; i < permissions.length; i++) {
                    var permission = permissions[i];
                    permission.isAssigned = $.inArray(permission.name, role.permissions) >= 0;
                }
            }

            function init() {
                roleService.getAllPermissions()
                    .then(function (result) {
                        ctrl.permissions = result.data.items;
                    }).then(function () {
                        roleService.get({ id: id })
                            .then(function (result) {
                                ctrl.role = result.data;
                                setAssignedPermissions(ctrl.role, ctrl.permissions);
                            });
                    });
            }

            ctrl.save = function () {
                var assignedPermissions = [];

                for (var i = 0; i < ctrl.permissions.length; i++) {
                    var permission = ctrl.permissions[i];
                    if (!permission.isAssigned) {
                        continue;
                    }

                    assignedPermissions.push(permission.name);
                }

                ctrl.role.permissions = assignedPermissions;
                roleService.update(ctrl.role)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            ctrl.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            init();
        }
    ]);
})();