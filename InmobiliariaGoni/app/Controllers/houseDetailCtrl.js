(function () {
    "use strict";

    angular.module("realEstateManagement").controller("HouseDetailCtrl", ["house", HouseDetailCtrl]);

    function HouseDetailCtrl(house) {
        var self = this;

        self.house = house;

        if (self.house.tags) {
            self.house.tagList = self.house.tags.toString();
        }
    }
}());