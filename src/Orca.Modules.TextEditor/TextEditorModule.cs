using Catel;
using Catel.IoC;
using Catel.MVVM;
using Microsoft.Win32;
using Orca.Modules.TextEditor.ViewModels;
using Orca.Modules.TextEditor.Views;
using Orchestra;
using Orchestra.Models;
using Orchestra.Modules;
using Orchestra.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Orca.Modules.TextEditor
{
    public class TextEditorModule : ModuleBase
    {
        #region Constants
        /// <summary>
        /// The module name.
        /// </summary>
        public const string Name = "TextEditor";
        private readonly IOrchestraService _orchestraService;

        ObservableCollection<TextEditorViewModel> _files = new ObservableCollection<TextEditorViewModel>();
        ReadOnlyObservableCollection<TextEditorViewModel> _readonyFiles = null;
        public ReadOnlyObservableCollection<TextEditorViewModel> Files
        {
            get
            {
                if (_readonyFiles == null)
                    _readonyFiles = new ReadOnlyObservableCollection<TextEditorViewModel>(_files);

                return _readonyFiles;
            }
        }

        int count = 2;
        #endregion

        #region Commands
        public Command NewDocumentCommand { get; private set; }
        public Command OpenDocumentCommand { get; private set; }
       
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the module.
        /// </summary>
        public TextEditorModule(IOrchestraService orchestraService)
            : base(Name)
        {
            Argument.IsNotNull(() => orchestraService);

            _orchestraService = orchestraService;
        }


        /// <summary>
        /// Called when the module is initialized.
        /// </summary>
        protected override void OnInitialized()
        {
            NewDocumentCommand = new Command(NewDocumentCommandExecute, NewDocumentCommandCanExecute);
            OpenDocumentCommand = new Command(OpenDocumentCommandExecute, OpenDocumentCommandCanExecute);
        }

        /// <summary>
        /// Initializes the ribbon.
        /// <para />
        /// Use this method to hook up views to ribbon items.
        /// </summary>
        /// <param name="ribbonService">The ribbon service.</param>
        protected override void InitializeRibbon(IRibbonService ribbonService)
        {
            #region Module Specific
            ribbonService.RegisterRibbonItem(
                  new RibbonButton(HomeRibbonTabName, ModuleName, "Open", new Command(() => _orchestraService.ShowDocument<TextEditorViewModel>()))
                  {
                      ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_WordWrap32.png"
                  }); 
            #endregion
            
            #region View Specific
            #region File Buttons

            // View specific
            ribbonService.RegisterContextualRibbonItem<TextEditorView>(
               new RibbonButton(Name, "File", "New", new Command(() => NewDocumentCommand.Execute(null))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_New32.png" },
               ModuleName);

            ribbonService.RegisterContextualRibbonItem<TextEditorView>(
               new RibbonButton(Name, "File", "Open", new Command(() => OpenDocumentCommand.Execute(null))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_Open32.png" },
               ModuleName);

            //ribbonService.RegisterContextualRibbonItem<TextEditorView>(
            //   new RibbonButton(Name, "File", "Open", "OpenDocumentCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_Open32.png" },
            //   ModuleName);

            ribbonService.RegisterContextualRibbonItem<TextEditorView>(
                 new RibbonButton(Name, "File", "Save", "SaveCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_Save32.png" },
                 ModuleName);

            ribbonService.RegisterContextualRibbonItem<TextEditorView>(
                new RibbonButton(Name, "File", "SaveAs", "SaveAsCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_SaveAs32.png" },
                ModuleName);

            ribbonService.RegisterContextualRibbonItem<TextEditorView>(
               new RibbonButton(Name, "File", "Close", "CloseCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_Close32.png" },
               ModuleName);

            #endregion

            #region Edit Buttons

            ribbonService.RegisterContextualRibbonItem<TextEditorView>(
             new RibbonButton(Name, "Edit", "Copy", ApplicationCommands.Copy) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Copy32.png" },
             ModuleName);

            ribbonService.RegisterContextualRibbonItem<TextEditorView>(
             new RibbonButton(Name, "Edit", "Cut", ApplicationCommands.Cut) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Cut32.png" },
             ModuleName);

            ribbonService.RegisterContextualRibbonItem<TextEditorView>(
            new RibbonButton(Name, "Edit", "Paste", ApplicationCommands.Paste) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Paste32.png" },
            ModuleName);

            ribbonService.RegisterContextualRibbonItem<TextEditorView>(
            new RibbonButton(Name, "Edit", "Delete", ApplicationCommands.Delete) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Delete32.png" },
            ModuleName);

            #endregion

            #region Undo / Redo Buttons

            ribbonService.RegisterContextualRibbonItem<TextEditorView>(
              new RibbonButton(Name, "Undo", "Undo", ApplicationCommands.Undo) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Undo32.png" },
              ModuleName);

            ribbonService.RegisterContextualRibbonItem<TextEditorView>(
            new RibbonButton(Name, "Undo", "Redo", ApplicationCommands.Redo) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Redo32.png" },
            ModuleName);

            #endregion

            #region Text Editor Buttons
            ribbonService.RegisterContextualRibbonItem<TextEditorView>(
               new RibbonButton(Name, "Text Editor", "WordWrap", "WordWrapCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_WordWrap32.png" },
               ModuleName);

            ribbonService.RegisterContextualRibbonItem<TextEditorView>(
             new RibbonButton(Name, "Text Editor", "LineNumbers", "ShowLineNumbersCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Numbers32.png" },
             ModuleName);

            //ribbonService.RegisterContextualRibbonItem<TextEditorView>(
            // new RibbonButton(Name, "Text Editor", "EndLine", "EndLineCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_EndLine32.png" },
            // ModuleName);

            //ribbonService.RegisterContextualRibbonItem<TextEditorView>(
            //new RibbonButton(Name, "Text Editor", "ShowSpaces", "ShowSpacesCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/ShowSpaces32.png" },
            //ModuleName);

            //ribbonService.RegisterContextualRibbonItem<TextEditorView>(
            //new RibbonButton(Name, "Text Editor", "ShowTab", "ShowTabCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/ShowTab32.png" },
            //ModuleName);

            #endregion

            #region Properties Window

            var contextualViewModelManager = GetService<IContextualViewModelManager>();
            //contextualViewModelManager.RegisterNestedDockView<TextEditorViewModel>();
            contextualViewModelManager.RegisterContextualView<TextEditorViewModel, PropertyViewModel>("Properties", DockLocation.Right);

            //var userControl1ViewModel = typeFactory.CreateInstance<avalonViewModel>();
            //ribbonService.RegisterRibbonItem(
            //    new RibbonButton(Name, Name, "Hello Word!",
            //        new Command(() => orchestraService.ShowDocument(userControl1ViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/ActionPlot.png" });


            // Demo: show two pages with different tags
            //var orcaViewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<TextEditorViewModel>("Orca Avalon Editor");
            //orchestraService.ShowDocument(orcaViewModel, "Orca Avalon Editor");
            #endregion 
            #endregion
        }
        #endregion

        #region New Document Command
        /// <summary>
        /// Method to check whether the New command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool NewDocumentCommandCanExecute()
        {
            // TODO: Handle command logic here
            return true;
        }

        /// <summary>
        /// Method to invoke when the New command is executed.
        /// </summary>
        private void NewDocumentCommandExecute()
        {
            var typeFactory = TypeFactory.Default;
            var orcaViewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<TextEditorViewModel>(this);
            _orchestraService.ShowDocument(orcaViewModel, "Sheet " + count.ToString());

            _files.Add(orcaViewModel);
            count++;
        } 
        #endregion

        #region Open Document Command
        /// <summary>
        /// Method to check whether the New command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OpenDocumentCommandCanExecute()
        {
            // TODO: Handle command logic here
            return true;
        }

        /// <summary>
        /// Method to invoke when the New command is executed.
        /// </summary>
        private void OpenDocumentCommandExecute()
        {
            // TODO: Handle command logic here
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog().GetValueOrDefault())
            {
                var fileViewModel = Open(dlg.FileName);
                //ActiveDocument = fileViewModel;
            }
        }

        public TextEditorViewModel Open(string filepath)
        {
            // Verify whether file is already open in editor, and if so, show it
            var fileViewModel = _files.FirstOrDefault(fm => fm.FilePath == filepath);
            if (fileViewModel != null)
                return fileViewModel;

            var typeFactory = TypeFactory.Default;
            fileViewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<TextEditorViewModel>(filepath, this);
            _orchestraService.ShowDocument(fileViewModel, fileViewModel.Title);
            _files.Add(fileViewModel);

            count++;

            return fileViewModel;
        }
        #endregion

        #region ActiveDocument

        private TextEditorViewModel _activeDocument = null;
        public TextEditorViewModel ActiveDocument
        {
            get { return _activeDocument; }
            set
            {
                if (_activeDocument != value)
                {
                    _activeDocument = value;
                    //RaisePropertyChanged("ActiveDocument");
                    if (ActiveDocumentChanged != null)
                        ActiveDocumentChanged(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler ActiveDocumentChanged;

        #endregion

        internal void Close(TextEditorViewModel fileToClose)
        {
            if (fileToClose.IsDirty)
            {
                var res = MessageBox.Show(string.Format("Save changes for file '{0}'?", fileToClose.FileName), "AvalonDock Test App", MessageBoxButton.YesNoCancel);
                if (res == MessageBoxResult.Cancel)
                    return;
                if (res == MessageBoxResult.Yes)
                {
                    Save(fileToClose);
                }
            }

            _files.Remove(fileToClose);
        }

        internal void Save(TextEditorViewModel fileToSave, bool saveAsFlag = false)
        {
            if (fileToSave.FilePath == null || saveAsFlag)
            {
                var dlg = new SaveFileDialog();
                if (dlg.ShowDialog().GetValueOrDefault())
                    fileToSave.FilePath = dlg.FileName;
                    //fileToSave.FilePath = dlg.SafeFileName;
            }

            File.WriteAllText(fileToSave.FilePath, fileToSave.Document.Text);
            ActiveDocument.IsDirty = false;
        }

    }
}
