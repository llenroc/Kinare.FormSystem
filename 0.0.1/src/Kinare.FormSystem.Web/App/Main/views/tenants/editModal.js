(function () {
    angular.module('app').controller('app.views.tenants.editModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.tenant', 'id',
        function ($scope, $uibModalInstance, tenantService, id) {
            var ctrl = this;

            ctrl.tenant = {};

            function init() {
                tenantService.get({
                    id: id
                }).then(function (result) {
                    ctrl.tenant = result.data;
                });
            }

            init();

            ctrl.save = function () {
                abp.ui.setBusy();
                tenantService.update(ctrl.tenant)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    }).finally(function () {
                        abp.ui.clearBusy();
                    });
            };

            ctrl.cancel = function () {
                $uibModalInstance.dismiss();
            };
        }
    ]);
})();