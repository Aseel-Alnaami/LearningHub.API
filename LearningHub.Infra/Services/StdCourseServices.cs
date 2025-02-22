using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class StdCourseServices:IStdCourseServices
    {
        private readonly IStdCourseRepository _stdCourseRepository;
        public StdCourseServices( IStdCourseRepository stdCourseRepository) {
        _stdCourseRepository = stdCourseRepository;
        }

        public void CreateStdCourse(Stdcourse stdCourse)
        {
            _stdCourseRepository.CreateStdCourse(stdCourse);
        }

        public void DeleteStdCourse(int id)
        {
            _stdCourseRepository.DeleteStdCourse(id);        }

        public List<Stdcourse> GetAllStdCourses()
        {
          return  _stdCourseRepository.GetAllStdCourses();        }

        public Stdcourse GetStdCourseById(int id)
        {
            return _stdCourseRepository.GetStdCourseById(id);        }

        public void UpdateStdCourse(Stdcourse stdCourse)
        {
            _stdCourseRepository.UpdateStdCourse(stdCourse);
        }
    }
}
