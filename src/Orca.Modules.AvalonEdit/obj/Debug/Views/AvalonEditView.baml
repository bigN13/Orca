   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5   	    Orca.Modules.AvalonEdit2   ,Orca.Modules.AvalonEdit.Views.AvalonEditView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   m iXceed.Wpf.AvalonDock.Themes.Expression, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4g cXceed.Wpf.AvalonDock.Themes.Aero, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4i eXceed.Wpf.AvalonDock.Themes.VS2010, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4h	 dXceed.Wpf.AvalonDock.Themes.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4[
 WXceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4E
avalonDock,http://schemas.xceed.com/wpf/xaml/avalondock    	 
 5   	   ` \ICSharpCode.AvalonEdit, Version=4.3.1.9429, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonEdit.http://icsharpcode.net/sharpdevelop/avalonedit  5   	   Lforms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   E ACatel.MVVM, Version=3.7.0.0, Culture=neutral, PublicKeyToken=nullT PCatel.Extensions.Controls, Version=3.7.0.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   L HOrchestra.Library, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null-	orchestrahttp://orchestra.codeplex.com  5
   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Display=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� $��0��6   .@�5      m� $��_File��6   .@�5      m� $	��New��6    m� Command 6(   �� *
NewCommand+m� 5      -   5        $
��Open��5      6)   �� 5      m� 5      -   5        $
��Save��5      6)   m� 5      $��
Save As...��6    6/   �� *ActiveDocument.SaveAsCommand+�� 5      m� 5      $��Close��6    6*   �� *ActiveDocument.CloseCommand+5      m� 5       $��_Tools��6   .@�5!      m� $��
Properties��6    m� IsCheckable .  m� 	IsChecked 6/   �� *FileStats.IsVisible+ �� Mode$ TwoWay=�6f   5"      m� 5#      $��_Layout��6   .@�5$      m� $
��Load��6    6)   �� *LoadLayoutCommand+ �� ElementName$ 
mainWindow��m� 5%      $
��Save��6    6)   �� *SaveLayoutCommand+$ 
mainWindow��5'      5(      `� 5*   
   $��1��6    J� SnapsToDevicePixels . .�5+      c� $��Stretch=�6    `� IsLocked .  . .@�5.      �� $
��Copy��6    . 	 � ToolTip	 5/      �� 
 �� RelativeSource
 �� *Self+ �� Path$ Command.Text�.��50      �� $M��G/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Copy32.png��6   $��32��6m    . 6y   51      �� 52      $	��Cut��6    . 	 53      �� 
 �� *Self+$ Command.Text�.��54      �� $L��F/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Cut32.png��6   $��32��6l    . 6x   55      �� 56      $��Paste��6    . 	 57      �� 
 �� *Self+$ Command.Text�.��58      �� $N��H/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Paste32.png��6   $��32��6n    . 6z   59      �� 5:      $��Delete��6    . 	 5;      �� 
 �� *Self+$ Command.Text�.��5<      �� $O��I/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Delete32.png��6   $��32��6o   5=      �� 5>      $��3q�6   �� 5@      $
��Undo��6    . 	 5A      �� 
 �� *Self+$ Command.Text�.��5B      �� $M��G/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Undo32.png��6   $��32��6m   5C      �� 5D      $
��Redo��6    . 	 5E      �� 
 �� *Self+$ Command.Text�.��5F      �� $M��G/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Redo32.png��6   $��32��6m   5G      �� 5H      �� 5I       d� 	IsChecked 6   �� $ 
textEditor��$ WordWrap�.��5J      �� $M��G/Orca.Modules.AvalonEdit;component/Resources/Images/App/Edit_Copy32.png��6   $��16��6m   5K      �� 5L       6   �� $ 
textEditor��$ ShowLineNumbers�.��5M      �� $��16��6     �� TextAlignment$ Center=�6+   #6E   5N      �� 5O       6   �� $ 
textEditor��$ Options.ShowEndOfLine�.��5P      �� $��16��6    $ Center=�6+   ¶6E   5Q      �� 5R      -   5        $��highlightingComboBox��5R       �� SelectedItem 5S      �� *SyntaxHighlighting+$ 
textEditor����5T      �� =  7ICSharpCode.AvalonEdit.Highlighting.HighlightingManager   Instance �� Source# Z $ HighlightingDefinitions�5U      5V      5W      ) 
 #Xceed.Wpf.AvalonDock.DockingManager  5Y   
   -   5          Name$ dockManager��5Y   $   $��2��69      Layout. 5Z      , 
 &Xceed.Wpf.AvalonDock.Layout.LayoutRoot     	RootPanel. 5[      - 
 'Xceed.Wpf.AvalonDock.Layout.LayoutPanel     Orientation$ 
Horizontal=�6)   � 
 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutPanelElement, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 5\      ; 
 5Xceed.Wpf.AvalonDock.Layout.LayoutAnchorablePaneGroup  -   5        LeftAnchorableGroup��� 
 �Xceed.Wpf.AvalonDock.Layout.LayoutPositionableGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutAnchorablePane, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   	DockWidth$	 250 �5\   X   �	 
 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutAnchorablePane, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]] 	  Children. 5]      6
 
 0Xceed.Wpf.AvalonDock.Layout.LayoutAnchorablePane
  � 
 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 5^      2 
 ,Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable  / 
 )Xceed.Wpf.AvalonDock.Layout.LayoutContent   Title$ 
Properties��6:      Content. 5_   "   ��  �� Orientation$ Vertical=�6-   .+�5`   &   �� -   5        $��propertyGridComboBox��5`   /   $	��Top=�6K    �� SelectedIndex$ 0��5a      .@�5b   *   �� .��67   
TextEditor6C   �� 5c   *   .��67   
TextArea6A   �� 5d   *   .��67   	Options6@   5e   '   7  1System.Windows.Forms.Integration.WindowsFormsHost  5f   &      Child. 5g   *   '   !System.Windows.Forms.PropertyGrid  -   5        propertyGrid��5g   =   5h   '   5i   #   5j      5k      5l        5m      $ Vertical=�6-   . 5n        $ 
Horizontal=�61   . 5o      9 
 3Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPaneGroup  -   5        leftDocumentGroup��� 
 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutDocumentPane, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 5p   "   4 
 .Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPane  � 
 �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutContent, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]   Children. 5q   &   0 
 *Xceed.Wpf.AvalonDock.Layout.LayoutDocument  $ My Doc��6@   . 5r   *   '  !ICSharpCode.AvalonEdit.TextEditor  ?
avalonEdit.http://icsharpcode.net/sharpdevelop/avalonedit  5s   )   -	   5        $��
textEditor��5t   )   $��2��5r   @    . $��Consolas)�5u   )       SyntaxHighlightingM  GICSharpCode.AvalonEdit.Highlighting.HighlightingDefinitionTypeConverter$  C# 5v   )   $
��10pt(�5w   )   5x   '   5y   #   5z      5{      5|      5~      5      5�      5�      5�      