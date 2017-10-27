(function () {
    var controllerId = 'app.views.layout';
    angular.module('app').controller(controllerId, [
        '$scope', '$timeout', function ($scope, $timeout) {
            var ctrl = this;
            //Layout logic...


            ctrl.activateLeftSideBar = function () {
                $timeout(function () {
                    $.AdminBSB.leftSideBar.activate();
                }, 2000);
            };

            ctrl.activateRightSideBar = function () {
                $timeout(function () {
                    $.AdminBSB.rightSideBar.activate();
                }, 2000);
            };


            ctrl.activateTopBar = function () {
                $.AdminBSB.search.activate();
                $.AdminBSB.navbar.activate();
            };

        }]);
})();