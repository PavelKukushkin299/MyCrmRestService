// Decompiled with JetBrains decompiler
// Type: NSspi.EnumMgr
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Reflection;

namespace NSspi
{
  public class EnumMgr
  {
    public static string ToText(Enum value)
    {
      EnumStringAttribute[] customAttributes = (EnumStringAttribute[]) value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof (EnumStringAttribute), false);
      return customAttributes == null || customAttributes.Length == 0 ? (string) null : customAttributes[0].Text;
    }

    public static T FromText<T>(string text)
    {
      foreach (FieldInfo field in typeof (T).GetFields())
      {
        foreach (EnumStringAttribute customAttribute in (EnumStringAttribute[]) field.GetCustomAttributes(typeof (EnumStringAttribute), false))
        {
          if (customAttribute.Text == text)
            return (T) field.GetValue((object) null);
        }
      }
      throw new ArgumentException("Could not find a matching enumeration value for the text '" + text + "'.");
    }
  }
}
