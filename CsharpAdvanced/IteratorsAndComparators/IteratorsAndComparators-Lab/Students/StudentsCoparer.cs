using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
    class StudentsCoparer: IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {

            
            
                return x.Grade.CompareTo(y.Grade);
            
        }
    }
}
