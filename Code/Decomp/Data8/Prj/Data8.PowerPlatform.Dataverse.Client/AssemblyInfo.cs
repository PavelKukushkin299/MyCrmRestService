using System.Reflection;
//using System.Runtime.CompilerServices;

//[assembly: Extension]
[assembly: AssemblyCompany("MarkMpn,Data8 Ltd")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright © 2021 Data8 Limited")]
[assembly: AssemblyDescription("Provides a WS-Trust compatible client for connecting to on-premise IFD instances of Dynamics 365 from .NET Core.\r\n\r\nThis package builds on top of Microsoft.PowerPlatform.Dataverse.Client and offers an alternative IOrganizationService implementation using WS-Trust.\r\nThis allows you to connect using the URL of the organization service, username and password without any additional\r\nconfiguration.\r\n\r\nBecause this OnPremiseClient implements the same IOrganizationService as the standard ServiceClient implementation\r\nyour code can work with either as shown in the sample code below.\r\n\r\nusing Data8.PowerPlatform.Dataverse.Client;\r\nusing Microsoft.PowerPlatform.Dataverse.Client;\r\nusing Microsoft.Xrm.Sdk;\r\n\r\nvar onPrem = new OnPremiseClient(\"https://org.crm.contoso.com/XRMServices/2011/Organization.svc\", \"AD\\\\username\", \"password!\");\r\nvar online = new ServiceClient(\"AuthType=ClientSecret;Url=https://contoso.crm.dynamics.com;ClientId=637C79F7-AE71-4E9A-BD5B-1EC5EC9F397A;ClientSecret=p1UiydoIWwUH5AdMbiVBOrEYn8t4RXud\");\r\n\r\nCreateRecord(onPrem);\r\nCreateRecord(online);\r\n\r\nvoid CreateRecord(IOrganizationService svc)\r\n{\r\n  var entity = new Entity(\"account\")\r\n  {\r\n    [\"name\"] = \"Data8\"\r\n  };\r\n  \r\n  entity.Id = svc.Create(entity);\r\n}\r\n    ")]
[assembly: AssemblyFileVersion("2.3.1.0")]
[assembly: AssemblyInformationalVersion("2.3.1")]
[assembly: AssemblyProduct("Data8.PowerPlatform.Dataverse.Client")]
[assembly: AssemblyTitle("Data8.PowerPlatform.Dataverse.Client")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/Data8/DataverseClient")]
[assembly: AssemblyVersion("2.3.1.0")]
