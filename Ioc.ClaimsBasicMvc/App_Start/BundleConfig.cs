using System.Web;
using System.Web.Optimization;

namespace Ioc.ClaimsBasicMvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            //bundles sb-admin-2
            bundles.Add(new ScriptBundle("~/bundles/sb-admin-2/js").Include(
               "~/Scripts/sb-admin/metisMenu.js",
               "~/Scripts/sb-admin/sb-admin-2.js"));

            bundles.Add(new StyleBundle("~/bundles/sb-admin-2/css").Include(
                "~/Content/sb-admin-2.css",
                "~/Content/metisMenu.css",
                "~/Content/font-awesome.min.css"));
        }
    }
}
