//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Reflection.AssemblyVersionAttribute("1.0.0.0")]
[assembly: global::System.Reflection.AssemblyProductAttribute("prototypeBoardConnectionTest")]
[assembly: global::System.Reflection.AssemblyTitleAttribute("prototypeBoardConnectionTest")]
[assembly: global::Microsoft.Dss.Core.Attributes.ServiceDeclarationAttribute(global::Microsoft.Dss.Core.Attributes.DssServiceDeclaration.Transform, SourceAssemblyKey="prototypeBoardConnectionTest.Y2012.M10, Version=1.0.0.0, Culture=neutral, PublicK" +
    "eyToken=c4ad29636fb3ed1b")]
[assembly: global::System.Security.SecurityTransparentAttribute()]
[assembly: global::System.Security.SecurityRulesAttribute(global::System.Security.SecurityRuleSet.Level1)]

namespace Dss.Transforms.TransformprototypeBoardConnectionTest {
    
    
    public class Transforms : global::Microsoft.Dss.Core.Transforms.TransformBase {
        
        static Transforms() {
            Register();
        }
        
        public static void Register() {
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddProxyTransform(typeof(global::prototypeBoardConnectionTest.Proxy.prototypeBoardConnectionTestState), new global::Microsoft.Dss.Core.Attributes.Transform(prototypeBoardConnectionTest_Proxy_prototypeBoardConnectionTestState_TO_prototypeBoardConnectionTest_prototypeBoardConnectionTestState));
            global::Microsoft.Dss.Core.Transforms.TransformBase.AddSourceTransform(typeof(global::prototypeBoardConnectionTest.prototypeBoardConnectionTestState), new global::Microsoft.Dss.Core.Attributes.Transform(prototypeBoardConnectionTest_prototypeBoardConnectionTestState_TO_prototypeBoardConnectionTest_Proxy_prototypeBoardConnectionTestState));
        }
        
        private static global::prototypeBoardConnectionTest.Proxy.prototypeBoardConnectionTestState _cachedInstance0 = new global::prototypeBoardConnectionTest.Proxy.prototypeBoardConnectionTestState();
        
        private static global::prototypeBoardConnectionTest.prototypeBoardConnectionTestState _cachedInstance = new global::prototypeBoardConnectionTest.prototypeBoardConnectionTestState();
        
        public static object prototypeBoardConnectionTest_Proxy_prototypeBoardConnectionTestState_TO_prototypeBoardConnectionTest_prototypeBoardConnectionTestState(object transformFrom) {
            return _cachedInstance;
        }
        
        public static object prototypeBoardConnectionTest_prototypeBoardConnectionTestState_TO_prototypeBoardConnectionTest_Proxy_prototypeBoardConnectionTestState(object transformFrom) {
            return _cachedInstance0;
        }
    }
}
