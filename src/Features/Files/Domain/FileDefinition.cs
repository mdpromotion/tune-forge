namespace tune_forge.Features.Files.Domain;

public abstract record FileDefinition : IFileDefinition
{
    public required string OriginalFileName { get; init; }
    public required string Extension { get; init; }
    public required string MimeType { get; init; }
    public required long SizeInBytes { get; init; }
    public required Uri StorageLocation { get; init; }
}