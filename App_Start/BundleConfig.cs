using System.Web.Optimization;

namespace PersonelMVCUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery-3.5.1.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap4.min.js",
                "~/Scripts/bootbox.min.js",
                "~/Scripts/custom.js"

            ));
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/bootstrap.min.css",
            "~/Content/site.css",
            "~/Content/DataTables/css/dataTables.bootstrap4.min.css"
            ));
        }
    }
}
