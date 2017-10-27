(function () {
    var controllerId = 'app.views.layout.sidebarUserArea';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$state', 'appSession',
        function ($rootScope, $state, appSession) {
            var ctrl = this;
            
            ctrl.userEmailAddress = appSession.user.emailAddress;
            ctrl.getShownUserName = function () {
                if (!abp.multiTenancy.isEnabled) {
                    return appSession.user.userName;
                } else {
                    if (appSession.tenant) {
                        return appSession.tenant.tenancyName + '\\' + appSession.user.userName;
                    } else {
                        return '.\\' + appSession.user.userName;
                    }
                }
            };
        }
    ]);
})();