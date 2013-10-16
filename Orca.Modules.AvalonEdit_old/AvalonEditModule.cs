using Catel.IoC;
using Catel.Messaging;
using Catel.MVVM;
using Catel.MVVM.Services;
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
            ribbonService.RegisterRibbonItem(
                new RibbonButton(Name, Name, "Open",
                    new Command(() => orchestraService.ShowDocument(avalonViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/Smiley_Happy.png" });

            //var userControl1ViewModel = typeFactory.CreateInstance<avalonViewModel>();
            //ribbonService.RegisterRibbonItem(
            //    new RibbonButton(Name, Name, "Hello Word!",
            //        new Command(() => orchestraService.ShowDocument(userControl1ViewModel))) { ItemImage = "/Orca.Modules.AvalonEdit;component/Resources/Images/ActionPlot.png" });
        }
    }
}
