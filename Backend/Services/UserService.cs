using Backend.Models;
using Backend.Models.Entities.User;
using Backend.Repositories.Users;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Backend.Services
{
    public class UserService
    {
        private readonly UserRepositoy _userRepo;
        private readonly RoleRepositoty _roleRepo;

        public UserService(UserRepositoy userRepo, RoleRepositoty roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }

        public async Task<UserEntity> GetUserFromToken(ClaimsPrincipal userClaims)
        {
            var userIdClaim = userClaims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if(userIdClaim == null)
            {
                throw new ArgumentException("Invalid user token");
            }
            var userId = Guid.Parse(userIdClaim.Value);

            var user = await _userRepo.GetAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            return user;
        }

        public async Task<bool> CheckUserExistsAsync(Expression<Func<UserEntity, bool>> predicate)
        {
            return await _userRepo.AnyAsync(predicate);
        }

        public async Task<bool> RegisterAsync(UserEntity user, string password)
        {
            if(!await _userRepo.AnyAsync() || !await _roleRepo.AnyAsync())
            {
                try
                {
                    var roleAdminId = Guid.NewGuid();
                    await _roleRepo.AddAsync(new RoleEntity
                    {
                        Id = roleAdminId,
                        Name = "Admin"
      
                    });
                    user.RoleId = roleAdminId;
                    
                }
                catch { }
                try
                {
                    var roleUserId = Guid.NewGuid();
                    await _roleRepo.AddAsync(new RoleEntity
                    {
                        Id = roleUserId,
                        Name = "User"
                    });
                }
                catch { }
            }


            if (!await _userRepo.AnyAsync(x => x.Email == user.Email))
            {
                var userRole = await _roleRepo.GetAsync(x => x.Name == "User");
                var adminRole = await _roleRepo.GetAsync(x => x.Name == "Admin");

                user.Id = Guid.NewGuid();
                if (await CheckUserExistsAsync(x => x.RoleId == adminRole.Id))
                {
                    user.RoleId = userRole.Id;
                }
                else
                {
                    user.RoleId = adminRole.Id;
                }
                    
                user.SetSecurePassword(password);
                await _userRepo.AddAsync(user);

                if(await _userRepo.AnyAsync(x => x.Email == user.Email))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var entity = await _userRepo.GetAsync(x => x.Email == email);
            if(entity != null)
            {
                if(entity.ValidateSecurePassword(password))
                {
                    return TokenGenerator.GenerateJwtToken(entity);
                }
            }
            return null!;
        }

        public async Task<bool> UpdateProfileAsync(UserEntity user, UserProfileModel model)
        {
            if(user != null)
            {
                user.Name = model.Name;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                await _userRepo.UpdateAsync(user);
                return true;
            }
            return false;
        }
    }
}
