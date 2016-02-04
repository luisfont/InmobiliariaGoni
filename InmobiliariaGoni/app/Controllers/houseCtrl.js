(function () {
	"use strict";
	angular
		.module("realEstateManagement")
		.controller("HouseListCtrl", HouseListCtrl);

	function HouseListCtrl() {
		var self = this;

		self.houses = [
		   {
			   "houseId": 1,
			   "houseTitle": "Casa en renta o venta",
			   "houseCode": "VNT-001",
			   "description": "Hermosa casa disponible para compra o renta en buena ubicación.",
			   "price": 1500000,
			   "category": "house",
			   "tags": ["casa", "renta", "venta"],
			   "imageUrl": "http://placehold.it/700x400"
		   },
			{
			    "houseId": 2,
			    "houseTitle": "Casa en venta",
			    "houseCode": "VNT-002",
			    "description": "Casa unicamente en venta.",
			    "price": 2500000,
			    "category": "house",
			    "tags": ["casa", "venta"],
			    "imageUrl": "http://placehold.it/700x400"
			}];
	}
}());