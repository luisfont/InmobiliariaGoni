(function () {
    "use strict";

    angular.module("realEstateManagement").controller("HouseEditInfoCtrl", ["house", HouseEditInfoCtrl]);

    function HouseEditInfoCtrl(house) {
        var self = this;

        self.house = house;

        self.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            self.opened = !self.opened;
        }
    }
}());