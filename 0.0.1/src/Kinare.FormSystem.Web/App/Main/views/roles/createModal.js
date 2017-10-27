(function () {
    angular.module('app').controller('app.views.roles.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.role',
        function ($scope, $uibModalInstance, roleService) {
            var ctrl = this;

            ctrl.role = {};
            ctrl.permissions = [];

            function getPermissions() {
                roleService.getAllPermissions()
                    .then(function (result) {
                        ctrl.permissions = result.data.items;
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
                roleService.create(ctrl.role)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            ctrl.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            getPermissions();
        }
    ]);
})();