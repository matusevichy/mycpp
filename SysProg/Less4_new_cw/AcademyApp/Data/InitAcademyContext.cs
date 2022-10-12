using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AcademyApp.Model
{
    public class InitAcademyContext: DropCreateDatabaseAlways<AcademyContext>
    {
        protected override void Seed(AcademyContext context)
        {
            context.Students.Add(new Student { Name = "Вася", Age = 21, Email = "vasja@mail.com" });
            context.Students.Add(new Student { Name = "Маша", Age = 19, Email = "masha@mail.com" });
            context.Students.Add(new Student { Name = "Миша", Age = 32, Email = "misha@mail.com" });
            context.Students.Add(new Student { Name = "Вова", Age = 54, Email = "vovan@mail.com" });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
