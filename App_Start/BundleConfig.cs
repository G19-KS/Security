using System.Web;
using System.Web.Optimization;

namespace QuanLiKS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/TemplateScript").Include(
                      "~/js/jquery.min.js",
                     "~/js/bootstrap.bundle.min.js",
                     "~/js/jquery.easing.min.js",
                     "~/js/jquery.dataTables.js",
                      "~/js/dataTables.bootstrap4.js",
                      "~/js/sb-admin.min.js",
                      "~/js/sb-admin-datatables.min.js"));

            bundles.Add(new StyleBundle("~/Content/TemplateStyle").Include(
                      "~/css//bootstrap.min.css",
                      "~/css/font-awesome.min.css",
                      "~/css/dataTables.bootstrap4.css",
                      "~/css/sb-admin.css"));
        }
    }
}
