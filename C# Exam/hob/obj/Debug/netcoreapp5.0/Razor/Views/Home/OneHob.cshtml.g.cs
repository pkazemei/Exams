#pragma checksum "C:\Users\pkaze\Desktop\hob\Views\Home\OneHob.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d661d5aa4441b6654d5db99cf5be00e055c7689"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_OneHob), @"mvc.1.0.view", @"/Views/Home/OneHob.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\pkaze\Desktop\hob\Views\_ViewImports.cshtml"
using Hob;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pkaze\Desktop\hob\Views\_ViewImports.cshtml"
using Hob.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d661d5aa4441b6654d5db99cf5be00e055c7689", @"/Views/Home/OneHob.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e696afdcfd195d400a2e691a8fbb56cd774485a6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_OneHob : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Hobby>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 3 "C:\Users\pkaze\Desktop\hob\Views\Home\OneHob.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<br>\r\n<div>\r\n    <h4>Hobby Creator: </h4>\r\n        <p>");
#nullable restore
#line 7 "C:\Users\pkaze\Desktop\hob\Views\Home\OneHob.cshtml"
      Write(Model.Creator.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p><br>\r\n\r\n    <h4>Description: </h4>\r\n        <p>");
#nullable restore
#line 10 "C:\Users\pkaze\Desktop\hob\Views\Home\OneHob.cshtml"
      Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p><br>\r\n\r\n    <h4>Enthusiasts: </h4>\r\n");
#nullable restore
#line 13 "C:\Users\pkaze\Desktop\hob\Views\Home\OneHob.cshtml"
          
            foreach(Association a in Model.AssociatedHob)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>");
#nullable restore
#line 16 "C:\Users\pkaze\Desktop\hob\Views\Home\OneHob.cshtml"
               Write(a.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 17 "C:\Users\pkaze\Desktop\hob\Views\Home\OneHob.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hobby> Html { get; private set; }
    }
}
#pragma warning restore 1591
