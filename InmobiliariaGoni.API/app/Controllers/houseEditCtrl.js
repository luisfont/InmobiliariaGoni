(function () {
    "use strict";

    angular.module("realEstateManagement").controller("HouseEditCtrl", ["house", HouseEditCtrl]);

    function HouseEditCtrl(house) {
        var self = this;

        self.house = house;

        if (self.house && self.house.houseId) {
            self.title = "Editar: " + self.house.houseTitle;
        }
        else {
            self.title = "Nueva casa";
        }

        if (self.house.tags) {
            self.house.tagList = self.house.tags.toString();
        }
    }
}());