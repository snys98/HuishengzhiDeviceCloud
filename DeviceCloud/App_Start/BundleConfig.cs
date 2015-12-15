using System.Web;
using System.Web.Optimization;

namespace DeviceCloud
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/js/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/js/modernizr-*"));

            bundles.Add(new StyleBundle("~/bundles/common-css").Include(
                      "~/Content/css/site.css",
                      "~/Content/css/amazeui.css"));

            bundles.Add(new ScriptBundle("~/bundles/ie9-gt-js").Include(
                      "~/Content/js/jquery-1.8.2.js",
                      "~/Content/js/amazeui.js",
                      "~/Content/js/nest.js",
                      "~/Content/js/amazeui.widgets.helper.js"));

            bundles.Add(new ScriptBundle("~/bundles/ie9-lt-js").Include(
                "~/Content/js/jquery-1.8.2.js",
                "~/Content/js/amazeui.ie8polyfill.js"));
        }
    }
}
