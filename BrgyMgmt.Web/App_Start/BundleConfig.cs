using System.Web;
using System.Web.Optimization;

namespace BrgyMgmt.Web {
    public class BundleConfig {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/js/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/js/jquery/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Content/js/bootstrap/bootstrap.js"
                      , "~/Content/js/adminlte.min.js"
                      , "~/Content/js/overlayScrollbars/jquery.overlayScrollbars.min.js"
                      , "~/Content/js/demo.js"
                      ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/css/bootstrap.css"
                      , "~/Content/css/fontello/fontello.css"
                      , "~/Content/css/adminlte.min.css"
                      , "~/Content/css/fontello/fontello.css"
                      , "~/Content/css/overlayScrollbars/OverlayScrollbars.min.css"
                      , "~/Content/css/site.css"
                      ));
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
