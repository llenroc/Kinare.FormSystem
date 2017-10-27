(function () {
    angular.module('app').controller('app.views.roles.index', [
        '$scope', '$uibModal', 'abp.services.app.role',
        function ($scope, $uibModal, roleService) {
            var ctrl = this;

            ctrl.roles = [];

            function getRoles() {
                roleService.getAll({}).then(function (result) {
                    ctrl.roles = result.data.items;
                });
            }

            ctrl.openRoleCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/roles/createModal.cshtml',
                    controller: 'app.views.roles.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getRoles();
                });
            };

            ctrl.openRoleEditModal = function (role) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/roles/editModal.cshtml',
                    controller: 'app.views.roles.editModal as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return role.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getRoles();
                });
            };

            ctrl.delete = function (role) {
                abp.message.confirm(
                    "Delete role '" + role.name + "'?",
                    function (result) {
                        if (result) {
                            roleService.delete({ id: role.id })
                                .then(function () {
                                    abp.notify.info("Deleted role: " + role.name);
                                    getRoles();
                                });
                        }
                    });
            }

            ctrl.refresh = function () {
                getRoles();
            };

            getRoles();
        }
    ]);
})();