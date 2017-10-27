(function () {
    var controllerId = 'app.views.directives.formControls.datePickerController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        function ($scope) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.controlId = App.newGuid();
            ctrl.app = App;
            ctrl.formats = ['yyyy-MM-dd', 'shortDate'];
            ctrl.format = ctrl.formats[0];
            ctrl.opened = false;
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            //
            ctrl.initialize = function () {
                if (!$scope.entity) {
                    $scope.entity = new Date();
                }

                ctrl.dateOptions = {
                    dateDisabled: disabled,
                    formatYear: 'yy',
                    maxDate: new Date(2020, 5, 22),
                    minDate: new Date(),
                    startingDay: 1
                };
            };
            // Disable weekend selection
            function disabled(data) {
                var date = data.date,
                    mode = data.mode;
                return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
            };
            //
            ctrl.open = function () {
                ctrl.opened = true;
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
    app.directive('datePickerDirective', function () {
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
                disable: '=',
            },
            require: '', // or // ['^parentDirectiveName', '?optionalDirectiveName', '?^optionalParent'],
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/common/formControls/datePickerDirective.html',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {
                //binding of elements | parentDirectCtrl | DOM manipulation
            }
        }
    });

})();