namespace tune_forge.Features.Files.Domain.Sound;


public sealed record SoundFileDefinition : FileDefinition
{
    public required SoundMetadata Metadata { get; init; }
}