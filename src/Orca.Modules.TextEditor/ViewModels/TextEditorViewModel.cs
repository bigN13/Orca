using Catel;
using Catel.IoC;
using Catel.Messaging;
using Catel.MVVM;
using Catel.MVVM.Services;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Utils;
using Microsoft.Win32;
using Orchestra.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Orca.Modules.TextEditor.ViewModels
{
    public class TextEditorViewModel : ViewModelBase
    {
        #region Properties
        private readonly IMessageService _messageService;
        private readonly IOrchestraService _orchestraService;
        private readonly IMessageMediator _messageMediator;
        TextEditorViewModel f;

        static ImageSourceConverter ISC = new ImageSourceConverter();

        //private string _title = null;
        //public string Title
        //{
        //    get { return _title; }
        //    set
        //    {
        //        if (_title != value)
        //        {
        //            _title = value;
        //            RaisePropertyChanged("Title");
        //        }
        //    }
        //}
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextEditorViewModel" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="messageService">The message service.</param>
        /// <param name="orchestraService">The orchestra service.</param>
        /// <param name="messageMediator">The message mediator.</param>
        //public TextEditorViewModel(string title, IMessageService messageService, IOrchestraService orchestraService, IMessageMediator messageMediator)
        //    : this(messageService, orchestraService, messageMediator)
        //{
        //    if (!string.IsNullOrWhiteSpace(title))
        //    {
        //        Title = title;
        //    }
        //}

         /// <summary>
        /// Initializes a new instance of the <see cref="TextEditorViewModel" /> class.
        /// </summary>
        /// <param name="messageService">The message service.</param>
        /// <param name="orchestraService">The orchestra service.</param>
        /// <param name="messageMediator">The message mediator.</param>
        public TextEditorViewModel(IMessageService messageService, IOrchestraService orchestraService, IMessageMediator messageMediator)
        {
            Argument.IsNotNull(() => orchestraService);
            Argument.IsNotNull(() => orchestraService);
            Argument.IsNotNull(() => messageMediator);

            _messageService = messageService;
            _orchestraService = orchestraService;
            _messageMediator = messageMediator;

            // Text Editor features
            TextOptions = new TextEditorOptions() 
            {
                ShowSpaces = true,
            };
            //this.TextOptions.ShowSpaces = true;

            //this.f = new TextEditorViewModel();
            //this.Document = new TextDocument();

            this.HighlightDef = HighlightingManager.Instance.GetDefinition("C#");
            this._isDirty = false;
            this.IsReadOnly = false;
            this.ShowLineNumbers = false;
            this.WordWrap = false;
           

            // Comands
            ShowLineNumbersCommand = new Command(OnShowLineNumbersCommandExecute, OnShowLineNumbersCommandCanExecute);
            WordWrapCommand = new Command(OnWordWrapCommandExecute, OnWordWrapCommandCanExecute);
            EndLineCommand = new Command(OnEndLineCommandExecute, OnEndLineCommandCanExecute);
            ShowSpacesCommand = new Command(OnShowSpacesCommandExecute, OnShowSpacesCommandCanExecute);
            ShowTabCommand = new Command(OnShowTabCommandExecute, OnShowTabCommandCanExecute);

            SaveAsCommand = new Command(OnSaveAsCommandExecute, OnSaveAsCommandCanExecute);
            SaveCommand = new Command(OnSaveCommandExecute, OnSaveCommandCanExecute);
            CloseCommand = new Command(OnCloseCommandExecute, OnCloseCommandCanExecute);

            Title = FileName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextEditorViewModel" /> class.
        /// </summary>
        /// <param name="messageService">The message service.</param>
        /// <param name="orchestraService">The orchestra service.</param>
        /// <param name="messageMediator">The message mediator.</param>
        public TextEditorViewModel(string filePath, IMessageService messageService, IOrchestraService orchestraService, IMessageMediator messageMediator)
        {
            Argument.IsNotNull(() => orchestraService);
            Argument.IsNotNull(() => orchestraService);
            Argument.IsNotNull(() => messageMediator);

            _messageService = messageService;
            _orchestraService = orchestraService;
            _messageMediator = messageMediator;

            // Text Editor features
            TextOptions = new TextEditorOptions()
            {
                ShowSpaces = true,
            };
            //this.TextOptions.ShowSpaces = true;

            //this.f = new TextEditorViewModel();
            //this.Document = new TextDocument();

            this.HighlightDef = HighlightingManager.Instance.GetDefinition("C#");
            this._isDirty = false;
            this.IsReadOnly = false;
            this.ShowLineNumbers = false;
            this.WordWrap = false;


            if (!string.IsNullOrWhiteSpace(filePath))
            {
                FilePath = filePath;
            }

            ShowLineNumbersCommand = new Command(OnShowLineNumbersCommandExecute, OnShowLineNumbersCommandCanExecute);
            WordWrapCommand = new Command(OnWordWrapCommandExecute, OnWordWrapCommandCanExecute);
            EndLineCommand = new Command(OnEndLineCommandExecute, OnEndLineCommandCanExecute);
            ShowSpacesCommand = new Command(OnShowSpacesCommandExecute, OnShowSpacesCommandCanExecute);
            ShowTabCommand = new Command(OnShowTabCommandExecute, OnShowTabCommandCanExecute);

            SaveAsCommand = new Command(OnSaveAsCommandExecute, OnSaveAsCommandCanExecute);
            CloseCommand = new Command(OnCloseCommandExecute, OnCloseCommandCanExecute);

            Title = FileName;
        }

        #endregion

        #region FilePath
        private string _filePath = null;
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    RaisePropertyChanged("FilePath");
                    RaisePropertyChanged("FileName");
                    RaisePropertyChanged("Title");

                    if (File.Exists(this._filePath))
                    {
                        this._document = new TextDocument();
                        this.HighlightDef = HighlightingManager.Instance.GetDefinition("C#");
                        this._isDirty = false;
                        this.IsReadOnly = false;
                        this.ShowLineNumbers = false;
                        this.WordWrap = false;

                        // Check file attributes and set to read-only if file attributes indicate that
                        if ((System.IO.File.GetAttributes(this._filePath) & FileAttributes.ReadOnly) != 0)
                        {
                            this.IsReadOnly = true;
                            this.IsReadOnlyReason = "This file cannot be edit because another process is currently writting to it.\n" +
                                                    "Change the file access permissions or save the file in a different location if you want to edit it.";
                        }

                        using (FileStream fs = new FileStream(this._filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            using (StreamReader reader = FileReader.OpenStream(fs, Encoding.UTF8))
                            {
                                this._document = new TextDocument(reader.ReadToEnd());
                            }
                        }

                        ContentId = _filePath;
                    }
                }
            }
        }
        #endregion

        #region FileName
        public string FileName
        {
            get
            {
                if (FilePath == null)
                    return "Noname" + (IsDirty ? "*" : "");

                return System.IO.Path.GetFileName(FilePath) + (IsDirty ? "*" : "");
            }
        }
        #endregion FileName

        #region TextContent

        private TextDocument _document = new TextDocument();
        public TextDocument Document
        {
            get { return this._document; }
            set
            {
                if (this._document != value)
                {
                    this._document = value;
                    RaisePropertyChanged("Document");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region HighlightingDefinition

        private IHighlightingDefinition _highlightdef = null;
        public IHighlightingDefinition HighlightDef
        {
            get { return this._highlightdef; }
            set
            {
                if (this._highlightdef != value)
                {
                    this._highlightdef = value;
                    RaisePropertyChanged("HighlightDef");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region IsDirty

        private bool _isDirty = false;
        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                if (_isDirty != value)
                {
                    _isDirty = value;
                    RaisePropertyChanged("IsDirty");
                    RaisePropertyChanged("Title");
                    RaisePropertyChanged("FileName");
                }
            }
        }

        #endregion

        #region IsReadOnly
        private bool mIsReadOnly = false;
        public bool IsReadOnly
        {
            get
            {
                return this.mIsReadOnly;
            }

            protected set
            {
                if (this.mIsReadOnly != value)
                {
                    this.mIsReadOnly = value;
                    this.RaisePropertyChanged("IsReadOnly");
                }
            }
        }

        private string mIsReadOnlyReason = string.Empty;
        public string IsReadOnlyReason
        {
            get
            {
                return this.mIsReadOnlyReason;
            }

            protected set
            {
                if (this.mIsReadOnlyReason != value)
                {
                    this.mIsReadOnlyReason = value;
                    this.RaisePropertyChanged("IsReadOnlyReason");
                }
            }
        }
        #endregion IsReadOnly

        #region WordWrap
        // Toggle state WordWrap
        private bool mWordWrap = false;
        public bool WordWrap
        {
            get
            {
                return this.mWordWrap;
            }

            set
            {
                if (this.mWordWrap != value)
                {
                    this.mWordWrap = value;
                    this.RaisePropertyChanged("WordWrap");
                }
            }
        }
        #endregion WordWrap

        #region ShowLineNumbers
        // Toggle state ShowLineNumbers
        private bool mShowLineNumbers = false;
        public bool ShowLineNumbers
        {
            get
            {
                return this.mShowLineNumbers;
            }

            set
            {
                if (this.mShowLineNumbers != value)
                {
                    this.mShowLineNumbers = value;
                    this.RaisePropertyChanged("ShowLineNumbers");
                }
            }
        }
        #endregion ShowLineNumbers

        #region TextEditorOptions
        private TextEditorOptions mTextOptions = new TextEditorOptions()
        {
            ConvertTabsToSpaces = false,
            IndentationSize = 2
        };

        //private TextEditorOptions mTextOptions;
        public TextEditorOptions TextOptions 
        {
            get
            {
                return this.mTextOptions;
            }
            set
            {
                if (this.mTextOptions != value)
                {
                    this.mTextOptions = value;
                    this.RaisePropertyChanged("TextOptions");
                }
            }
        }
        #endregion TextEditorOptions


        // Helpers
        #region ContentId

        private string _contentId = null;
        public string ContentId
        {
            get { return _contentId; }
            set
            {
                if (_contentId != value)
                {
                    _contentId = value;
                    RaisePropertyChanged("ContentId");
                }
            }
        }

        #endregion

        #region IsSelected

        private bool _isSelected = false;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    RaisePropertyChanged("IsSelected");
                }
            }
        }

        #endregion

        #region IsActive

        private bool _isActive = false;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    RaisePropertyChanged("IsActive");
                }
            }
        }

        #endregion


        // File Commands
        #region SaveCommand
        bool saveAsFlag = true;

        public Command SaveCommand { get; private set; }

        private bool OnSaveCommandCanExecute()
        {
            return true;
        }

        private void OnSaveCommandExecute()
        {
            if (this.FilePath == null || saveAsFlag)
            {
                var dlg = new SaveFileDialog();
                if (dlg.ShowDialog().GetValueOrDefault())
                    this.FilePath = dlg.SafeFileName;
            }

            File.WriteAllText(this.FilePath, this.Document.Text);
            this.IsDirty = false;
        }

        #endregion

        #region SaveAsCommand
       
        public Command SaveAsCommand { get; private set; }

        private bool OnSaveAsCommandCanExecute()
        {
            return true;
        }

        private void OnSaveAsCommandExecute()
        {
            if (this.FilePath == null || saveAsFlag)
            {
                var dlg = new SaveFileDialog();
                if (dlg.ShowDialog().GetValueOrDefault())
                    this.FilePath = dlg.SafeFileName;
            }

            File.WriteAllText(this.FilePath, this.Document.Text);
            this.IsDirty = false;
        }

        #endregion

        #region CloseCommand
       
        public Command CloseCommand  { get; private set; }

        private bool OnCloseCommandCanExecute()
        {
            //return IsDirty;
            return true;
        }

        
        private void OnCloseCommandExecute()
        {
            //if (this.IsDirty)
            //{
                var res = MessageBox.Show(string.Format("Save changes for file '{0}'?", this.FileName), "TextEditor App", MessageBoxButton.YesNoCancel);
                if (res == MessageBoxResult.Cancel)
                    return;
                if (res == MessageBoxResult.Yes)
                {
                    OnSaveAsCommandExecute();
                }
                //this.Document = null;

            //}
        }

        #endregion


        // Text Editor Commands
        #region ShowLineNumbers Command
        /// <summary>
        /// Gets the ShowLineNumbers command.
        /// </summary>
        public Command ShowLineNumbersCommand { get; private set; }

        /// <summary>
        /// Method to check whether the ShowLineNumbers command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnShowLineNumbersCommandCanExecute()
        {
            return true;
        }

        /// <summary>
        /// Method to invoke when the ShowLineNumbers command is executed.
        /// </summary>
        private void OnShowLineNumbersCommandExecute()
        {
            // TODO: Handle command logic here
            if (ShowLineNumbers == false)
                ShowLineNumbers = true;
            else
                ShowLineNumbers = false;
        } 
        #endregion

        #region WordWrap Command
        /// <summary>
        /// Gets the WordWrap command.
        /// </summary>
        public Command WordWrapCommand { get; private set; }

        /// <summary>
        /// Method to check whether the WordWrap command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnWordWrapCommandCanExecute()
        {
            return true;
        }

        /// <summary>
        /// Method to invoke when the WordWrap command is executed.
        /// </summary>
        private void OnWordWrapCommandExecute()
        {
            // TODO: Handle command logic here
            if (WordWrap == false)
                WordWrap = true;
            else
                WordWrap = false;
        }
        #endregion

        #region EndLine Command
        /// <summary>
        /// Gets the EndLine command.
        /// </summary>
        public Command EndLineCommand { get; private set; }

        /// <summary>
        /// Method to check whether the EndLineCommand command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnEndLineCommandCanExecute()
        {
            return true;
        }

        /// <summary>
        /// Method to invoke when the EndLineCommand command is executed.
        /// </summary>
        private void OnEndLineCommandExecute()
        {
            // TODO: Handle command logic here
            this.TextOptions.ShowEndOfLine = true;      
        }
        #endregion

        #region ShowSpaces Command
        /// <summary>
        /// Gets the EndLine command.
        /// </summary>
        public Command ShowSpacesCommand { get; private set; }

        /// <summary>
        /// Method to check whether the EndLineCommand command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnShowSpacesCommandCanExecute()
        {
            return true;
        }

        /// <summary>
        /// Method to invoke when the EndLineCommand command is executed.
        /// </summary>
        private void OnShowSpacesCommandExecute()
        {
            // TODO: Handle command logic here
            if (this.TextOptions.ShowSpaces == false)
                this.TextOptions.ShowSpaces = true;
            else
                this.TextOptions.ShowSpaces = false;
        }
        #endregion

        #region ShowTab Command
        /// <summary>
        /// Gets the EndLine command.
        /// </summary>
        public Command ShowTabCommand { get; private set; }

        /// <summary>
        /// Method to check whether the EndLineCommand command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnShowTabCommandCanExecute()
        {
            return true;
        }

        /// <summary>
        /// Method to invoke when the EndLineCommand command is executed.
        /// </summary>
        private void OnShowTabCommandExecute()
        {
            // TODO: Handle command logic here
            if (this.TextOptions.ShowTabs == false)
                this.TextOptions.ShowTabs = true;
            else
                this.TextOptions.ShowTabs = false;
        }
        #endregion

        public TextEditorViewModel()            
        {
        }
    }
}