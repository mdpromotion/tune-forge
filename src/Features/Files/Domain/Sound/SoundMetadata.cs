namespace tune_forge.Features.Files.Domain.Sound;

public sealed record SoundMetadata(
    TimeSpan Duration,
    int Bitrate,
    int SampleRate,
    int Channels,
    AudioCodec Codec);