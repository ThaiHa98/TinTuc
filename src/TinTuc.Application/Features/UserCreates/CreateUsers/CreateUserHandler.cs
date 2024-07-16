using MediatR;
using TinTuc.Domain.Model;
using TinTuc.Infrastructure.Repositories.Interface;

namespace TinTuc.Application.Features.UserCreates.CreateUsers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, User>
    {
        private readonly IRepositoryInterface<User> _userRepository;

        public CreateUserHandler(IRepositoryInterface<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    throw new Exception("The request has not been filled in with enough data");
                }

                var user = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Address = request.Address,
                };

                var savedUser = await _userRepository.AddAsync(user);

                var response = new User
                {
                    Name = savedUser.Name,
                    Email = savedUser.Email,
                    Address = savedUser.Address
                };

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating user", ex);
            }
        }
    }
}
