using System;
using System.Linq;
using System.Windows;

namespace UI
{
    public static class ResourceDictionaryResolver
    {
        public static ResourceDictionary GetResourceDictionary(string uri)
        {
            return
                Application.Current.Resources.MergedDictionaries.FirstOrDefault(
                    resourceDictionaryScan => resourceDictionaryScan.Source == new Uri(uri, UriKind.RelativeOrAbsolute));
        }
    }
}
