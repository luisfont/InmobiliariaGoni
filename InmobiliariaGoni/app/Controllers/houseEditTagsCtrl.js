(function () {
    "use strict";

    angular.module("realEstateManagement").controller("HouseEditTagsCtrl", ["house", "$state", HouseEditTagsCtrl]);

    function HouseEditTagsCtrl(house, $state) {
        var self = this;

        self.house = house;

        self.addTags = function (tags) {
            if (tags) {
                var array = tags.split(',');
                self.house.tags = self.house.tags ? self.house.tags.concat(array) : array;
                self.newTags = "";
            } else {
                alert('Necesitas escribir las palabras clave a agregar');
            }
        }

        self.removeTag = function (idx) {
            self.house.tags.splice(idx, 1);
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