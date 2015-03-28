// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotifyPropertyChangedClass.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the NotifyPropertyChangedClass type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.ComponentModel
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provide an event and methods usable in your properties.
    /// </summary>
    [Serializable]
    public class NotifyPropertyChangedClass : INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed event.
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// On property changed. Raise the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
