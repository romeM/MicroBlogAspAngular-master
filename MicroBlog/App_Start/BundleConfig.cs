using System.Web.Optimization;

namespace MicroBlog
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/browserApp/bower_components/angularjs/angular.js")
                .Include("~/browserApp/bower_components/angular-route/angular-route.js"));
            
            bundles.Add(new StyleBundle("~/css/bootstrap")
                .Include("~/browserApp/bower_components/bootstrap/dist/css/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/application")
                .Include("~/browserApp/js/main.js")
                .IncludeDirectory("~/browserApp/js/controllers", "*.js", false)
                .IncludeDirectory("~/browserApp/js/services", "*.js", false));
            
            bundles.Add(new StyleBundle("~/css/styles").Include("~/browserApp/css/app.css"));
        }
    }
}