using tune_forge.Features.Conversion.Application;
using tune_forge.Features.Files.Domain;

namespace tune_forge.Features.Conversion.Domain.Jobs;

public sealed class ConversionJob
{
    public Guid Id { get; }
    public IFileDefinition Input { get; }
    public ConversionTarget Target { get; }
    public ConversionJobStatus Status { get; private set; }
    public IFileDefinition? Output { get; private set; }
    public string? ErrorMessage { get; private set; }
    public DateTimeOffset CreatedAt { get; }
    public DateTimeOffset? StartedAt { get; private set; }
    public DateTimeOffset? CompletedAt { get; private set; }

    private ConversionJob(Guid id, IFileDefinition input, ConversionTarget target)
    {
        Id = id;
        Input = input;
        Target = target;
        Status = ConversionJobStatus.Pending;
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public static ConversionJob Create(IFileDefinition input, ConversionTarget target)
        => new(Guid.NewGuid(), input, target);

    public void MarkRunning() => (Status, StartedAt) = (ConversionJobStatus.Running, DateTimeOffset.UtcNow);

    public void MarkCompleted(IFileDefinition output)
        => (Status, Output, CompletedAt) = (ConversionJobStatus.Completed, output, DateTimeOffset.UtcNow);

    public void MarkFailed(string error)
        => (Status, ErrorMessage, CompletedAt) = (ConversionJobStatus.Failed, error, DateTimeOffset.UtcNow);
}

public enum ConversionJobStatus { Pending, Running, Completed, Failed }