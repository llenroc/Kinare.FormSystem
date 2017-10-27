﻿(function () {
    var controllerId = 'app.views.directives.formControls.radioButtonController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        function ($scope) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.data = [];
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            //
            ctrl.callServer = function (tableState) {
            };
            /******************************  End  *************************************************************************/
        }
    ]);

    /*
    * Scopre Attributes:
    */
    app.directive('radioButtonDirective', function () {
        return {
            priority: 0,
            restrict: 'E',  //E = element, A = attribute, C = class, M = comment
            scope: {
                entity: '=',    //@ reads the attribute value, = provides two-way binding, & works with functions
                entityHeader: '@',
                entityName: '@',
                placeHolder: '@',
                helpText: '@',
                disable: '=',
                required: '='
            },
            require: '', // or // ['^parentDirectiveName', '?optionalDirectiveName', '?^optionalParent'],
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/common/formControls/radioButtonDirective.html',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {
                //binding of elements | parentDirectCtrl | DOM manipulation
            }
        }
    });

})();