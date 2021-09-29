using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project3_FinalExam.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Project3_FinalExam.Services;
using Project3_FinalExam.ViewModels;

namespace Project3_FinalExam.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetAbout _about;
        private readonly IGetFaculty _facultyRepository;
        private readonly IGetStaff _staffRepository;
        private readonly IGetUndergraduate _underGrad;
        private readonly IGetGraduate _Grad;
        private readonly IGetMinors _minor; 
        private readonly IGetResearch _research;
        private readonly IGetEmployment _employment;
        private readonly IGetCoop _coop;

        public HomeController(IGetFaculty facultyRepository, IGetStaff staffRepository)
        {
            _facultyRepository = facultyRepository;
            _staffRepository = staffRepository;
        }
        
        //public HomeController(IGetFaculty facultyRepository, IGetUndergraduate underGrad, IGetGraduate Grad)
        //{
        // _facultyRepository = facultyRepository;
        //  _underGrad = underGrad;
        // _Grad = Grad;

        // }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public async Task<IActionResult> Index()
        {
            var getAbout = new GetAbout();
            var aboutt = await getAbout.Getabout();
            var aboutViewModel = new AboutViewModel()
            {
                about = aboutt,
                Title = "Home Page"
            };
            return View(aboutViewModel);
        }

        public async Task<IActionResult> GetFaculty()
        {
            var allFaculty = await _facultyRepository.GetAllFaculty();
            var sortedFaculty = allFaculty.OrderBy(f => f.username);
            var facultyViewModel = new FacultyViewModel()
            {
                Faculty = allFaculty.ToList(),
                Title = "Faculty"
            };
            return View(facultyViewModel);
        }
        public async Task<IActionResult> GetStaff()
        {
            var allStaff = await _staffRepository.GetAllStaff();
            var sortedFaculty = allStaff.OrderBy(f => f.username);
            var staffViewModel = new StaffViewModel()
            {
                Staff = allStaff.ToList(),
                Title = "Staff"
            };
            return View(staffViewModel);
        }

        public async Task<IActionResult> Under()
        {
            var getUnder = new GetUndergraduate();
            var under = await getUnder.GetUnderGradDegrees();
            var underViewModel = new UndergradViewModel()
            {
                UnderGrads = under,
                Title = "Undergraduate Programs"
            };
            return View(underViewModel);
        }
        public async Task<IActionResult> Grad()
        {
            var getGrad = new GetGraduate();
            var grad = await getGrad.GetGradDegrees();
            var gradViewModel = new GradViewModel()
            {
                Grads = grad,
                Title = "Graduate Programs"
            };
            return View(gradViewModel);
        }
        public async Task<IActionResult> Minors()
        {
            var getMinors = new GetMinors();
            var minorss = await getMinors.Getminors();
            var minorsViewModel = new MinorsViewModel()
            {
                minors = minorss,
                Title = "Minors"
            };
            return View(minorsViewModel);

        }
        public async Task<IActionResult> Employment()
        {
            var getEmployment = new GetEmployment();
            var emp = await getEmployment.Getemployment();
            var employmentViewModel = new EmploymentViewModel()
            {
                Employment = emp,
                Title = "Employment"
            };
            return View(employmentViewModel);

        }
        public async Task<IActionResult> Coop()
        {
            var getCoop = new GetCoop();
            var c = await getCoop.Getcoop();
            var coopViewModel = new CoopViewModel()
            {
                Coop = c,
                Title = "Co-op"
            };
            return View(coopViewModel);

        }
        public async Task<IActionResult> Research()
        {
            var getResearch = new GetResearch();
            var researchh = await getResearch.Research();
            var researchViewModel = new ResearchViewModel()
            {
                Research = researchh,
                Title = "Research"

            };
            return View(researchViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
