(function () {
    "use strict";
    var app = angular.module("realEstateManagement",
                                ["common.services",
                                    "ui.router",
                                    "ui.mask",
                                    "ui.bootstrap",
                                    "houseResourceMock"]);

    app.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.html5mode = true;

        $urlRouterProvider.otherwise("/");

        $stateProvider
            //Home
            .state("home", {
                url: "/",
                templateUrl: "app/Views/Home/welcomeView.html"
            })
            //About Us
            .state("about", {
                url: "/about",
                templateUrl: "app/Views/Home/aboutView.html"
            })
            //House List
            .state("houseList", {
                url: "/houses",
                templateUrl: "app/Views/House/houseListView.html",
                controller: "HouseListCtrl as vm"
            })
            //House Detail
            .state("houseDetail", {
                url: "/houses/:houseId",
                templateUrl: "app/Views/House/houseDetailView.html",
                controller: "HouseDetailCtrl as vm",
                resolve: {
                    houseResource: "houseResource",
                    house: function (houseResource, $stateParams) {
                        var houseId = $stateParams.houseId;
                        return houseResource.get({ houseId: houseId }).$promise;
                    }
                }
            })
            //House edit
            .state("houseEdit", {
                abstract: true,
                url: "/houses/edit/:houseId",
                templateUrl: "app/Views/House/houseEditView.html",
                controller: "HouseEditCtrl as vm",
                resolve: {
                    houseResource: "houseResource",
                    house: function (houseResource, $stateParams) {
                        var houseId = $stateParams.houseId;
                        return houseResource.get({ houseId: houseId }).$promise;
                    }
                }
            })
            .state("houseEdit.info", {
                url: "/info",
                templateUrl: "app/Views/House/houseEditInfoView.html",
                controller: "HouseEditInfoCtrl as vm"
            })
            .state("houseEdit.tags", {
                url: "/tags",
                templateUrl: "app/Views/House/houseEditTagsView.html",
                controller: "HouseEditTagsCtrl as vm"
            })
            .state("houseEdit.images", {
                url: "/images",
                templateUrl: "app/Views/House/houseEditImagesView.html"
            })
            .state("houseEdit.adminInfo", {
                url: "/adminInfo",
                templateUrl: "app/Views/House/houseEditAdminInfoView.html"
            })
            .state("houseEdit.map", {
                url: "/map",
                templateUrl: "app/Views/House/houseEditMapView.html"
            });
    }]);
}());