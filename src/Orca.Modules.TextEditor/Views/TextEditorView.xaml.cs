using Catel.IoC;
using Catel.Messaging;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using Xceed.Wpf.AvalonDock.Layout.Serialization;

namespace Orca.Modules.TextEditor.Views
{
    /// <summary>
    /// Interaction logic for AvalonEditView.xaml
    /// </summary>
    public partial class TextEditorView : DocumentView
    {
        public TextEditorView()
        {
            InitializeComponent();
        }
    }
}