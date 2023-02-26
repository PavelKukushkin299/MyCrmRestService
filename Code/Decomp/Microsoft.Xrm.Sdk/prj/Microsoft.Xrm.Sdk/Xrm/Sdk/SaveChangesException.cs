// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SaveChangesException
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;

namespace Microsoft.Xrm.Sdk
{
  [Serializable]
  public sealed class SaveChangesException : Exception
  {
    private new const string _message = "An error occured while processing this request.";

    public SaveChangesResultCollection Results { get; private set; }

    public SaveChangesException()
    {
    }

    public SaveChangesException(string message)
      : base(message)
    {
    }

    public SaveChangesException(string message, Exception exception)
      : base(message, exception)
    {
    }

    public SaveChangesException(SaveChangesResultCollection results)
      : this("An error occured while processing this request.", results)
    {
    }

    public SaveChangesException(string message, SaveChangesResultCollection results)
      : this(message, SaveChangesException.GetException((IEnumerable<SaveChangesResult>) results), results)
    {
    }

    public SaveChangesException(Exception innerException, SaveChangesResultCollection results)
      : this("An error occured while processing this request.", innerException, results)
    {
    }

    public SaveChangesException(
      string message,
      Exception innerException,
      SaveChangesResultCollection results)
      : base(message, innerException)
    {
      this.Results = results;
    }

    private SaveChangesException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    [SecurityCritical]
    public override void GetObjectData(SerializationInfo info, StreamingContext context) => base.GetObjectData(info, context);

    private static Exception GetException(IEnumerable<SaveChangesResult> results) => results.Where<SaveChangesResult>((Func<SaveChangesResult, bool>) (r => r.Error != null)).Select<SaveChangesResult, Exception>((Func<SaveChangesResult, Exception>) (r => r.Error)).FirstOrDefault<Exception>();
  }
}
