(function () {
    var controllerId = 'app.views.directives.formControls.cardController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        function ($scope) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.controlId = App.newGuid();
            ctrl.app = App;
            ctrl.accessorycard = null;
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            //
            ctrl.initialize = function () {

            };
            //
            ctrl.back = function () {
                if (angular.isFunction($scope.onBack) || angular.isFunction($scope.onBack())) {
                    if (angular.isFunction($scope.onBack)) {
                        $scope.onBack();
                        return;
                    }
                    if (angular.isFunction($scope.onBack())) {
                        $scope.onBack()();
                        return;
                    }
                }
            };
            //
            ctrl.selectItem = function (item) {
                if (angular.isFunction($scope.onSelect) || angular.isFunction($scope.onSelect())) {
                    if (angular.isFunction($scope.onSelect)) {
                        $scope.onSelect(item);
                        ctrl.back();
                        return;
                    }
                    if (angular.isFunction($scope.onSelect())) {
                        $scope.onSelect()(item);
                        ctrl.back();
                        return;
                    }
                }
            };
            /******************************  End  *************************************************************************/
        }
    ]);

    /*
    * Scopre Attributes:
    */
    app.directive('cardDirective', function () {
        return {
            priority: 0,
            restrict: 'E',
            scope: {
                ngModel: '=',
                entityDescriptionList: '=',
                imageThumbnail: '=',
                onSelect: '=',
                onBack: '=',
            },
            require: 'ngModel',
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/common/formControls/cardDirective.html',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {
                //binding of elements | parentDirectCtrl | DOM manipulation
            }
        }
    });

})();