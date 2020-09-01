using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VEMS.Models;
using VEMS.Models.Auth;
using VEMS.Models.DB.DTO;
using VEMS.Models.DB.Identity;

namespace VEMS.Controllers.V1
{
    public class AuthController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IConfiguration configuration;
        public IHttpContextAccessor httpContext;

        public AuthController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            httpContext = httpContextAccessor;
        }

        [HttpGet("GetUserInfo")]
        public async Task<IActionResult> GetUserInfoAsync()
        {
            var result = new ApiResponse<UserDTO>();
            var response = new RegisterResponse();
            try
            {
                var currentUser = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userFound = await this.userManager.Users.SingleOrDefaultAsync(c => c.Email == currentUser);

                if (userFound != null)
                {
                    var checkRole = await this.userManager.GetRolesAsync(userFound);
                    var user = new UserDTO()
                    {
                        Id = userFound.Id,
                        Email = userFound.Email,
                        FullName = userFound.FullName,
                        UserName = userFound.UserName,
                        IsAdmin = checkRole[0] == "Admin"
                    };

                    result.Data = user;
                    return Ok(result);
                }
                else
                {

                    response.Success = false;
                    response.Message = "Somthing went wrong";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return Ok(response);
            }

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register model)
        {
            var result = new RegisterResponse();

            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = ModelState.Values.ToList()[0].Errors[0].ErrorMessage;
                    return Ok(result);
                }


                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FullName = model.FullName
                };


                var createResult = await userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    //await userManager.AddToRoleAsync(user, "Admin");

                    result.Success = true;
                    result.Message = "Successfully Registered the new user...";
                }
                else
                {
                    result.Success = false;
                    result.Message = "Error registering new user...";
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                return Ok(result);
            }
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login model)
        {
            var result = new LoginResponse();
            try
            {
                if (!ModelState.IsValid)
                {
                    result.Message = "Please enter username or password";
                    return Ok(result);
                }

                var user = await userManager.FindByNameAsync(model.Username);

                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    var checkRole = await this.userManager.GetRolesAsync(user);

                    if (checkRole != null)
                    {
                        var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(ClaimTypes.Role, checkRole[0]),
                    };

                        var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

                        var token = new JwtSecurityToken(
                            issuer: configuration["Jwt:Issuer"],
                            audience: configuration["Jwt:Audience"],
                            expires: DateTime.Now.AddMinutes(2),
                            claims: claims,
                            signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256)
                            );


                        result.Token = new JwtSecurityTokenHandler().WriteToken(token);
                        result.RefreshToken = "";
                        result.IsAdmin = (checkRole[0] == "Admin") ? true : false;
                        result.ExpireDate = token.ValidTo;

                        return Ok(result);
                    }
                    else
                    {
                        result.Message = "Contact Administrator";
                        return Ok(result);
                    }
                }
                else
                {
                    result.Message = "Username or Password are incorrect...";
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return Ok(result);
            }
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await this.roleManager.Roles.ToListAsync();

            return Ok(roles);
        }
    }
}
