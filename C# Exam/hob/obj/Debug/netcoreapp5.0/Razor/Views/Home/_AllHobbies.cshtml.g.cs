#pragma checksum "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e1799157d005289dfba6f9a448b83c6e4b5dc96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__AllHobbies), @"mvc.1.0.view", @"/Views/Home/_AllHobbies.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e1799157d005289dfba6f9a448b83c6e4b5dc96", @"/Views/Home/_AllHobbies.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e696afdcfd195d400a2e691a8fbb56cd774485a6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__AllHobbies : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"table table-striped\">\r\n        <table>\r\n            <tr>\r\n                <th>Name</th>\r\n                <th>Creator</th>\r\n                <th>Enthusiasts</th>\r\n                <th>Actions</th>\r\n            </tr>\r\n");
#nullable restore
#line 10 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
              
                foreach(Hobby a in ViewBag.AllHobbies)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 384, "\"", 408, 2);
            WriteAttributeValue("", 391, "/hobby/", 391, 7, true);
#nullable restore
#line 14 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
WriteAttributeValue("", 398, a.HobbyId, 398, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 14 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
                                               Write(a.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                    <td>");
#nullable restore
#line 15 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
                   Write(a.Creator.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 16 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
                   Write(a.AssociatedHob.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 17 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
                      
                        if(@ViewBag.loggedIn.UserId == @a.CreatorId) //if loggedin user is the creator, delete
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td> <a");
            BeginWriteAttribute("href", " href=\"", 729, "\"", 759, 2);
            WriteAttributeValue("", 736, "hobby/delete/", 736, 13, true);
#nullable restore
#line 20 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
WriteAttributeValue("", 749, a.HobbyId, 749, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Delete</a></td>");
#nullable restore
#line 20 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
                                                                                                         ;
                        }
                        
                        if(@ViewBag.loggedIn.UserId != @a.CreatorId) //if loggedin user is not the creator, join or leave
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><a");
            BeginWriteAttribute("href", " href=\"", 1039, "\"", 1092, 4);
            WriteAttributeValue("", 1046, "hobby/join/", 1046, 11, true);
#nullable restore
#line 25 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
WriteAttributeValue("", 1057, a.HobbyId, 1057, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1067, "/", 1067, 1, true);
#nullable restore
#line 25 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
WriteAttributeValue("", 1068, ViewBag.loggedIn.UserId, 1068, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Join</a></td>");
#nullable restore
#line 25 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
                                                                                                                              ;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><a");
            BeginWriteAttribute("href", " href=\"", 1168, "\"", 1223, 4);
            WriteAttributeValue("", 1175, "/hobby/leave/", 1175, 13, true);
#nullable restore
#line 26 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
WriteAttributeValue("", 1188, a.HobbyId, 1188, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1198, "/", 1198, 1, true);
#nullable restore
#line 26 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
WriteAttributeValue("", 1199, ViewBag.loggedIn.UserId, 1199, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-dark\">Leave</a></td>");
#nullable restore
#line 26 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
                                                                                                                              ;
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 30 "C:\Users\pkaze\Desktop\hob\Views\Home\_AllHobbies.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
