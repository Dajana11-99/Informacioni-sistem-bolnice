﻿#pragma checksum "..\..\..\PacijentPrikaz\ZakazivanjeSaPrioritetom.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "52813A48EE0A5E1942CAFCF8573FBBC1BC02B75E0EB038B5E2607FBD782E11A7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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
using ZdravoKorporacija.PacijentPrikaz;


namespace ZdravoKorporacija.PacijentPrikaz {
    
    
    /// <summary>
    /// ZakazivanjeSaPrioritetom
    /// </summary>
    public partial class ZakazivanjeSaPrioritetom : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\PacijentPrikaz\ZakazivanjeSaPrioritetom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox lekar;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\PacijentPrikaz\ZakazivanjeSaPrioritetom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datumOd;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\PacijentPrikaz\ZakazivanjeSaPrioritetom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datumDo;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\PacijentPrikaz\ZakazivanjeSaPrioritetom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox prioritet;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\PacijentPrikaz\ZakazivanjeSaPrioritetom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button prikaziDatume;
        
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
            System.Uri resourceLocater = new System.Uri("/ZdravoKorporacija;component/pacijentprikaz/zakazivanjesaprioritetom.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PacijentPrikaz\ZakazivanjeSaPrioritetom.xaml"
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
            this.lekar = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.datumOd = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.datumDo = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.prioritet = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.prikaziDatume = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\PacijentPrikaz\ZakazivanjeSaPrioritetom.xaml"
            this.prikaziDatume.Click += new System.Windows.RoutedEventHandler(this.prikaziDatume_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
