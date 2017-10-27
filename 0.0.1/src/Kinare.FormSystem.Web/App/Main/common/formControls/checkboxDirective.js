(function () {
    var controllerId = 'app.views.directives.formControls.checkboxController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        function ($scope) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.controlId = App.newGuid();
            ctrl.app = App;
            ctrl.entityCheckBox = false;
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            ctrl.changeCheckBox = function () {
                if (ctrl.entityCheckBox) {
                    $scope.entity = $scope.trueValue;
                }
                else {
                    $scope.entity = $scope.falseValue;
                }
            };
            /******************************  End  *************************************************************************/
        }
    ]);

    /*
    * Scopre Attributes:
    */
    app.directive('checkboxDirective', function () {
        return {
            priority: 0,
            restrict: 'E',  //E = element, A = attribute, C = class, M = comment
            scope: {
                entity: '=',    //@ reads the attribute value, = provides two-way binding, & works with functions
                trueValue: '@',
                falseValue: '@',
                entityHeader: '@',
                parentForm: '=',
                required: '=',
                disable: '=',
                patternText: '=',
            },
            require: '', // or // ['^parentDirectiveName', '?optionalDirectiveName', '?^optionalParent'],
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/common/formControls/checkboxDirective.html',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {
                //binding of elements | parentDirectCtrl | DOM manipulation
                parentDirectCtrl.entityCheckBox = attr.trueValue == $scope.entity;
            }
        }
    });

})();