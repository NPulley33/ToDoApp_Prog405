using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCToDoWebApp.Models;
using ToDoApp;

namespace MVCToDoWebApp.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDoController

        public static List<ToDoViewModel> Repo { get; set; }

        public ToDoController(IToDoViewModels viewModels) { Repo = viewModels.Repo; }

        public ActionResult Index()
        {
            return View(Repo);
        }

        // GET: ToDoController/Details/5
        public ActionResult Details(int id)
        {
            //return RedirectToAction("Index", "Task", id);
            return View();
        }

        // GET: ToDoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ToDoViewModel t = new ToDoViewModel();
                t.Name = collection["Name"];

                /** add to create under name field if want to add ability to immedietly check off a todo
                //t.IsCompleted = collection["IsCompleted"] != false;
                 *  <div class="form-group form-check">
                <label class="form-check-label">
                    <input class="form-check-input" asp-for="IsCompleted" /> @Html.DisplayNameFor(model => model.IsCompleted)
                </label>
            </div>
                 */

                Repo.Add(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoController/Edit/5
        public ActionResult Edit(int id)
        {
            ToDoViewModel t = Repo.FirstOrDefault(t => t.Id == id);
            return View(t);
        }

        // POST: ToDoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                ToDoViewModel t = Repo.FirstOrDefault(t => t.Id == id);
                t.UpdateName(collection["Name"]);
                t.IsCompleted = collection["IsCompleted"] != false;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoController/Delete/5
        public ActionResult Delete(int id)
        {
            ToDoViewModel t = Repo.FirstOrDefault(t => t.Id == id);
            Repo.Remove(t);
            return RedirectToAction("Index");
        }

        // POST: ToDoController/Delete/5
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
    }
}
