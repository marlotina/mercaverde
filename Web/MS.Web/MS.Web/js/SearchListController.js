
var app = angular.module('multipleCtrlApp', ['ui.bootstrap']);

app.controller('listStoresController', function ($scope, $http) {
    $scope.currentPage = 1
  , $scope.numPerPage = 10
  , $scope.maxSize = 5;

    $scope.getStores = function(startItem, numItems) {

        var distrcits = [];
        $('#divDistricts input:checked').each(function() {
            distrcits.push($(this).attr('value'));
        });

        var categories = [];
        $('#divCategory input:checked').each(function() {
            categories.push($(this).attr('value'));
        });

        var labels = [];
        $('#divLabel input:checked').each(function() {
            labels.push($(this).attr('value'));
        });

        var filter = {
            IdLocation: $('#pLocationId').val(),
            LocationName: $('#pLocationName').val(),
            LanguageId: $('#pIdLanguage').val(),
            DistrictsList: distrcits,
            CategoryList: categories,
            LabelList: labels,
            StartItem: startItem,
            NumItems: numItems,
            Order: $("#pOrder").val()
        };

        UpdateQueryStringParameter("pLocationId", filter.IdLocation);
        UpdateQueryStringParameter("pLocationName", filter.LocationName);
        UpdateQueryStringParameter("pIdLanguage", filter.LanguageId);
        UpdateQueryStringParameter("pDistrictsList", filter.DistrictsList);
        UpdateQueryStringParameter("pCategoryList", filter.CategoryList);
        UpdateQueryStringParameter("pLabelList", filter.LabelList);

        $http.post('/api/Search/List/', filter).success(function(data) {
            $scope.storeList = data;
            $scope.loading = false;
        }).error(function(data) {
            alert(data.Message);
            $scope.loading = false;

        });
    };

    $scope.$watch('currentPage + numPerPage', function() {
        var startItem = (($scope.currentPage - 1) * $scope.numPerPage);
        $scope.getStores(startItem, $scope.numPerPage);
    });

    $scope.cleanFilters = function() {
        $('#searchForm input:checked').each(function () {
            $(this).attr('checked', false);
        });
    };

    $scope.changeOrder = function () {
        $("#pOrder").val($("#selectOrder option:selected").val());

        var startItem = (($scope.currentPage - 1) * $scope.numPerPage);
        $scope.getStores(startItem, $scope.numPerPage);
    };
});

$("#DdlCities").change(function () {
    $("#pLocationName").val($("#DdlCities option:selected").text());
    $("#pLocationId").val($("#DdlCities option:selected").val());
});




//(function () {
//    'use strict';
//    angular
//        .module('autocompleteDemo', ['ngMaterial'])
//        .controller('DemoCtrl', DemoCtrl);
//    function DemoCtrl($timeout, $q, $log) {
//        var self = this;
//        self.simulateQuery = false;
//        self.isDisabled = false;
//        // list of `state` value/display objects
//        self.states = loadAll();
//        self.querySearch = querySearch;
//        self.selectedItemChange = selectedItemChange;
//        self.searchTextChange = searchTextChange;
//        self.newState = newState;
//        function newState(state) {
//            alert("Sorry! You'll need to create a Constituion for " + state + " first!");
//        }
//        // ******************************
//        // Internal methods
//        // ******************************
//        /**
//         * Search for states... use $timeout to simulate
//         * remote dataservice call.
//         */
//        function querySearch(query) {
//            var results = query ? self.states.filter(createFilterFor(query)) : self.states,
//                deferred;
//            if (self.simulateQuery) {
//                deferred = $q.defer();
//                $timeout(function () { deferred.resolve(results); }, Math.random() * 1000, false);
//                return deferred.promise;
//            } else {
//                return results;
//            }
//        }
//        function searchTextChange(text) {
//            $log.info('Text changed to ' + text);
//        }
//        function selectedItemChange(item) {
//            $log.info('Item changed to ' + JSON.stringify(item));
//        }
//        /**
//         * Build `states` list of key/value pairs
//         */
//        function loadAll() {
//            var allStates = 'Alabama, Alaska, Arizona, Arkansas, California, Colorado, Connecticut, Delaware,\
//              Florida, Georgia, Hawaii, Idaho, Illinois, Indiana, Iowa, Kansas, Kentucky, Louisiana,\
//              Maine, Maryland, Massachusetts, Michigan, Minnesota, Mississippi, Missouri, Montana,\
//              Nebraska, Nevada, New Hampshire, New Jersey, New Mexico, New York, North Carolina,\
//              North Dakota, Ohio, Oklahoma, Oregon, Pennsylvania, Rhode Island, South Carolina,\
//              South Dakota, Tennessee, Texas, Utah, Vermont, Virginia, Washington, West Virginia,\
//              Wisconsin, Wyoming';
//            return allStates.split(/, +/g).map(function (state) {
//                return {
//                    value: state.toLowerCase(),
//                    display: state
//                };
//            });
//        }
//        /**
//         * Create filter function for a query string
//         */
//        function createFilterFor(query) {
//            var lowercaseQuery = angular.lowercase(query);
//            return function filterFn(state) {
//                return (state.value.indexOf(lowercaseQuery) === 0);
//            };
//        }
//    }
//})();

function UpdateQueryStringParameter(key, value) {
    //actualiza url navegador
    var uri = window.location.href;
    var url = uri;
    var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
    var separator = uri.indexOf('?') !== -1 ? "&" : "?";
    if (uri.match(re)) {
        if (value != "") {
            url = uri.replace(re, '$1' + key + "=" + value + '$2');
        } else {
            url = uri.replace(re, '');
        }
    }
    else {
        if (value != "") {
            url = uri + separator + key + "=" + value;
        }
    }

    window.history.pushState("", "", url);

    // url enlace busqueda mapa
    var uriSearchLink = $("#SearchToOtherViewLink").attr('href');
    var urlSearchLink = uriSearchLink;
    
    if (uriSearchLink.match(re)) {
        if (value != "") {
            urlSearchLink = uriSearchLink.replace(re, '$1' + key + "=" + value + '$2');
        } else {
            urlSearchLink = uriSearchLink.replace(re, '');
        }
    }
    else {
        if (value != "") {
            urlSearchLink = uriSearchLink + separator + key + "=" + value;
        }
    }

    $("#SearchToOtherViewLink").attr("href", urlSearchLink);
}




