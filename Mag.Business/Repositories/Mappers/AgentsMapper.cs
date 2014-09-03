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
                    Login = from.login,
                    Email = from.email,
                    FullName = from.fullName,
                    RegistrationDate = from.regDate,
                    IsAdmin = from.isAdmin,
                    PasswordHash = from.passwordHash,
                };
        }

        public static tbAgent ToItem(this Agent from)
        {
            return new tbAgent
                {
                    login = from.Login,
                    email = from.Email,
                    fullName = from.FullName,
                    regDate = from.RegistrationDate,
                    isAdmin = from.IsAdmin,
                    passwordHash = from.PasswordHash
                };
        }
    }
}