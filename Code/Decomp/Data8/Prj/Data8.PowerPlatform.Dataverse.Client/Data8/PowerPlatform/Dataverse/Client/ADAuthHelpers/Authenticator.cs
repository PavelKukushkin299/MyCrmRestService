// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.Authenticator
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers
{
  internal class Authenticator
  {
    private readonly SHA1 _hash;

    public Authenticator() => this._hash = SHA1.Create();

    public void AddToDigest(XmlDocument xmlDoc)
    {
      XmlDsigExcC14NTransform excC14Ntransform = new XmlDsigExcC14NTransform();
      excC14Ntransform.LoadInput((object) xmlDoc);
      using (Stream output = (Stream) excC14Ntransform.GetOutput(typeof (Stream)))
      {
        using (StreamReader streamReader = new StreamReader(output))
        {
          streamReader.ReadToEnd();
          output.Position = 0L;
          byte[] numArray = new byte[1024];
          while (true)
          {
            int inputCount = output.Read(numArray, 0, numArray.Length);
            if (inputCount != 0)
              this._hash.TransformBlock(numArray, 0, inputCount, numArray, 0);
            else
              break;
          }
        }
      }
    }

    public void Validate(byte[] proofToken, byte[] actualAuthenticator)
    {
      this._hash.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
      byte[] pshA1 = this.CalculatePSHA1(proofToken, ((IEnumerable<byte>) Encoding.UTF8.GetBytes("AUTH-HASH")).Concat<byte>((IEnumerable<byte>) this._hash.Hash).ToArray<byte>(), 256);
      if (actualAuthenticator.Length != pshA1.Length)
        throw new ApplicationException("Invalid authenticator");
      for (int index = 0; index < actualAuthenticator.Length; ++index)
      {
        if ((int) actualAuthenticator[index] != (int) pshA1[index])
          throw new ApplicationException("Invalid authenticator");
      }
    }

    private byte[] CalculatePSHA1(byte[] client, byte[] server, int sizeBits)
    {
      int length1 = sizeBits / 8;
      using (HMACSHA1 hmacshA1 = new HMACSHA1())
      {
        hmacshA1.Key = client;
        int length2 = hmacshA1.HashSize / 8 + server.Length;
        int index1 = 0;
        byte[] buffer1 = server;
        byte[] buffer2 = new byte[length2];
        byte[] pshA1 = new byte[length1];
label_5:
        while (index1 < length1)
        {
          hmacshA1.Initialize();
          buffer1 = hmacshA1.ComputeHash(buffer1);
          buffer1.CopyTo((Array) buffer2, 0);
          server.CopyTo((Array) buffer2, hmacshA1.HashSize / 8);
          byte[] hash = hmacshA1.ComputeHash(buffer2);
          int index2 = 0;
          while (true)
          {
            if (index2 < hash.Length && index1 < length1)
            {
              pshA1[index1] = hash[index2];
              ++index1;
              ++index2;
            }
            else
              goto label_5;
          }
        }
        return pshA1;
      }
    }
  }
}
