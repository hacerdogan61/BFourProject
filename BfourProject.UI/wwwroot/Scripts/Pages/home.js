ProjectApp.controller('HomeController', ['$scope', '$http', '$sce', function ($scope, $http, $sce) {

    $scope.Alert = function () {
        alert("sa");
    }


    $(document).ready(function () {
        $scope.Alert();
    });


}]).directive('onFinishRender', function ($timeout) {
    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            if (scope.$last === true) {//ng repeat dönerken son kayıtmı diye bakıyorum
                $timeout(function () {
                    scope.$emit(attr.onFinishRender);
                });
            }
        }
    };
});