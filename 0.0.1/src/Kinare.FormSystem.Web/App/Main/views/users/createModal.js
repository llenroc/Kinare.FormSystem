(function () {
    angular.module('app').controller('app.views.users.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.user',
        function ($scope, $uibModalInstance, userService) {
            var ctrl = this;

            ctrl.user = {
                isActive: true
            };

            ctrl.roles = [];

            function getRoles() {
                userService.getRoles()
                    .then(function (result) {
                        ctrl.roles = result.data.items;
                    });
            }

            ctrl.save = function () {
                var assingnedRoles = [];

                for (var i = 0; i < ctrl.roles.length; i++) {
                    var role = ctrl.roles[i];
                    if (!role.isAssigned) {
                        continue;
                    }

                    assingnedRoles.push(role.name);
                }

                ctrl.user.roleNames = assingnedRoles;
                userService.create(ctrl.user)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });
            };

            ctrl.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            getRoles();
        }
    ]);
})();