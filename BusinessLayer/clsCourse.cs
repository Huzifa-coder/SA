using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsCourse
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;

        public int CourseID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }

        public string DurationString { get
            {
                if(Duration == 15)
                {
                    return Duration + " Days";
                }
                else
                {
                    return Duration + " Month";
                }
            }
        }

        public int Fees { get; set; }

        public clsCourse()
        {
            CourseID = 0;
            Name = string.Empty;
            Duration = 0;
            Fees = 0;

            _Mode = enMode.Add;
        }

        public clsCourse(int courseID, string name, int duration, int fees)
        {
            CourseID = courseID;
            Name = name;
            Duration = duration;
            Fees = fees;

            _Mode = enMode.Update;
        }

        static public clsCourse Find(int courseID)
        {
            string name = string.Empty;
            int duration = 0;
            int fees = 0;

            if (clsCourseData.GetCourse(courseID, ref name, ref duration, ref fees))
            {
                return new clsCourse(courseID, name, duration, fees);
            }

            return null;
        }

        static public clsCourse Find(string CourseName)
        {
            int courseID = -1;
            int duration = 0;
            int fees = 0;

            if (clsCourseData.GetCourse(CourseName, ref courseID, ref duration, ref fees))
            {
                return new clsCourse(courseID, CourseName, duration, fees);
            }

            return null;
        }

        static public bool IsExist(int courseID)
        {
            return clsCourseData.IsExist(courseID);
        }

        static public bool Delete(int courseID)
        {
            return clsCourseData.DeleteCourse(courseID);
        }

        static public DataTable GetCourses()
        {
            return clsCourseData.GetCourses();
        }

        // Add New Course Info
        private bool _Add()
        {
            int resultCourseID = clsCourseData.AddNewCourse(Name, Duration, Fees);

            if (resultCourseID > 0)
            {
                this.CourseID = resultCourseID;
                return true;
            }

            return false;
        }

        // Update Course Info
        private bool _Update()
        {
            return clsCourseData.UpdateCourseInfo(CourseID, Name, Duration, Fees);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_Add())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();
            }

            return false;
        }
    }

}
