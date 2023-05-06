using LernsiegDatabase.Entities;

namespace LernsiegDatabase;

public static class DatabaseSeeder
{
    public static void Seed(LernsiegContext context)
    {
        SeedSchools(context);
        SeedTeachers(context);
        context.SaveChanges();
    }

    private static void SeedSchools(LernsiegContext context)
    {
        foreach (var line in File
                     .ReadLines("CSVs/schools.csv")
                     .Select(x => x.Split(";")))
        {
            context.Schools.Add(new School
            {
                SchoolNumber = Convert.ToInt32(line[0]),
                Name = line[1],
                Address = line[2]
            });
        }
    }

    private static void SeedTeachers(LernsiegContext context)
    {
        foreach (var line in File
                     .ReadLines("CSVs/teachers.csv")
                     .Skip(1)
                     .Select(x => x.Split(";")))
        {
            context.Teachers.Add(new Teacher
            {
                Name = line[0],
                Title = line[1],
                SchoolId = Convert.ToInt32(line[2])
            });
        }
    }
}
