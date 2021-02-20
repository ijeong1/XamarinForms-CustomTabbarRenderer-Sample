using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CustomTabbarRendererSample.Droid.Renderers;

[assembly: ExportRenderer(typeof(Shell), typeof(CustomShellRenderer))]
namespace CustomTabbarRendererSample.Droid.Renderers
{
    public class CustomShellRenderer : ShellRenderer
    {
        public CustomShellRenderer(Context context) : base(context)
        {
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
        {
            return new CustomShellItemRenderer(this);
        }
    }
}
