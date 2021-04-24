using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitAssignment8
{
    public class OrderedTestAttribute : Attribute
    {
        public int Order { get; set; }

        public OrderedTestAttribute(int order)
        {
            this.Order = order;
        }
    }
}
