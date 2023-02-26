// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Extensions.ContextExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

namespace Microsoft.Xrm.Sdk.Extensions
{
  public static class ContextExtensions
  {
    public static T InputParameterOrDefault<T>(
      this IPluginExecutionContext context,
      string parameterName)
    {
      object obj1;
      context.InputParameters.TryGetValue(parameterName, out obj1);
      return obj1 is T obj2 ? obj2 : default (T);
    }
  }
}
