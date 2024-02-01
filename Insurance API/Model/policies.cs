namespace LearnDapper.Model
{
    public class policies
    {
        public int policyID { get; set; }

        public string policyType { get; set; }

        public int PolicyOwnerID { get; set; }

        public DateTime policyStartDate { get; set; }

        public DateTime policyEndDate { get; set; }

        public decimal policyPremium { get; set; }

        public string policyFrequency { get; set; }
    }
}
