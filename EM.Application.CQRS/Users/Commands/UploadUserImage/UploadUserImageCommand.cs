using MediatR;
using Microsoft.AspNetCore.Http;

namespace EM.Application.CQRS.Users.Commands.UploadUserImage;

public class UploadUserImageCommand : IRequest
{
    public string UserId { get; set; }

    public IFormFile File { get; set; }
}