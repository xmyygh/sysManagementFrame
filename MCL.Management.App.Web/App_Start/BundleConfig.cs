using System.Web;
using System.Web.Optimization;

namespace MCL.Management.App.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //系统必须css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                          "~/Content/css/bootstrap.min14ed.css?v=3.3.6",
                          "~/Content/css/font-awesome.min93e3.css?v=4.4.0",
                          "~/Content/css/animate.min.css",
                          "~/Content/css/style.min862f.css?v=4.1.0"));

            //系统必须js
            bundles.Add(new ScriptBundle("~/Content/js").Include(
                        "~/Content/js/jquery.min.js?v=2.1.4",
                        "~/Content/js/bootstrap.min.js?v=3.3.6",
                        "~/Content/js/content.min.js?v=1.0.0"));

            //cookice js
            bundles.Add(new ScriptBundle("~/Content/js/plugins/cookie/jquery.cookie.js").Include());

            //bootstrap-table表格 css
            bundles.Add(new StyleBundle("~/Content/css/table").Include(
                          "~/Content/css/plugins/bootstrap-table/bootstrap-table.min.css"));

            //bootstrap-table表格 js
            bundles.Add(new ScriptBundle("~/Content/js/table").Include(
                      "~/Content/js/plugins/bootstrap-table/bootstrap-table.min.js",
                      "~/Content/js/plugins/bootstrap-table/bootstrap-table-mobile.min.js",
                      "~/Content/js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"));            
        }
    }
}
