using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace IClockTest.Struct
{
    public struct BusinessDate : IFormattable, IEquatable<BusinessDate>, IComparable<BusinessDate>, IXmlSerializable
    {
        public DateTime Date
        {
            get;
            private set;
        }

        public BusinessDate(DateTime d)
        {
            Date = d;
        }

        public int CompareTo(BusinessDate other)
        {
            return Date.CompareTo(other.Date);
        }

        public bool Equals(BusinessDate other)
        {
            return other.Date == Date;
        }

        public override bool Equals(Object other)
        {
            return (other is BusinessDate otherObj) && Equals(otherObj);
        }

        public override int GetHashCode()
        {
            return Date.GetHashCode();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            this = new BusinessDate(DateTime.Parse(reader.Value, CultureInfo.InvariantCulture));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Date.ToString(format, formatProvider);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(this.Date.ToString(CultureInfo.InvariantCulture));
        }
    }
}
