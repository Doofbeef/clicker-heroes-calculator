using System.Windows;
using System.Windows.Input;

namespace Clicker_Heroes_Calculator.Behaviors
{
    /// <summary>
    /// This class is an attached behavior for the KeyDown and KeyUp event.
    /// </summary>
    public static class KeyBehaviour
    {
        public static readonly DependencyProperty KeyDownCommandProperty = DependencyProperty.RegisterAttached(
                "KeyDownCommand",
                typeof(ICommand),
                typeof(KeyBehaviour),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnKeyDownCommandPropertyChanged)));

        public static readonly DependencyProperty KeyUpCommandProperty = DependencyProperty.RegisterAttached(
                "KeyUpCommand",
                typeof(ICommand),
                typeof(KeyBehaviour),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnKeyUpCommandPropertyChanged)));

        public static ICommand GetKeyDownCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(KeyDownCommandProperty);
        }

        public static ICommand GetKeyUpCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(KeyUpCommandProperty);
        }

        public static void SetKeyDownCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(KeyDownCommandProperty, value);
        }

        public static void SetKeyUpCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(KeyUpCommandProperty, value);
        }

        private static void OnKeyDownCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            if (element != null)
            {
                if ((e.OldValue == null) && (e.NewValue != null))
                {
                    element.KeyDown += new KeyEventHandler(OnUIElementKeyDownEvent);
                    //element.AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(OnUIElementKeyDownEvent), true);
                }
                else if ((e.OldValue != null) && (e.NewValue == null))
                {
                    element.KeyDown -= new KeyEventHandler(OnUIElementKeyDownEvent);
                    //element.RemoveHandler(UIElement.KeyDownEvent, new KeyEventHandler(OnUIElementKeyDownEvent));
                }
            }
        }

        private static void OnKeyUpCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = d as UIElement;
            if (element != null)
            {
                if ((e.OldValue == null) && (e.NewValue != null))
                {
                    element.KeyUp += new KeyEventHandler(OnUIElementKeyUpEvent);
                    //element.AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(OnUIElementKeyDownEvent), true);
                }
                else if ((e.OldValue != null) && (e.NewValue == null))
                {
                    element.KeyUp -= new KeyEventHandler(OnUIElementKeyUpEvent);
                    //element.RemoveHandler(UIElement.KeyDownEvent, new KeyEventHandler(OnUIElementKeyDownEvent));
                }
            }
        }

        static void OnUIElementKeyDownEvent(object sender, KeyEventArgs e)
        {
            UIElement element = sender as UIElement;
            if (element != null)
            {
                if (e.Key == Key.LeftCtrl || e.Key == Key.LeftShift || e.Key == Key.Z)
                {
                    ICommand iCommand = (ICommand)element.GetValue(KeyDownCommandProperty);
                    if (iCommand != null)
                    {
                        iCommand.Execute(e.Key);
                    }
                    e.Handled = true;
                }
            }
        }

        static void OnUIElementKeyUpEvent(object sender, KeyEventArgs e)
        {
            UIElement element = sender as UIElement;
            if (element != null)
            {
                if (e.Key == Key.LeftCtrl || e.Key == Key.LeftShift || e.Key == Key.Z)
                {
                    ICommand iCommand = (ICommand)element.GetValue(KeyUpCommandProperty);
                    if (iCommand != null)
                    {
                        iCommand.Execute(e.Key);
                    }
                    e.Handled = true;
                }
            }
        }
    }
}
