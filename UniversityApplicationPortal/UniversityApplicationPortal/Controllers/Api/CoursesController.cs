using System.Linq;
using System.Web.Http;
using UniversityApplicationPortal.Core.Models;
using UniversityApplicationPortal.Persistance;

namespace UniversityApplicationPortal.Controllers.Api
{

    [Authorize]
    
    public class CoursesController : ApiController
    {

        private ApplicationDbContext _context;

        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }


       

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var course = _context.Courses.Single(c => c.Id == id && !c.IsCanceled);
            course.IsCanceled = true;
           // _context.Courses.Remove(course);
            _context.SaveChanges();
            return Ok();
        }
    }
}
