using Mag.Business.Domain;

namespace Mag.Business.Repositories.Mappers
{
    public static class AgentsMapper
    {
        public static Agent ToDomain(this tbAgent from)
        {
            return new Agent
                {
                    Id = from.id,
                    Name = from.name,
                    Patronym = from.patronym,
                    Surname = from.surname,
                    RegistrationDate = from.regDate,
                    IsAdmin = from.isAdmin
                };
        }

        public static tbAgent ToItem(this Agent from)
        {
            return new tbAgent
                {
                    name = from.Name,
                    patronym = from.Patronym,
                    surname = from.Surname,
                    regDate = from.RegistrationDate,
                    isAdmin = from.IsAdmin
                };
        }
    }
}