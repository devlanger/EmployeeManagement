using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MediatR;

namespace EM.Application.CQRS.Users.Commands.UploadUserImage;

public class UploadUserImageCommandHandler : IRequestHandler<UploadUserImageCommand>
{
    private readonly BlobServiceClient _blobServiceClient;
    
    public async Task Handle(UploadUserImageCommand request, CancellationToken cancellationToken)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(request.UserId);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob, cancellationToken: cancellationToken);
        var newBlobName = $"{Guid.NewGuid()}.jpg";
        await containerClient.UploadBlobAsync(newBlobName, request.File.OpenReadStream(), cancellationToken);
    }
}