using MediatR;
using TinTuc.Infrastructure.Repositories.Interface;
using TinTuc.ModelDto.ModelDto;

namespace TinTuc.Application.Features.User.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, GetUserResponse>
    {
        private readonly IRepositoryInterface<UserDto> _userRepository;

        public CreateUserHandler(IRepositoryInterface<UserDto> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    throw new Exception("The request has not been filled in with enough data");
                }

                var user = new UserDto
                {
                    Name = request.Name,
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Address = request.Address,
                };

                var savedUser = await _userRepository.AddAsync(user);

                var response = new GetUserResponse
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
