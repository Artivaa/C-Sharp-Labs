using System.Collections.Generic;

namespace Labs.Labs.Lab10
{
    public class SortByEmployeeCount : IComparer<Organization>
    {
        public int Compare(Organization x, Organization y)
        {
            if (x == null || y == null)
                return 0;
            if (x.EmployeeCount > y.EmployeeCount)
                return 1;
            if (x.EmployeeCount < y.EmployeeCount)
                return -1;
            return 0;
        }
    }
}
