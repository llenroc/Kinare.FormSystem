(function () {
    angular.module('app').controller('app.views.tenants.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.tenant',
        function ($scope, $uibModalInstance, tenantService) {
            var ctrl = this;

            ctrl.tenant = {
                tenancyName: '',
                name: '',
                adminEmailAddress: '',
                connectionString: ''
            };

            ctrl.save = function () {
                abp.ui.setBusy();
                tenantService.create(ctrl.tenant)
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