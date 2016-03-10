(function () {
    "use strict";

    angular.module("realEstateManagement").controller("HouseEditCtrl", ["house", "$state", HouseEditCtrl]);

    function HouseEditCtrl(house, $state) {
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

        self.submit = function () {
            console.log("Saved house: " + self.house);
            self.house.$save();
        }

        self.cancel = function () {
            $state.go('houseList');
        }
    }
}());