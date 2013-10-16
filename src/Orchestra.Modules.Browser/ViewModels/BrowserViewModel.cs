﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrowserViewModel.cs" company="Orchestra development team">
//   Copyright (c) 2008 - 2012 Orchestra development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Orca.Modules.Browser.ViewModels
{
    using System.Collections.Generic;
    using Catel;
    using Catel.Data;
    using Catel.MVVM;
    using Catel.MVVM.Services;
    using Catel.Messaging;
    using Orchestra.Services;
    using Orchestra.Models;
    using Orchestra;

    /// <summary>
    /// UserControl view model.
    /// </summary>
    public class BrowserViewModel : Orchestra.ViewModels.ViewModelBase, IContextualViewModel
    {
        private readonly List<string> _previousPages = new List<string>();
        private readonly List<string> _nextPages = new List<string>();

        private readonly IMessageService _messageService;
        private readonly IOrchestraService _orchestraService;
        private readonly IMessageMediator _messageMediator;
        private readonly IContextualViewModelManager _contextualViewModelManager;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserViewModel" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="messageService">The message service.</param>
        /// <param name="orchestraService">The orchestra service.</param>
        /// <param name="messageMediator">The message mediator.</param>
        /// <param name="contextualViewModelManager">The contextual view model manager.</param>
        public BrowserViewModel(string title, IMessageService messageService, IOrchestraService orchestraService, IMessageMediator messageMediator, IContextualViewModelManager contextualViewModelManager)
            : this(messageService, orchestraService, messageMediator, contextualViewModelManager)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                Title = title;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserViewModel" /> class.
        /// </summary>
        /// <param name="messageService">The message service.</param>
        /// <param name="orchestraService">The orchestra service.</param>
        /// <param name="messageMediator">The message mediator.</param>
        /// <param name="contextualViewModelManager">The contextual view model manager.</param>
        public BrowserViewModel(IMessageService messageService, IOrchestraService orchestraService, IMessageMediator messageMediator, IContextualViewModelManager contextualViewModelManager)
        {
            Argument.IsNotNull(() => orchestraService);
            Argument.IsNotNull(() => orchestraService);
            Argument.IsNotNull(() => messageMediator);

            _messageService = messageService;
            _orchestraService = orchestraService;
            _messageMediator = messageMediator;
            _contextualViewModelManager = contextualViewModelManager;

            GoBack = new Command(OnGoBackExecute, OnGoBackCanExecute);
            GoForward = new Command(OnGoForwardExecute, OnGoForwardCanExecute);
            Browse = new Command(OnBrowseExecute, OnBrowseCanExecute);
            Test = new Command(OnTestExecute);
            CloseBrowser = new Command(OnCloseBrowserExecute);
            this.Title = "Browser";
        }

        private void OnTestExecute()
        {
            _messageService.ShowInformation("This is a test, for loading dynamic content into the ribbon...");
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets the name of the URL changed message.
        /// </summary>
        /// <value>The name of the URL changed message.</value>
        public string UrlChangedMessageTag { get { return string.Format("{0}_{1}", BrowserModule.Name, UniqueIdentifier); } }

        /// <summary>
        /// Gets the recent sites.
        /// </summary>
        /// <value>
        /// The recent sites.
        /// </value>
        public string[] RecentSites { get { return new[] { "Orchestra", "Catel" }; } }

        #region SelectedSite property

        /// <summary>
        /// Gets or sets the SelectedSite value.
        /// </summary>
        public string SelectedSite
        {
            get { return GetValue<string>(SelectedSiteProperty); }
            set { SetValue(SelectedSiteProperty, value); }
        }

        /// <summary>
        /// SelectedSite property data.
        /// </summary>
        public static readonly PropertyData SelectedSiteProperty = RegisterProperty("SelectedSite", typeof(string), null, OnSelectedSiteChanged);        

        /// <summary>
        /// Called when the SelectedSite value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="AdvancedPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnSelectedSiteChanged(object sender, AdvancedPropertyChangedEventArgs e)
        {
            var _this = ((BrowserViewModel)sender);

            switch (_this.SelectedSite)
            {
                case "Orchestra":
                    _this.Url = "http://www.github.com/Orcomp/Orchestra";
                    break;

                case "Catel":
                    _this.Url = "http://www.catelproject.com";
                    break;

                default:
                    return;
            }

            _this.OnBrowseExecute();
        }
        #endregion

        #endregion

        #region Commands
        /// <summary>
        /// Gets the test command.
        /// </summary>
        /// <value>
        /// The test.
        /// </value>
        public Command Test { get; private set; }

        /// <summary>
        /// Gets the GoBack command.
        /// </summary>
        public Command GoBack { get; private set; }

        /// <summary>
        /// Method to check whether the GoBack command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnGoBackCanExecute()
        {
            return _previousPages.Count > 0;
        }

        /// <summary>
        /// Method to invoke when the GoBack command is executed.
        /// </summary>
        private void OnGoBackExecute()
        {
            // TODO: Handle command logic here
        }

        /// <summary>
        /// Gets the GoForward command.
        /// </summary>
        public Command GoForward { get; private set; }

        /// <summary>
        /// Method to check whether the GoForward command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnGoForwardCanExecute()
        {
            return _nextPages.Count > 0;
        }

        /// <summary>
        /// Method to invoke when the GoForward command is executed.
        /// </summary>
        private void OnGoForwardExecute()
        {
            // TODO: Handle command logic here
        }

        /// <summary>
        /// Gets the Browse command.
        /// </summary>
        public Command Browse { get; private set; }

        /// <summary>
        /// Method to check whether the Browse command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnBrowseCanExecute()
        {
            return !string.IsNullOrWhiteSpace(Url);
        }

        /// <summary>
        /// Method to invoke when the Browse command is executed.
        /// </summary>
        private void OnBrowseExecute()
        {
            var url = Url;
            if (!url.StartsWith("http://"))
            {
                url = "http://" + url;
            }

            _messageMediator.SendMessage(url, UrlChangedMessageTag);

            Title = string.Format("Browser: {0}", url);
        }

        /// <summary>
        /// Gets the CloseBrowser command.
        /// </summary>
        public Command CloseBrowser { get; private set; }

        /// <summary>
        /// Method to invoke when the CloseBrowser command is executed.
        /// </summary>
        private void OnCloseBrowserExecute()
        {
            _orchestraService.CloseDocument(this);
            Url = null;
        }

        /// <summary>
        /// Method is called when the active view changes within the orchestra application
        /// </summary>
        public void ViewModelActivated()
        {
            var propertiesViewModel = _contextualViewModelManager.GetViewModelForContextSensitiveView<PropertiesViewModel>();
            if (propertiesViewModel != null)
            {
                propertiesViewModel.Url = Url;
            }
        }
        #endregion
    }
}