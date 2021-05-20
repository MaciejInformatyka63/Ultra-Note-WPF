﻿using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Text;

namespace UltraNotes.VueModele
{
    public class LoadDocumentCommand :  ICommand
    {
        #region Fields

        // Member variables
        private MainWindowViewModel m_ViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LoadDocumentCommand(MainWindowViewModel viewModel)
        {
            m_ViewModel = viewModel;
        }

        #endregion

        #region ICommand Members

        /// <summary>
        /// Whether the LoadDocumentCommand is enabled.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Actions to take when CanExecute() changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Executes the LoadDocumentCommand
        /// </summary>
        public void Execute(object parameter)
        {
            /* We set the Document property on the view model to simulate 
             * a document load from the app back-end. */

            m_ViewModel.DocumentXaml = "<FlowDocument PagePadding=\"5,0,5,0\" AllowDrop=\"True\" "
                + "xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">"
                + "<Paragraph>Text generated by app back-end</Paragraph></FlowDocument>";
        }

        #endregion
    }
}
