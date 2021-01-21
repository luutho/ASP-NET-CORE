using MISA.CukCuk.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.ApplicationCore.Entities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate:Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey:Attribute
    {

    }

    public class BaseEntity
    {
        public EntityState EntityState { get; set; } = EntityState.AddNew;
        public DateTime CreatedDate { get; set; }

        public string Createdby { get; set; }

        public DateTime? ModifyDate { get; set; }

        public string ModifyBy { get; set; }
    }
}
