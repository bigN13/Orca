using Catel.IoC;
using Catel.Messaging;
using Catel.MVVM;
using Catel.MVVM.Services;
using Orca.Modules.AvalonEdit.ViewModel;
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
            var orchestraService = GetService<IOrchestraService>();

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

            var avalonViewModel = typeFactory.CreateInstance<AvalonEditViewModel>();

            #region File Commands
            ribbonService.RegisterRibbonItem(
            new RibbonButton(Name, "File", "New",
             new Command(() => orchestraService.ShowDocument(avalonViewModel))) 
             { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_New32.png" });


            ribbonService.RegisterRibbonItem(
                new RibbonButton(Name, "File", "Open",
                    new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_Open32.png" });

      
            ribbonService.RegisterRibbonItem(
               new RibbonButton(Name, "File", "Save",
                   new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_Save32.png" });

            ribbonService.RegisterRibbonItem(
              new RibbonButton(Name, "File", "Save As",
                  new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_SaveAs32.png" });

            ribbonService.RegisterRibbonItem(
              new RibbonButton(Name, "File", "Close",
                  new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/File_Close32.png" });

            ribbonService.RegisterRibbonItem(
             new RibbonButton(Name, "Edit", "Edit",
                 new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Copy32.png" });

            ribbonService.RegisterRibbonItem(
             new RibbonButton(Name, "Edit", "Cut",
                 new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Cut32.png" });

            ribbonService.RegisterRibbonItem(
            new RibbonButton(Name, "Edit", "Paste",
                new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Paste32.png" });

            ribbonService.RegisterRibbonItem(
            new RibbonButton(Name, "Edit", "Delete",
                new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Delete32.png" });
            #endregion

            #region Undo / Redo Commands
            ribbonService.RegisterRibbonItem(
            new RibbonButton(Name, "Undo", "Undo",
              new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Undo32.png" });

            ribbonService.RegisterRibbonItem(
            new RibbonButton(Name, "Undo", "Redo",
            new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Redo32.png" });
            #endregion

            #region Text Editor Commands
            ribbonService.RegisterRibbonItem(
               new RibbonButton(Name, "Word Wrap", "Text Editor",
               new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_WordWrap32.png" });

            ribbonService.RegisterRibbonItem(
              new RibbonButton(Name, "Show Line Numbers", "Text Editor",
              new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Numbers32.png" });

            ribbonService.RegisterRibbonItem(
             new RibbonButton(Name, "Show End Of Line", "Text Editor",
             new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_EndLine32.png" });


            #endregion

            //var userControl1ViewModel = typeFactory.CreateInstance<avalonViewModel>();
            //ribbonService.RegisterRibbonItem(
            //    new RibbonButton(Name, Name, "Hello Word!",
            //        new Command(() => orchestraService.ShowDocument(userControl1ViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/ActionPlot.png" });
        }
    }
}
