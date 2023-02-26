// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IPluginExecutionContextExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

namespace Microsoft.Xrm.Sdk
{
  public static class IPluginExecutionContextExtensions
  {
    public static bool IsWithinMainTransaction(this IPluginExecutionContext context) => context.Stage >= 20 && context.Stage <= 40;

    public static bool IsAutoTransact(this IPluginExecutionContext context) => (bool) context.SharedVariables[nameof (IsAutoTransact)];
  }
}
