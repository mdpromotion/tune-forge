namespace tune_forge.Features.Files.Domain;

public interface IFileDefinition
{
    string OriginalFileName { get; }
    string Extension { get; }
    string MimeType { get; }
    long SizeInBytes { get; }
    Uri StorageLocation { get; }
}