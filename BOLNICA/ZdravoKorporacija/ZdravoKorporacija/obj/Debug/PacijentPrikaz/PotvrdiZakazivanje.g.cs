﻿#pragma checksum "..\..\..\PacijentPrikaz\PotvrdiZakazivanje.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9212CF89EFC445D2E05CA74965FA6E543A808FE55A059353CB7EF3E800B10271"
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
    /// PotvrdiZakazivanje
    /// </summary>
    public partial class PotvrdiZakazivanje : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\PacijentPrikaz\PotvrdiZakazivanje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lekar;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\PacijentPrikaz\PotvrdiZakazivanje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock datum;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\PacijentPrikaz\PotvrdiZakazivanje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock vreme;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\PacijentPrikaz\PotvrdiZakazivanje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button potvrdiZakazivanje;
        
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
            System.Uri resourceLocater = new System.Uri("/ZdravoKorporacija;component/pacijentprikaz/potvrdizakazivanje.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PacijentPrikaz\PotvrdiZakazivanje.xaml"
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
            this.lekar = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.datum = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.vreme = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.potvrdiZakazivanje = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\PacijentPrikaz\PotvrdiZakazivanje.xaml"
            this.potvrdiZakazivanje.Click += new System.Windows.RoutedEventHandler(this.potvrdiZakazivanje_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
