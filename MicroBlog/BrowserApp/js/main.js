/**
 * Microblog application main
 */

"use strict";

// Main module, to extend with submodules as needed
var app = angular.module("MicroBlog", ['ngRoute'])
    .config(['$routeProvider', function ($routeProvider) {

        // Create some default routes, to refine
        $routeProvider
        .when('/', { templateUrl: 'BrowserApp/partials/authors.html', controller: 'authorsCtrl' })
        .when('/posts', { templateUrl: 'BrowserApp/partials/posts.html', controller: 'postsCtrl' })
        .when('/authors', { templateUrl: 'BrowserApp/partials/authors.html', controller: 'authorsCtrl' })
        .when('/author/:authorId', { templateUrl: 'BrowserApp/partials/author.html', controller: 'authorCtrl' })
        .otherwise({ redirectTo: '/authors' }); // Default

    }])

    // Initial run function setting the version number
    .run(['$rootScope', function ($rootScope) {
        $rootScope.version = "0.0";
    }]);