// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.AuthenticationHelpers
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
  public static class AuthenticationHelpers
  {
    internal static bool ShouldAuthenticateWithLiveId<TService>(
      this IServiceManagement<TService> serviceManagement,
      ClientCredentials clientCredentials)
    {
      ClientExceptionHelper.ThrowIfNull((object) serviceManagement, nameof (serviceManagement));
      ClientExceptionHelper.ThrowIfNull((object) clientCredentials, nameof (clientCredentials));
      return false;
    }

    internal static bool ShouldAuthenticateWithLiveId<TService>(
      this IServiceConfiguration<TService> serviceConfiguration,
      ClientCredentials clientCredentials)
    {
      ClientExceptionHelper.ThrowIfNull((object) serviceConfiguration, nameof (serviceConfiguration));
      ClientExceptionHelper.ThrowIfNull((object) clientCredentials, nameof (clientCredentials));
      return false;
    }

    internal static bool ShouldAuthenticateWithLiveId<TService>(
      this ServiceConfiguration<TService> serviceConfiguration,
      ClientCredentials clientCredentials)
    {
      ClientExceptionHelper.ThrowIfNull((object) serviceConfiguration, nameof (serviceConfiguration));
      ClientExceptionHelper.ThrowIfNull((object) clientCredentials, nameof (clientCredentials));
      return false;
    }
  }
}
