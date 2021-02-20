using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using CustomTabbarRendererSample.Controls;
using CustomTabbarRendererSample.Droid.Extensions;
using Android.Support.Design.Widget;

using Xamarin.Forms.Platform.Android;

namespace CustomTabbarRendererSample.Droid.Renderers
{
    public class CustomShellItemRenderer : ShellItemRenderer
    {
        FrameLayout _shellOverlay;
        BottomNavigationView _bottomView;

        public CustomShellItemRenderer(IShellContext shellContext) : base(shellContext)
        {
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var outerlayout = base.OnCreateView(inflater, container, savedInstanceState);
            _bottomView = outerlayout.FindViewById<BottomNavigationView>(Resource.Id.bottomtab_tabbar);
            _shellOverlay = outerlayout.FindViewById<FrameLayout>(Resource.Id.bottomtab_tabbar_container);

            if (ShellItem is CustomTabBar todoTabBar && todoTabBar.LargeTab != null)
                SetupLargeTab();

            return outerlayout;
        }

        private async void SetupLargeTab()
        {
            var todoTabBar = (CustomTabBar)ShellItem;
            var layout = new FrameLayout(Context);

            var imageHandler = todoTabBar.LargeTab.Icon.GetHandler();
            Bitmap bitmap = await imageHandler.LoadImageAsync(todoTabBar.LargeTab.Icon, Context);
            var image = new ImageView(Context);
            image.SetImageBitmap(bitmap);

            layout.AddView(image);

            var lp = new FrameLayout.LayoutParams(150, 150);
            _bottomView.Measure((int)MeasureSpecMode.Unspecified, (int)MeasureSpecMode.Unspecified);
            lp.BottomMargin = _bottomView.MeasuredHeight / 2;

            layout.LayoutParameters = lp;

            _shellOverlay.RemoveAllViews();
            _shellOverlay.AddView(layout);
        }
    }
}
