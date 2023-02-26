// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.SdkUtilities
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Microsoft.Xrm.Sdk.Discovery
{
  internal static class SdkUtilities
  {
    [SecuritySafeCritical]
    internal static string SecureStringToString(SecureString value)
    {
      if (value == null)
        return (string) null;
      IntPtr num = IntPtr.Zero;
      try
      {
        num = Marshal.SecureStringToBSTR(value);
        return Marshal.PtrToStringUni(num);
      }
      finally
      {
        if (num != IntPtr.Zero)
          Marshal.ZeroFreeBSTR(num);
      }
    }

    internal static SecureString StringToSecureString(string value)
    {
      if (value == null)
        return (SecureString) null;
      SecureString secureString = new SecureString();
      foreach (char c in value)
        secureString.AppendChar(c);
      secureString.MakeReadOnly();
      return secureString;
    }
  }
}
