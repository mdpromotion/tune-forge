using tune_forge.Features.Files.Domain;

namespace tune_forge.Features.Conversion.Application;

public interface IFileConverter<TIn, TOut>
    where TIn : IFileDefinition
    where TOut : IFileDefinition
{
    Task<TOut> ConvertAsync(TIn source, ConversionTarget target, CancellationToken ct);
}

public sealed record ConversionTarget(Uri OutputLocation, string TargetFormat, IReadOnlyDictionary<string, string> Options);