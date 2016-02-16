(function () {
	"use strict";
	angular
		.module("realEstateManagement")
		.controller("HouseListCtrl", ["houseResource", HouseListCtrl]);

	function HouseListCtrl(houseResource) {
		var self = this;

		houseResource.query(function (data) {
		    self.houses = data;
		});

	}
}());