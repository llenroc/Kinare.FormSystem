(function () {
    var controllerId = 'app.views.directives.formControls.labelController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        function ($scope) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.app = App;
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/

            /******************************  End  *************************************************************************/
        }
    ]);

    /*
    * Scopre Attributes:
    */
    app.directive('labelDirective', function () {
        return {
            priority: 0,
            restrict: 'E',  //E = element, A = attribute, C = class, M = comment
            scope: {
                entity: '=',    //@ reads the attribute value, = provides two-way binding, & works with functions
                entityHeader: '=',
                parentForm: '=',
            },
            require: '', // or // ['^parentDirectiveName', '?optionalDirectiveName', '?^optionalParent'],
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/common/formControls/labelDirective.html',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {
                //binding of elements | parentDirectCtrl | DOM manipulation
            }
        }
    });

})();