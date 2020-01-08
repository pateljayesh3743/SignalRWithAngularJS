(function () { // Angular encourages module pattern, good!
    var app = angular.module('myApp', []);
    app.controller('myCtrl', ['$http', '$scope', function ($http, $scope) {
    
        $scope.hub = null;
        $scope.hub = $.connection.myHub;
        $.connection.hub.start().done(function () {
            $scope.load_data_grid();
        });
        $scope.hub.client.updateGrid = function (item) {
            $scope.students.push(item);
            $scope.$apply();
        };  
        
        $scope.students = [];
        $scope.studentIdSubscribed;

        $scope.load_data_grid = function () {
            
            $http({
                url: "/home/GetStudent",
                method: "GET",
                //data: $.param(self.grid_request),
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
            }).then(function (response) {
                $scope.students = response.data;
            }).catch(function (reason) {
               
                // your error reason here
            });
        };

        $scope.postOne = function () {
            $http({
                url: "/home/AddStudent",
                method: "POST",
                data: $.param({id : $scope.id, student_name : $scope.student_name}),
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
            }).then(function (response) {
                console.log('su');              
            }).catch(function (reason) {
               
                // your error reason here
            });
        };
    }]);
})();
