using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using LiteDatabase;
using Repertoire;
using UI.DependencyProperties;

namespace UI.ValueConverters
{
    class vcSongNode : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dataGridCell = value as DataGridCell;

            var currentSong = dataGridCell.DataContext as wrapSong;
            var nodeName = (string)tagNode.GetTag(dataGridCell.Column);
            var groupName = (string)tagGroup.GetTag(dataGridCell.Column);

            if (dataGridCell.IsEditing)
            {
                var checkBox = dataGridCell.Content as CheckBox;
                checkBox.Checked += CheckBoxOnChecked;
                checkBox.Unchecked += CheckBoxOnUnchecked;
            }

            var any = ContextManager.Context.Songs.Any(
                x =>
                    x.Title == currentSong.Title &&
                    x.rProgressNodeSongs.Any(y =>
                                                 y.ProgressNode.Name == nodeName &&
                                                 y.Group.Name == groupName));

            return any;
        }

        private void CheckBoxOnUnchecked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CheckBoxOnChecked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            var dataGridCell = VisualTreeHelper.GetParent(checkBox) as DataGridCell;

            var nodeName = (string) tagNode.GetTag(dataGridCell.Column);
            var groupName = (string) tagGroup.GetTag(dataGridCell.Column);
            var currentSong = dataGridCell.DataContext as wrapSong;

            ContextManager.AddNodeToSong(nodeName, currentSong.Title, groupName);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
