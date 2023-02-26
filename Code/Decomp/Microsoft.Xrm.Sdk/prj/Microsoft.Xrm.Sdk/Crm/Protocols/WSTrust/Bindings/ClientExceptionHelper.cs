// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Protocols.WSTrust.Bindings.ClientExceptionHelper
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Globalization;

namespace Microsoft.Crm.Protocols.WSTrust.Bindings
{
  public static class ClientExceptionHelper
  {
    public static string GetString(string value, params object[] args)
    {
      string format = value;
      if (string.IsNullOrEmpty(value))
        return value;
      if (args != null && args.Length != 0)
        format = string.Format((IFormatProvider) CultureInfo.CurrentCulture, format, args);
      return format;
    }
  }
}
