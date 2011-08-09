using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cjrCommon.Extensions
{
#pragma warning disable 1591
    public static class EdiMessagingExtensions
    {
        public static string PrintAll<T>(this IEnumerable<T> items) 
        {
            if (items == null) return string.Empty;
            var result = new StringBuilder();
            items.ToList().ForEach(x => result.Append(x + Environment.NewLine));
            return result.ToString();
        }

        public static bool IsShipToAddress(this Address address)
        {
            if (address == null) return false;
            return address.AddressType == AddressType.ShipTo.GetEDIValue();
        }

        public static bool IsBillToAddress(this Address address)
        {
            if (address == null) return false;
            return address.AddressType == AddressType.BillTo.GetEDIValue();
        }

        public static bool IsShipFromAddress(this Address address)
        {
            if (address == null) return false;
            return address.AddressType == AddressType.ShipFrom.GetEDIValue();
        }
    }
}