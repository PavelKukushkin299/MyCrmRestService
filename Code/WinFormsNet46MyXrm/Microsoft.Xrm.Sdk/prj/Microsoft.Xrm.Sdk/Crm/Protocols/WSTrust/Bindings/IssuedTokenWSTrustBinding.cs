// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Protocols.WSTrust.Bindings.IssuedTokenWSTrustBinding
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace Microsoft.Crm.Protocols.WSTrust.Bindings
{
  internal sealed class IssuedTokenWSTrustBinding : WSTrustBindingBase
  {
    private SecurityAlgorithmSuite _algorithmSuite;
    private Collection<System.ServiceModel.Security.Tokens.ClaimTypeRequirement> _claimTypeRequirements;
    private EndpointAddress _issuerAddress;
    private Binding _issuerBinding;
    private EndpointAddress _issuerMetadataAddress;
    private SecurityKeyType _keyType;
    private string _tokenType;

    public IssuedTokenWSTrustBinding()
      : this((Binding) null, (EndpointAddress) null)
    {
    }

    public IssuedTokenWSTrustBinding(Binding issuerBinding, EndpointAddress issuerAddress)
      : this(issuerBinding, issuerAddress, SecurityMode.Message, TrustVersion.WSTrust13, (EndpointAddress) null)
    {
    }

    public IssuedTokenWSTrustBinding(
      Binding issuerBinding,
      EndpointAddress issuerAddress,
      EndpointAddress issuerMetadataAddress)
      : this(issuerBinding, issuerAddress, SecurityMode.Message, TrustVersion.WSTrust13, issuerMetadataAddress)
    {
    }

    public IssuedTokenWSTrustBinding(
      Binding issuerBinding,
      EndpointAddress issuerAddress,
      string tokenType,
      IEnumerable<System.ServiceModel.Security.Tokens.ClaimTypeRequirement> claimTypeRequirements)
      : this(issuerBinding, issuerAddress, SecurityKeyType.SymmetricKey, SecurityAlgorithmSuite.Basic256, tokenType, claimTypeRequirements)
    {
    }

    public IssuedTokenWSTrustBinding(
      Binding issuerBinding,
      EndpointAddress issuerAddress,
      SecurityMode mode,
      TrustVersion trustVersion,
      EndpointAddress issuerMetadataAddress)
      : this(issuerBinding, issuerAddress, mode, trustVersion, SecurityKeyType.SymmetricKey, SecurityAlgorithmSuite.Basic256, (string) null, (IEnumerable<System.ServiceModel.Security.Tokens.ClaimTypeRequirement>) null, issuerMetadataAddress)
    {
    }

    public IssuedTokenWSTrustBinding(
      Binding issuerBinding,
      EndpointAddress issuerAddress,
      SecurityKeyType keyType,
      SecurityAlgorithmSuite algorithmSuite,
      string tokenType,
      IEnumerable<System.ServiceModel.Security.Tokens.ClaimTypeRequirement> claimTypeRequirements)
      : this(issuerBinding, issuerAddress, SecurityMode.Message, TrustVersion.WSTrust13, keyType, algorithmSuite, tokenType, claimTypeRequirements, (EndpointAddress) null)
    {
    }

    public IssuedTokenWSTrustBinding(
      Binding issuerBinding,
      EndpointAddress issuerAddress,
      SecurityMode mode,
      TrustVersion version,
      SecurityKeyType keyType,
      SecurityAlgorithmSuite algorithmSuite,
      string tokenType,
      IEnumerable<System.ServiceModel.Security.Tokens.ClaimTypeRequirement> claimTypeRequirements,
      EndpointAddress issuerMetadataAddress)
      : base(mode, version)
    {
      this._claimTypeRequirements = new Collection<System.ServiceModel.Security.Tokens.ClaimTypeRequirement>();
      if (SecurityMode.Message != mode && SecurityMode.TransportWithMessageCredential != mode)
        throw new InvalidOperationException(ClientExceptionHelper.GetString("ID3226: SecurityMode of IssuedTokenBinding must be SecurityMode.Message or SecurityMode.TransportWithMessageCredential. But actual value is '{0}'.", (object) mode));
      if (this._keyType == SecurityKeyType.BearerKey && version == TrustVersion.WSTrustFeb2005)
        throw new InvalidOperationException(ClientExceptionHelper.GetString("ID3267: Bearer KeyType is not supported with WSTrustFeb2005 version of WSTrust. Consider using WSTrust13 instead."));
      this._keyType = keyType;
      this._algorithmSuite = algorithmSuite;
      this._tokenType = tokenType;
      this._issuerBinding = issuerBinding;
      this._issuerAddress = issuerAddress;
      this._issuerMetadataAddress = issuerMetadataAddress;
      if (claimTypeRequirements == null)
        return;
      foreach (System.ServiceModel.Security.Tokens.ClaimTypeRequirement claimTypeRequirement in claimTypeRequirements)
        this._claimTypeRequirements.Add(claimTypeRequirement);
    }

    private void AddAlgorithmParameters(
      SecurityAlgorithmSuite algorithmSuite,
      TrustVersion trustVersion,
      SecurityKeyType keyType,
      ref IssuedSecurityTokenParameters issuedParameters)
    {
      issuedParameters.AdditionalRequestParameters.Insert(0, this.CreateEncryptionAlgorithmElement(algorithmSuite.DefaultEncryptionAlgorithm));
      issuedParameters.AdditionalRequestParameters.Insert(0, this.CreateCanonicalizationAlgorithmElement(algorithmSuite.DefaultCanonicalizationAlgorithm));
      string signatureAlgorithm;
      string encryptionAlgorithm;
      switch (keyType)
      {
        case SecurityKeyType.SymmetricKey:
          signatureAlgorithm = algorithmSuite.DefaultSymmetricSignatureAlgorithm;
          encryptionAlgorithm = algorithmSuite.DefaultEncryptionAlgorithm;
          break;
        case SecurityKeyType.AsymmetricKey:
          signatureAlgorithm = algorithmSuite.DefaultAsymmetricSignatureAlgorithm;
          encryptionAlgorithm = algorithmSuite.DefaultAsymmetricKeyWrapAlgorithm;
          break;
        case SecurityKeyType.BearerKey:
          return;
        default:
          throw new ArgumentOutOfRangeException(nameof (keyType));
      }
      issuedParameters.AdditionalRequestParameters.Insert(0, this.CreateSignWithElement(signatureAlgorithm));
      issuedParameters.AdditionalRequestParameters.Insert(0, this.CreateEncryptWithElement(encryptionAlgorithm));
      if (trustVersion == TrustVersion.WSTrustFeb2005)
        return;
      issuedParameters.AdditionalRequestParameters.Insert(0, IssuedTokenWSTrustBinding.CreateKeyWrapAlgorithmElement(algorithmSuite.DefaultAsymmetricKeyWrapAlgorithm));
    }

    protected override void ApplyTransportSecurity(HttpTransportBindingElement transport) => throw new NotSupportedException(ClientExceptionHelper.GetString("ID3227: Issued token authentication is not supported for Transport security. IssuedTokenWSTrustBinding.SecurityMode must be set to 'Message' or 'TransportWithMessageCredential'."));

    private XmlElement CreateCanonicalizationAlgorithmElement(
      string canonicalizationAlgorithm)
    {
      if (canonicalizationAlgorithm == null)
        throw new ArgumentNullException(nameof (canonicalizationAlgorithm));
      XmlDocument xmlDocument = new XmlDocument();
      XmlElement algorithmElement = (XmlElement) null;
      if (this.TrustVersion == TrustVersion.WSTrust13)
        algorithmElement = xmlDocument.CreateElement("trust", "CanonicalizationAlgorithm", "http://docs.oasis-open.org/ws-sx/ws-trust/200512");
      else if (this.TrustVersion == TrustVersion.WSTrustFeb2005)
        algorithmElement = xmlDocument.CreateElement("t", "CanonicalizationAlgorithm", "http://schemas.xmlsoap.org/ws/2005/02/trust");
      algorithmElement?.AppendChild((XmlNode) xmlDocument.CreateTextNode(canonicalizationAlgorithm));
      return algorithmElement;
    }

    private XmlElement CreateEncryptionAlgorithmElement(string encryptionAlgorithm)
    {
      if (encryptionAlgorithm == null)
        throw new ArgumentNullException(nameof (encryptionAlgorithm));
      XmlDocument xmlDocument = new XmlDocument();
      XmlElement algorithmElement = (XmlElement) null;
      if (this.TrustVersion == TrustVersion.WSTrust13)
        algorithmElement = xmlDocument.CreateElement("trust", "EncryptionAlgorithm", "http://docs.oasis-open.org/ws-sx/ws-trust/200512");
      else if (this.TrustVersion == TrustVersion.WSTrustFeb2005)
        algorithmElement = xmlDocument.CreateElement("t", "EncryptionAlgorithm", "http://schemas.xmlsoap.org/ws/2005/02/trust");
      algorithmElement?.AppendChild((XmlNode) xmlDocument.CreateTextNode(encryptionAlgorithm));
      return algorithmElement;
    }

    private XmlElement CreateEncryptWithElement(string encryptionAlgorithm)
    {
      if (encryptionAlgorithm == null)
        throw new ArgumentNullException(nameof (encryptionAlgorithm));
      XmlDocument xmlDocument = new XmlDocument();
      XmlElement encryptWithElement = (XmlElement) null;
      if (this.TrustVersion == TrustVersion.WSTrust13)
        encryptWithElement = xmlDocument.CreateElement("trust", "EncryptWith", "http://docs.oasis-open.org/ws-sx/ws-trust/200512");
      else if (this.TrustVersion == TrustVersion.WSTrustFeb2005)
        encryptWithElement = xmlDocument.CreateElement("t", "EncryptWith", "http://schemas.xmlsoap.org/ws/2005/02/trust");
      encryptWithElement?.AppendChild((XmlNode) xmlDocument.CreateTextNode(encryptionAlgorithm));
      return encryptWithElement;
    }

    private static XmlElement CreateKeyWrapAlgorithmElement(string keyWrapAlgorithm)
    {
      if (keyWrapAlgorithm == null)
        throw new ArgumentNullException(nameof (keyWrapAlgorithm));
      XmlDocument xmlDocument = new XmlDocument();
      XmlElement element = xmlDocument.CreateElement("trust", "KeyWrapAlgorithm", "http://docs.oasis-open.org/ws-sx/ws-trust/200512");
      element.AppendChild((XmlNode) xmlDocument.CreateTextNode(keyWrapAlgorithm));
      return element;
    }

    protected override SecurityBindingElement CreateSecurityBindingElement()
    {
      IssuedSecurityTokenParameters issuedParameters = new IssuedSecurityTokenParameters(this._tokenType, this._issuerAddress, this._issuerBinding)
      {
        KeyType = this._keyType,
        IssuerMetadataAddress = this._issuerMetadataAddress
      };
      issuedParameters.KeySize = this._keyType != SecurityKeyType.SymmetricKey ? 0 : this._algorithmSuite.DefaultSymmetricKeyLength;
      if (this._claimTypeRequirements != null)
      {
        foreach (System.ServiceModel.Security.Tokens.ClaimTypeRequirement claimTypeRequirement in this._claimTypeRequirements)
          issuedParameters.ClaimTypeRequirements.Add(claimTypeRequirement);
      }
      this.AddAlgorithmParameters(this._algorithmSuite, this.TrustVersion, this._keyType, ref issuedParameters);
      SecurityBindingElement securityBindingElement;
      if (SecurityMode.Message == this.SecurityMode)
      {
        securityBindingElement = (SecurityBindingElement) SecurityBindingElement.CreateIssuedTokenForCertificateBindingElement(issuedParameters);
      }
      else
      {
        if (SecurityMode.TransportWithMessageCredential != this.SecurityMode)
          throw new InvalidOperationException(ClientExceptionHelper.GetString("ID3226: SecurityMode of IssuedTokenBinding must be SecurityMode.Message or SecurityMode.TransportWithMessageCredential. But actual value is '{0}'.", (object) this.SecurityMode));
        securityBindingElement = (SecurityBindingElement) SecurityBindingElement.CreateIssuedTokenOverTransportBindingElement(issuedParameters);
      }
      securityBindingElement.DefaultAlgorithmSuite = this._algorithmSuite;
      securityBindingElement.IncludeTimestamp = true;
      return securityBindingElement;
    }

    private XmlElement CreateSignWithElement(string signatureAlgorithm)
    {
      if (signatureAlgorithm == null)
        throw new ArgumentNullException(nameof (signatureAlgorithm));
      XmlDocument xmlDocument = new XmlDocument();
      XmlElement signWithElement = (XmlElement) null;
      if (this.TrustVersion == TrustVersion.WSTrust13)
        signWithElement = xmlDocument.CreateElement("trust", "SignatureAlgorithm", "http://docs.oasis-open.org/ws-sx/ws-trust/200512");
      else if (this.TrustVersion == TrustVersion.WSTrustFeb2005)
        signWithElement = xmlDocument.CreateElement("t", "SignatureAlgorithm", "http://schemas.xmlsoap.org/ws/2005/02/trust");
      signWithElement?.AppendChild((XmlNode) xmlDocument.CreateTextNode(signatureAlgorithm));
      return signWithElement;
    }

    public SecurityAlgorithmSuite AlgorithmSuite
    {
      get => this._algorithmSuite;
      set => this._algorithmSuite = value;
    }

    public Collection<System.ServiceModel.Security.Tokens.ClaimTypeRequirement> ClaimTypeRequirement => this._claimTypeRequirements;

    public EndpointAddress IssuerAddress
    {
      get => this._issuerAddress;
      set => this._issuerAddress = value;
    }

    public Binding IssuerBinding
    {
      get => this._issuerBinding;
      set => this._issuerBinding = value;
    }

    public EndpointAddress IssuerMetadataAddress
    {
      get => this._issuerMetadataAddress;
      set => this._issuerMetadataAddress = value;
    }

    public SecurityKeyType KeyType
    {
      get => this._keyType;
      set => this._keyType = value;
    }

    public string TokenType
    {
      get => this._tokenType;
      set => this._tokenType = value;
    }
  }
}
