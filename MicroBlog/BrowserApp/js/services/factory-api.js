app.factory('Api', ['$http', function ($http) {
    urlApi = 'http://localhost:50864/api/';
    return {
        getAuthors: function () {
            return $http.get(urlApi + 'authors');
        },
        getAuthor: function (id) {
            return $http.get(urlApi + 'authors/' + id);
        },
        putAuthor: function (author) {
            return $http.put(urlApi + 'authors', author);
        },
        postAuthor: function (author) {
            return $http.post(urlApi + 'authors', author);
        },
        deleteAuthor: function (id) {
            return $http.delete(urlApi + 'authors/' + id);
        },
        getPosts: function () {
            return $http.get(urlApi + 'posts');
        },
        putPost: function (author) {
            return $http.put(urlApi + 'posts', author);
        },
        postPost: function (author) {
            return $http.post(urlApi + 'posts', author);
        },
        deletePost: function (id) {
            return $http.delete(urlApi + 'posts/' + id);
        }
    };
}]);