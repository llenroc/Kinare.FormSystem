(function () {
    angular.module('app').controller('app.views.users.editModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.user', 'id',
        function ($scope, $uibModalInstance, userService, id) {
            var ctrl = this;

            ctrl.user = {
                isActive: true
            };

            ctrl.roles = [];

            var setAssignedRoles = function (user, roles) {
                for (var i = 0; i < roles.length; i++) {
                    var role = roles[i];
                    role.isAssigned = $.inArray(role.name, user.roles) >= 0;
                }
            }

            var init = function () {
                userService.getRoles()
                    .then(function (result) {
                        ctrl.roles = result.data.items;

                        userService.get({ id: id })
                            .then(function (result) {
                                ctrl.user = result.data;
                                setAssignedRoles(ctrl.user, ctrl.roles);
                            });
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
                userService.update(ctrl.user)
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