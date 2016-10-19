using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    public enum ObjectStatus
    {
        Vip,Ordinar,Looser
    }
  [AttributeUsage(AttributeTargets.Class,Inherited=false,AllowMultiple=false)]
    class StatusAttribute:Attribute
    {
        public ObjectStatus Status { get; set; }
        public bool IsSecret { get; set; }
        public StatusAttribute(ObjectStatus status)
        {
            Status = status;
            //IsSecret = false;
        }
        //public StatusAttribute()
        //{

        //}
    }
}
