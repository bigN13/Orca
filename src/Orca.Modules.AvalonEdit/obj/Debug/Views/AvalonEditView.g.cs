﻿#pragma checksum "..\..\..\Views\AvalonEditView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3074EA956553CB8679F6A7D29C29AC67"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Catel.MVVM;
using Catel.Windows;
using Catel.Windows.Controls;
using Catel.Windows.Controls.MVVMProviders;
using Catel.Windows.Data;
using Catel.Windows.Data.Converters;
using Catel.Windows.Interactivity;
using Catel.Windows.Markup;
using Catel.Windows.Media.Effects;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Search;
using Orchestra.Layout;
using Orchestra.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Controls;
using Xceed.Wpf.AvalonDock.Converters;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.AvalonDock.Themes;


namespace Orca.Modules.AvalonEdit.Views {
    
    
    /// <summary>
    /// AvalonEditView
    /// </summary>
    public partial class AvalonEditView : Orchestra.Views.DocumentView, System.Windows.Markup.IComponentConnector {
        
        
        #line 82 "..\..\..\Views\AvalonEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox highlightingComboBox;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Views\AvalonEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.AvalonDock.DockingManager dockManager;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Views\AvalonEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.AvalonDock.Layout.LayoutAnchorablePaneGroup LeftAnchorableGroup;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\Views\AvalonEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox propertyGridComboBox;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\Views\AvalonEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.PropertyGrid propertyGrid;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Views\AvalonEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPaneGroup leftDocumentGroup;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\Views\AvalonEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ICSharpCode.AvalonEdit.TextEditor textEditor;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Orca.Modules.AvalonEdit;component/views/avaloneditview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\AvalonEditView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 25 "..\..\..\Views\AvalonEditView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.openFileClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 27 "..\..\..\Views\AvalonEditView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.saveFileClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.highlightingComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 85 "..\..\..\Views\AvalonEditView.xaml"
            this.highlightingComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.HighlightingComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dockManager = ((Xceed.Wpf.AvalonDock.DockingManager)(target));
            return;
            case 5:
            this.LeftAnchorableGroup = ((Xceed.Wpf.AvalonDock.Layout.LayoutAnchorablePaneGroup)(target));
            return;
            case 6:
            this.propertyGridComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 97 "..\..\..\Views\AvalonEditView.xaml"
            this.propertyGridComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.propertyGridComboBoxSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.propertyGrid = ((System.Windows.Forms.PropertyGrid)(target));
            return;
            case 8:
            this.leftDocumentGroup = ((Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPaneGroup)(target));
            return;
            case 9:
            this.textEditor = ((ICSharpCode.AvalonEdit.TextEditor)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

