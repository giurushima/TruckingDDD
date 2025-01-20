using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Auth
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IUsersRepository _userRepository;

        public AuthenticationServices(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? ValidateUser(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            return _userRepository.ValidateUser(authenticationRequest);
        }
    }
}
