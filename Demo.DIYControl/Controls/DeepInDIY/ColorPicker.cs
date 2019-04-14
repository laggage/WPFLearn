using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

namespace Demo.DIYControl.Controls.DeepInDIY
{
    [TemplatePart(Name = RedSliderName,Type = typeof(RangeBase))]
    [TemplatePart(Name = GreenSliderName, Type = typeof(RangeBase))]
    [TemplatePart(Name = BlueSliderName, Type = typeof(RangeBase))]
    [TemplatePart(Name = PreviewBrushName, Type = typeof(SolidColorBrush))]
    public class ColorPicker:Control
    {
        private const string RedSliderName = "PART_RedSlider";
        private const string GreenSliderName = "PART_GreenSlider";
        private const string BlueSliderName = "PART_BlueSlider";
        private const string PreviewBrushName = "PART_PreviewBrush";

        private Brush _initializeBorderBrush;
        

        public const byte RGBMaxValue = 255;

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

        public byte Green
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
                typeof(ColorPicker), new FrameworkPropertyMetadata(Colors.Black,OnColorChanged));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ColorPicker), 
                new FrameworkPropertyMetadata(default(CornerRadius)));

        public bool UseDynamicBorder
        {
            get { return (bool)GetValue(UseDynamicBorderProperty); }
            set { SetValue(UseDynamicBorderProperty, value); }
        }
        // Using a DependencyProperty as the backing store for UseDynamicBorder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UseDynamicBorderProperty =
            DependencyProperty.Register(
                "UseDynamicBorder", typeof(bool), typeof(ColorPicker), 
                new FrameworkPropertyMetadata(true, OnUseDynamicBorderChanged));


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

        public ColorPicker()
        {
            Loaded += (sender, args) =>
            {
                _initializeBorderBrush = BorderBrush;   //save initial borderbrush
                BorderBrush = UseDynamicBorder? new SolidColorBrush(Color) : BorderBrush;
            };
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

            //set border color
            if (colorPicker.UseDynamicBorder)
                colorPicker.BorderBrush = new SolidColorBrush(colorPicker.Color);

            colorPicker.RaiseEvent(
                new RoutedEventArgs(ColorChangedEvent, e.NewValue));
        }

        private static void OnUseDynamicBorderChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            ColorPicker colorPicker = d as ColorPicker;
            colorPicker = colorPicker ?? throw new ArgumentException();

            colorPicker.BorderBrush = (bool)args.NewValue ? new SolidColorBrush(colorPicker.Color) : colorPicker._initializeBorderBrush;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            RangeBase slider = GetTemplateChild("PART_RedSlider") as RangeBase;
            if (slider != null)
            {
                Binding binding = new Binding()
                {
                    Path = new PropertyPath("Red"),
                    Source = this,
                    Mode = BindingMode.TwoWay
                };
                slider.SetBinding(RangeBase.ValueProperty, binding);
                slider.Maximum = RGBMaxValue;
            }

            slider = GetTemplateChild("PART_GreenSlider") as RangeBase;
            if (slider != null)
            {
                Binding binding = new Binding()
                {
                    Path = new PropertyPath(nameof(Green)),
                    Source = this,
                    Mode = BindingMode.TwoWay
                };
                slider.SetBinding(RangeBase.ValueProperty, binding);
                slider.Maximum = RGBMaxValue;
            }

            slider = GetTemplateChild("PART_BlueSlider") as RangeBase;
            if (slider != null)
            {
                Binding binding = new Binding()
                {
                    Path = new PropertyPath(nameof(Blue)),
                    Source = this,
                    Mode = BindingMode.TwoWay
                };
                slider.SetBinding(RangeBase.ValueProperty, binding);
                slider.Maximum = RGBMaxValue;
            }

            SolidColorBrush brush = GetTemplateChild("PART_PreviewBrush") as SolidColorBrush;
            if (brush != null)
            {
                Binding bd = new Binding
                {
                    Path = new PropertyPath(nameof(brush.Color)),
                    Source = brush,
                    Mode = BindingMode.OneWayToSource
                };
                SetBinding(ColorPicker.ColorProperty, bd);
            }
        }

    }
}
