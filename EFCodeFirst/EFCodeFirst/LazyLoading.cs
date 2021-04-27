using System;
using System.Linq;
using System.Threading.Tasks;
using EFCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirst
{
    public class LazyLoading
    {
        private readonly ApplicationContext _context;

        public LazyLoading(ApplicationContext context)
        {
            _context = context;
        }

        public async Task DateDiffs()
        {
            var dateDiffs = await _context.Employees
                .Select(e => EF.Functions.DateDiffDay(e.HiredDate, DateTime.UtcNow))
                .ToListAsync();

            foreach (var diff in dateDiffs)
            {
                Console.WriteLine($"Date diff: {diff} ");
            }
        }

        public async Task UpdateEmployees()
        {
            var employees = await _context.Employees
                .Where(e => e.FirstName.StartsWith("D"))
                .Take(2)
                .ToListAsync();

            foreach (var employee in employees)
            {
                employee.TitleId = 5;
            }

            _context.Employees.UpdateRange(employees);
            await _context.SaveChangesAsync();
        }

        public async Task InsertEmployee()
        {
            var employee = await _context.Employees.AddAsync(new Employee { FirstName = "Frodo", LastName = "Baggins", HiredDate = DateTime.UtcNow, DateOfBirth = new DateTime(1980, 10, 3), OfficeId = 41, TitleId = 8 });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee()
        {
            var employee = await _context.Employees.SingleAsync(e => e.FirstName == "Frodo");
            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();
        }

        public async Task EmployeeGroupByTitle()
        {
            var titles = await _context.Employees
               .GroupBy(t => t.Title.Name)
               .Select(t => t.Key)
               .Where(t => !t.Contains("a"))
               .ToListAsync();

            foreach (var title in titles)
            {
                Console.WriteLine($"Title name: {title} ");
            }
        }
    }
}
