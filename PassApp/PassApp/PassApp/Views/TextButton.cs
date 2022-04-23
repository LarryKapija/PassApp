using System;
using Xamarin.Forms;

namespace PassApp.Views
{
    public class TextButton : Button
    {
        public TextButton() { }

        public Color ButtonColor
        {
            get => (Color)GetValue(ButtonColorProperty);
            set => SetValue(ButtonColorProperty, value);
        }

        public static readonly BindableProperty ButtonColorProperty =
            BindableProperty.Create(
                propertyName: nameof(ButtonColor),
                returnType: typeof(Color),
                declaringType: typeof(TextButton),
                defaultValue: default,
                propertyChanged: OnButtonColorPropertyChanged);

        private static void OnButtonColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as TextButton;

            var color = (Color)newValue;
            var transluscentColor = color.ToHex().Replace("#FF", "#22");

            control.TextColor = color;
            control.BackgroundColor = Color.FromHex(transluscentColor);
        }
    }
}

