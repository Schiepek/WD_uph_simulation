﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UPH_Simulation_Model.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UPH_Simulation_Model.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;assemblyline xmlns=&quot;http://wdth.wdc.com/uph_simulation&quot;&gt;
        ///	&lt;name&gt;requirement&lt;/name&gt;
        ///	
        ///	&lt;assemblylineitem&gt;
        ///		&lt;name&gt;autostacker&lt;/name&gt;
        ///		&lt;position&gt;
        ///			&lt;name&gt;aZ1&lt;/name&gt;
        ///			&lt;type&gt;buffer&lt;/type&gt;
        ///			&lt;time&gt;2&lt;/time&gt;
        ///		&lt;/position&gt;
        ///		&lt;position&gt;
        ///			&lt;name&gt;aT1&lt;/name&gt;
        ///			&lt;type&gt;transfer&lt;/type&gt;
        ///			&lt;time&gt;1&lt;/time&gt;
        ///		&lt;/position&gt;
        ///		&lt;position&gt;
        ///			&lt;name&gt;aZ2&lt;/name&gt;
        ///			&lt;type&gt;work&lt;/type&gt;
        ///			&lt;time&gt;4&lt;/time&gt;
        ///		&lt;/position&gt;
        ///		&lt;position&gt;
        ///			&lt;name&gt;aT2&lt;/name&gt;
        ///			&lt;type&gt;transfer&lt;/t [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string requirementsSampleLine {
            get {
                return ResourceManager.GetString("requirementsSampleLine", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;xs:schema xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;
        ///           elementFormDefault=&quot;qualified&quot;
        ///           attributeFormDefault=&quot;unqualified&quot;
        ///           targetNamespace=&quot;http://wdth.wdc.com/uph_simulation&quot;&gt;
        ///  &lt;xs:element name=&quot;assemblyline&quot;&gt;
        ///    &lt;xs:complexType&gt;
        ///      &lt;xs:sequence&gt;
        ///        &lt;xs:element name=&quot;name&quot; minOccurs=&quot;1&quot;  maxOccurs=&quot;1&quot;&gt;
        ///          &lt;xs:simpleType&gt;
        ///            &lt;xs:restriction base=&quot;xs:string&quot;&gt;
        ///              &lt;xs:maxLength value=&quot;30&quot;/&gt;
        ///              &lt;xs:pattern value=&quot;^[a-zA-Z0 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string uphschema {
            get {
                return ResourceManager.GetString("uphschema", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to http://wdth.wdc.com/uph_simulation.
        /// </summary>
        internal static string xmlNamespace {
            get {
                return ResourceManager.GetString("xmlNamespace", resourceCulture);
            }
        }
    }
}
