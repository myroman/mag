using System;

namespace Mag.Business.Domain
{
    public class Agent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Patronym { get; set; }

        public string Surname { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool? IsAdmin { get; set; }

        public string FullName()
        {
            return string.Format("{0} {1}", Name, Surname);
        }
    }
}