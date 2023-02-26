// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ChannelExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.ServiceModel;

namespace MyCrmConnector.Client
{
  internal static class ChannelExtensions
  {
    public static void Abort(this ICommunicationObject communicationObject) => communicationObject?.Abort();

    public static void Close(this ICommunicationObject communicationObject, bool throwOnException = true)
    {
      if (communicationObject == null)
        return;
      try
      {
        CommunicationState state = communicationObject.State;
        if (CommunicationState.Faulted == state)
        {
          communicationObject.Abort();
        }
        else
        {
          if (state == CommunicationState.Closing || state == CommunicationState.Closed)
            return;
          communicationObject.Close();
        }
      }
      catch (CommunicationException ex)
      {
        communicationObject.Abort();
      }
      catch (TimeoutException ex)
      {
        communicationObject.Abort();
      }
      catch (Exception ex)
      {
        communicationObject.Abort();
        if (!throwOnException)
          return;
        throw;
      }
    }
  }
}
