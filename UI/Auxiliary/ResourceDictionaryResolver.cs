using System;
using System.Linq;
using System.Windows;

namespace UI.Auxiliary
{
    public static class ResourceDictionaryResolver
    {
        public static ResourceDictionary GetResourceDictionary(string uri)
        {
            return
                System.Windows.Application.Current.Resources.MergedDictionaries.FirstOrDefault(
                    x => x.Source == new Uri(uri, UriKind.RelativeOrAbsolute));
        }
    }
}