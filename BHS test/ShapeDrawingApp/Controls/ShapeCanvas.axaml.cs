using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using ShapeDrawingApp.ViewModels;

namespace ShapeDrawingApp.Controls
{
    public partial class ShapeCanvas : UserControl
    {
        private readonly Canvas _canvas;
        
        public ShapeCanvas()
        {
            InitializeComponent();
            _canvas = this.FindControl<Canvas>("DrawingCanvas")!;
            
            _canvas.SizeChanged += (_, _) => UpdateShape();
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object? sender, EventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                vm.PropertyChanged += (_, _) => UpdateShape();
                UpdateShape();
            }
        }

        private void UpdateShape()
        {
            if (DataContext is not MainWindowViewModel vm) return;

            _canvas.Children.Clear();

            var canvasWidth = _canvas.Bounds.Width > 0 ? _canvas.Bounds.Width : 600;
            var canvasHeight = _canvas.Bounds.Height > 0 ? _canvas.Bounds.Height : 600;
            
            var centerX = canvasWidth / 2;
            var centerY = canvasHeight / 2;

            Shape shape;

            if (vm.IsRectangle)
            {
                shape = new Rectangle
                {
                    Width = vm.Width,
                    Height = vm.Height,
                    Fill = ParseBrush(vm.FillColor),
                    RenderTransformOrigin = new RelativePoint(0.5, 0.5, RelativeUnit.Relative)
                };

                shape.RenderTransform = new RotateTransform { Angle = vm.Rotation };
                
                Canvas.SetLeft(shape, centerX - vm.Width / 2);
                Canvas.SetTop(shape, centerY - vm.Height / 2);
            }
            else
            {
                shape = new Ellipse
                {
                    Width = vm.Width,
                    Height = vm.Width,
                    Fill = ParseBrush(vm.FillColor),
                    RenderTransformOrigin = new RelativePoint(0.5, 0.5, RelativeUnit.Relative)
                };

                shape.RenderTransform = new ScaleTransform 
                { 
                    ScaleX = vm.HorizontalScale,
                    ScaleY = vm.VerticalScale
                };
                
                Canvas.SetLeft(shape, centerX - vm.Width / 2);
                Canvas.SetTop(shape, centerY - vm.Width / 2);
            }

            _canvas.Children.Add(shape);

            var textBlock = new TextBlock
            {
                Text = vm.Text,
                Foreground = ParseBrush(vm.TextColor),
                FontSize = 20,
                FontWeight = FontWeight.Bold,
                TextAlignment = Avalonia.Media.TextAlignment.Center,
                Width = 200
            };

            textBlock.Measure(new Size(200, double.PositiveInfinity));
            var textHeight = textBlock.DesiredSize.Height;

            Canvas.SetLeft(textBlock, centerX - 100);
            Canvas.SetTop(textBlock, centerY - textHeight / 2);
            
            _canvas.Children.Add(textBlock);
        }

        private IBrush ParseBrush(string color)
        {
            try
            {
                return new SolidColorBrush(Color.Parse(color));
            }
            catch
            {
                return Brushes.Black;
            }
        }
    }
}
