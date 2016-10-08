using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using DataAccess;
using Models;

namespace ThreadsOfHistory.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IRepository<Person> _context;

        public PeopleController(IRepository<Person> context)
        {
            _context = context;
        }

        // GET: People
        public async Task<ActionResult> Index()
        {
            return View(await _context.GetAsync());
        }

        // GET: People/Details/5
        public async Task<ActionResult> Details(long id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var person = await _context.GetAsync(id);
            if (person == null)
                return HttpNotFound();
            
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FirstName,MiddleName,LastName,Born,Died,CountryId")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public async Task<ActionResult> Edit(long id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var person = await _context.GetAsync(id);
            if (person == null)
                return HttpNotFound();
            
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,Born,Died,CountryId")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Update(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var person = await _context.GetAsync(id);
            if (person == null)
                return HttpNotFound();
            
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            var person = await _context.GetAsync(id);
            _context.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
