(function () {
    'use strict';
    // angular service to perform game of life patterns
    app.service("goiService", function ($http, $q) {
        //Service to initialize GOI grid
        this.getInititalGridData = function () {
            var response = $http({
                url: rootUrl + 'api/initializeGOIGrid/' + goiGridSize,
                method: 'GET',
            });
            return response;

        }
        //Service to update GOI grid with next pattern
        this.updateGridData = function (dataToSend) {
            var response = $http({
                url: rootUrl + 'api/updateGOIGrid',
                method: 'POST',
                data: dataToSend,
            });
            return response;
        };
    });
}());