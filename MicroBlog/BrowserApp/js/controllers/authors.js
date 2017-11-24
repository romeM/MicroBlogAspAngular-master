app.controller('authorsCtrl', ['$scope', 'Api', function ($scope, Api) {
    var $this = this;

    this.apiGetAuthors = function() {
        Api.getAuthors().then(function (response) {
            $scope.authors = response.data;
        });
    };

    $scope.save = function (author) {
        Api.putAuthor(author);
        $scope.selectedAuthor = null;
    };

    $scope.selectAuthor = function (author) {
        $scope.selectedAuthor = author;
    };

    $scope.create = function (author) {
        Api.postAuthor(author).then(function () {
            $scope.selectedAuthor = null;
            $this.apiGetAuthors();
        });
    };

    $scope.cancel = function () {
        $scope.selectedAuthor = null;
        $this.apiGetAuthors();
    };

    $scope.delete = function (id) {
        Api.deleteAuthor(id).then(function () {
            $this.apiGetAuthors();
            $scope.selectedAuthor = null;
        });
    };

    this.apiGetAuthors();

}]);