using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Models.Dtos.Tokens;
using ToDoList.Models.Entities;
using ToDoList.Service.Services.Abstracts;

namespace ToDoList.Service.Services.Concretes;

public class JwtService : IJwtService
{
    private readonly CustomTokenOptions _customTokenOptions;
    private readonly UserManager<User> _userManager;
    
    public JwtService(IOptions<CustomTokenOptions> options, UserManager<User> userManager)
    {
        _userManager = userManager;
        _customTokenOptions = options.Value;
    }
    
    
    public async Task<TokenResponseDto> CreateToken(User user)
    {
        var accessTokenExpiration = DateTime.Now.AddMinutes(_customTokenOptions.AccessTokenExpiration);
        var securityKey = SecurityKeyHelper.GetSecurityKey(_customTokenOptions.SecurityKey);
        SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha512Signature);
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _customTokenOptions.Issuer,
            expires: accessTokenExpiration,
            claims: await GetClaims(user,_customTokenOptions.Audience),
            signingCredentials: signingCredentials
        );
        var jwtHandler = new JwtSecurityTokenHandler();
        var token = jwtHandler.WriteToken(jwtSecurityToken);
        return new TokenResponseDto
        {
            AccessToken = token,
            AccessTokenExpiration = accessTokenExpiration
        };
    }
    
    private async Task<IEnumerable<Claim>> GetClaims(User user,List<string> audiences)
    {
        var userList = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim("email",user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
        };
        var roles = await _userManager.GetRolesAsync(user);
        if (roles.Count > 0)
        {
            userList.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        }
        
        userList.AddRange(audiences.Select(audience => new Claim(JwtRegisteredClaimNames.Aud, audience)));
        return userList;
    }
}