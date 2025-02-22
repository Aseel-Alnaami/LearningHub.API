using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using LearningHub.Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;




namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        //the controller is beakhed el request from clent side and handel it and then send the requet to the clent side 
        //is inject from service leayre
        private readonly ICourseServices courseServices;
        private CourseController(ICourseServices courseServices)
        {
            this.courseServices = courseServices;
        }


        [HttpGet]
        public List<Course> GetAllCourses()
        {
            return courseServices.GetAllCourses();
        }

        [HttpGet]
        [Route("getbyId/{id}")]// bec its the second get method
        public Course GetCourseById(int id)
        {
            return courseServices.GetCourseById(id);
        }

        [HttpPost]
        public void CreateCourse(Course course)
        {
            courseServices.CreateCourse(course);
        }
        [HttpPut]// update from bode
        public void UpdateCourse(Course course)
        {
            courseServices.UpdateCourse(course);
        }

        [HttpDelete]// from Url
        [Route("DeleteCourse/{id}")]
        public void DeleteCourse(int id)
        {
            courseServices.DeleteCourse(id);
        }
        [HttpPost]
        [Route("uploadImage")]
        public Course UploadImage()
        {
            var file =Request.Form.Files[0];
            var fileName=Guid.NewGuid().ToString()+"_"+file.FileName;
            var fullPath=Path.Combine("Images",fileName);

            using (var stream =new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            Course item = new Course();
            item.Imagename = fileName;
            return item;    
        }

    }


    //    }
    //    PROCEDURE TotalStudentInEachCourse

    //As

    //C_all SYS_REFCURSOR ;

    //Begin

    //open C_all for 

    //select c.coursename , count(s.studentid) as StudentCount

    //from stdcourse sc

    //full outer join student s

    //on s.studentid = sc.stdid

    //full outer join course c

    //on c.courseid = sc.courseid

    //group by c.coursename ;

    //    Dbms_sql.return_result(c_all);

    //End TotalStudentInEachCourse;




    //2
    /*
     
     procedure SearchCourseStudent(StdName in varchar , cName in varchar , Datefrom in date , dateto in date )

as 

C_all SYS_REFCURSOR ;

begin 

open C_all for select std.FirstName , std.LastName , c.CourseName , sdtc.Markofstd 

from student std 

inner join stdcourse sdtc 

on std.studentid = sdtc.STDID 

inner join course c

on sdtc.courseid = c.courseid 

where (upper(std.firstname) like '%'|| upper(StdName)||'%')--

and (upper(c.CourseName) like '%'||upper(cName)||'%')--

and ( sdtc.DATEOFREGISTER BETWEEN Datefrom and dateto OR datefrom is  null or dateto is null ) ;--datefrom :17-02-2022 

Dbms_sql.return_result(c_all);
 
end SearchCourseStudent;

 
     */
}
