using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TopicController : Controller
    {
        private readonly ApplicationDBContext _db;

        public TopicController(ApplicationDBContext db)
        {
           _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Topic> objTopicList = _db.Topics;
            return View(objTopicList);
        }
        
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Topic obj)
        {
            /*if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError(
                    "Name", "Такая тема уже существует");
            }*/
            if (ModelState.IsValid)
            {
                _db.Topics.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Тема добавленна";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null && id == 0)
            {
                return NotFound();
            }
            var topic = _db.Topics.Find(id);
            if(topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Topic obj)
        {
           
            if (ModelState.IsValid)
            {
                _db.Topics.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Тема изменена";
                return RedirectToAction("Index");
            }
            return View(obj);


        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            var topic = _db.Topics.Find(id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            var topic = _db.Topics.Find(id);
            if (topic == null)
            {
                return NotFound();
            }

            _db.Topics.Remove(topic);
            _db.SaveChanges();
            TempData["success"] = "Тема удалена";
            return RedirectToAction("Index");

            
          
        }

    }
}
