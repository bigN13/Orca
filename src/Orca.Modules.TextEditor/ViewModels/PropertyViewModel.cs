using Catel;
using Catel.IoC;
using Catel.Messaging;
using Catel.MVVM;
using Catel.MVVM.Services;

using Orchestra.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orca.Modules.TextEditor.ViewModels
{
    public class PropertyViewModel : ViewModelBase
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
        public PropertyViewModel(string title, IMessageService messageService, IOrchestraService orchestraService, IMessageMediator messageMediator)
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
        public PropertyViewModel(IMessageService messageService, IOrchestraService orchestraService, IMessageMediator messageMediator)
        {
            Argument.IsNotNull(() => orchestraService);
            Argument.IsNotNull(() => orchestraService);
            Argument.IsNotNull(() => messageMediator);

            _messageService = messageService;
            _orchestraService = orchestraService;
            _messageMediator = messageMediator;

            Title = "Properties";
        }

        #endregion

   
    }
}
