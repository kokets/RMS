namespace HSRC_RMS.Models
{
    public class TimeRecordings
    {
        public int Id { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'BudgetYear' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string BudgetYear { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'BudgetYear' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Project' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Project { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Project' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Budgeted_hours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Budgeted_hours { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Budgeted_hours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Cost_Of_Budget' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Cost_Of_Budget { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Cost_Of_Budget' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Recorded_Hours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Recorded_Hours { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Recorded_Hours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Hours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Hours { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Hours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Remaining_Hours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Remaining_Hours { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Remaining_Hours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Cost_Of_Recorded_Hours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Cost_Of_Recorded_Hours { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Cost_Of_Recorded_Hours' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Remaining_Cost' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Remaining_Cost { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Remaining_Cost' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        public bool active { get; set; }
    }
}