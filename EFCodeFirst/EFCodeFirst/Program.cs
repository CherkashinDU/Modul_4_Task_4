using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFCodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCodeFirst
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new ContextFactory().CreateDbContext(args))
            {
                await new LazyLoading(context).DateDiffs();
            }

            await using (var context = new ContextFactory().CreateDbContext(args))
            {
                await new LazyLoading(context).UpdateEmployees();
            }

            await using (var context = new ContextFactory().CreateDbContext(args))
            {
                await new LazyLoading(context).InsertEmployee();
            }

            await using (var context = new ContextFactory().CreateDbContext(args))
            {
                await new LazyLoading(context).DeleteEmployee();
            }

            await using (var context = new ContextFactory().CreateDbContext(args))
            {
                await new LazyLoading(context).EmployeeGroupByTitle();
            }
        }
    }
}
