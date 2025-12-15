namespace ShapeDrawingApp.Models
{
    public class ShapeState
    {
        public string FillColor { get; set; } = "#FF0000FF";
        public string Text { get; set; } = "Текст";
        public string TextColor { get; set; } = "#FFFFFFFF";
        public double Width { get; set; } = 200;
        public double Height { get; set; } = 150;
        public double Rotation { get; set; } = 0;
        public double HorizontalScale { get; set; } = 1.0;
        public double VerticalScale { get; set; } = 1.0;
    }
}
