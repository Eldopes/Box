using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

namespace Box.Helpers
{
    public class Validator
    {
        public static bool Validate(Object obj)
        {
            bool result = false;
            switch (obj.GetType().Name)
            {
                case "Sensor":
                    result = SensorValidation(obj);
                    break;
                case "Indication":
                    result = IndicationValidation(obj);
                    break;
                default:
                    break;
            }            
            return result;
        }

        private static bool SensorValidation(Object obj)
        {
            bool isValid;
            try
            {
                isValid = obj.GetType().GetProperties()
                    .Where(prop => (prop.Name == "Enabled") || (prop.Name == "Name") || (prop.Name == "Scale")) // selects properties with the listed names
                    .All(prop => (prop.GetValue(obj) != null)); // where all of them are not null
            }
            catch (NullReferenceException e)
            {
                isValid = false;
            }
            return isValid;
        }

        private static bool IndicationValidation(Object obj) // TODO: add this 
        {
            bool isValid = obj.GetType().GetProperties()
                    .Where(prop => (prop.Name == "IndicationData") || (prop.Name == "SensorID")) 
                    .All(prop => (prop.GetValue(obj) != null));
            return isValid;
        }
    }
}

