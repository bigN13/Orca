using Catel.IoC;
using Catel.Messaging;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;
using Orca.Modules.AvalonEdit.Commands;
using Orca.Modules.AvalonEdit.Common;
using Orca.Modules.AvalonEdit.ViewModels;
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
using Xceed.Wpf.AvalonDock.Layout.Serialization;

namespace Orca.Modules.AvalonEdit.Views
{
    /// <summary>
    /// Interaction logic for AvalonEditView.xaml
    /// </summary>
    public partial class AvalonEditView : DocumentView
    {
        public AvalonEditView()
        {
            InitializeComponent();

            //this.DataContext = AvalonEditModule;
            //this.DataContext = Workspace.This;

            //this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            //this.Unloaded += new RoutedEventHandler(MainWindow_Unloaded);

            
            textEditor.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            textEditor.TextArea.TextEntered += textEditor_TextArea_TextEntered;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //var serializer = new Xceed.Wpf.AvalonDock.Layout.Serialization.XmlLayoutSerializer(dockManager);
            //serializer.LayoutSerializationCallback += (s, args) =>
            //{
            //    args.Content = args.Content;
            //};

            //if (File.Exists(@".\AvalonDock.config"))
            //    serializer.Deserialize(@".\AvalonDock.config");
        }

        void MainWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            //var serializer = new Xceed.Wpf.AvalonDock.Layout.Serialization.XmlLayoutSerializer(dockManager);
            //serializer.Serialize(@".\AvalonDock.config");
        }

        #region LoadLayoutCommand
        RelayCommand _loadLayoutCommand = null;
        public ICommand LoadLayoutCommand
        {
            get
            {
                if (_loadLayoutCommand == null)
                {
                    _loadLayoutCommand = new RelayCommand((p) => OnLoadLayout(p), (p) => CanLoadLayout(p));
                }

                return _loadLayoutCommand;
            }
        }

        private bool CanLoadLayout(object parameter)
        {
            return File.Exists(@".\AvalonDock.Layout.config");
        }

        private void OnLoadLayout(object parameter)
        {
            //var layoutSerializer = new XmlLayoutSerializer(dockManager);
            //Here I've implemented the LayoutSerializationCallback just to show
            // a way to feed layout desarialization with content loaded at runtime
            //Actually I could in this case let AvalonDock to attach the contents
            //from current layout using the content ids
            //LayoutSerializationCallback should anyway be handled to attach contents
            //not currently loaded
            //layoutSerializer.LayoutSerializationCallback += (s, e) =>
            //{
            //    //if (e.Model.ContentId == FileStatsViewModel.ToolContentId)
            //    //    e.Content = Workspace.This.FileStats;
            //    //else if (!string.IsNullOrWhiteSpace(e.Model.ContentId) &&
            //    //    File.Exists(e.Model.ContentId))
            //    //    e.Content = Workspace.This.Open(e.Model.ContentId);
            //};
            //layoutSerializer.Deserialize(@".\AvalonDock.Layout.config");
        }

        #endregion

        #region SaveLayoutCommand
        RelayCommand _saveLayoutCommand = null;
        public ICommand SaveLayoutCommand
        {
            get
            {
                if (_saveLayoutCommand == null)
                {
                    _saveLayoutCommand = new RelayCommand((p) => OnSaveLayout(p), (p) => CanSaveLayout(p));
                }

                return _saveLayoutCommand;
            }
        }

        private bool CanSaveLayout(object parameter)
        {
            return true;
        }

        private void OnSaveLayout(object parameter)
        {
            //var layoutSerializer = new XmlLayoutSerializer(dockManager);
            //layoutSerializer.Serialize(@".\AvalonDock.Layout.config");
        }

        #endregion

        private void OnDumpToConsole(object sender, RoutedEventArgs e)
        {
            // Uncomment when TRACE is activated on AvalonDock project
            //dockManager.Layout.ConsoleDump(0);
        }

        CompletionWindow completionWindow;

        void textEditor_TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == ".")
            {
                // Open code completion after the user has pressed dot:
                completionWindow = new CompletionWindow(textEditor.TextArea);
                IList<ICompletionData> data = completionWindow.CompletionList.CompletionData;
                data.Add(new MyCompletionData("Item1"));
                data.Add(new MyCompletionData("Item2"));
                data.Add(new MyCompletionData("Item3"));
                completionWindow.Show();
                completionWindow.Closed += delegate
                {
                    completionWindow = null;
                };
            }
        }

        void textEditor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length > 0 && completionWindow != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    completionWindow.CompletionList.RequestInsertion(e);
                }
            }
            // Do not set e.Handled=true.
            // We still want to insert the character that was typed.
        }

    }
}