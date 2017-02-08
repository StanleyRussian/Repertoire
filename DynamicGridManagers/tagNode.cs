using System.Windows;

namespace DynamicGridManagers
{
    public static class tagNode
    {
        public static readonly DependencyProperty TagProperty = DependencyProperty.RegisterAttached(
            "tagNode", typeof (string), typeof (tagNode), new FrameworkPropertyMetadata(null));

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
