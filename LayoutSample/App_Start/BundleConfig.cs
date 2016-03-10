using System.Web;
using System.Web.Optimization;

namespace LayoutSample
{
    public class BundleConfig
    {
        // 如需「搭配」的詳細資訊，請瀏覽 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.DirectoryFilter.Clear();
            bundles.DirectoryFilter.Ignore("*.intellisense.js");
            bundles.DirectoryFilter.Ignore("*-vsdoc.js");
            bundles.DirectoryFilter.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            bundles.DirectoryFilter.Ignore("*.min.css", OptimizationMode.WhenDisabled);

            bundles.Add(new ScriptBundle("~/bundles/Bootstrap_Metro_Dashboard_JS").Include(
                              "~/js/jquery-migrate-*",
                              "~/js/jquery-ui-*",
                              "~/js/jquery.ui.touch-punch*",
                              "~/js/modernizr*",
                              "~/js/bootstrap*",
                              "~/js/jquery.cookie*",
                              "~/js/fullcalendar*",
                              "~/js/jquery.dataTables*",
                              "~/js/excanvas*",
                              "~/js/jquery.flot*",
                              "~/js/jquery.flot.pie*",
                              "~/js/jquery.flot.stack*",
                              "~/js/jquery.flot.resize*",
                              "~/js/jquery.chosen*",
                              "~/js/jquery.uniform*",
                              "~/js/jquery.cleditor*",
                              "~/js/jquery.noty*",
                              "~/js/jquery.elfinder*",
                              "~/js/jquery.raty*",
                              "~/js/jquery.iphone.toggle*",
                              "~/js/jquery.uploadify-*",
                              "~/js/jquery.gritter*",
                              "~/js/jquery.imagesloaded*",
                              "~/js/jquery.masonry*",
                              "~/js/jquery.knob.modified*",
                              "~/js/jquery.sparkline*",
                              "~/js/counter*",
                              "~/js/retina*",
                              "~/js/custom.js"));



            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好實際執行時，請使用 http://modernizr.com 上的建置工具，只選擇您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
