(function () {
    var controllerId = 'app.views.directives.formControls.sliderController';
    var app = angular.module('app');

    //
    app.controller(controllerId, [
        '$scope',
        '$timeout',
        function ($scope, $timeout) {
            var ctrl = this;
            /******************************  Variables  *******************************************************************/
            ctrl.controlId = App.newGuid();
            ctrl.sliderContainerId = App.newGuid();
            ctrl.sliderControllsId = App.newGuid();
            ctrl.app = App;
            ctrl.slider = null;
            /******************************  End  *************************************************************************/
            /******************************  Functions  *******************************************************************/
            //
            ctrl.initialize = function (filterList) {
                var sliderContainer = $('#' + ctrl.sliderContainerId);
                sliderContainer.empty();

                ctrl.buildList(filterList);
                ctrl.buildSlider();
                ctrl.buildClick();
                ctrl.setViewStyle();
            };
            //
            ctrl.buildList = function (filterList) {
                var sliderContainer = $('#' + ctrl.sliderContainerId);

                var ulElementString = '<ul id="' + ctrl.controlId + '" class="parentHeight" style="margin-left: 45px; margin-right: 45px;"></ul>';
                sliderContainer.append(ulElementString);

                var ulElement = $('#' + ctrl.controlId);

                for (var i = 0; i < $scope.ngModel.length; i++) {
                    var showItem = false;

                    if (!App.isValidObject($scope.ngModel[i].isSelected))
                        $scope.ngModel[i].isSelected = false;

                    if (App.isValidArray(filterList)) {
                        for (var j = 0; j < filterList.length; j++) {
                            if ($scope.ngModel[i].id === filterList[j].id) {
                                showItem = true;
                                break;
                            }
                        }
                    }
                    else {
                        showItem = true;
                    }

                    if (showItem) {
                        var liElement = '<li class="parentHeight custom-cursor" id="@Id"> <div class="parentHeight checkIcon"> <img class="sliderImage @Selected" src="@ImageThumbnail" /> </div> </li >';

                        liElement = liElement.replace('@Id', $scope.ngModel[i].id);
                        liElement = liElement.replace('@ImageThumbnail', $scope.ngModel[i][$scope.imageThumbnail]);
                        liElement = liElement.replace('@Selected', $scope.ngModel[i].isSelected ? 'borderGreen' : 'borderGray');

                        ulElement.append(liElement);
                    }
                }

            };
            //
            ctrl.buildSlider = function () {
                var margin = 30;
                var imageWidth = 335;
                var buttonWidth = 47 + 5;
                var sliderContainer = $(window).width() - (buttonWidth * 2);

                var itemsToShow = Math.floor(sliderContainer / (imageWidth + margin));

                ctrl.slider = $('#' + ctrl.controlId).lightSlider({
                    item: itemsToShow,
                    autoWidth: false,
                    slideMove: 1, // slidemove will be 1 if loop is true
                    slideMargin: margin,

                    addClass: '',
                    mode: 'slide',
                    useCSS: true,
                    cssEasing: 'ease', //'cubic-bezier(0.25, 0, 0.25, 1)',//
                    easing: 'linear', //'for jquery animation',////

                    speed: 500, //ms'
                    auto: false,
                    loop: false,
                    slideEndAnimation: true,
                    pause: 2000,

                    keyPress: false,
                    controls: false,
                    prevHtml: '<button type="button" class="btn btn-primary"><i class="fa fa-caret-left"></i></button>',
                    nextHtml: '<button type="button" class="btn btn-primary"><i class="fa fa-caret-right"></i></button>',

                    rtl: false,
                    adaptiveHeight: true,

                    vertical: false,

                    thumbItem: 10,
                    pager: false,
                    gallery: false,
                    galleryMargin: 5,
                    thumbMargin: 5,
                    currentPagerPosition: 'middle',

                    enableTouch: false,
                    enableDrag: false,
                    freeMove: false,
                    swipeThreshold: 40,

                    responsive: [],
                });
            };
            //
            ctrl.buildClick = function () {
                $('li').click(function (e) {
                    var id = this.id;

                    for (var i = 0; i < $scope.ngModel.length; i++) {
                        var item = $scope.ngModel[i];
                        if (item.id == id) {
                            ctrl.selectItem(item);
                            $scope.$apply();
                            break;
                        }
                    }
                });
            };
            //
            ctrl.setViewStyle = function () {
                var margin = 30;
                var imageWidth = 335;
                var buttonWidth = 47 + 5;
                var sliderContainer = ($(window).width() - (buttonWidth * 2)) - 10;

                $('#' + ctrl.sliderContainerId).css('width', sliderContainer + 'px');
                $('#' + ctrl.sliderContainerId).css('margin-left', buttonWidth + 'px');
                $('#' + ctrl.sliderContainerId).css('margin-right', buttonWidth + 'px');
                $('#' + ctrl.sliderContainerId).css('text-align', 'left');
                $('#' + ctrl.sliderContainerId).css('top', '8px');

                $('.sliderControlls').css('height', $('#' + ctrl.controlId).height() + 'px');

            };
            //
            ctrl.changeSelectedClass = function () {
                for (var i = 0; i < $scope.ngModel.length; i++) {
                    var item = $scope.ngModel[i];

                    var imgElement = $('#' + ctrl.controlId).find('#' + item.id + ' img')[0];

                    if (!App.isValidObject(imgElement))
                        continue;

                    if (item.isSelected) {
                        if (!imgElement.className.includes('borderGreen'))
                            imgElement.className = 'sliderImage borderGreen';
                    }
                    else {
                        if (!imgElement.className.includes('borderGray'))
                            imgElement.className = 'sliderImage borderGray';
                    }
                }
            };
            //
            ctrl.moveSlide = function (isNextSlide) {
                if (isNextSlide)
                    ctrl.slider.goToNextSlide();
                else
                    ctrl.slider.goToPrevSlide();
            };
            //
            ctrl.selectItem = function (item) {

                if (angular.isFunction($scope.onSelect) || angular.isFunction($scope.onSelect())) {
                    if (angular.isFunction($scope.onSelect)) {
                        $scope.onSelect(item);
                        return;
                    }
                    if (angular.isFunction($scope.onSelect())) {
                        $scope.onSelect()(item);
                        return;
                    }
                }
            };
            /******************************  End  *************************************************************************/
            /******************************  Load View Complete  **********************************************************/
            //
            angular.element(function () {
                $scope.$apply(function () {
                    ctrl.initialize();
                });
            });
            //
            $(window).resize(function () {
                $scope.$apply(function () {
                    ctrl.initialize();
                });
            });
            /******************************  End  *************************************************************************/
            $scope.directive = ctrl;
        }
    ]);

    /*
    * Scopre Attributes:
    */
    app.directive('sliderDirective', function () {
        return {
            priority: 0,
            restrict: 'E',
            scope: {
                ngModel: '=',
                imageThumbnail: '=',
                onSelect: '=',
                directive: '=',
            },
            require: 'ngModel',
            templateNamespace: 'html',
            transclude: false,
            bindToController: false,
            controller: controllerId,   //Embed a custom controller in the directive
            controllerAs: 'ctrl',
            templateUrl: '/App/Main/common/formControls/sliderDirective.html',    //UI for directive
            link: function ($scope, $element, attr, parentDirectCtrl, transcludeFn) {

            }
        }
    });

    app.directive('ngLightSlider', function () {
        return {
            restrict: 'A',
            link: function ($scope, $element, $attrs, $parentDirectCtrl) {
                if ($scope.$last) {
                    angular.element(function () {
                        $scope.$apply(function () {
                            $scope.$parent.ctrl.initialize();
                        });
                    });
                }
            }
        };
    });

})();