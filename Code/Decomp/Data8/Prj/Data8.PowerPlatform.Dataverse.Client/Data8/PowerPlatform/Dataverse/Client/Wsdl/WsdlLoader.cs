// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.Wsdl.WsdlLoader
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace Data8.PowerPlatform.Dataverse.Client.Wsdl
{
  public static class WsdlLoader
  {
    public static IEnumerable<Definitions> Load(string url) => WsdlLoader.Load(new HashSet<string>(), url);

    private static IEnumerable<Definitions> Load(
      HashSet<string> loaded,
      string url)
    {
      if (loaded.Add(url))
      {
        using (WebResponse resp = WebRequest.CreateHttp(url).GetResponse())
        {
          using (Stream stream = resp.GetResponseStream())
          {
            Definitions wsdl = (Definitions) new XmlSerializer(typeof (Definitions)).Deserialize(stream);
            yield return wsdl;
            if (wsdl.Imports != null)
            {
              Import[] importArray = wsdl.Imports;
              for (int index = 0; index < importArray.Length; ++index)
              {
                foreach (Definitions definitions in WsdlLoader.Load(loaded, importArray[index].Location))
                  yield return definitions;
              }
              importArray = (Import[]) null;
            }
            wsdl = (Definitions) null;
          }
        }
      }
    }
  }
}
