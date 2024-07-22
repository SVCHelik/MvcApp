using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.UchGroupes.ToListAsync());
        }
        public IActionResult Create()
        {
            var teachersList = db.Teachers.Select(x => new { x.Id, x.Name }).ToList();
            ViewBag.TeachersList = new SelectList(teachersList, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UchGroupe user)
        {
            var teacher = db.Teachers.Find(int.Parse(user.Teacher_name));
            user.Teacher_name = teacher.Name;
            user.TeacherId = teacher.Id;
            db.UchGroupes.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                UchGroupe user = new UchGroupe { Id = id.Value };
                db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                UchGroupe? user = await db.UchGroupes.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null) return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string Name)
        {
            UchGroupe? user = await db.UchGroupes.FindAsync(id);

            if (user != null)
            {
                user.Name = Name;

                db.UchGroupes.Update(user);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return NotFound();
        }
        public async Task<IActionResult> AddStudent(int? id)
        {
            UchGroupe? user = await db.UchGroupes.FindAsync(id);
            if (user != null)
            {
                var organisationList = db.Organisations.Where(x => x.TeacherId == user.TeacherId);
                var organListTrue = organisationList.Select(x => new { x.Id, x.Name }).ToList();
                ViewBag.OrganisationsList = new SelectList(organListTrue, "Id", "Name");
                foreach (var organisation in organisationList)
                {
                    foreach (var student in organisation.Students)
                    {
                        user.Students.Add(student);
                    }
                }

            }
            return View(user);
        }
        [HttpPost]
        public IActionResult AddStudent(int organisationId)
        {
            var student = db.Students.Select(x => x.OrganisationId == organisationId).ToList();
            return Json(student);
        }
    }
}