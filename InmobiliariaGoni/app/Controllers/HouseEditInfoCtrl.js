(function () {
    "use strict";

    angular.module("realEstateManagement").controller("HouseEditInfoCtrl", ["house", "$state", HouseEditInfoCtrl]);

    function HouseEditInfoCtrl(house, $state) {
        var self = this;

        self.house = house;

        // Open method for calendar control
        self.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            self.opened = !self.opened;
        }

        self.submit = function () {
            console.log("Saved house: " + self.house);
            self.house.$save(function (data) {
                toastr.success("La casa se guardó existosamente");
            });
        }

        self.cancel = function () {
            $state.go('houseList');
        }
    }
}());