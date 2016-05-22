<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="Ijepai.Web.Azure" generation="1" functional="0" release="0" Id="4b992cb9-d783-4ea0-bc35-65b22fdf853c" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="Ijepai.Web.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="Ijepai.Web:HttpIn" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/LB:Ijepai.Web:HttpIn" />
          </inToChannel>
        </inPort>
        <inPort name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/LB:Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Certificate|Ijepai.Web:IjepaiLatest" defaultValue="">
          <maps>
            <mapMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/MapCertificate|Ijepai.Web:IjepaiLatest" />
          </maps>
        </aCS>
        <aCS name="Certificate|Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" defaultValue="">
          <maps>
            <mapMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/MapCertificate|Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/MapIjepai.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="">
          <maps>
            <mapMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="">
          <maps>
            <mapMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="">
          <maps>
            <mapMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:StorageConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/MapIjepai.Web:StorageConnectionString" />
          </maps>
        </aCS>
        <aCS name="Ijepai.WebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/MapIjepai.WebInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:Ijepai.Web:HttpIn">
          <toPorts>
            <inPortMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/HttpIn" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput">
          <toPorts>
            <inPortMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </toPorts>
        </lBChannel>
        <sFSwitchChannel name="SW:Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp">
          <toPorts>
            <inPortMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
          </toPorts>
        </sFSwitchChannel>
      </channels>
      <maps>
        <map name="MapCertificate|Ijepai.Web:IjepaiLatest" kind="Identity">
          <certificate>
            <certificateMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/IjepaiLatest" />
          </certificate>
        </map>
        <map name="MapCertificate|Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" kind="Identity">
          <certificate>
            <certificateMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </certificate>
        </map>
        <map name="MapIjepai.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </setting>
        </map>
        <map name="MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </setting>
        </map>
        <map name="MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </setting>
        </map>
        <map name="MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </setting>
        </map>
        <map name="MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </setting>
        </map>
        <map name="MapIjepai.Web:StorageConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/StorageConnectionString" />
          </setting>
        </map>
        <map name="MapIjepai.WebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.WebInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="Ijepai.Web" generation="1" functional="0" release="0" software="C:\Users\Bhawini\Documents\GitHub\Ijepai-Poc\Ijepai.Web.Azure\csx\Debug\roles\Ijepai.Web" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="HttpIn" protocol="http" portRanges="80" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp" portRanges="3389" />
              <outPort name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/SW:Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="" />
              <aCS name="StorageConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;Ijepai.Web&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;Ijepai.Web&quot;&gt;&lt;e name=&quot;HttpIn&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
            <storedcertificates>
              <storedCertificate name="Stored0IjepaiLatest" certificateStore="My" certificateLocation="System">
                <certificate>
                  <certificateMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/IjepaiLatest" />
                </certificate>
              </storedCertificate>
              <storedCertificate name="Stored1Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" certificateStore="My" certificateLocation="System">
                <certificate>
                  <certificateMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
                </certificate>
              </storedCertificate>
            </storedcertificates>
            <certificates>
              <certificate name="IjepaiLatest" />
              <certificate name="Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
            </certificates>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.WebInstances" />
            <sCSPolicyUpdateDomainMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.WebUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.WebFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="Ijepai.WebUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="Ijepai.WebFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="Ijepai.WebInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="ee5a6b15-2ea1-4886-9633-e7c4349ca6bb" ref="Microsoft.RedDog.Contract\ServiceContract\Ijepai.Web.AzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="627af26d-3107-44a9-9652-41b53f0c0f57" ref="Microsoft.RedDog.Contract\Interface\Ijepai.Web:HttpIn@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web:HttpIn" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="f5e81084-3460-4b5a-a4f9-c02b55afd97c" ref="Microsoft.RedDog.Contract\Interface\Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/Ijepai.Web.Azure/Ijepai.Web.AzureGroup/Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>