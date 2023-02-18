using PTMK.Entities;
using PTMK.Entities.Enum;

namespace PTMK.Helpers
{
    /// <summary>
    /// Класс, для работы с консолью
    /// </summary>
    public static class MenuHelper
    {
        public static int ShowMenu()
        {
            int selectedValue;

            Console.Clear();
            Console.WriteLine("Привет!");
            Console.WriteLine();
            Console.Write(
                "Please enter your choice: \n\n" +
                "[0] Show people list. \n" +
                "[1] Add new person. \n" +
                "[2] Show people list starts with F. \n");
            Console.WriteLine("-------------------------------");

            var value = Console.ReadLine();

            if (!int.TryParse(value, out selectedValue))
            {
                selectedValue = 999;
                Console.WriteLine("Bad");
            }

            return selectedValue;
        }

        public static void ShowContinueMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("Operation completed! \n" +
                "Press return key to continue...");
            Console.Read();
        }

        public static void ShowPeople(IEnumerable<Person> people)
        {
            var table = new ConsoleTable("Id", "LastName", "FirstName", "Patronomyc", "Age", "Date", "Gender");

            foreach (var person in people)
            {
                string lastName = person.FullName.Split(' ').First();
                string firstName = person.FullName.Split(' ')[1];
                string patronomyc = person.FullName.Split(' ').Last();
                var parsedGender = Enum.GetName(typeof(Gender), person.Gender);
                int age = CalculateAge(person.Date);

                table.AddRow(
                    person.Id,
                    lastName,
                    firstName,
                    patronomyc,
                    age,
                    person.Date.ToString("MM.dd.yyyy"),
                    parsedGender);
            }

            table.Print();

            ShowContinueMessage();
        }

        public static Person ShowAddInfo()
        {
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter patronomyc");
            string patronomyc = Console.ReadLine();

            Console.WriteLine("Enter date of birth (format yyyy-mm-dd");
            DateOnly date = DateOnly.Parse(Console.ReadLine());

            Console.WriteLine("Enter your gender (male/female)");
            Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine(), true);

            return new Person
            {
                FullName = lastName + " " + firstName + " " + patronomyc,
                Date = date,
                Gender = gender
            };
        }

        private static int CalculateAge(DateOnly date)
        {
            var today = DateTime.Today;

            var age = today.Year - date.Year;

            if (date.Month > today.Month || date.Day > today.Day)
                age--;

            return age;
        }
    }
}
