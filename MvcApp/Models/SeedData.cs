using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcApp.Models;
using System;
using System.Linq;

namespace MvcApp.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationContext>>()))
        {
            context.Teachers.AddRange(
                new Teacher
                {
                    Name = "Цветоков Д. Ю.",
                    Email = "tstvetkovdu@gmail.com"
                },
                new Teacher
                {
                    Name = "Соколов А. С.",
                    Email = "sokolovas@yandex.ru"
                },
                new Teacher
                {
                    Name = "Кокарев С. С.",
                    Email = "kockars@bk.ru"
                }
            );
                context.SaveChanges();
            }
        }
    }
}