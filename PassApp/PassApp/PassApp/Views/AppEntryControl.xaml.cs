using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PassApp.Views
{	
	public partial class AppEntryControl : ContentView
	{	
		public AppEntryControl ()
		{
			InitializeComponent ();
		}

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static readonly BindableProperty TextProperty =
         BindableProperty.Create(
             propertyName: nameof(Text),
             returnType: typeof(string),
             declaringType: typeof(AppEntryControl),
             defaultValue: default,
             defaultBindingMode: BindingMode.TwoWay,
             propertyChanged: OnTextPropertyChanged);


        public static readonly BindableProperty PlaceholderProperty =
          BindableProperty.Create(
              propertyName: nameof(Placeholder),
              returnType: typeof(string),
              declaringType: typeof(AppEntryControl),
              defaultValue: default,
              propertyChanged: OnPlaceholderPropertyChanged);

        private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as AppEntryControl;

            control.Entry.Text = (string)newValue;
        }

        private static void OnPlaceholderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as AppEntryControl;

            control.Entry.Placeholder = (string)newValue;
        }

        void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Text = e.NewTextValue;
        }
    }
}

