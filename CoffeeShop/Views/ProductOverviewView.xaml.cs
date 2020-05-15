using System;
using System.Collections.Generic;
using CoffeeShop.ViewModels;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace CoffeeShop.Views
{
    public partial class ProductOverviewView : ContentPage
    {
        public ProductOverviewView()
        {
            InitializeComponent();
        }

        SKPaint arcColor = new SKPaint
        {
            Color = SKColor.Parse("#106b70"),
            StrokeWidth = 2,
            Style = SKPaintStyle.StrokeAndFill
        };

        void SKCanvasView_PaintSurface(System.Object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var w = e.Info.Width;
            var h = e.Info.Height;

            var canvas = e.Surface.Canvas;

            canvas.Clear();

            var h1 = h/3.33f;
            float xDelta = w/165;
            float yDelta = h/6;
            var h2 = h1 + yDelta;

            var p1 = new SKPoint(0, h1);
            var p2 = new SKPoint(xDelta, h2);
            var p3 = new SKPoint(w / 3 - xDelta, h2);
            var p4 = new SKPoint(w / 3, h1);
            var p5 = new SKPoint(2*w/3, h1);
            var p6 = new SKPoint(2*w/3 + xDelta, h2);
            var p7 = new SKPoint(w - xDelta, h2);
            var p8 = new SKPoint(w, h1);

            var e1Xr = (p3.X - p2.X) / 2;
            var e2Xr = (p5.X - p4.X) / 2;
            var e3Xr = (p7.X - p6.X) / 2;

            float e1Yr = h/2.5f;
            float e2Yr = h1;

            using (var path = new SKPath())
            {
                path.MoveTo(0, 0);

                path.LineTo(p1);
                path.LineTo(p2);

                path.ArcTo(e1Xr, e1Yr, 0, SKPathArcSize.Large, SKPathDirection.CounterClockwise, p3.X,p3.Y);

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
