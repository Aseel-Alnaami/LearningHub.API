using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface ICourseServices
    {// ANY  busness logic code && l7ta nkhaly coll el function tshofum el UI 

        List<Course> GetAllCourses();
        //Course bec ana rah ab3et col el data, and we dont return any thing so we use void .
        void CreateCourse(Course course);
        //AbandonedMutexException here the same thing 
        void UpdateCourse(Course course);

        void DeleteCourse(int id);
        Course GetCourseById(int id); // Should return a Course instead of void

    }
}
