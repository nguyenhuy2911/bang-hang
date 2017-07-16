using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Common
{
    public class StringMenthod
    {
        public static string friendly_urlSEO(string unicodeString)
        {
            try
            {
                //Remove VietNamese character                 
                unicodeString = unicodeString.ToLower();
                unicodeString = Regex.Replace(unicodeString, "[áàảãạâấầẩẫậăắằẳẵặ]", "a");
                unicodeString = Regex.Replace(unicodeString, "[éèẻẽẹêếềểễệ]", "e");
                unicodeString = Regex.Replace(unicodeString, "[iíìỉĩị]", "i");
                unicodeString = Regex.Replace(unicodeString, "[óòỏõọơớờởỡợôốồổỗộ]", "o");
                unicodeString = Regex.Replace(unicodeString, "[úùủũụưứừửữự]", "u");
                unicodeString = Regex.Replace(unicodeString, "[yýỳỷỹỵ]", "y");
                unicodeString = Regex.Replace(unicodeString, "[đ]", "d");

                //Remove space                 
                unicodeString = unicodeString.Replace(" ", "-");

                //Remove more
                unicodeString = unicodeString.Replace(":", "");

                //Remove special character                 
                unicodeString = Regex.Replace(unicodeString, "[`~!@#$%^&*()-+=?/>.<,{}[]|]\\]", "");

                return unicodeString;
            }
            catch (Exception)
            {
                return "";
            }
        }

        
    }
}