﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.EntityAttributeCollection
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [CollectionDataContract(Name = "EntityAttributeCollection", Namespace = "http://schemas.microsoft.com/xrm/7.1/Contracts")]
  [Serializable]
  public sealed class EntityAttributeCollection : DataCollection<string, StringCollection>
  {
  }
}
