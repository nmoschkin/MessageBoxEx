using DataTools.MessageBoxEx.Resources;

using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace DataTools.MessageBoxEx
{
    /// <summary>
    /// Class to customize the localization of system message box types.
    ///
    /// This class is indexed by <see cref="MessageBoxExResult" /> values mapped to resource keys.
    /// See the <see cref="this[MessageBoxExResult]">Indexer</see> help page for more information.
    /// </summary>
    public class ResourceTextConfig
    {
        private CultureInfo ci = null;

        /// <summary>
        /// Gets the current Resource type name string.
        /// </summary>
        public string ResourceTypeName { get; private set; }

        internal NameValueCollection ResourceKeys { get; private set; }

        private ResourceManager ResMgr;

        public ResourceTextConfig() : this(typeof(AppResources).FullName, Assembly.GetAssembly(typeof(AppResources)))
        {
        }

        /// <summary>
        /// Create a new instance of <see cref="ResourceTextConfig" />
        /// </summary>
        /// <param name="resourceTypeName">The fully qualified type name of the resource class.</param>
        /// <param name="assembly">The assembly that contains the resource class.</param>
        /// <param name="cultureInfo">CultureInfo to reference when rendering a string.</param>
        public ResourceTextConfig(string resourceTypeName, Assembly assembly, CultureInfo cultureInfo = null)
        {
            ResourceTypeName = resourceTypeName;
            ResMgr = new ResourceManager(ResourceTypeName, assembly);
            ci = cultureInfo ?? Application.CurrentCulture;

            GenerateResourceKeys();
        }

        /// <summary>
        /// Gets or sets the CultureInfo associated with this instance.
        /// </summary>
        public CultureInfo CultureInfo
        {
            get => ci;
            set => ci = value;
        }

        /// <summary>
        /// Gets or sets the resource key to use for the specified index.
        ///
        /// For localization, each member of <see cref="MessageBoxExResult"/> has a
        /// default resource key associated with it.  Use this indexer to set a different value.
        /// </summary>
        /// <param name="index"><see cref="MessageBoxExResult"/> enumeration value</param>
        /// <returns>A string representing a resource key</returns>
        public string this[MessageBoxExResult index]
        {
            get
            {
                string s = index.ToString();
                return ResourceKeys[s];
            }
            set
            {
                string s = index.ToString();
                ResourceKeys[s] = value;
            }
        }

        private void GenerateResourceKeys()
        {
            NameValueCollection lOut = new NameValueCollection();

            FieldInfo[] fields = typeof(MessageBoxExResult).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            foreach (var field in fields)
            {
                if (field.Name == "value__") continue;
                lOut.Add(field.Name, field.Name);
            }

            ResourceKeys = lOut;
        }

        /// <summary>
        /// Gets the localized resource text for the specified index.
        /// </summary>
        /// <param name="index">MessageBoxExResult enumeration value</param>
        /// <returns></returns>
        public string GetText(MessageBoxExResult index)
        {
            var s = index.ToString();
            return ProvideValue(ResourceKeys[s]);
        }

        private string ProvideValue(string resourceKey)
        {
            if (resourceKey == null)
                return string.Empty;

            string translation = null;

            try
            {
                translation = ResMgr.GetString(resourceKey, ci);
            }
            catch
            {
                try
                {
                    translation = ResMgr.GetString(resourceKey, new CultureInfo("en")); // default to English
                }
                catch
                {
                    translation = "bad translation for " + resourceKey;
                }
            }

            if (translation == null)
            {
                ArgumentException ex = new ArgumentException(
                    string.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", resourceKey, ResourceTypeName, ci.Name),
                    "Text");
#if DEBUG
                throw ex;
#else
                try
                {
                    translation = ResMgr.GetString(resourceKey, new CultureInfo("en")); // default to English
                }
                catch
                {
                    translation = resourceKey; // HACK: returns the key, which GETS DISPLAYED TO THE USER
                }
#endif
            }
            return translation;
        }
    }
}