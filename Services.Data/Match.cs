namespace Services.Data
{
    public class Match
    {
        public List<Team>? Teams { get; set; }
    }

    public class Team
    {
        public string? TeamName { get; set; }
        public List<Player>? Players { get; set; }
    }

    public class Player
    {
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public string? City { get; set; }
        public string? CompanyName { get; set; }
    }
}