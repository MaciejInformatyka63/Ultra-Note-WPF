using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Modele
{
    public abstract class VueModeleBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Protected Methods

        /// <summary>
        /// Fires the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the changed property.</param>
        protected void RaisePropertyChangedEvent(string nomPropriete)
        {
            if (PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(nomPropriete);
                PropertyChanged(this, e);
            }
        }

        #endregion
    }
}
