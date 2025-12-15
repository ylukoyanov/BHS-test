using Avalonia.Controls;
using Avalonia.Interactivity;
using ShapeDrawingApp.Models;
using ShapeDrawingApp.ViewModels;

namespace ShapeDrawingApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void OnRectangleSelected(object? sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                vm.CurrentShapeType = ShapeType.Rectangle;
            }
        }

        private void OnCircleSelected(object? sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                vm.CurrentShapeType = ShapeType.Circle;
            }
        }

        private void SetRedColor(object? sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                vm.FillColor = "#FFFF0000";
            }
        }

        private void SetBlueColor(object? sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                vm.FillColor = "#FF0000FF";
            }
        }

        private void SetGreenColor(object? sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                vm.FillColor = "#FF00FF00";
            }
        }
    }
}
