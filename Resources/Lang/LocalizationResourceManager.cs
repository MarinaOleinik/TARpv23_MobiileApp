using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TARpv23_MobiileApp.Resources.Lang;

namespace TARpv23_MobiileApp.Resources.Lang
{
    public class LocalizationResourceManager
    {
        public static LocalizationResourceManager Instance { get; } = new();

        public void SetCulture(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }

        public string this[string key] =>
            Resource.ResourceManager.GetString(key, CultureInfo.CurrentUICulture);
    }
}
