using System;
using System.Collections.Generic;
using ShapeDrawingApp.Models;

namespace ShapeDrawingApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly Dictionary<ShapeType, ShapeState> _shapeStates = new()
        {
            { ShapeType.Rectangle, new ShapeState() },
            { ShapeType.Circle, new ShapeState { Width = 200, Height = 200 } }
        };

        private ShapeType _currentShapeType = ShapeType.Rectangle;
        private string _fillColor = "#FF0000FF";
        private string _text = "Текст";
        private string _textColor = "#FFFFFFFF";
        private double _width = 200;
        private double _height = 150;
        private double _rotation = 0;
        private double _horizontalScale = 1.0;
        private double _verticalScale = 1.0;

        public ShapeType CurrentShapeType
        {
            get => _currentShapeType;
            set
            {
                if (SetProperty(ref _currentShapeType, value))
                {
                    LoadStateForCurrentShape();
                }
            }
        }

        public bool IsRectangle => CurrentShapeType == ShapeType.Rectangle;
        public bool IsCircle => CurrentShapeType == ShapeType.Circle;

        public string FillColor
        {
            get => _fillColor;
            set
            {
                if (SetProperty(ref _fillColor, value))
                {
                    SaveCurrentState();
                }
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                if (SetProperty(ref _text, value))
                {
                    SaveCurrentState();
                }
            }
        }

        public string TextColor
        {
            get => _textColor;
            set
            {
                if (SetProperty(ref _textColor, value))
                {
                    SaveCurrentState();
                }
            }
        }

        public double Width
        {
            get => _width;
            set
            {
                value = Math.Max(50, Math.Min(500, value));
                if (SetProperty(ref _width, value))
                {
                    SaveCurrentState();
                }
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                value = Math.Max(50, Math.Min(500, value));
                if (SetProperty(ref _height, value))
                {
                    SaveCurrentState();
                }
            }
        }

        public double Rotation
        {
            get => _rotation;
            set
            {
                value = Math.Max(0, Math.Min(360, value));
                if (SetProperty(ref _rotation, value))
                {
                    SaveCurrentState();
                }
            }
        }

        public double HorizontalScale
        {
            get => _horizontalScale;
            set
            {
                value = Math.Max(0.1, Math.Min(2.0, value));
                if (SetProperty(ref _horizontalScale, value))
                {
                    SaveCurrentState();
                }
            }
        }

        public double VerticalScale
        {
            get => _verticalScale;
            set
            {
                value = Math.Max(0.1, Math.Min(2.0, value));
                if (SetProperty(ref _verticalScale, value))
                {
                    SaveCurrentState();
                }
            }
        }

        private void SaveCurrentState()
        {
            var state = _shapeStates[CurrentShapeType];
            state.FillColor = FillColor;
            state.Text = Text;
            state.TextColor = TextColor;
            state.Width = Width;
            state.Height = Height;
            state.Rotation = Rotation;
            state.HorizontalScale = HorizontalScale;
            state.VerticalScale = VerticalScale;
        }

        private void LoadStateForCurrentShape()
        {
            var state = _shapeStates[CurrentShapeType];
            _fillColor = state.FillColor;
            _text = state.Text;
            _textColor = state.TextColor;
            _width = state.Width;
            _height = state.Height;
            _rotation = state.Rotation;
            _horizontalScale = state.HorizontalScale;
            _verticalScale = state.VerticalScale;

            OnPropertyChanged(nameof(FillColor));
            OnPropertyChanged(nameof(Text));
            OnPropertyChanged(nameof(TextColor));
            OnPropertyChanged(nameof(Width));
            OnPropertyChanged(nameof(Height));
            OnPropertyChanged(nameof(Rotation));
            OnPropertyChanged(nameof(HorizontalScale));
            OnPropertyChanged(nameof(VerticalScale));
            OnPropertyChanged(nameof(IsRectangle));
            OnPropertyChanged(nameof(IsCircle));
        }
    }
}
