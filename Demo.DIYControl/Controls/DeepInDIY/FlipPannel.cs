using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Demo.DIYControl.Controls.DeepInDIY
{
    [TemplateVisualState(GroupName = "ViewStates", Name = "Fliped")]
    [TemplateVisualState(GroupName = "ViewStates", Name = "Normal")]
    [TemplatePart(Name = FlipButtonName, Type = typeof(ToggleButton))]
    [TemplatePart(Name = FlipButtonAlternateName, Type = typeof(ToggleButton))]
    public class FlipPannel:Control
    {
        
        private const string FlipButtonName = "PART_FlipButton";
        private const string FlipButtonAlternateName = "PART_FlipButtonAlternate";

        public object BackContent
        {
            get => (object)GetValue(BackContentProperty); 
            set => SetValue(BackContentProperty, value);
        }
        // Using a DependencyProperty as the backing store for BackContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackContentProperty =
            DependencyProperty.Register(nameof(BackContent), typeof(object), typeof(FlipPannel), 
                new FrameworkPropertyMetadata(default(object)));

        public object FrontContent
        {
            get => (object)GetValue(FrontContentProperty);
            set => SetValue(FrontContentProperty, value);
        }
        // Using a DependencyProperty as the backing store for FrontContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FrontContentProperty =
            DependencyProperty.Register(nameof(FrontContent), typeof(object), typeof(FlipPannel),
            new FrameworkPropertyMetadata(default(object)));

        public bool IsFilped
        {
            get => (bool)GetValue(IsFilpedProperty);
            set => SetValue(IsFilpedProperty, value);
        }
        // Using a DependencyProperty as the backing store for IsFilped.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsFilpedProperty =
            DependencyProperty.Register(nameof(IsFilped), typeof(bool), typeof(FlipPannel),
            new FrameworkPropertyMetadata(false));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(FlipPannel),
            new FrameworkPropertyMetadata(default(CornerRadius)));

        /// <summary>
        /// The content need to be displayed aside the filpbutton which may be an icon button
        /// </summary>
        public object FlipHeader
        {
            get => GetValue(FlipHeaderProperty);
            set => SetValue(FlipHeaderProperty, value);
        }
        public static readonly DependencyProperty FlipHeaderProperty =
            DependencyProperty.Register(
                nameof(FlipHeader), typeof(object),typeof(FlipPannel), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// The content which will be displayed upon the top of the card
        /// </summary>
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(
                nameof(Header), typeof(object), typeof(FlipPannel),
                new FrameworkPropertyMetadata(null));

        static FlipPannel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(FlipPannel), 
                new FrameworkPropertyMetadata(typeof(FlipPannel)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild(FlipButtonName) is ToggleButton btn)
                btn.Click += flipButton_Click;

            if (GetTemplateChild(FlipButtonAlternateName) is ToggleButton btnAlternate)
                btnAlternate.Click += flipButton_Click;

            ChangeVisualState();
        }

        private void flipButton_Click(object sender, RoutedEventArgs e)
        {
            IsFilped = !IsFilped;
            ChangeVisualState();
        }

        private void ChangeVisualState(bool useTransitions = true)
        {
            if (IsFilped)
            {
                VisualStateManager.GoToState(this, "Fliped", useTransitions);
            }
            else
            {
                VisualStateManager.GoToState(this, "Normal", useTransitions);
            }
        }
    }
}
