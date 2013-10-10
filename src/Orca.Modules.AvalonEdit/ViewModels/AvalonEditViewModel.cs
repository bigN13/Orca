using Catel;
using Catel.Messaging;
using Catel.MVVM;
using Catel.MVVM.Services;
using Orca.Modules.AvalonEdit.ViewModels;
using Orchestra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orca.Modules.AvalonEdit.ViewModels
{
    public class AvalonEditViewModel : ViewModelBase
    {
        private readonly IMessageService _messageService;
        private readonly IOrchestraService _orchestraService;
        private readonly IMessageMediator _messageMediator;



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
            //GoBack = new Command(OnGoBackExecute, OnGoBackCanExecute);
            //GoForward = new Command(OnGoForwardExecute, OnGoForwardCanExecute);
            //Browse = new Command(OnBrowseExecute, OnBrowseCanExecute);
            Test = new Command(OnTestExecute);
            //CloseBrowser = new Command(OnCloseBrowserExecute);

            Title = "AvalonEdit";
        }


        /// <summary>
        /// Gets the GoBack command.
        /// </summary>
        public Command NewFile { get; private set; }

        /// <summary>
        /// Method to check whether the GoBack command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private void NewFileExecute()
        {
            System.Windows.Forms.MessageBox.Show("Test");
            //return _previousPages.Count > 0;
        }

        /// <summary>
        /// Gets the test command.
        /// </summary>
        /// <value>
        /// The test.
        /// </value>
        public Command Test { get; private set; }


        private void OnTestExecute()
        {
            _messageService.ShowInformation("This is a test, for loading dynamic content into the ribbon...");
        }

        #endregion

        #region AvalonEditMainViewModel 

        #endregion

    }
}
