using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using LiteDatabase;
using Repertoire;

namespace UI.ValueConverters
{
    class vcSongNode : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dataGridCell = value as DataGridCell;

            var currentSong = dataGridCell.DataContext as Song;
            var nodeName = (string)tagNode.GetTag(dataGridCell.Column);
            var group = vmMainWindow.SelectedTab.Group;

            var checkBox = dataGridCell.Content as CheckBox;
            checkBox.Checked += CheckBoxOnChecked;
            checkBox.Unchecked += CheckBoxOnUnchecked;

            bool result;

            if (group != null)
            result = ContextManager.Context.Songs.Any(
                x =>
                    x.Title == currentSong.Title &&
                    x.rProgressNodeSongs.Any(y =>
                                                 y.ProgressNode.Name == nodeName &&
                                                 y.Group.Name == group.Name));
            else
            {
                result = ContextManager.Context.Songs.Any(
                    x =>
                        x.Title == currentSong.Title &&
                        !x.Groups.Any() &&
                        x.rProgressNodeSongs.Any(y => y.ProgressNode.Name == nodeName));

            }

            return result;
        }

        private void CheckBoxOnUnchecked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (!checkBox.IsFocused)
                return;

            var dataGridCell = checkBox.Parent as DataGridCell;
            var nodeName = (string)tagNode.GetTag(dataGridCell.Column);
            var currentSong = dataGridCell.DataContext as Song;

            ContextManager.RemoveNodeFromSong(nodeName, currentSong.Title, vmMainWindow.SelectedTab.Header);
        }

        private void CheckBoxOnChecked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (!checkBox.IsFocused)
                return;

            var dataGridCell = checkBox.Parent as DataGridCell;
            var nodeName = (string)tagNode.GetTag(dataGridCell.Column);
            var currentSong = dataGridCell.DataContext as Song;

            ContextManager.AddNodeToSong(nodeName, currentSong.Title, vmMainWindow.SelectedTab.Header);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
