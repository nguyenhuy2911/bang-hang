using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Common.Contract;

namespace Common
{
    public static class Validation
    {
     //   private static ILog log = LogManager.GetLogger(typeof(Validation) );
        public static bool IsValidate<T>(Object objClass, ref ValidationResult validationResult) where T : class
        {
            string trader = string.Empty;
            try
            {
                var attribute = typeof(T);
                var attributeProperties = attribute.GetProperties();

                foreach (var property in attributeProperties)
                {

                    var customAttributes = property.GetCustomAttributes(true);
                    foreach (var itemAttr in customAttributes)
                    {
                        var customAttribute = itemAttr.GetType();
                        if (customAttribute.Equals(typeof(Required)))
                        {
                            var customAttributeObj = (Required)itemAttr;
                            var value = property.GetValue(objClass, null);
                            return customAttributeObj.IsValid(value, ref validationResult);

                        }
                        if (customAttribute.Equals(typeof(IsEmail)))
                        {
                            var customAttributeObj = (IsEmail)itemAttr;
                            var value = property.GetValue(objClass, null);
                            return customAttributeObj.IsValid(value, ref validationResult);

                        }
                        if (customAttribute.Equals(typeof(IsPhoneNumber)))
                        {
                            var customAttributeObj = (IsPhoneNumber)itemAttr;
                            var value = property.GetValue(objClass, null);
                            return customAttributeObj.IsValid(value, ref validationResult);

                        }
                        if (customAttribute.Equals(typeof(IsNumber)))
                        {
                            var customAttributeObj = (IsNumber)itemAttr;
                            var value = property.GetValue(objClass, null);
                            return customAttributeObj.IsValid(value, ref validationResult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

              //  log.Error(ex.ToString() +  trader);
                return false;
            }

            return true;
        }
    }
    abstract public class ValidationBase : Attribute
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        abstract public bool IsValid(object value, ref ValidationResult validationResult);
    }

    public class Required : ValidationBase
    {
        public Required(string errorCode)
        {
            this.ErrorCode = errorCode;
            // this.ErrorMessage = errorMessage;
        }
        public override bool IsValid(object value, ref ValidationResult validationResult)
        {
            bool result = true;
            if (value == null)
                result = false;
            if (string.IsNullOrEmpty(value.ToString()))
                result = false;            
            validationResult = new ValidationResult()
            {
                ErrorCode = this.ErrorCode,
                IsValid = result
            };
            return result;
        }

    }

    public class IsEmail : ValidationBase
    {
        public IsEmail(string errorCode)
        {
            this.ErrorCode = errorCode;
            // this.ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value, ref ValidationResult validationResult)
        {
            
            const string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool result = Regex.IsMatch(value.ToString().Trim(), pattern);
            validationResult = new ValidationResult()
            {
                ErrorCode = this.ErrorCode,
                IsValid = result
            };
            return result;
        }
    }

    public class IsPhoneNumber : ValidationBase
    {
        public IsPhoneNumber(string errorCode)
        {
            this.ErrorCode = errorCode;
            //  this.ErrorMessage = errorMessage;
        }


        public override bool IsValid(object value, ref ValidationResult validationResult)
        {
            bool result = true;
            validationResult = new ValidationResult()
            {
                ErrorCode = this.ErrorCode,
                IsValid = result
            };
            return result;
        }
    }

    public class IsNumber : ValidationBase
    {
        public IsNumber(string errorCode)
        {
            this.ErrorCode = errorCode;
            //   this.ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value, ref ValidationResult validationResult)
        {
            bool result = true;
            validationResult = new ValidationResult()
            {
                ErrorCode = this.ErrorCode,
                IsValid = result
            };
            return result;
        }
    }
}
