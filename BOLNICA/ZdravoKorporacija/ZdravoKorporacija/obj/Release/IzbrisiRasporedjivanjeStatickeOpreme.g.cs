﻿#pragma checksum "..\..\IzbrisiRasporedjivanjeStatickeOpreme.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A4DDF66E0BB855B70746108EE0918D81F924860252E81D3135B6047437398C12"
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
using ZdravoKorporacija;


namespace ZdravoKorporacija {
    
    
    /// <summary>
    /// IzbrisiRasporedjivanjeStatickeOpreme
    /// </summary>
    public partial class IzbrisiRasporedjivanjeStatickeOpreme : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\IzbrisiRasporedjivanjeStatickeOpreme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPotvrdi;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\IzbrisiRasporedjivanjeStatickeOpreme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOdustani;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\IzbrisiRasporedjivanjeStatickeOpreme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerRasporedjenoOd;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\IzbrisiRasporedjivanjeStatickeOpreme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Kolicina;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\IzbrisiRasporedjivanjeStatickeOpreme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbStatickaOprema;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\IzbrisiRasporedjivanjeStatickeOpreme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbProstorija;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\IzbrisiRasporedjivanjeStatickeOpreme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbProstorijaIz;
        
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
            System.Uri resourceLocater = new System.Uri("/ZdravoKorporacija;component/izbrisirasporedjivanjestatickeopreme.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\IzbrisiRasporedjivanjeStatickeOpreme.xaml"
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
            this.btnPotvrdi = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\IzbrisiRasporedjivanjeStatickeOpreme.xaml"
            this.btnPotvrdi.Click += new System.Windows.RoutedEventHandler(this.btnPotvrdi_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnOdustani = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\IzbrisiRasporedjivanjeStatickeOpreme.xaml"
            this.btnOdustani.Click += new System.Windows.RoutedEventHandler(this.btnOdustani_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.datePickerRasporedjenoOd = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.Kolicina = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cmbStatickaOprema = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.cmbProstorija = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.cmbProstorijaIz = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

