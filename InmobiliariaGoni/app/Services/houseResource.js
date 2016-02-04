(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("houseResource",
            ["$resource", houseResource]);

    function houseResource($resource) {
        return $resource("api/houses/:houseId");
    }
}());