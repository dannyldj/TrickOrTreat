using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TrickOrTreat.Controls
{
    public partial class FluentIcon : TextBlock
    {
        public static readonly DependencyProperty SymbolProperty = DependencyProperty.Register(
            nameof(Symbol), typeof(IconGlyph?), typeof(FluentIcon), new PropertyMetadata(null, SymbolPropertyChanged));

        static FluentIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FluentIcon),
                new FrameworkPropertyMetadata(typeof(FluentIcon)));
        }

        public IconGlyph? Symbol
        {
            get => (IconGlyph?)GetValue(SymbolProperty);
            set => SetValue(SymbolProperty, value);
        }

        private static void SymbolPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FluentIcon icon && e.NewValue != null)
                icon.Text = Encoding.Unicode.GetString(BitConverter.GetBytes((ushort)e.NewValue));
        }
    }
}