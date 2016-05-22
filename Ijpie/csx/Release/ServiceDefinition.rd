<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="Ijpie" generation="1" functional="0" release="0" Id="805dc89a-b737-463a-9f03-c9d7f7fd2445" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="IjpieGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="Ijepai.Web:HttpIn" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/Ijpie/IjpieGroup/LB:Ijepai.Web:HttpIn" />
          </inToChannel>
        </inPort>
        <inPort name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/Ijpie/IjpieGroup/LB:Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Certificate|Ijepai.Web:IjepaiLatest" defaultValue="">
          <maps>
            <mapMoniker name="/Ijpie/IjpieGroup/MapCertificate|Ijepai.Web:IjepaiLatest" />
          </maps>
        </aCS>
        <aCS name="Certificate|Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" defaultValue="">
          <maps>
            <mapMoniker name="/Ijpie/IjpieGroup/MapCertificate|Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:APPINSIGHTS_INSTRUMENTATIONKEY" defaultValue="">
          <maps>
            <mapMoniker name="/Ijpie/IjpieGroup/MapIjepai.Web:APPINSIGHTS_INSTRUMENTATIONKEY" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/Ijpie/IjpieGroup/MapIjepai.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="">
          <maps>
            <mapMoniker name="/Ijpie/IjpieGroup/MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="">
          <maps>
            <mapMoniker name="/Ijpie/IjpieGroup/MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="">
          <maps>
            <mapMoniker name="/Ijpie/IjpieGroup/MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/Ijpie/IjpieGroup/MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/Ijpie/IjpieGroup/MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </maps>
        </aCS>
        <aCS name="Ijepai.Web:StorageConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/Ijpie/IjpieGroup/MapIjepai.Web:StorageConnectionString" />
          </maps>
        </aCS>
        <aCS name="Ijepai.WebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/Ijpie/IjpieGroup/MapIjepai.WebInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:Ijepai.Web:HttpIn">
          <toPorts>
            <inPortMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/HttpIn" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput">
          <toPorts>
            <inPortMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </toPorts>
        </lBChannel>
        <sFSwitchChannel name="SW:Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp">
          <toPorts>
            <inPortMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
          </toPorts>
        </sFSwitchChannel>
      </channels>
      <maps>
        <map name="MapCertificate|Ijepai.Web:IjepaiLatest" kind="Identity">
          <certificate>
            <certificateMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/IjepaiLatest" />
          </certificate>
        </map>
        <map name="MapCertificate|Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" kind="Identity">
          <certificate>
            <certificateMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </certificate>
        </map>
        <map name="MapIjepai.Web:APPINSIGHTS_INSTRUMENTATIONKEY" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/APPINSIGHTS_INSTRUMENTATIONKEY" />
          </setting>
        </map>
        <map name="MapIjepai.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </setting>
        </map>
        <map name="MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </setting>
        </map>
        <map name="MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </setting>
        </map>
        <map name="MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </setting>
        </map>
        <map name="MapIjepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </setting>
        </map>
        <map name="MapIjepai.Web:StorageConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/StorageConnectionString" />
          </setting>
        </map>
        <map name="MapIjepai.WebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/Ijpie/IjpieGroup/Ijepai.WebInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="Ijepai.Web" generation="1" functional="0" release="0" software="C:\Users\Bhawini\Downloads\Ijepai-Poc\Ijepai-Poc\Ijepai-Poc\Ijpie\csx\Release\roles\Ijepai.Web" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="HttpIn" protocol="http" portRanges="80" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp" portRanges="3389" />
              <outPort name="Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/Ijpie/IjpieGroup/SW:Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="APPINSIGHTS_INSTRUMENTATIONKEY" defaultValue="" />
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
                  <certificateMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/IjepaiLatest" />
                </certificate>
              </storedCertificate>
              <storedCertificate name="Stored1Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" certificateStore="My" certificateLocation="System">
                <certificate>
                  <certificateMoniker name="/Ijpie/IjpieGroup/Ijepai.Web/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
                </certificate>
              </storedCertificate>
            </storedcertificates>
            <certificates>
              <certificate name="IjepaiLatest" />
              <certificate name="Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
            </certificates>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/Ijpie/IjpieGroup/Ijepai.WebInstances" />
            <sCSPolicyUpdateDomainMoniker name="/Ijpie/IjpieGroup/Ijepai.WebUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/Ijpie/IjpieGroup/Ijepai.WebFaultDomains" />
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
    <implementation Id="77668185-f637-4c69-9055-bc19bfb125ea" ref="Microsoft.RedDog.Contract\ServiceContract\IjpieContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="ce73387c-567d-4138-b63c-b23959192d7a" ref="Microsoft.RedDog.Contract\Interface\Ijepai.Web:HttpIn@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/Ijpie/IjpieGroup/Ijepai.Web:HttpIn" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="2af984ed-9bcb-4f6d-9830-c532e29a720b" ref="Microsoft.RedDog.Contract\Interface\Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/Ijpie/IjpieGroup/Ijepai.Web:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>