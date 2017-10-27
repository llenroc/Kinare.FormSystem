﻿(function () {
    var controllerId = 'app.views.directives.formControls.passwordController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        function ($scope) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            //ctrl.patternText = /^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s\d]*$/;
            ctrl.controlId = App.newGuid();
            ctrl.app = App;
            //ctrl.entityModel = $scope.entity;
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/

            /******************************  End  *************************************************************************/
        }
    ]);

    /*
    * Scopre Attributes:
    */
    app.directive('passwordDirective', function () {
        return {
            priority: 0,
            restrict: 'E',  //E = element, A = attribute, C = class, M = comment
            scope: {
                entity: '=',    //@ reads the attribute value, = provides two-way binding, & works with functions
                entityHeader: '@',
                placeHolder: '@',
                helpText: '@',
                parentForm: '=',
                required: '=',
                type: '=',
                disable: '=',
                patternText: '=',
            },
            require: '', // or // ['^parentDirectiveName', '?optionalDirectiveName', '?^optionalParent'],
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/common/formControls/passwordDirective.html',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {
                //binding of elements | parentDirectCtrl | DOM manipulation
                if (!attr.type) {
                    type = 'text';
                }
            }
        }
    });

})();