using CustomerService.Application.Common.Enums;
using CustomerService.Application.Common.Errors;
using CustomerService.Application.Common.Interfaces.Authentication;
using CustomerService.Application.Common.Interfaces.Persistence;
using CustomerService.Application.Common.Interfaces.Services;
using CustomerService.Domain.User;

namespace CustomerService.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, 
            IUserRepository userRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            //1.Validate the user doesn`t exist
            if (await _userRepository.GetUserByEmail(email) is not null)
            {
                throw new DuplicateEmailException();
            }

            //2. Create new user (generate unique ID) & Persist to DB
            var user = User.Create(firstName,
                lastName,
                email,
                password,
                Role.Customer.ToString(),
                _dateTimeProvider.UtcNow,
                _dateTimeProvider.UtcNow);


            await _userRepository.Add(user);

            //3. Create jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }

        public async Task <AuthenticationResult> Login(string email, string password)
        {
            if (await _userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exist.");
            }

            if(user.Password != password)
            {
                throw new Exception("Invalid password");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
