using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Demo.DIYControl.Controls.DeepInDIY
{
    public class ColorPicker:Control    
    {
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Red.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RedProperty =
            DependencyProperty.Register(
                nameof(Red), typeof(byte), typeof(ColorPicker), 
                new FrameworkPropertyMetadata(OnColorRGBChanged));


        public int Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Green.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GreenProperty =
            DependencyProperty.Register(
                nameof(Green), typeof(byte), typeof(ColorPicker), 
                new FrameworkPropertyMetadata(OnColorRGBChanged));


        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Blue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BlueProperty =
            DependencyProperty.Register(
                nameof(Blue), typeof(byte), typeof(ColorPicker), 
                new FrameworkPropertyMetadata(OnColorRGBChanged));


        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(nameof(Color), typeof(Color), 
                typeof(ColorPicker), new FrameworkPropertyMetadata(OnColorChanged));


        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent(
            "ColorChangedEvent", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        static ColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));
        }

        private static void OnColorRGBChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs args)
        {
            ColorPicker colorPicker = sender as ColorPicker;
            colorPicker = colorPicker ?? throw new ArgumentException();

            Color color = colorPicker.Color;
            if (args.Property == RedProperty)
                color.R = (byte)args.NewValue;
            else if (args.Property == GreenProperty)
                color.G = (byte)args.NewValue;
            else if (args.Property == BlueProperty)
                color.B = (byte)args.NewValue;
            colorPicker.Color = color;
        }


        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = d as ColorPicker;
            d = d ?? throw new ArgumentException();
            colorPicker.Red = colorPicker.Color.R;
            colorPicker.Green = colorPicker.Color.G;
            colorPicker.Blue = colorPicker.Color.B;

            colorPicker.RaiseEvent(new RoutedEventArgs(
                ColorChangedEvent, e.NewValue));
        }

    }
}
