using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace CS_Take_Home_Challenge
{
    class SortPeopleBehaviour
    {

        #region private member

        private static Dictionary<DependencyObject, ListSortDirection> previousSortDirectionDictionary = new Dictionary<DependencyObject, ListSortDirection>();

        #endregion

        #region public methods

        public static bool GetSortColumnHeader(DependencyObject obj)
        {
            return (bool)obj.GetValue(SortColumnHeaderProperty);
        }

        public static void SetSortColumnHeader(DependencyObject obj, bool value)
        {
            obj.SetValue(SortColumnHeaderProperty, value);
        }

        public static readonly DependencyProperty SortColumnHeaderProperty =
            DependencyProperty.RegisterAttached("SortColumnHeader"
                , typeof(bool)
                , typeof(SortPeopleBehaviour)
                , new UIPropertyMetadata(false, OnStartupRegisterClickHandler));

        #endregion

        #region private methods

        private static void OnStartupRegisterClickHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement columnHeader = d as UIElement;
            columnHeader.AddHandler(UIElement.MouseDownEvent, new RoutedEventHandler(OnColumnHeaderClick_));
        }

        private static void OnColumnHeaderClick_(object sender, RoutedEventArgs e)
        {
            UIElement columnHeader = sender as UIElement;
            ListView parentListView = FindParent<ListView>(columnHeader, (o) => { return true; });
            parentListView.Items.SortDescriptions.Clear();
            string columnName = ((TextBlock)columnHeader).Text; //change this if you change if you change what the click event is attached to.
            ListSortDirection sortDirection = GetListSortDirection(columnHeader);
            parentListView.Items.SortDescriptions.Add(new SortDescription(columnName, sortDirection));
        }

        private static ListSortDirection GetListSortDirection(DependencyObject obj)
        {
            ListSortDirection newSortDirection;
            if (!previousSortDirectionDictionary.ContainsKey(obj))
            {
                newSortDirection = ListSortDirection.Ascending;
            }
            else if (previousSortDirectionDictionary[obj] == ListSortDirection.Ascending)
            {
                newSortDirection = ListSortDirection.Descending;
            }
            else
            {
                newSortDirection = ListSortDirection.Ascending;
            }
            previousSortDirectionDictionary[obj] = newSortDirection;
            return newSortDirection;
        }

        private static T FindParent<T>(DependencyObject obj, Predicate<T> predicate)
            where T : FrameworkElement
        {
            if (obj == null || predicate == null)
                return null;

            if (obj is T)
            {
                T control = (T)obj;
                if (predicate(control))
                    return control;
            }

            DependencyObject parent;
            if (obj is Visual || obj is Visual3D)
            {
                parent = VisualTreeHelper.GetParent(obj);

            }
            else
            {
                // If we're in Logical Land then we must walk 
                // up the logical tree until we find a 
                // Visual/Visual3D to get us back to Visual Land.
                // https://www.codeproject.com/Articles/21495/Understanding-the-Visual-Tree-and-Logical-Tree-in
                parent = LogicalTreeHelper.GetParent(obj);

            }
            return (parent == null) ? null : FindParent<T>(parent, predicate);
        }

        #endregion
    }
}
