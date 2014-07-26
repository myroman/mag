namespace Mag.Business.Domain
{
    public class InsuranceType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}