namespace _03.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] teamInfo = Console.ReadLine()
                                            .Split("-")
                                            .ToArray();

                string creatorName = teamInfo[0];
                string teamName = teamInfo[1];

                if (teams.Any(t => t.TeamName == teamName)) // проверяваме дали има отбор с това име
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(t => t.Creator == creatorName))  // проверявам дали има друг отбор с този създател
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                }
                else // този създател може да направи нов отбор
                {
                    // създавам нова инстанция на класа Team
                    Team currentTeam = new Team(teamName, creatorName);

                    //добавяме отбора в списъка с отбори
                    teams.Add(currentTeam);

                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                }
            }

            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                string[] joinInfo = input.Split("->").ToArray();

                string memberName = joinInfo[0];
                string teamName = joinInfo[1];

                if (!teams.Any(t => t.TeamName == teamName)) // търсим дали съществива такъв отбор
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Any(t => t.Members.Contains(memberName) // търсим дали потребителя не участва вече в друг отбор
                                        || t.Creator == memberName)) // ИЛИ дали потребителя не е създател на друг отбор
                {

                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                }
                else// може този потребител да се добави в отбота
                {

                    // вадя си отбора от списъка по референция
                    Team currentTeam = teams.FirstOrDefault(t => t.TeamName == teamName);

                    // добавям участника в отбора по референция
                    currentTeam.Members.Add(memberName);
                }

                input = Console.ReadLine();
            }

            foreach(var team in teams
                                .Where(t => t.Members.Count > 0)
                                .OrderByDescending(t => t.Members.Count)
                                .ThenBy(t => t.TeamName))
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.Creator}");

                foreach(var member in team.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in teams
                                .Where(t => t.Members.Count == 0)
                                .OrderBy(t => t.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
}
