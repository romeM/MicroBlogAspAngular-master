app.controller('postsCtrl', ['$scope', 'Api', function ($scope, Api) {
    var $this = this;

    this.apiGetPosts = function () {
        Api.getPosts().then(function (response) {
            $scope.posts = response.data;
        });
    };

    this.apiGetAuthors = function () {
        Api.getAuthors().then(function (response) {
            $scope.authors = response.data;
        });
    };

    $scope.save = function (author) {
        Api.putPost(author).then(function () {
            $scope.selectedPost = null;
            $this.apiGetPosts();
        });
    };

    $scope.selectPost = function (post) {
        $scope.selectedPost = post;
    };

    $scope.create = function (post) {
        Api.postPost(post).then(function () {
            $scope.selectedPost = null;
            $this.apiGetPosts();
        });
    };

    $scope.cancel = function () {
        $scope.selectedPost = null;
        $this.apiGetPosts();
    };

    $scope.delete = function (id) {
        Api.deletePost(id).then(function () {
            $this.apiGetPosts();
            $scope.selectedAuthor = null;
        });
    };

    this.apiGetPosts();
    this.apiGetAuthors();

}]);