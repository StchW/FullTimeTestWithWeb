namespace FullTimeForceTest.Api.Models
{
    public class CalculateFinalNoteResponse
    {
        public int TotalApproved { get; set; }
        public int TotalNotApproved { get; set; }

        public double AverageNoteGeneral { get; set; }
        public double AverageNoteApproved { get; set; }
        public double AverageNoteNotApproved { get; set; }
    }
}
