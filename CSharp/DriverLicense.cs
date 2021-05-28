using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CSharp
{
    public static class DriverLicense
    {
        /// <summary>
        /// Consider this list of formats: https://ntsi.com/drivers-license-format/
        /// Validate Driver's license number, implement Nebraska and Mississippi in an expandable way to eventually handle all US states.
        /// Fail validation if unexpected data is passed in.
        /// Nebraska: 1Alpha+6-8Numeric
        /// Mississippi: 9Numeric
        /// </summary>
        /// <param name="licenseNumber"></param>
        /// <param name="stateCode"></param>
        /// <returns></returns>
        public static bool Validate(string licenseNumber, string stateCode)
        {
            string strLicenseFormat = "";

            if (stateCode == "NE") strLicenseFormat = "1Alpha+6-8Numeric";
            else if (stateCode == "MS") strLicenseFormat = "9Numeric";
            else if (stateCode == "CO") strLicenseFormat = "9Numeric or 1Alpha+3-6Numeric or 2Alpha+2-5Numeric";
            else
            {
                // other states not implemented yet
                return false;
            }

            //Parse the format into an array as some states have multiple formats (separated by " or ")
            strLicenseFormat = strLicenseFormat.Replace(" or ", "|");
            strLicenseFormat = strLicenseFormat.Replace(" ", ""); //remove spaces (if any)
            string[] strFormatArray = strLicenseFormat.Split("|".ToCharArray());
            string strRegexPattern;
            foreach (string strFormat in strFormatArray)
            {
                string[] strSegmentArray = strFormat.Split("+".ToCharArray());
                strRegexPattern = "";
                foreach (string strSegment in strSegmentArray)
                {
                    if (strSegment.Contains("Alpha")) strRegexPattern += "[A-Za-z]{" + strSegment.Replace("Alpha", "").Replace("-",",") + "}";
                    else if (strSegment.Contains("Numeric")) strRegexPattern += "[0-9]{" + strSegment.Replace("Numeric", "").Replace("-", ",") + "}";
                    else { return false; } //invalid format string 

                }
                strRegexPattern = "^" + strRegexPattern + "$"; //check the entire string
                if (Regex.IsMatch(licenseNumber, strRegexPattern)) return true;
            }

            // at this point, the string failed to match a pattern
            return false;
        }
    }
}
