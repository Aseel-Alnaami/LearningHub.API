using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IStdCourseRepository
    {

        List<Stdcourse> GetAllStdCourses();
        Stdcourse GetStdCourseById(int id);
        void CreateStdCourse(Stdcourse stdCourse);
        void UpdateStdCourse(Stdcourse stdCourse);
        void DeleteStdCourse(int id);
    }
}
