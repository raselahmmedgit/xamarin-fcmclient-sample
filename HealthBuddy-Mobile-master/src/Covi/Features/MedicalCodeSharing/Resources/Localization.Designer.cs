//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Covi.Features.MedicalCodeSharing.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Localization {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Localization() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Covi.Features.MedicalCodeSharing.Resources.Localization", typeof(Localization).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tap code to copy and send to your patient so as they can change their status.
        /// </summary>
        internal static string MedicalCodeSharing_CodeLabel_Text {
            get {
                return ResourceManager.GetString("MedicalCodeSharing_CodeLabel_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Code generator.
        /// </summary>
        internal static string MedicalCodeSharing_PageName_Text {
            get {
                return ResourceManager.GetString("MedicalCodeSharing_PageName_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SHARE CODE.
        /// </summary>
        internal static string MedicalCodeSharing_ShareBtn_Text {
            get {
                return ResourceManager.GetString("MedicalCodeSharing_ShareBtn_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Share Code.
        /// </summary>
        internal static string MedicalCodeSharing_ShareSystem_TitleText {
            get {
                return ResourceManager.GetString("MedicalCodeSharing_ShareSystem_TitleText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please find your code for the following status:.
        /// </summary>
        internal static string MedicalCodeSharing_Title_Text {
            get {
                return ResourceManager.GetString("MedicalCodeSharing_Title_Text", resourceCulture);
            }
        }
    }
}
