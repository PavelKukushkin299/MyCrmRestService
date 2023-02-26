// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ILocalConfigStore
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Collections.Generic;

namespace Microsoft.Xrm.Sdk
{
  public interface ILocalConfigStore
  {
    void SetData(string keyName, object data);

    void SetData(Dictionary<string, object> keyData);

    T GetData<T>(string keyName);

    Dictionary<string, object> GetAllData();

    Dictionary<string, object> GetDataByKeyNames(List<string> keyNames);
  }
}
