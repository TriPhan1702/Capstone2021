using System.Linq;

namespace HairCutAppAPI.Utilities
{
    public static class ObjectTrimmer
    {
        public static object TrimObject(object obj)
        {
            var stringProperties = obj.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof (string));

            foreach (var stringProperty in stringProperties)
            {
                var currentValue = (string) stringProperty.GetValue(obj, null);
                if (currentValue != null) 
                    stringProperty.SetValue(obj, currentValue.Trim(), null);
            }

            return obj;
        }
    }
}