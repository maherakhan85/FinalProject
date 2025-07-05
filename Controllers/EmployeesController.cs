using Microsoft.AspNetCore.Mvc;
using FinalProject.Services;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly StoreDbContext context;
        private readonly IWebHostEnvironment environment;
        public EmployeesController(StoreDbContext context, IWebHostEnvironment environment)  
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index(string searchTerm)
        {
            // Start with all employees
            var employees = context.Employees.AsQueryable();

            // If there's a search term, filter the employees
            if (!string.IsNullOrEmpty(searchTerm))
            {
                employees = employees.Where(e => e.Fname.Contains(searchTerm) ||
                                                  e.Lname.Contains(searchTerm) ||
                                                  e.EmailId.Contains(searchTerm));
            }

            return View(employees.ToList());
        }
        public IActionResult List(string searchTerm)
        {
            // Starts with all employees
            var employees = context.Employees.AsQueryable();

            // If there's a search term, it filter the employees
            if (!string.IsNullOrEmpty(searchTerm))
            {
                employees = employees.Where(e => e.Fname.Contains(searchTerm) ||
                                                  e.Lname.Contains(searchTerm) ||
                                                  e.EmailId.Contains(searchTerm));
            }

            return View(employees.ToList());
        }
        public IActionResult Create() {
            return View();
                }

        [HttpPost]
        public IActionResult Create(EmployeeDto employeeDto)
        {
            if (employeeDto.ImageFile == null) {
                ModelState.AddModelError("ImageFile", "Image File Required");
            }
            if (!ModelState.IsValid)
            {
                return View(employeeDto);
            }
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(employeeDto.ImageFile!.FileName);
            string imageFullPath = environment.WebRootPath + "/employees/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                employeeDto.ImageFile.CopyTo(stream);
            }
            Employee employee = new Employee() { 
            Fname=employeeDto.Fname,
            Lname=employeeDto.Lname,
            EmailId=employeeDto.EmailId,
            PhoneNumber=employeeDto.PhoneNumber,
            Address=employeeDto.Address,
            JoinDate=employeeDto.JoinDate,
            ImageFileName= newFileName,
            
            };

            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index", "Employees");
        }

        public IActionResult View(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return RedirectToAction("Index", "Employees");
            }

            var employeeDto = new EmployeeDto()
            {
                Fname = employee.Fname,
                Lname = employee.Lname,
                EmailId = employee.EmailId,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                JoinDate = employee.JoinDate,

            };
            ViewData["EmployeeId"] = employee.Id;
            ViewData["ImageFileName"] = employee.ImageFileName;
            ViewData["JoinDate"] = employee.JoinDate;
            return View(employeeDto);
        }
        public IActionResult Edit(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return RedirectToAction("Index", "Employees");
            }

            var employeeDto = new EmployeeDto()
            {
                Fname = employee.Fname,
                Lname = employee.Lname,
                EmailId = employee.EmailId,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                JoinDate=employee.JoinDate,
                
            };
            ViewData["EmployeeId"] = employee.Id;
            ViewData["ImageFileName"] = employee.ImageFileName;
            ViewData["JoinDate"] = employee.JoinDate;
            return View(employeeDto);
        }
        [HttpPost]
        public IActionResult Edit(int id, EmployeeDto employeeDto)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return RedirectToAction("Index", "Employees");
            }
            if (!ModelState.IsValid)
            {
                ViewData["EmployeeId"] = employee.Id;
                ViewData["ImageFileName"] = employee.ImageFileName;
                ViewData["JoinDate"] = employee.JoinDate.ToString("MM/dd/yyyy");
                return View(employeeDto);
            }

            //update image file
            string newFileName = employee.ImageFileName;
            if (employeeDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(employeeDto.ImageFile.FileName);
                string imageFullPath = environment.WebRootPath + "/employees/" + newFileName;
                using(var stream = System.IO.File.Create(imageFullPath))
                {
                    employeeDto.ImageFile.CopyTo(stream);
                }

                //delete old image
                string oldImageFullPath = environment.WebRootPath + "/employees/" + employee.ImageFileName;
                System.IO.File.Delete(oldImageFullPath);
            }
            //update employee detail
            employee.Fname = employeeDto.Fname;
            employee.Lname = employeeDto.Lname;
            employee.EmailId = employeeDto.EmailId;
            employee.PhoneNumber = employeeDto.PhoneNumber;
            employee.Address = employeeDto.Address;
            employee.JoinDate = employeeDto.JoinDate;
            employee.ImageFileName = newFileName;
            context.SaveChanges();
            return RedirectToAction("Index", "Employees");


        }
        public IActionResult Delete(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return RedirectToAction("Index", "Employees");
            }
            string imageFullPath = environment.WebRootPath + "/employees/" + employee.ImageFileName;
            System.IO.File.Delete(imageFullPath);
            context.Employees.Remove(employee);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Employees");
        }
    }
}
