namespace HSRC_RMS.Models
{
    public class Team
    {
        public int Id { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Email' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Email { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Email' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Username' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Username { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Username' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Surname' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Surname { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Surname' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'GroupID' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string GroupID { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'GroupID' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'active' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string active { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'active' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
