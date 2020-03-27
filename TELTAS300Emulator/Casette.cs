using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TELTAS300Emulator
{
    public class Casette : Dictionary<int,SlotStatus>
    {
        public int NumberOfSlots { get; set; }
        public Casette(int numberOfSlots):base(numberOfSlots)
        {
            NumberOfSlots = numberOfSlots;
            Enumerable.Range(0, numberOfSlots).ToList().ForEach(s => Add(s, SlotStatus.NoWafer));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var status in Values)
            {
                sb.Append(GetEnumDescription(status));
            }

            return sb.ToString();
        }

        static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            //DescriptionAttribute[] attributes =
            //    (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            EnumMemberAttribute[] attributes =
                (EnumMemberAttribute[])fi.GetCustomAttributes(typeof(EnumMemberAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Value;
            else
                return ((int)fi.GetValue(null)).ToString();
        }
    }
}
