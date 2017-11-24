app.controller('authorCtrl', ['$scope','$routeParams', 'Api', function ($scope, $routeParams, Api) {
    var $this = this;
    this.authorId = $routeParams.authorId;

    this.apiGetAuthor = function(id) {
        Api.getAuthor(id).then(function (response) {
            $scope.author = response.data;
        });
    };
    
    this.apiGetAuthor(this.authorId);

}]);