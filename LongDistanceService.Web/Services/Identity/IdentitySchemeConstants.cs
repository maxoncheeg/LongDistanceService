namespace LongDistanceService.Web.Services.Identity;

public class IdentitySchemeConstants : IIdentitySchemeConstants
{
    public string ApplicationScheme { get; }
    public string ExternalScheme { get; }

    public IdentitySchemeConstants(string applicationScheme, string externalScheme)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(applicationScheme);
        ArgumentException.ThrowIfNullOrWhiteSpace(externalScheme);

        ApplicationScheme = applicationScheme;
        ExternalScheme = externalScheme;
    }
}