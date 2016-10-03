using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using DataAccess;
using Models;

namespace ThreadsOfHistory.Controllers
{
    public class EventsController : Controller
    {
        private readonly IRepository<Event> _repository;

        public EventsController(IRepository<Event> repository)
        {
            _repository = repository;
        }

        // GET: Events
        public async Task<ActionResult> Index()
        {
            return View(await _repository.GetAsync());
        }

        // GET: Events/Details/5
        public async Task<ActionResult> Details(long id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var @event = await _repository.GetAsync(id);
            if (@event == null)
                return HttpNotFound();

            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Description,Scale,StartDate,EndDate")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(@event);
                await _repository.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<ActionResult> Edit(long id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var @event = await _repository.GetAsync(id);
            if (@event == null)
                return HttpNotFound();

            return View(@event);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Description,Scale,StartDate,EndDate")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(@event);
                await _repository.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var @event = await _repository.GetAsync(id);
            if (@event == null)
                return HttpNotFound();

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            var @event = await _repository.GetAsync(id);
            _repository.Remove(@event);
            await _repository.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
