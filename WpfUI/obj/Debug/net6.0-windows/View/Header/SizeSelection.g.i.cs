﻿#pragma checksum "..\..\..\..\..\View\Header\SizeSelection.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BD0F18CB85C0E5338C23E6A06351463BEA230F22"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
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
using WpfUI.View.Header;


namespace WpfUI.View.Header {
    
    
    /// <summary>
    /// SizeSelection
    /// </summary>
    public partial class SizeSelection : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\View\Header\SizeSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSizeAuto;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\View\Header\SizeSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSizeKB;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\View\Header\SizeSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSizeMB;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\View\Header\SizeSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSizeGB;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfUI;V1.0.0.0;component/view/header/sizeselection.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Header\SizeSelection.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ButtonSizeAuto = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\..\View\Header\SizeSelection.xaml"
            this.ButtonSizeAuto.Click += new System.Windows.RoutedEventHandler(this.Button_Size_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ButtonSizeKB = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\..\View\Header\SizeSelection.xaml"
            this.ButtonSizeKB.Click += new System.Windows.RoutedEventHandler(this.Button_Size_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ButtonSizeMB = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\..\View\Header\SizeSelection.xaml"
            this.ButtonSizeMB.Click += new System.Windows.RoutedEventHandler(this.Button_Size_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonSizeGB = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\..\View\Header\SizeSelection.xaml"
            this.ButtonSizeGB.Click += new System.Windows.RoutedEventHandler(this.Button_Size_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
