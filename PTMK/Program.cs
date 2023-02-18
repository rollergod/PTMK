using PTMK;
using PTMK.Data;
using PTMK.Helpers;
using PTMK.Repositories;

IRepository repo = new Repository(new AppDbContext());
SeedData.GenerateData(); // seeding

int selectedValue;
do
{
    selectedValue = MenuHelper.ShowMenu();
	switch (selectedValue)
	{
		//show list
		case 0:
			{
				var people = repo.GetPeople();
				MenuHelper.ShowPeople(people);
			}
			break;

		//add new person
		case 1:
			{
				var personToAdd = MenuHelper.ShowAddInfo();
				repo.AddPerson(personToAdd);

				MenuHelper.ShowContinueMessage();
			}
			break;
		//show list of people with F
        case 2:
			{
                var startTime = System.Diagnostics.Stopwatch.StartNew();
				//0156 - 154
                var peopleWithF = repo.GetPeopleWithF();

                startTime.Stop();
                var resultTime = startTime.Elapsed;
                string elapsedTime = String.Format(
					"{0:00}:{1:00}:{2:00}.{3:000}",
					resultTime.Hours,
					resultTime.Minutes,
					resultTime.Seconds,
					resultTime.Milliseconds);

				Console.WriteLine($"Method execution time - {elapsedTime}");
                MenuHelper.ShowPeople(peopleWithF);
            }
            break;

        default:
			break;
	}
} while (true);