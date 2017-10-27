(function () {
    var controllerId = 'app.views.directives.formControls.selectController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        function ($scope) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.controlId = App.newGuid();
            ctrl.app = App;
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            //
            ctrl.initialize = function () {
                $scope.directive = ctrl;
                ctrl.preselectItem();
            };
            //
            ctrl.preselectItem = function () {
                if (App.isValidObject($scope.ngModel)) {
                    for (var i = 0; i < $scope.list.length; i++) {
                        if ($scope.list[i].id == $scope.ngModel.id) {
                            $scope.ngModel = $scope.list[i];
                            break;
                        }

                    }
                }
            };
            //
            ctrl.onSelectItem = function () {
                if (angular.isFunction($scope.onSelectItem) && angular.isFunction($scope.onSelectItem())) {
                    $scope.onSelectItem()($scope.ngModel);
                    return;
                }
            };
            /******************************  End  *************************************************************************/
            /******************************  Initialize  ******************************************************************/
            ctrl.initialize();
            /******************************  End  *************************************************************************/
        }
    ]);

    /*
    * Scopre Attributes:
    */
    app.directive('selectDirective', function () {
        return {
            priority: 0,
            restrict: 'E',  //E = element, A = attribute, C = class, M = comment
            scope: {
                ngModel: '=',    //@ reads the attribute value, = provides two-way binding, & works with functions
                onSelectItem: '&',
                list: '=',
                propertyName: '@',
                secondProperty: '@?',
                entityHeader: '@',
                placeHolder: '@',
                helpText: '@',
                parentForm: '=',
                required: '=',
                disable: '=',
                directive: '=?',
            },
            require: 'ngModel',// or // ['^parentDirectiveName', '?optionalDirectiveName', '?^optionalParent'],
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/common/formControls/selectDirective.html',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {

            }
        }
    });

})();