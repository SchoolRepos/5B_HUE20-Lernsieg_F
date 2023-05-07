using LernsiegDatabase.Entities;

namespace LernsiegDatabase;

public static class DatabaseSeeder
{
    private static readonly string[] SchoolCriteriaDescriptions =
    {
        "Klassenzimmer",
        "Lehrangebot",
        "Stimmung",
        "Motivationsfähigkeit",
        "Sportanlage",
        "Mensa oder Kantine",
        "Supplierungen",
        "Bibliothek",
        "Sauberkeit",
        "Neue Medien",
        "Veranstaltungen",
        "Fridays for Future"
    };

    private static readonly string[] TeacherCriteriaDescriptions =
    {
        "Unterricht",
        "Fairness",
        "Respekt",
        "Motivationsfähigkeit",
        "Geduld",
        "Vorbereitung",
        "Durchsetzungsfähigkeit",
        "Pünktlichkeit"
    };

    private const int NumberOfEvaluations = 1_000;

    public static void Seed(LernsiegContext context)
    {
        SeedSchools(context);
        SeedTeachers(context);
        SeedCriterias(context);
        SeedEvaluations(context);
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

    private static void SeedCriterias(LernsiegContext context)
    {
        var schoolCriterias = SchoolCriteriaDescriptions
            .Select((description, index) =>
                new Criteria
                {
                    EvaluationType = 1,
                    Description = description,
                    SequenceNr = index + 1
                });

        var teacherCriterias = TeacherCriteriaDescriptions
            .Select((description, index) =>
                new Criteria
                {
                    EvaluationType = 2,
                    Description = description,
                    SequenceNr = index + 1
                });

        context.Criterias.AddRange(schoolCriterias);
        context.Criterias.AddRange(teacherCriterias);
    }

    private static void SeedEvaluations(LernsiegContext context)
    {
        var random = new Random(NumberOfEvaluations); // seeded to make it always produce the same output
        
        for (var i = 0; i < NumberOfEvaluations; i++)
        {
            var isSchool = random.NextSingle() > 0.5;

            var targetIds = isSchool
                ? context.Schools.Select(x => x.Id)
                : context.Teachers.Select(x => x.Id);

            var targetLengths = targetIds.Count();

            var targetId = targetIds
                .OrderBy(x => x)
                .Skip((int)(random.NextSingle() * targetLengths))
                .First();

            var evaluationItems = context.Criterias
                .Where(x => x.EvaluationType == (isSchool ? 1 : 2))
                .Select(criteria => new EvaluationItem
                {
                    Criteria = criteria,
                    Value = random.Next() % 5 + 1
                });

            context.Evaluations.Add(new Evaluation
            {
                EvaluationType = isSchool ? 1 : 2,
                PhoneNr = "+" + random.NextInt64(),
                SchoolOrTeacherId = targetId,
                EvaluationItems = evaluationItems.ToList()
            });
        }
    }
}
