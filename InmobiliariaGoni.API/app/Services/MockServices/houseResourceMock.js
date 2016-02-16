(function () {
    "use strict";
    
    var app = angular.module("houseResourceMock", ["ngMockE2E"]);

    app.run(function ($httpBackend) {
        var houses = [{
                "houseId": 1,
                "houseTitle": "Casa en renta o venta",
                "houseCode": "VNT-001",
                "description": "Hermosa casa disponible para compra o renta en buena ubicación.",
                "availableFrom": "01/01/2016",
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
                "availableFrom": "01/01/2016",
                "price": 2500000,
                "category": "house",
                "tags": ["casa", "venta"],
                "imageUrl": "http://placehold.it/700x400"
            }];

        var houseUrl = "api/houses";
        var editingRegex = new RegExp(houseUrl + "/[0-9][0-9]*", '');

        $httpBackend.whenGET(houseUrl).respond(houses);
        $httpBackend.whenGET(editingRegex).respond(function (method, url, data) {
            var house = { "houseId": 0 };
            var parameters = url.split('/');
            var length = parameters.length;
            var id = parameters[length - 1];

            if (id > 0) {
                for (var i = 0; i < houses.length; i++) {
                    if (houses[i].houseId == id) {
                        house = houses[i];
                        break;
                    }
                };
            }
            return [200, house, {}];
        });

        $httpBackend.whenPOST(houseUrl).respond(function (method, url, data) {
            var house = angular.fromJson(data);

            if (!house.houseId) {
                // new house Id
                house.houseId = houses[houses.length - 1].houseId + 1;
                houses.push(house);
            }
            else {
                // Updated house
                for (var i = 0; i < houses.length; i++) {
                    if (houses[i].houseId == house.houseId) {
                        houses[i] = house;
                        break;
                    }
                };
            }
            return [200, house, {}];
        });

        // Pass through any requests for application files
        $httpBackend.whenGET(/app/).passThrough();
    });

}());