using System.Windows;

namespace UI.DependencyProperties
{
    class tagGroup
    {
        public static readonly DependencyProperty TagProperty = DependencyProperty.RegisterAttached(
            "tagGroup", typeof (string), typeof (tagGroup), new FrameworkPropertyMetadata(null));

        public static object GetTag(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(TagProperty);
        }

        public static void SetTag(DependencyObject dependencyObject, object value)
        {
            dependencyObject.SetValue(TagProperty, value);
        }
    }
}