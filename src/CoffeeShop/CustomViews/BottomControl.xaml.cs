using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeShop.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomControl : ContentView
    {
        public static readonly BindableProperty LeftBtnBackgroundColorProperty =
            BindableProperty.Create("LeftBtnBackgroundColor", typeof(Color), typeof(BottomControl), null);

        public Color LeftBtnBackgroundColor
        {
            get { return (Color)GetValue(LeftBtnBackgroundColorProperty); }
            set { SetValue(LeftBtnBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty CenterBtnBackgroundColorProperty =
            BindableProperty.Create("CenterBtnBackgroundColor", typeof(Color), typeof(BottomControl), null);

        public Color CenterBtnBackgroundColor
        {
            get { return (Color)GetValue(CenterBtnBackgroundColorProperty); }
            set { SetValue(CenterBtnBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty RightBtnBackgroundColorProperty =
            BindableProperty.Create("RightBtnBackgroundColor", typeof(Color), typeof(BottomControl), null);

        public Color RightBtnBackgroundColor
        {
            get { return (Color)GetValue(RightBtnBackgroundColorProperty); }
            set { SetValue(RightBtnBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty LeftBtnTextColorProperty =
            BindableProperty.Create("LeftBtnTextColor", typeof(Color), typeof(BottomControl), null);

        public Color LeftBtnTextColor
        {
            get { return (Color)GetValue(LeftBtnTextColorProperty); }
            set { SetValue(LeftBtnTextColorProperty, value); }
        }

        public static readonly BindableProperty CenterBtnTextColorProperty =
            BindableProperty.Create("CenterBtnTextColor", typeof(Color), typeof(BottomControl), null);

        public Color CenterBtnTextColor
        {
            get { return (Color)GetValue(CenterBtnTextColorProperty); }
            set { SetValue(CenterBtnTextColorProperty, value); }
        }

        public static readonly BindableProperty RightBtnTextColorProperty =
            BindableProperty.Create("RightBtnTextColor", typeof(Color), typeof(BottomControl), null);

        public Color RightBtnTextColor
        {
            get { return (Color)GetValue(RightBtnTextColorProperty); }
            set { SetValue(RightBtnTextColorProperty, value); }
        }


        public static readonly BindableProperty ArcColorProperty =
            BindableProperty.Create("ArcColor", typeof(Color), typeof(BottomControl), null);

        public Color ArcColor
        {
            get { return (Color)GetValue(ArcColorProperty); }
            set { SetValue(ArcColorProperty, value); }
        }

        public static readonly BindableProperty LeftBtnIconTextProperty =
            BindableProperty.Create("LeftBtnIconText", typeof(string), typeof(BottomControl), null);
        public string LeftBtnIconText
        {
            get { return (string)GetValue(LeftBtnIconTextProperty); }
            set { SetValue(LeftBtnIconTextProperty, value); }
        }

        public static readonly BindableProperty CenterBtnIconTextProperty =
            BindableProperty.Create("CenterBtnIconText", typeof(string), typeof(BottomControl), null);
        public string CenterBtnIconText
        {
            get { return (string)GetValue(CenterBtnIconTextProperty); }
            set { SetValue(CenterBtnIconTextProperty, value); }
        }

        public static readonly BindableProperty RightBtnIconTextProperty =
            BindableProperty.Create("RightBtnIconText", typeof(string), typeof(BottomControl), null);
        public string RightBtnIconText
        {
            get { return (string)GetValue(RightBtnIconTextProperty); }
            set { SetValue(RightBtnIconTextProperty, value); }
        }

        public BottomControl()
        {
            InitializeComponent();
            BindingContext = this;
        }

        void SKCanvasView_PaintSurface(System.Object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKPaint arcColor = new SKPaint
            {
                Color = ArcColor.ToSKColor(),
                StrokeWidth = 2,
                Style = SKPaintStyle.StrokeAndFill
            };

            var w = e.Info.Width;
            var h = e.Info.Height;

            var canvas = e.Surface.Canvas;

            canvas.Clear();

            var h1 = h / 3.33f;
            float xDelta = w / 165;
            float yDelta = h / 6;
            var h2 = h1 + yDelta;

            var p1 = new SKPoint(0, h1);
            var p2 = new SKPoint(xDelta, h2);
            var p3 = new SKPoint(w / 3 - xDelta, h2);
            var p4 = new SKPoint(w / 3, h1);
            var p5 = new SKPoint(2 * w / 3, h1);
            var p6 = new SKPoint(2 * w / 3 + xDelta, h2);
            var p7 = new SKPoint(w - xDelta, h2);
            var p8 = new SKPoint(w, h1);

            var e1Xr = (p3.X - p2.X) / 2;
            var e2Xr = (p5.X - p4.X) / 2;
            var e3Xr = (p7.X - p6.X) / 2;

            float e1Yr = h / 2.5f;
            float e2Yr = h1;

            using (var path = new SKPath())
            {
                path.MoveTo(0, 0);

                path.LineTo(p1);
                path.LineTo(p2);

                path.ArcTo(e1Xr, e1Yr, 0, SKPathArcSize.Large, SKPathDirection.CounterClockwise, p3.X, p3.Y);

                path.LineTo(p4);

                path.ArcTo(e2Xr, e2Yr, 0, SKPathArcSize.Large, SKPathDirection.Clockwise, p5.X, p5.Y);

                path.LineTo(p6);

                path.ArcTo(e3Xr, e1Yr, 0, SKPathArcSize.Large, SKPathDirection.CounterClockwise, p7.X, p7.Y);

                path.LineTo(p8);

                path.LineTo(w, 0);

                canvas.DrawPath(path, arcColor);
            }

        }
    }
}