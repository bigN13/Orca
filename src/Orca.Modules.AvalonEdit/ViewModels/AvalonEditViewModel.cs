using Catel;
using Catel.IoC;
using Catel.Messaging;
using Catel.MVVM;
using Catel.MVVM.Services;
using Orca.Modules.AvalonEdit.ViewModels;
using Orca.Modules.AvalonEdit.ViewModels.Base;
using Orchestra.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orca.Modules.AvalonEdit.ViewModels
{
    public class AvalonEditViewModel : Catel.MVVM.ViewModelBase
    {
        #region Properties
        private readonly IMessageService _messageService;
        private readonly IOrchestraService _orchestraService;
        private readonly IMessageMediator _messageMediator;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AvalonEditViewModel" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="messageService">The message service.</param>
        /// <param name="orchestraService">The orchestra service.</param>
        /// <param name="messageMediator">The message mediator.</param>
        public AvalonEditViewModel(string title, IMessageService messageService, IOrchestraService orchestraService, IMessageMediator messageMediator)
            : this(messageService, orchestraService, messageMediator)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                Title = title;
            }
        }

         /// <summary>
        /// Initializes a new instance of the <see cref="AvalonEditViewModel" /> class.
        /// </summary>
        /// <param name="messageService">The message service.</param>
        /// <param name="orchestraService">The orchestra service.</param>
        /// <param name="messageMediator">The message mediator.</param>
        public AvalonEditViewModel(IMessageService messageService, IOrchestraService orchestraService, IMessageMediator messageMediator)
        {
            Argument.IsNotNull(() => orchestraService);
            Argument.IsNotNull(() => orchestraService);
            Argument.IsNotNull(() => messageMediator);

            _messageService = messageService;
            _orchestraService = orchestraService;
            _messageMediator = messageMediator;

            NewFile = new Command(NewFileExecute);
            OpenFile = new Command(OpenFileExecute);
            SaveFile = new Command(SaveFileExecute);
            SaveAsFile = new Command(SaveAsFileExecute);
            CloseFile = new Command(CloseFileExecute);
            //GoBack = new Command(OnGoBackExecute, OnGoBackCanExecute);
            //GoForward = new Command(OnGoForwardExecute, OnGoForwardCanExecute);
            //Browse = new Command(OnBrowseExecute, OnBrowseCanExecute);
            //Test = new Command(OnTestExecute);
            //CloseBrowser = new Command(OnCloseBrowserExecute);

            Title = "AvalonEdit";
        }

        #endregion

        #region New Command
        /// <summary>
        /// New File command.
        /// </summary>
        public Command NewFile { get; private set; }

        int count = 1;
        /// <summary>
        /// Method to check whether the GoBack command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private void NewFileExecute()
        {
            var orchestraService = GetService<IOrchestraService>();
            var typeFactory = TypeFactory.Default;
            var orcaViewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<AvalonEditViewModel>("Sheet " + count.ToString());
            orchestraService.ShowDocument(orcaViewModel, "Sheet " + count.ToString());

            count++;

            //Workspace.This.NewCommand.Execute(null);
        }
        #endregion

        #region Open Command
        /// <summary>
        /// New File command.
        /// </summary>
        public Command OpenFile { get; private set; }

        /// <summary>
        /// Method to check whether the GoBack command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private void OpenFileExecute()
        {
            // Calling Commands from 
            Workspace.This.OpenCommand.Execute(null);

            //return _previousPages.Count > 0;
        }
        #endregion

        #region Save Command
        /// <summary>
        /// New File command.
        /// </summary>
        public Command SaveFile { get; private set; }

        /// <summary>
        /// Method to check whether the GoBack command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private void SaveFileExecute()
        {
            // Calling Commands from Workspace
            Workspace.This.ActiveDocument.SaveCommand.Execute(null);

            //return _previousPages.Count > 0;
        }
        #endregion

        #region SaveAs Command
        /// <summary>
        /// New File command.
        /// </summary>
        public Command SaveAsFile { get; private set; }

        /// <summary>
        /// Method to check whether the GoBack command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private void SaveAsFileExecute()
        {
            // Calling Commands from Workspace
            Workspace.This.ActiveDocument.SaveAsCommand.Execute(null);
        }
        #endregion

        #region Close Command
        /// <summary>
        /// New File command.
        /// </summary>
        public Command CloseFile { get; private set; }

        /// <summary>
        /// Method to check whether the GoBack command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private void CloseFileExecute()
        {
            // Calling Commands from Workspace
            Workspace.This.ActiveDocument.CloseCommand.Execute(null);
        }
        #endregion

        /// <summary>
        /// Gets the test command.
        /// </summary>
        /// <value>
        /// The test.
        /// </value>
        //public Command Test { get; private set; }

        private void OnTestExecute()
        {
            _messageService.ShowInformation("This is a test, for loading dynamic content into the ribbon...");
        }



        #region Workspace Functions


        #endregion
    }
}
