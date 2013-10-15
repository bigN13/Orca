using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;
using Orca.Modules.AvalonEdit.Common;
using Orchestra.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace Orca.Modules.AvalonEdit.Views
{
    /// <summary>
    /// Interaction logic for AvalonEditView.xaml
    /// </summary>
    public partial class PropertyView : DocumentView
    {
        public PropertyView()
        {
            InitializeComponent();

            // Load our custom highlighting definition
            //IHighlightingDefinition customHighlighting;
            //using (Stream s = typeof(AvalonEditView).Assembly.GetManifestResourceStream("AvalonEdit.Sample.CustomHighlighting.xshd"))
            //{
            //    if (s == null)
            //        throw new InvalidOperationException("Could not find embedded resource");
            //    using (XmlReader reader = new XmlTextReader(s))
            //    {
            //        customHighlighting = ICSharpCode.AvalonEdit.Highlighting.Xshd.
            //            HighlightingLoader.Load(reader, HighlightingManager.Instance);
            //    }
            //}
            //// and register it in the HighlightingManager
            //HighlightingManager.Instance.RegisterHighlighting("Custom Highlighting", new string[] { ".cool" }, customHighlighting);



            //propertyGridComboBox.SelectedIndex = 2;

            // in the constructor:
            //textEditor.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            //textEditor.TextArea.TextEntered += textEditor_TextArea_TextEntered;

            //DispatcherTimer foldingUpdateTimer = new DispatcherTimer();
            //foldingUpdateTimer.Interval = TimeSpan.FromSeconds(2);
            //foldingUpdateTimer.Tick += foldingUpdateTimer_Tick;
            //foldingUpdateTimer.Start();
        }


  
    }
}