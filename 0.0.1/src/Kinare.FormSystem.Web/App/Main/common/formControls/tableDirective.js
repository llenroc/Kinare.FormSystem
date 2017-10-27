(function () {
    var controllerId = 'app.views.directives.formControls.tableController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        function ($scope) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.controlId = App.newGuid();
            ctrl.app = App;
            ctrl.entitySelected = null;

            ctrl.pagination = {
                order: 'status',
                limit: 5,
                page: 1
            };

            ctrl.limitOptions = [5, 25, 50, 100,
                //{
                //    label: 'TODOS',
                //    value: function () {
                //        return $scope.ngModel.data.length;
                //    }
                //}
            ];

            ctrl.options = {
                rowSelection: true,
                multiSelect: true,
                autoSelect: true,
                decapitate: false,
                largeEditDialog: false,
                boundaryLinks: false,
                limitSelect: true,
                pageSelect: true
            };
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            //
            ctrl.initialize = function () {

            };
            //
            ctrl.getProperty = function (entity, propertyPath) {
                return App.getObjectBy(entity, propertyPath);
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
    app.directive('tableDirective', function () {
        return {
            priority: 0,
            restrict: 'E',
            scope: {
                ngModel: '=',
                tableDescription: '=',
                onSelect: '=',
                onBack: '=',
            },
            require: 'ngModel',
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/common/formControls/tableDirective.html',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {
                //binding of elements | parentDirectCtrl | DOM manipulation
            }
        }
    });

})();