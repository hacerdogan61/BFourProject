var ProjectApp = angular.module('ProjectApp', ['ngSanitize', 'ngResource']);

ProjectApp.run(['$rootScope', '$http', function ($rootScope, $http) {
    $rootScope.IsShow = false;
    $rootScope.currentUser = {};

    //$rootScope.FireCustomLoading = function (cntrl) {
    //    if (cntrl === undefined || cntrl === null || cntrl === "")
    //        cntrl = false;

    //    if (cntrl) {
    //        if (!$('.loading-full').hasClass("loading-show"))
    //            $('.loading-full').addClass("loading-show");
    //    }
    //    else {
    //        if ($('.loading-full').hasClass("loading-show"))
    //            $('.loading-full').removeClass("loading-show");
    //    }
    //}
    $rootScope.getCurrent = function () {
        $http({
            method: "GET",
            url: "/Base/GetBankList",
            headers: { "Content-Type": "Application/json;charset=utf-8" },
            data: {}

        }).then(function (response) {
            $rootScope.currentUser = response.data;
        });
    };

    $(document).ready(function () {
     //   $rootScope.IsShow = false;
       // $rootScope.getCurrent();
    });

}]);