using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace Gizmo.Sourcerer.Interaction
{
    /// <summary>
    /// Provides the functionality to automatically highlight the currently selected item.
    /// </summary>
    /// <typeparam name="T">The type of the items inside the <see cref="TreeView"/>.</typeparam>
    public class TreeViewSelectionBehavior<T> : Behavior<TreeView>
    {
        /// <summary>
        /// Identifies the <see cref="TreeViewSelectionBehavior{T}.SelectedItem"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            nameof(SelectedItem),
            typeof(T),
            typeof(TreeViewSelectionBehavior<T>),
            new UIPropertyMetadata(null, OnSelectedItemChanged));

        /// <summary>
        /// An <see cref="EventSetter"/> for automatically pre-processing the <see cref="TreeViewItem"/>s.
        /// </summary>
        private readonly EventSetter loadedEventSetter;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeViewSelectionBehavior{T}"/> class.
        /// </summary>
        public TreeViewSelectionBehavior()
        {
            this.loadedEventSetter = (new EventSetter(FrameworkElement.LoadedEvent, new RoutedEventHandler(TreeViewChanged)));
        }

        /// <summary>
        /// Gets or sets the currently selected item.
        /// </summary>
        public T SelectedItem
        {
            get => (T)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Handles changes of the <see cref="SelectedItem"/>-property.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventArgs">An object that contains the event data.</param>
        protected static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
        {
            if (sender is TreeViewSelectionBehavior<T> behavior)
            {
                behavior.UpdateSelection(behavior.AssociatedObject, eventArgs.NewValue);
            }
        }

        /// <summary>
        /// Updates the selection-state of the items inside the <paramref name="itemsCtonrol"/>.
        /// </summary>
        /// <param name="itemsCtonrol">The control to update.</param>
        /// <param name="selectedItem">The item to select.</param>
        protected void UpdateSelection(ItemsControl itemsCtonrol, object selectedItem)
        {
            for (int i = 0; i < itemsCtonrol.ItemContainerGenerator.Items.Count; i++)
            {
                TreeViewItem item = itemsCtonrol.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;

                if (item != null)
                {
                    object dataContext = itemsCtonrol.ItemContainerGenerator.ItemFromContainer(item);

                    if (selectedItem is T tItem)
                    {

                    }

                    if (
                        dataContext == selectedItem ||
                        IsInPath((T)dataContext, (T)selectedItem))
                    {
                        if (dataContext == selectedItem)
                        {
                            item.IsSelected = true;
                        }
                        else
                        {
                            item.IsSelected = false;
                            item.IsExpanded = true;
                            UpdateSelection(item, selectedItem);
                        }
                    }
                    else
                    {
                        item.IsSelected = false;
                    }
                }
            }
        }

        /// <summary>
        /// Checks whether the specified <paramref name="subject"/> is inside the path to the specified <paramref name="leaf"/>.
        /// </summary>
        /// <param name="subject">The item to check.</param>
        /// <param name="leaf">The leaf whos path is to be checked.</param>
        /// <returns>A value indicating whether the <paramref name="subject"/> is part of the path to the <paramref name="leaf"/>.</returns>
        protected virtual bool IsInPath(T subject, T leaf)
        {
            return true;
        }

        /// <inheritdoc/>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectedItemChanged += TreeView_SelectedItemChanged;

            if (AssociatedObject.ItemContainerStyle == null)
            {
                AssociatedObject.ItemContainerStyle = (
                    new Style(
                        typeof(TreeViewItem),
                        (Style)Application.Current.TryFindResource(typeof(TreeViewItem))));
            }

            if (!AssociatedObject.ItemContainerStyle.Setters.Contains(loadedEventSetter))
            {
                AssociatedObject.ItemContainerStyle.Setters.Add(loadedEventSetter);
            }

            (AssociatedObject.Items as INotifyCollectionChanged).CollectionChanged += TreeViewChanged;
            TreeViewChanged();
        }

        /// <inheritdoc/>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (AssociatedObject != null)
            {
                AssociatedObject.SelectedItemChanged -= TreeView_SelectedItemChanged;
                AssociatedObject.ItemContainerStyle?.Setters?.Remove(loadedEventSetter);
                ((INotifyCollectionChanged)AssociatedObject.Items).CollectionChanged -= TreeViewChanged;
            }
        }

        /// <summary>
        /// Handles changes made to the content of the <see cref="TreeView"/>.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventArgs">An object which contains the event data.</param>
        protected void TreeViewChanged(object sender, EventArgs eventArgs)
        {
            TreeViewChanged();
        }

        /// <summary>
        /// Handles changes made to the content of the <see cref="TreeView"/>.
        /// </summary>
        protected void TreeViewChanged()
        {
            UpdateSelection(AssociatedObject, SelectedItem);
        }

        /// <summary>
        /// Handles changes of the currently selected item of the <see cref="TreeView"/>.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventArgs">An object which contains event data.</param>
        protected void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> eventArgs)
        {
            if (
                eventArgs.NewValue != null &&
                eventArgs.NewValue is T newItem)
            {
                SelectedItem = newItem;
            }
        }
    }
}
