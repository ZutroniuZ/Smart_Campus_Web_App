using Microsoft.AspNetCore.Mvc;
using Smart_Campus_Web_App.Data;
using Smart_Campus_Web_App.Models;
using System.Linq;

namespace Smart_Campus_Web_App.Controllers
{
    public class SOSController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SOSController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ReportIncident(IncidentReports report)
        {
            if (ModelState.IsValid) 
            {
                var rep = new IncidentReports
                {
                    Description = report.Description,
                    Type = report.Type,
                    Location = report.Location,
                    ReportedAt = DateTime.Now,
                };
                
                //report.ReportedAt = DateTime.Now;
                _context.IncidentReport.Add(rep);
                _context.SaveChanges();
                return RedirectToAction("Reports");
            }
            return View(report);
        }

        public IActionResult Reports()
        {
            var reports = _context.IncidentReport.ToList();
            return View(reports);
        }

        public IActionResult SOS()
        {
            return View();
        }
    }
}
