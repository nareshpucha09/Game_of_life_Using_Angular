(function () {
    'use strict';
    // Angular contorller to dispaly grid and manage active and inative on cell click
    app.controller("goiCtrl", function ($scope, goiService) {
        $scope.isStarted = false;

        // Initialize with empty grid - Start
        $scope.goiGrid = [];
        var gridInfo = goiService.getInititalGridData();
        gridInfo.then(function (gridData) {
            gridData = gridData.data;
            $scope.goiGrid = gridData.gridCells;
            for (var x = 0; x < goiGridSize; x++) {
                for (var y = 0; y < goiGridSize; y++) {
                    $scope.goiGrid[x][y] = Cell(gridData.gridCells[x][y].position, { isAlive: gridData.gridCells[x][y].isAlive });
                }
            }
        },
        function () {
            toastr.error('Error in adding record');
        });
        // Initialize with empty grid - End

        // Generate next pattern - Start
        $scope.next = function () {
            var previousGoiGrid = angular.copy($scope.goiGrid);
            var dataToSend =
                {
                    gridData: {
                        totalRows: goiGridSize,
                        gridCells: previousGoiGrid
                    }
                };

            var gridInfo = goiService.updateGridData(dataToSend);
            gridInfo.then(function (gridData) {
                gridData = gridData.data;
                for (var x = 0; x < goiGridSize; x++) {
                    for (var y = 0; y < goiGridSize; y++) {
                        $scope.goiGrid[x][y] = Cell(gridData.gridCells[x][y].position, { isAlive: gridData.gridCells[x][y].isAlive });
                    }
                }
            },
            function () {
                toastr.error('Error in adding record');
            });

            function newCellState(cellState) {
                var newCell = Cell(cellState.position, { isAlive: cellState.isAlive });
                return newCell;
            }


        };
        // Generate next pattern - End
    });
}());

// Cell model
function Cell(position, options) {
    var defaults = {
        isAlive: false
    };
    return {
        position: position,
        isAlive: options && options.isAlive,
        toggle: function () { this.isAlive = !this.isAlive; }
    };
}