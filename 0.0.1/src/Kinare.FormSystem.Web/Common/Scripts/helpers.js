var App = App || {};
(function () {
    var appLocalizationSource = abp.localization.getSource('FormSystem');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

    App.boardSize = new Object();
    App.boardSize.col1 = 'col-xs-1 col-sm-1 col-md-1 col-lg-1';
    App.boardSize.col2 = 'col-xs-2 col-sm-2 col-md-2 col-lg-2';
    App.boardSize.col3 = 'col-xs-3 col-sm-3 col-md-3 col-lg-3';
    App.boardSize.col4 = 'col-xs-4 col-sm-4 col-md-4 col-lg-4';
    App.boardSize.col5 = 'col-xs-5 col-sm-5 col-md-5 col-lg-5';
    App.boardSize.col6 = 'col-xs-6 col-sm-6 col-md-6 col-lg-6';
    App.boardSize.col7= 'col-xs-7 col-sm-7 col-md-7 col-lg-7';
    App.boardSize.col8 = 'col-xs-8 col-sm-8 col-md-8 col-lg-8';
    App.boardSize.col9 = 'col-xs-9 col-sm-9 col-md-9 col-lg-9';
    App.boardSize.col10 = 'col-xs-10 col-sm-10 col-md-10 col-lg-10';
    App.boardSize.col11 = 'col-xs-11 col-sm-11 col-md-11 col-lg-11';
    App.boardSize.col12 = 'col-xs-12 col-sm-12 col-md-12 col-lg-12';

    App.pattern = new Object();
    App.pattern.cedula = /^\d{10}$/;
    App.pattern.word = /^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s\d]*$/;
    App.pattern.paragraph = /^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s\d\.\,\;\-]*$/;
    App.pattern.email = /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    App.pattern.cellphone = /^09\d{8}$/;
    App.pattern.phone = /^\d{2}\s?\d{3}\s?\d{4}$/;
    App.pattern.year = /^20\d{2}$/;
    App.pattern.licensePlate = /^[a-zA-Z]{3,4}[\s-]?\d{3,4}$/;
    App.pattern.vehicleIdentificationNumber = /^[a-zA-Z\d]{17}$/;

    App.message = new Object();
    App.message.requestHeader = 'Solicitud enviada';
    App.message.requestBody = 'Gracias por su interés - Nuestros representantes estarán en contacto en breve';

    App.message.brochureHeader = 'Descarga de Catalogo';
    App.message.brochureBody = 'Gracias por su interés en nuestros vehículos';

    App.message.scheduleAppointmentHeader = 'Información Enviada Con Exito';
    App.message.scheduleAppointmentBody = '¡GRACIAS POR CONTACTARNOS! - UN ASESOR ESPECIALIZADO SE COMUNICARÁ CONTIGO';

    App.isMobile = $(window).width() <= 640;

    App.getHelpText = function (property, propertyOwner) {

        if (propertyOwner === undefined)
            propertyOwner = '';

        return helptText.format(property, propertyOwner);
    };


    App.newGuid = function () {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
                .toString(16)
                .substring(1);
        }
        return s4() + s4() + s4() + s4() + s4() + s4() + s4() + s4();
    }

    App.isValidObject = function (obj) {
        var result = false;

        if (obj === undefined)
            return result;

        if (obj === null)
            return result;

        if (angular.isObject(obj) || angular.isString(obj) || angular.isNumber(obj) || angular.isDefined(obj))
            result = true;

        return result;
    };

    App.isValidArray = function (objArray) {
        var result = false;

        if (!App.isValidObject(objArray))
            return result;

        if (!angular.isArray(objArray))
            return result;

        if (objArray.length >= 1)
            result = true;

        return result;
    };

    //
    App.getDistinctList = function (list, propertyName) {
        var result = [];

        if (angular.isString(propertyName)) {
            for (var i = 0; i < list.length; i++) {
                if (!App.checkDuplicate(result, list[i][propertyName])) {
                    result.push(list[i][propertyName]);
                }
            }
        }
        else {
            for (var i = 0; i < list.length; i++) {
                if (!App.checkDuplicate(result, list[i])) {
                    result.push(list[i]);
                }
            }
        }

        return result;
    };
    //
    App.checkDuplicate = function (list, obj) {
        var result = false;

        for (var i = 0; i < list.length; i++) {
            if (App.checkObjectEqual(list[i], obj)) {
                result = true;
                break;
            }
        }

        return result;
    };
    //
    App.checkObjectEqual = function (obj1, obj2) {
        var result = false;

        result = angular.equals(obj1, obj2);

        return result;
    };
    //Returns a random number between min (inclusive) and max (inclusive)
    App.getRandomInt = function (min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
    //
    App.getDate = function (date, time) {
        var dateTime = '';

        if (date !== undefined && time !== undefined) {
            var year = date.getFullYear();
            var month = date.getMonth() + 1;
            var day = date.getDate();

            dateTime = '';

            dateTime = year;
            dateTime += '-';
            dateTime += month > 9 ? month : '0' + month;
            dateTime += '-';
            dateTime += day > 9 ? day : '0' + day;
            dateTime += ' ';
            dateTime += time.getHours() > 9 ? time.getHours() : '0' + time.getHours();
            dateTime += ':';
            dateTime += time.getMinutes() > 9 ? time.getMinutes() : '0' + time.getMinutes();
        }

        return dateTime;
    };
    //
    App.validateForm = function (entity, entityDescriptionList, currentStep, partialResult) {
        var result = true;

        if (currentStep > entityDescriptionList.length) {
            return result;
        }

        var entityDescription = entityDescriptionList[currentStep - 1];
        var rootEntity = entity[entityDescription.entityName];

        if (!App.isValidObject(rootEntity)) {
            result = false;
            return result;
        }

        for (var i = 0; i < entityDescription.attributeList.length; i++) {
            var attribute = entityDescription.attributeList[i];
            var property = App.getProperty(rootEntity, attribute);

            if (partialResult) {
                if (App.isValidObject(property)) {
                    break;
                }
            }
            else {
                if (!App.isValidObject(property)) {
                    result = false;
                    break;
                }
            }
        }

        return result;
    };
    //
    App.getProperty = function (entity, attribute) {
        var result = '';

        if (attribute.attributeName.indexOf('|') > 0) {
            result = App.getListBy(entity, attribute.attributeName)
        }
        else {
            if (attribute.attributeName.indexOf('.') > 0) {
                result = App.getObjectBy(entity, attribute.attributeName)
            }
            else {
                if (attribute.attributeName.toLowerCase().indexOf('date') !== -1 || attribute.attributeName.toLowerCase().indexOf('time') !== -1) {
                    var date = entity[attribute.attributeName];

                    if (date === undefined)
                        return date;

                    if (attribute.attributeName.toLowerCase().indexOf('date') !== -1) {
                        var year = date.getFullYear();
                        var month = date.getMonth() + 1;
                        var day = date.getDate();

                        result = year;
                        result += ' / ';
                        result += month > 9 ? month : '0' + month;
                        result += ' / ';
                        result += day > 9 ? day : '0' + day;
                    }
                    if (attribute.attributeName.toLowerCase().indexOf('time') !== -1) {
                        result += date.getHours() > 9 ? date.getHours() : '0' + date.getHours();
                        result += ' : ';
                        result += date.getMinutes() > 9 ? date.getMinutes() : '0' + date.getMinutes();
                    }
                }
                else {
                    result = entity[attribute.attributeName];
                }
            }
        }

        return result;
    };
    //
    App.getListBy = function (obj, stringName) {
        var attributeList = stringName.split('|');

        if (attributeList.length !== 2)
            return '';

        var result = '';

        var rootObj = App.getObjectBy(obj, attributeList[0]);

        if (!App.isValidArray(rootObj)) {
            return '';
        }

        for (var i = 0; i < rootObj.length; i++) {
            var childObj = App.getObjectBy(rootObj[i], attributeList[1]);
            if (i === 0) {
                result += childObj;
            }
            else {
                result += ', ' + childObj;
            }
        }

        return result;
    };
    //
    App.getObjectBy = function (obj, stringName) {
        if (!App.isValidObject(obj))
            return '';

        var attributeList = stringName.split('.');
        var result = obj;

        for (var i = 0; i < attributeList.length; i++) {
            result = result[attributeList[i]];
            if (result === undefined || result === null)
                break;
        }

        return result;
    };
    //
    App.getBaseFormRequest = function (currentStep, routeParams) {
        var formRequest = new Object();

        formRequest.parameterRequest = App.getParameterRequest(routeParams);
        formRequest.windowInformation = App.getWindowInformation();
        formRequest.browserInformation = App.getBrowserInformation();
        formRequest.session = App.getUserSession(currentStep);

        return formRequest;
    };
    //
    App.getUserSession = function (currentStep) {
        var session = new Object();
        session.currentStep = currentStep;
        session.userId = 'usr_' + App.newGuid();

        return session;
    };
    //
    App.getParameterRequest = function (routeParams) {
        var parameterList = [];

        if (!App.isValidObject(routeParams)) {
            return parameterList;
        }

        for (var parameter in routeParams) {
            var aux = new Object();
            aux.name = parameter;
            aux.value = routeParams[parameter];

            parameterList.push(aux);
        }
        return parameterList;
    };
    //
    App.getWindowInformation = function () {
        var windowInformation = new Object();

        windowInformation.width = $(window).width();
        windowInformation.height = $(window).height();

        return windowInformation;
    };
    //
    App.getBrowserInformation = function () {
        var browserInformation = new Object();

        browserInformation.previousUrl = document.referrer;
        browserInformation.platform = navigator.platform;
        browserInformation.name = navigator.appCodeName;
        browserInformation.version = navigator.appVersion;
        browserInformation.userAgent = navigator.userAgent;
        browserInformation.vendor = navigator.vendor;

        return browserInformation;
    };
    //
    if (!String.prototype.format) {
        String.prototype.format = function () {
            var args = arguments;
            return App.replace(/{(\d+)}/g, function (match, number) {
                return typeof args[number] != 'undefined'
                    ? args[number]
                    : match
                    ;
            });
        };
    };
})(App);