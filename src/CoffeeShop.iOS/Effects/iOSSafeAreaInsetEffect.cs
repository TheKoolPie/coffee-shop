using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("CoffeeShop")]
[assembly: ExportEffect(typeof(CoffeeShop.iOS.Effects.iOSSafeAreaInsetEffect),nameof(CoffeeShop.iOS.Effects.iOSSafeAreaInsetEffect))]
namespace CoffeeShop.iOS.Effects
{

    public class iOSSafeAreaInsetEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if(Element is Layout element)
            {
                var safeArea = UIApplication.SharedApplication.Delegate.GetWindow().SafeAreaInsets;
                element.Margin = new Thickness(0, 0, 0, -safeArea.Bottom);
            }
        }

        protected override void OnDetached()
        {
            if (Element is Layout element)
            {
                element.Margin = new Thickness();
            }
        }
    }
}
