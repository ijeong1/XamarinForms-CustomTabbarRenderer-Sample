using Xamarin.Forms;
using CoreGraphics;
using CustomTabbarRendererSample.Controls;
using CustomTabbarRendererSample.iOS.Renderers;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using System.Threading.Tasks;

[assembly: ExportRenderer(typeof(Shell), typeof(CustomShellRenderer))]
namespace CustomTabbarRendererSample.iOS.Renderers
{
    public class CustomShellRenderer : ShellRenderer
    {
        UIButton btn;
        IShellItemRenderer render;
        CustomTabBar thisitem;
        public CustomShellRenderer()
        {
            //use MessagingCenter to hide and show the button
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item)
        {
            render = base.CreateShellItemRenderer(item);
            thisitem = (CustomTabBar)item;

            if (thisitem.LargeTab != null)
            {
                SetLargeIcon();
            }

            return render;
        }

        private async void SetLargeIcon()
        {
            var view = render.ViewController;
            btn = new UIButton(frame: new CoreGraphics.CGRect(0, 0, 100, 100));
            btn.SetImage(await GetBitmapAsync(thisitem.LargeTab.Icon), UIControlState.Normal);
            view.Add(btn);
            //customize button
            btn.ClipsToBounds = true;
            btn.Layer.CornerRadius = 50;
            btn.AdjustsImageWhenHighlighted = false;
            CGPoint center = new CGPoint();
            //caculate to get the X and Y value of the button's location
            center.Y = (view.View.Frame.X + view.View.Frame.Size.Height) - 30 - 22 - 30;
            center.X = (view.View.Frame.Size.Width) / 2;
            btn.Center = center;
            //button click event
            btn.TouchUpInside += (sender, ex) =>
            {
                //use mssage center to inkove method in Forms project
            };
        }

        private async Task<UIImage> GetBitmapAsync(ImageSource source)
        {
            var handler = GetHandler(source);
            var returnValue = (UIImage)null;

            returnValue = await handler.LoadImageAsync(source);

            return returnValue;
        }

        private static IImageSourceHandler GetHandler(ImageSource source)
        {
            IImageSourceHandler returnValue = null;
            if (source is UriImageSource)
            {
                returnValue = new ImageLoaderSourceHandler();
            }
            else if (source is FileImageSource)
            {
                returnValue = new FileImageSourceHandler();
            }
            else if (source is StreamImageSource)
            {
                returnValue = new StreamImagesourceHandler();
            }
            return returnValue;
        }

    }
}
