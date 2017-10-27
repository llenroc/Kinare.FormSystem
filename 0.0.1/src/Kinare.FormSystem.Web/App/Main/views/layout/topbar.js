(function () {
    var controllerId = 'app.views.layout.topbar';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$state', 'appSession',
        function ($rootScope, $state, appSession) {
            var ctrl = this;
            ctrl.languages = [];
            ctrl.currentLanguage = {};

            function init() {
                ctrl.languages = abp.localization.languages;
                ctrl.currentLanguage = abp.localization.currentLanguage;
            }

            ctrl.changeLanguage = function (languageName) {
                location.href = abp.appPath + 'AbpLocalization/ChangeCulture?cultureName=' + languageName + '&returnUrl=' + window.location.pathname + window.location.hash;
            }

            init();

        }
    ]);
})();