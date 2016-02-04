(function () {
	"use strict";
	angular
		.module("realEstateManagement")
		.controller("ProductListCtrl", ProductListCtrl);

	function ProductListCtrl() {
		var self = this;

		self.products = [
		   {
			   "productId": 1,
			   "productName": "Leaf Rake",
			   "productCode": "GDN-0011",
			   "releaseDate": "March 19, 2009",
			   "description": "Leaf rake with 48-inch handle.",
			   "cost": 9.00,
			   "price": 19.95,
			   "category": "garden",
			   "tags": ["leaf", "tool"],
			   "imageUrl": "http://placehold.it/700x400"
		   },
		    {
			    "productId": 5,
			    "productName": "Hammer",
			    "productCode": "TBX-0048",
			    "releaseDate": "May 21, 2013",
			    "description": "Curved claw steel hammer",
			    "cost": 1.00,
			    "price": 8.99,
			    "category": "toolbox",
			    "tags": ["tool"],
			    "imageUrl": "http://placehold.it/700x400"
		    }];

		self.showImage = false;
		self.toggleImage = function () {
			self.showImage = !self.showImage;
		};
	}
}());