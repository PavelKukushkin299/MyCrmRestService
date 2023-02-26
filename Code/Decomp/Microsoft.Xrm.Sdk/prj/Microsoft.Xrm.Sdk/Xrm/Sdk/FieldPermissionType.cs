// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.FieldPermissionType
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Globalization;

namespace Microsoft.Xrm.Sdk
{
  public static class FieldPermissionType
  {
    public const int NotAllowed = 0;
    public const int Allowed = 4;

    public static void Validate(int value)
    {
      if (value != 4 && value != 0)
        throw new ArgumentOutOfRangeException(nameof (value), string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Value {0} is not a valid FieldPermissionType", (object) value));
    }
  }
}
