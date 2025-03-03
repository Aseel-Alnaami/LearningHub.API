﻿using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface ICourseRepository
    {
        //LIST GetAllCourses

        List<Course> GetAllCourses();
//Course bec ana rah ab3et col el data, and we dont return any thing so we use void .
        void CreateCourse(Course course);
        //AbandonedMutexException here the same thing 
        void UpdateCourse(Course course);

        void DeleteCourse(int id);
        Course GetCourseById(int id); // Should return a Course instead of void

    }
}
