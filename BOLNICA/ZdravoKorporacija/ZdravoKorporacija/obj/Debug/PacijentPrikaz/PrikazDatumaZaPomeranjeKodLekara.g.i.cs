﻿#pragma checksum "..\..\..\PacijentPrikaz\PrikazDatumaZaPomeranjeKodLekara.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "47032C4AED077B30149FF7925BB25A16BB3BC34B6A2EE6CB0C80B24BB878CEC9"
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
    /// PrikazDatumaZaPomeranjeKodLekara
    /// </summary>
    public partial class PrikazDatumaZaPomeranjeKodLekara : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\PacijentPrikaz\PrikazDatumaZaPomeranjeKodLekara.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NaslovTabele;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\PacijentPrikaz\PrikazDatumaZaPomeranjeKodLekara.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox slobodniDatumi;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\PacijentPrikaz\PrikazDatumaZaPomeranjeKodLekara.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button vratiSe;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\PacijentPrikaz\PrikazDatumaZaPomeranjeKodLekara.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nastavi;
        
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
            System.Uri resourceLocater = new System.Uri("/ZdravoKorporacija;component/pacijentprikaz/prikazdatumazapomeranjekodlekara.xaml" +
                    "", System.UriKind.Relative);
            
            #line 1 "..\..\..\PacijentPrikaz\PrikazDatumaZaPomeranjeKodLekara.xaml"
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
            this.NaslovTabele = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.slobodniDatumi = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.vratiSe = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\PacijentPrikaz\PrikazDatumaZaPomeranjeKodLekara.xaml"
            this.vratiSe.Click += new System.Windows.RoutedEventHandler(this.vratiSe_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.nastavi = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\PacijentPrikaz\PrikazDatumaZaPomeranjeKodLekara.xaml"
            this.nastavi.Click += new System.Windows.RoutedEventHandler(this.nastavi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

