﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarquesaReplenish.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.1.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\172.16.20.6\\Impresion\\Entradas\\ICFES\\@NombrePrueba")]
        public string RutaBaseArchivoSalida {
            get {
                return ((string)(this["RutaBaseArchivoSalida"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ListaTiposPruebas {
            get {
                return ((string)(this["ListaTiposPruebas"]));
            }
            set {
                this["ListaTiposPruebas"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COD_ACTA")]
        public string NombreColumnaActa {
            get {
                return ((string)(this["NombreColumnaActa"]));
            }
            set {
                this["NombreColumnaActa"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COD_CONTENEDOR")]
        public string NombreColumnaContenedor {
            get {
                return ((string)(this["NombreColumnaContenedor"]));
            }
            set {
                this["NombreColumnaContenedor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("TULA_VACIA")]
        public string NombreColumnaTulaVacia {
            get {
                return ((string)(this["NombreColumnaTulaVacia"]));
            }
            set {
                this["NombreColumnaTulaVacia"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CAJA_VACIA")]
        public string NombreColumnaCajaVacia {
            get {
                return ((string)(this["NombreColumnaCajaVacia"]));
            }
            set {
                this["NombreColumnaCajaVacia"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CODIGO_BOLSA")]
        public string NombreColumnaBolsa {
            get {
                return ((string)(this["NombreColumnaBolsa"]));
            }
            set {
                this["NombreColumnaBolsa"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("B")]
        public string PrefijoColmnaBolsa {
            get {
                return ((string)(this["PrefijoColmnaBolsa"]));
            }
            set {
                this["PrefijoColmnaBolsa"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\MarquesaReplenish")]
        public string RutaBaseTemp {
            get {
                return ((string)(this["RutaBaseTemp"]));
            }
            set {
                this["RutaBaseTemp"] = value;
            }
        }
    }
}
