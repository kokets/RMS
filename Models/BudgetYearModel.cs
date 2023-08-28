namespace HSRC_RMS.Models
{
    public class BudgetYearModel
    {
        public int Id { get; set; }

#pragma warning disable CS8618 // Non-nullable property 'budgetYear' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string budgetYear { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'budgetYear' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
