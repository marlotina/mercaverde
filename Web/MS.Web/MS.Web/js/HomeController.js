angular.module('multipleCtrlApp', [])
    .controller('homeSearchController', ['$scope', '$window', function ($scope, $window) {
        $scope.submit = function () {


            var selectedCategory = $("#ulCategories li.active");

            var url = "http://" + domain + "/Search/List?" + "pLocationName=" + $("#hdnLocationName").val() +
                "&pLocationId=" + $("#hdnLocationId").val() + "&pCategoryList=" + selectedCategory.attr('id').split("-")[1];

            $window.location.href = url;
        };
    }]);


$("#DdlCities").change(function () {
    $("#hdnLocationName").val($("#DdlCities option:selected").text());
    $("#hdnLocationId").val($("#DdlCities option:selected").val());
});



