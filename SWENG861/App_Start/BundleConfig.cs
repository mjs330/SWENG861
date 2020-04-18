using System.Web;
using System.Web.Optimization;

namespace SWENG861
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
                      //"~/Scripts/bootstrap.min.js",
                      "~/Content/styles/bootstrap-4.1.2/bootstrap.min.js",
                      "~/Content/styles/bootstrap-4.1.2/popper.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      "~/Content/styles/bootstrap-4.1.2/bootstrap.min.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/colorlib").Include(
                      "~/Content/plugins/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/Content/plugins/OwlCarousel2-2.3.4/owl.carousel.css",
                      "~/Content/plugins/OwlCarousel2-2.3.4/owl.theme.default.css",
                      "~/Content/plugins/OwlCarousel2-2.3.4/animate.css",
                      "~/Content/styles/main_styles.css",
                      "~/Content/styles/responsive.css"));
        }
    }
}
