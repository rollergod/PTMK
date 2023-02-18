using PTMK.Data;
using PTMK.Entities;
using PTMK.Entities.Enum;

namespace PTMK
{
    /// <summary>
    /// Класс, для генерации рандомных данных
    /// </summary>
    public static class SeedData
    {
        private static AppDbContext _context = new();

        public static void GenerateData()
        {
            if (_context.People.Count() < 100)
            {
                GenerateRandomData();
                GenerateRandomDataWithF();
            }
        }

        private static void GenerateRandomData()
        {
            Random random = new();
            int numberOfRecords = 1000000;

            string[] initials = new string[32];
            for (int i = 0; i < 32; i++)
            {
                initials[i] = ((char)('А' + i)).ToString();
            }

            for (int i = 0; i < numberOfRecords; i++)
            {
                string fullName = initials[random.Next(initials.Length)] + GenerateRandomLastName() + " " + GenerateRandomFirstName() + " " + GenerateRandomPatronomyc();

                int year = random.Next(1950, 2003);
                int month = random.Next(01, 12);
                int day = random.Next(01, 28);

                DateOnly date = new(year, month, day);

                Array values = Enum.GetValues(typeof(Gender));
                Gender gender = (Gender)values.GetValue(random.Next(values.Length));

                _context.People.Add(new Person
                {
                    FullName = fullName,
                    Date = date,
                    Gender = gender,
                });
            }

            _context.SaveChanges();
        }

        private static void GenerateRandomDataWithF()
        {
            Random random = new();
            int numberOfRecords = 100;
           
            for (int i = 0; i < numberOfRecords; i++)
            {
                string fullName = "F" + GenerateRandomLastName() + " " + GenerateRandomFirstName() + " " + GenerateRandomPatronomyc();

                int year = random.Next(1950, 2003);
                int month = random.Next(01, 12);
                int day = random.Next(01, 28);

                DateOnly date = new(year, month, day);

                Array values = Enum.GetValues(typeof(Gender));
                Gender gender = (Gender)values.GetValue(random.Next(values.Length));

                _context.People.Add(new Person
                {
                    FullName = fullName,
                    Date = date,
                    Gender = gender,
                });
            }
            s
            _context.SaveChanges();
        }

        // Методы для генерации случайного имени / фамилии / отчества
        private static string GenerateRandomLastName()
        {
            string[] names = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов", "Козлов", "Морозов", "Новиков", "Шестаков", "Гаврилов" };
            Random random = new();

            return names[random.Next(names.Length)];
        }

        private static string GenerateRandomFirstName()
        {
            string[] lastnames = { "Иван", "Петр", "Геогрий", "Артем", "Александр", "Евгений", "Илья", "Антон", "Константин", "Валерий" };
            Random random = new();

            return lastnames[random.Next(lastnames.Length)];
        }

        private static string GenerateRandomPatronomyc()
        {
            string[] patronomycs = { "Иванович", "Петрович", "Артемович", "Александрович", "Евгеньевич", "Ильич", "Антонович", "Валерьевич", "Ростиславович", "Гаврилович" };
            Random random = new Random();

            return patronomycs[random.Next(patronomycs.Length)];
        }
    }
}
