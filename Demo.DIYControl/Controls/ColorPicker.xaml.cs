using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Demo.DIYControl.Controls
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(
                nameof(Color), typeof(Color), typeof(ColorPicker), 
                new FrameworkPropertyMetadata(Colors.Black, OnColorChanged));

        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Red.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RedProperty =
            DependencyProperty.Register(
                "Red", typeof(byte), typeof(ColorPicker), 
                new FrameworkPropertyMetadata(OnColorRGBChanged));

        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Green.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GreenProperty =
            DependencyProperty.Register("Green", typeof(byte), typeof(ColorPicker), 
                new FrameworkPropertyMetadata(OnColorRGBChanged));

        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Blue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BlueProperty =
            DependencyProperty.Register(
                "Blue", typeof(byte), typeof(ColorPicker), 
                new FrameworkPropertyMetadata(OnColorRGBChanged));

        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent(
            "ColorChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<Color>),
            typeof(RoutedPropertyChangedEventArgs<Color>));
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent,value); }
        }


        private static void OnColorRGBChanged(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = d as ColorPicker;
            colorPicker = colorPicker ?? throw new ArgumentException();
            Color color = colorPicker.Color;
            if (e.Property == ColorPicker.RedProperty)
                color.R = (byte) e.NewValue;
            else if (e.Property == ColorPicker.GreenProperty)
                color.G = (byte) e.NewValue;
            else if (e.Property == ColorPicker.BlueProperty)
                color.B = (byte) e.NewValue;
            colorPicker.Color = color;
        }

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = d as ColorPicker;
            d = d ?? throw new ArgumentNullException();

            colorPicker.Red = colorPicker.Color.R;
            colorPicker.Green = colorPicker.Color.G;

            colorPicker.Blue = colorPicker.Color.B;

            colorPicker.RaiseEvent(new RoutedEventArgs(ColorChangedEvent, colorPicker));
        }

        public ColorPicker()
        {
            InitializeComponent();
        }
    }
}
