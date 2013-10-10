using Catel.IoC;
using Catel.Messaging;
using Catel.MVVM;
using Catel.MVVM.Services;
using Orca.Modules.AvalonEdit.Views;
using Orca.Modules.AvalonEdit.ViewModels;
using Orchestra.Models;
using Orchestra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orca.Modules.AvalonEdit
{
    /// <summary>
    /// The module.
    /// </summary>
    public class AvalonEditModule : Orchestra.Modules.ModuleBase
    {
        /// <summary>
        /// The module name.
        /// </summary>
        public const string Name = "AvalonEdit";

        /// <summary>
        /// Initializes the module.
        /// </summary>
        public AvalonEditModule()
            : base(Name)
        {
        }

        /// <summary>
        /// Called when the module is initialized.
        /// </summary>
        protected override void OnInitialized()
        {
            //var orchestraService = GetService<IOrchestraService>();
            //orchestraService.ShowDocument<AvalonEditViewModel>();

            // TODO: Register ribbon items
            //var openRibbonItem = new RibbonItem(ModuleName, ModuleName, "Action name", new Command(() =>
            //    {
            //        // Action to invoke
            //    }));
            //orchestraService.AddRibbonItem(openRibbonItem);

            // TODO: Handle additional initialization code
        }

        /// <summary>
        /// Initializes the ribbon.
        /// <para />
        /// Use this method to hook up views to ribbon items.
        /// </summary>
        /// <param name="ribbonService">The ribbon service.</param>
        protected override void InitializeRibbon(IRibbonService ribbonService)
        {
            var orchestraService = GetService<IOrchestraService>();

            // Module specific
            var typeFactory = TypeFactory.Default;
            var avalonEditViewModel = typeFactory.CreateInstance<AvalonEditViewModel>();
            ribbonService.RegisterRibbonItem(new RibbonButton(HomeRibbonTabName, ModuleName, "New", 
                new Command(() => orchestraService.ShowDocument(avalonEditViewModel))) {ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_New32.png" });

#region File Commands

            // View specific
            var newFileButton = new RibbonButton(Name, "File", "New", "NewFile") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_New32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(newFileButton, ModuleName);

            var OpenFileButton = new RibbonButton(Name, "File", "Open", "OpenFile") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_Open32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(OpenFileButton, ModuleName);

            var SaveFileButton = new RibbonButton(Name, "File", "Save", "SaveFile") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_Save32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(SaveFileButton, ModuleName);

            var SaveFileAsButton = new RibbonButton(Name, "File", "Save As", "SaveAsFile") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_SaveAs32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(SaveFileAsButton, ModuleName);

            var CloseFileButton = new RibbonButton(Name, "File", "Close", "CloseFile") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_Close32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(CloseFileButton, ModuleName);
#endregion

#region Edit Commands
            var EditTextButton = new RibbonButton(Name, "Edit", "Edit", "EditText") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Copy32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(EditTextButton, ModuleName);

            var CutTextButton = new RibbonButton(Name, "Edit", "Cut", "CutText") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Cut32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(CutTextButton, ModuleName);

            var PasteTextButton = new RibbonButton(Name, "Edit", "Paste", "PasteText") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Paste32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(PasteTextButton, ModuleName);

            var DeleteTextButton = new RibbonButton(Name, "Edit", "Delete", "DeleteText") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Delete32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(DeleteTextButton, ModuleName);
#endregion          
          
       

            #region Undo / Redo Commands
            var UndoButton = new RibbonButton(Name, "Undo", "Undo", "UndoAction") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Undo32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(UndoButton, ModuleName);

            var RedoButton = new RibbonButton(Name, "Undo", "Redo", "RedoAction") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Redo32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(RedoButton, ModuleName);
            #endregion  


            #region Text Editor Commands
            var WordWrapButton = new RibbonButton(Name, "Text Editor", "Word Wrap", "WordWrapAction") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_WordWrap32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(WordWrapButton, ModuleName);

            var ShowLineNumbersButton = new RibbonButton(Name, "Text Editor", "Show Line Numbers", "ShowLineNumbersAction") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Numbers32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(ShowLineNumbersButton, ModuleName);

            var ShowEndOfLineButton = new RibbonButton(Name, "Text Editor", "Show End Of Line", "ShowLineNumbersAction") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_EndLine32.png" };
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(ShowEndOfLineButton, ModuleName);
           
            #endregion

            //var userControl1ViewModel = typeFactory.CreateInstance<avalonViewModel>();
            //ribbonService.RegisterRibbonItem(
            //    new RibbonButton(Name, Name, "Hello Word!",
            //        new Command(() => orchestraService.ShowDocument(userControl1ViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/ActionPlot.png" });


            // Demo: show two pages with different tags
            var orchestraViewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<AvalonEditViewModel>("Orchestra");
            //orchestraViewModel.Url = "http://www.github.com/Orcomp/Orchestra";
            orchestraService.ShowDocument(orchestraViewModel, "orchestra");


        }
    }
}
