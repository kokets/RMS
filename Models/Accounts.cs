namespace HSRC_RMS.Models
{
    public class Accounts
    {
        public int Id { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'groupId' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string groupId { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'groupId' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.


    }
}
