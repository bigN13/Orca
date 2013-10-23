using Catel;
using Catel.IoC;
using Catel.Messaging;
using Catel.MVVM;
using Catel.MVVM.Services;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;
using Orca.Modules.AvalonEdit.ViewModels;
using Orca.Modules.AvalonEdit.ViewModels.Base;
using Orchestra.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

            //NewFileCommand = new Command(NewFileCommandExecute);
            //OpenFileCommand = new Command(OpenFileCommandExecute);
            //SaveFileCommand = new Command(SaveFileCommandExecute);
            //SaveAsFileCommand = new Command(SaveAsFileCommandExecute);
            //CloseFileCommand = new Command(CloseFileCommandExecute);
            //GoBack = new Command(OnGoBackExecute, OnGoBackCanExecute);
            //GoForward = new Command(OnGoForwardExecute, OnGoForwardCanExecute);
            //Browse = new Command(OnBrowseExecute, OnBrowseCanExecute);
            //Test = new Command(OnTestExecute);
            //CloseBrowser = new Command(OnCloseBrowserExecute);

            Title = "AvalonEdit";
        }


        public AvalonEditViewModel()            
        {
        }
        #endregion

        #region New Command
        /// <summary>
        /// New File command.
        /// </summary>
        //public Command NewFileCommand { get; private set; }

        //int count = 1;
        ///// <summary>
        ///// Method to check whether the GoBack command can be executed.
        ///// </summary>
        ///// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        //private void NewFileCommandExecute()
        //{
        //    var orchestraService = GetService<IOrchestraService>();
        //    var typeFactory = TypeFactory.Default;
        //    var orcaViewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<AvalonEditViewModel>("Sheet " + count.ToString());
        //    orchestraService.ShowDocument(orcaViewModel, "Sheet " + count.ToString());

        //    count++;

        //    //Workspace.This.NewCommand.Execute(null);
        //}
        #endregion

        //#region Open Command
        ///// <summary>
        ///// New File command.
        ///// </summary>
        //public Command OpenFileCommand { get; private set; }

        //string currentFileName;

        ///// <summary>
        ///// Method to check whether the GoBack command can be executed.
        ///// </summary>
        ///// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        //private void OpenFileCommandExecute()
        //{
        //    // Calling Commands from 
        //    Workspace.This.OpenCommand.Execute(null);


        //    //OpenFileDialog dlg = new OpenFileDialog();
        //    //dlg.CheckFileExists = true;
        //    //if (dlg.ShowDialog() ?? false)
        //    //{
        //    //    currentFileName = dlg.FileName;
        //    //    textEditor.Load(currentFileName);
        //    //    textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(currentFileName));
        //    //}

        //    //return _previousPages.Count > 0;
        //}
        //#endregion

        //#region Save Command
        ///// <summary>
        ///// New File command.
        ///// </summary>
        //public Command SaveFileCommand { get; private set; }

        ///// <summary>
        ///// Method to check whether the GoBack command can be executed.
        ///// </summary>
        ///// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        //private void SaveFileCommandExecute()
        //{
        //    // Calling Commands from Workspace
        //    Workspace.This.ActiveDocument.SaveCommand.Execute(null);

        //    //return _previousPages.Count > 0;
        //}
        //#endregion

        //#region SaveAsFileCommand Command
        ///// <summary>
        ///// New File command.
        ///// </summary>
        //public Command SaveAsFileCommand { get; private set; }

        ///// <summary>
        ///// Method to check whether the GoBack command can be executed.
        ///// </summary>
        ///// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        //private void SaveAsFileCommandExecute()
        //{
        //    // Calling Commands from Workspace
        //    Workspace.This.ActiveDocument.SaveAsCommand.Execute(null);
        //}
        //#endregion

        //#region Close Command
        ///// <summary>
        ///// New File command.
        ///// </summary>
        //public Command CloseFileCommand { get; private set; }

        ///// <summary>
        ///// Method to check whether the GoBack command can be executed.
        ///// </summary>
        ///// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        //private void CloseFileCommandExecute()
        //{
        //    _orchestraService.CloseDocument(this);

        //    // Calling Commands from Workspace
        //    //Workspace.This.ActiveDocument.CloseCommand.Execute(null);
        //}
        //#endregion

        ///// <summary>
        ///// Gets the test command.
        ///// </summary>
        ///// <value>
        ///// The test.
        ///// </value>
        ////public Command Test { get; private set; }

        //private void OnTestExecute()
        //{
        //    _messageService.ShowInformation("This is a test, for loading dynamic content into the ribbon...");
        //}



        #region Workspace Functions
        //AvalonEditViewModel _this = new AvalonEditViewModel();

        //public AvalonEditViewModel This
        //{
        //    get { return _this; }
        //}

        //ObservableCollection<FileViewModel> _files = new ObservableCollection<FileViewModel>();
        //ReadOnlyObservableCollection<FileViewModel> _readonyFiles = null;
        //public ReadOnlyObservableCollection<FileViewModel> Files
        //{
        //    get
        //    {
        //        if (_readonyFiles == null)
        //            _readonyFiles = new ReadOnlyObservableCollection<FileViewModel>(_files);

        //        return _readonyFiles;
        //    }
        //}

        //ToolViewModel[] _tools = null;

        //public IEnumerable<ToolViewModel> Tools
        //{
        //    get
        //    {
        //        if (_tools == null)
        //            _tools = new ToolViewModel[] { FileStats };
        //        return _tools;
        //    }
        //}

        //FileStatsViewModel _fileStats = null;
        //public FileStatsViewModel FileStats
        //{
        //    get
        //    {
        //        if (_fileStats == null)
        //            _fileStats = new FileStatsViewModel();

        //        return _fileStats;
        //    }
        //}

        //#region OpenCommand
        //RelayCommand _openCommand = null;
        //public ICommand OpenCommand
        //{
        //    get
        //    {
        //        if (_openCommand == null)
        //        {
        //            _openCommand = new RelayCommand((p) => OnOpen(p), (p) => CanOpen(p));
        //        }

        //        return _openCommand;
        //    }
        //}

        //private bool CanOpen(object parameter)
        //{
        //    return true;
        //}

        //private void OnOpen(object parameter)
        //{
        //    var dlg = new OpenFileDialog();
        //    if (dlg.ShowDialog().GetValueOrDefault())
        //    {
        //        var fileViewModel = Open(dlg.FileName);
        //        ActiveDocument = fileViewModel;
        //    }
        //}

        //public FileViewModel Open(string filepath)
        //{
        //    var fileViewModel = _files.FirstOrDefault(fm => fm.FilePath == filepath);
        //    if (fileViewModel != null)
        //        return fileViewModel;

        //    fileViewModel = new FileViewModel(filepath);
        //    _files.Add(fileViewModel);

        //    return fileViewModel;
        //}

        //#endregion

        //#region NewCommand
        //RelayCommand _newCommand = null;
        //public ICommand NewCommand
        //{
        //    get
        //    {
        //        if (_newCommand == null)
        //        {
        //            _newCommand = new RelayCommand((p) => OnNew(p), (p) => CanNew(p));
        //        }

        //        return _newCommand;
        //    }
        //}

        //private bool CanNew(object parameter)
        //{
        //    return true;
        //}

        //private void OnNew(object parameter)
        //{
        //    _files.Add(new FileViewModel() { Document = new TextDocument() });
        //    ActiveDocument = _files.Last();
        //}

        //#endregion

        //#region ActiveDocument

        //private FileViewModel _activeDocument = null;
        //public FileViewModel ActiveDocument
        //{
        //    get { return _activeDocument; }
        //    set
        //    {
        //        if (_activeDocument != value)
        //        {
        //            _activeDocument = value;
        //            RaisePropertyChanged("ActiveDocument");
        //            if (ActiveDocumentChanged != null)
        //                ActiveDocumentChanged(this, EventArgs.Empty);
        //        }
        //    }
        //}

        //public event EventHandler ActiveDocumentChanged;

        //#endregion

        //internal void Close(FileViewModel fileToClose)
        //{
        //    if (fileToClose.IsDirty)
        //    {
        //        var res = MessageBox.Show(string.Format("Save changes for file '{0}'?", fileToClose.FileName), "AvalonDock Test App", MessageBoxButton.YesNoCancel);
        //        if (res == MessageBoxResult.Cancel)
        //            return;
        //        if (res == MessageBoxResult.Yes)
        //        {
        //            Save(fileToClose);
        //        }
        //    }

        //    _files.Remove(fileToClose);
        //}

        //internal void Save(FileViewModel fileToSave, bool saveAsFlag = false)
        //{
        //    if (fileToSave.FilePath == null || saveAsFlag)
        //    {
        //        var dlg = new SaveFileDialog();
        //        if (dlg.ShowDialog().GetValueOrDefault())
        //            fileToSave.FilePath = dlg.SafeFileName;
        //    }

        //    File.WriteAllText(fileToSave.FilePath, fileToSave.Document.Text);
        //    ActiveDocument.IsDirty = false;
        //}

        //#region ToggleEditorOptionCommand
        //RelayCommand _toggleEditorOptionCommand = null;
        //public ICommand ToggleEditorOptionCommand
        //{
        //    get
        //    {
        //        if (this._toggleEditorOptionCommand == null)
        //        {
        //            this._toggleEditorOptionCommand = new RelayCommand((p) => OnToggleEditorOption(p),
        //                                                               (p) => CanToggleEditorOption(p));
        //        }

        //        return this._toggleEditorOptionCommand;
        //    }
        //}

        //private bool CanToggleEditorOption(object parameter)
        //{
        //    if (this.ActiveDocument != null)
        //        return true;

        //    return false;
        //}

        //private void OnToggleEditorOption(object parameter)
        //{
        //    FileViewModel f = this.ActiveDocument;

        //    if (parameter == null)
        //        return;

        //    if ((parameter is ToggleEditorOption) == false)
        //        return;

        //    ToggleEditorOption t = (ToggleEditorOption)parameter;

        //    if (f != null)
        //    {
        //        switch (t)
        //        {
        //            case ToggleEditorOption.WordWrap:
        //                f.WordWrap = !f.WordWrap;
        //                break;

        //            case ToggleEditorOption.ShowLineNumber:
        //                f.ShowLineNumbers = !f.ShowLineNumbers;
        //                break;

        //            case ToggleEditorOption.ShowSpaces:
        //                f.TextOptions.ShowSpaces = !f.TextOptions.ShowSpaces;
        //                break;

        //            case ToggleEditorOption.ShowTabs:
        //                f.TextOptions.ShowTabs = !f.TextOptions.ShowTabs;
        //                break;

        //            case ToggleEditorOption.ShowEndOfLine:
        //                f.TextOptions.ShowEndOfLine = !f.TextOptions.ShowEndOfLine;
        //                break;

        //            default:
        //                break;
        //        }
        //    }
        //}
        //#endregion ToggleEditorOptionCommand

        #endregion
    }
}
