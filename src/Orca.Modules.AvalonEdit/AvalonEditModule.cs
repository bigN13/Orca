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
using Orchestra;
using Catel;

namespace Orca.Modules.AvalonEdit
{
    /// <summary>
    /// The module.
    /// </summary>
    public class AvalonEditModule : Orchestra.Modules.ModuleBase
    {
        #region Constants
        /// <summary>
        /// The module name.
        /// </summary>
        public const string Name = "AvalonEdit";
        private readonly IOrchestraService _orchestraService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the module.
        /// </summary>
        public AvalonEditModule(IOrchestraService orchestraService)
            : base(Name)
        {
            Argument.IsNotNull(() => orchestraService);

            _orchestraService = orchestraService;
        }
        #endregion


        /// <summary>
        /// Called when the module is initialized.
        /// </summary>
        protected override void OnInitialized()
        {
            //var orchestraService = GetService<IOrchestraService>();
            //orchestraService.ShowDocument<PropertyViewModel>();

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
            
            // Module specific
            //var typeFactory = TypeFactory.Default;
            //var avalonEditViewModel = typeFactory.CreateInstance<AvalonEditViewModel>();

            //Home ribbon
            ribbonService.RegisterRibbonItem(
                new RibbonButton(HomeRibbonTabName, ModuleName, "New", new Command(() => _orchestraService.ShowDocument<AvalonEditViewModel>())) 
                {
                    ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_New32.png" 
                });

            #region File Buttons

            // View specific
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
               new RibbonButton(Name, "File", "New", "NewFileCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_New32.png" },
               ModuleName);

            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
               new RibbonButton(Name, "File", "Open", "OpenFileCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_Open32.png" },
               ModuleName);

            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
                 new RibbonButton(Name, "File", "Save", "SaveFileCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_Save32.png" },
                 ModuleName);

            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
                new RibbonButton(Name, "File", "SaveAs", "SaveFileAsCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_SaveAs32.png" },
                ModuleName);

            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
               new RibbonButton(Name, "File", "Close", "CloseFileCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_Close32.png" },
               ModuleName);
           
            #endregion

            #region Edit Buttons

            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
             new RibbonButton(Name, "Edit", "Edit", "EditTextCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Copy32.png" },
             ModuleName);

            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
             new RibbonButton(Name, "Edit", "Cut", "CutTextCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Cut32.png" },
             ModuleName);

            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
            new RibbonButton(Name, "Edit", "Paste", "PasteTextCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Paste32.png" },
            ModuleName);

            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
            new RibbonButton(Name, "Edit", "Delete", "DeleteTextCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Delete32.png" },
            ModuleName);

            #endregion          
          
            #region Undo / Redo Buttons

            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
              new RibbonButton(Name, "Undo", "Undo", "UndoActionCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Undo32.png" },
              ModuleName);

            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
            new RibbonButton(Name, "Undo", "Redo", "RedoActionCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Redo32.png" },
            ModuleName);

            #endregion  

            #region Text Editor Buttons
            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
               new RibbonButton(Name, "Text Editor", "WordWrap", "WordWrapActionCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_WordWrap32.png" },
               ModuleName);

            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
             new RibbonButton(Name, "Text Editor", "LineNumbers", "ShowLineNumbersAction") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Numbers32.png" },
             ModuleName);

            ribbonService.RegisterContextualRibbonItem<AvalonEditView>(
             new RibbonButton(Name, "Text Editor", "EndLine", "ShowLineNumbersActionCommand") { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_EndLine32.png" },
             ModuleName);
                   
            #endregion


            var contextualViewModelManager = GetService<IContextualViewModelManager>();
            //contextualViewModelManager.RegisterNestedDockView<AvalonEditViewModel>();
            contextualViewModelManager.RegisterContextualView<AvalonEditViewModel, PropertyViewModel>("HEHEHEHEHEHEHEHHE", DockLocation.Right);

            //var userControl1ViewModel = typeFactory.CreateInstance<avalonViewModel>();
            //ribbonService.RegisterRibbonItem(
            //    new RibbonButton(Name, Name, "Hello Word!",
            //        new Command(() => orchestraService.ShowDocument(userControl1ViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/ActionPlot.png" });


            // Demo: show two pages with different tags
            //var orcaViewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<AvalonEditViewModel>("Orca Avalon Editor");
            //orchestraService.ShowDocument(orcaViewModel, "Orca Avalon Editor");







        }
    }
}
