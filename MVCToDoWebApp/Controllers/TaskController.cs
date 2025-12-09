using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCToDoWebApp.Models;

namespace MVCToDoWebApp.Controllers
{
    public class TaskController : Controller
    {
        // GET: TaskConroller
        public ActionResult Index(int id)
        {
            return View(Program.repo.database[0].TaskViewModels);
        }

        // GET: TaskConroller/Details/5
        public ActionResult Details(int id)
        {
            TaskViewModel t = Program.repo.database[0].TaskViewModels.FirstOrDefault(t => t.Id == id);
            return View(t);
        }

        // GET: TaskConroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskConroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string Name = collection["Name"];
                string Description = collection["Description"];
                Program.repo.database[0].AddTask(Name, Description);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskConroller/Edit/5
        public ActionResult Edit(int id)
        {
            TaskViewModel t = Program.repo.database[0].TaskViewModels.FirstOrDefault(t => t.Id == id);
            return View(t);
        }

        // POST: TaskConroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                string Name = collection["Name"];
                string Description = collection["Description"];
                bool completed = collection["IsCompleted"] != false;
                TaskViewModel t = Program.repo.database[0].TaskViewModels.FirstOrDefault(t => t.Id == id);
                t.UpdateName(Name);
                t.UpdateDescription(Description);
                if (completed) t.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskConroller/Delete/5
        public ActionResult Delete(int id)
        {
            TaskViewModel t = Program.repo.database[0].TaskViewModels.FirstOrDefault(t => t.Id == id);
            Program.repo.database[0].TaskViewModels.Remove(t);
            return RedirectToAction("Index");
        }

        // POST: TaskConroller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Back()
        {
            return RedirectToAction("Index", "ToDo");
        }
    }
}
