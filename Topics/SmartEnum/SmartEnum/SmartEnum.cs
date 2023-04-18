using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartEnum
{
    internal abstract class SmartEnum<TEnum, TValue> where TEnum : SmartEnum<TEnum, TValue>
    {
        private static ConcurrentDictionary<TValue, TEnum> _enum
            = new ConcurrentDictionary<TValue, TEnum>();

        public TValue Value { get; set; }
        public string Name { get; set; }
        public SmartEnum(TValue value, string name)
        {
            Value = value;
            Name = name;
        }
        static SmartEnum()
        {
            // Automatically register all enum values
            foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var item = (TEnum)field.GetValue(null);
                Register(item);
            }
        }
        protected static TEnum Register(TEnum item)
        {
            return _enum.GetOrAdd(item.Value, item);
        }
        public static TEnum FromValue(TValue value)
        {
            return _enum[value];
        }

        public static bool TryFromValue(TValue value, out TEnum result)
        {
            return _enum.TryGetValue(value, out result);
        }

        public static IEnumerable<TEnum> GetAll()
        {
            return _enum.Values;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
