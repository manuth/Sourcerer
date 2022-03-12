using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Gizmo.Sourcerer.Core
{
    /// <summary>
    /// Represents an object which notifies about changes made to its properties.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Checks for a change to a value and, if the value is different, stores the value and notifies of property changes.
        /// </summary>
        /// <typeparam name="T">The type of the field changing.</typeparam>
        /// <param name="field">The storage location for the field behind the property.</param>
        /// <param name="newValue">The new value to store in the field.</param>
        /// <param name="propertyName">The property name to notify of changes if the values are different.</param>
        /// <returns><see langword="true"/> if the property value was changed.</returns>
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = default)
        {
            return SetProperty(ref field, newValue, () => { }, propertyName);
        }

        /// <summary>
        /// Checks for a change to a value and, if the value is different, stores the value and notifies of property changes.
        /// </summary>
        /// <typeparam name="T">The type of the field changing.</typeparam>
        /// <param name="field">The storage location for the field behind the property.</param>
        /// <param name="newValue">The new value to store in the field.</param>
        /// <param name="beforeNotifyAction">An action to call if the value changes, before notifying property changes.</param>
        /// <param name="propertyName">The property name to notify of changes if the values are different.</param>
        /// <returns><see langword="true"/> if the property value was changed.</returns>
        protected bool SetProperty<T>(ref T field, T newValue, Action beforeNotifyAction, [CallerMemberName] string propertyName = default)
        {
            return SetProperty(ref field, newValue, (oldValue, newValue) => beforeNotifyAction(), propertyName);
        }

        /// <summary>
        /// Checks for a change to a value and, if the value is different, stores the value and notifies of property changes.
        /// </summary>
        /// <typeparam name="T">The type of the field changing.</typeparam>
        /// <param name="field">The storage location for the field behind the property.</param>
        /// <param name="newValue">The new value to store in the field.</param>
        /// <param name="beforeNotifyAction">An action to call if the value changes, before notifying property changes.</param>
        /// <param name="propertyName">The property name to notify of changes if the values are different.</param>
        /// <returns><see langword="true"/> if the property value was changed.</returns>
        protected bool SetProperty<T>(ref T field, T newValue, Action<T, T> beforeNotifyAction, [CallerMemberName] string propertyName = default)
        {
            if (!object.Equals(field, newValue))
            {
                field = newValue;
                beforeNotifyAction(field, newValue);
                NotifyPropertyChanged(propertyName);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Notifies about a change of the property with the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property that has been changed.</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = default)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/>-event.
        /// </summary>
        /// <param name="eventArgs">Arguments containing information about the event.</param>
        protected void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            PropertyChanged?.Invoke(this, eventArgs);
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
