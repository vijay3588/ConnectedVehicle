#pragma checksum "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "794c9ae45cbf6420a0ae445354c0ea55fe056fd4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_CustomerDetails), @"mvc.1.0.view", @"/Views/Customer/CustomerDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Customer/CustomerDetails.cshtml", typeof(AspNetCore.Views_Customer_CustomerDetails))]
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
#line 1 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\_ViewImports.cshtml"
using ConnectVehicleWeb;

#line default
#line hidden
#line 2 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\_ViewImports.cshtml"
using ConnectVehicleWeb.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"794c9ae45cbf6420a0ae445354c0ea55fe056fd4", @"/Views/Customer/CustomerDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e7efe28b9357c4817f3a35be89c33c2575cec2f", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_CustomerDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ConnectVehicleWeb.Models.Customer>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
  
    ViewData["Title"] = "CustomerDetails";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(155, 146, true);
            WriteLiteral("\r\n<h2>Customer Details</h2>\r\n\r\n<table class=\"table table-bordered\">\r\n    <thead>\r\n        <tr class=\"success\">\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(302, 46, false);
#line 14 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.CustomerID));

#line default
#line hidden
            EndContext();
            BeginContext(348, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(404, 40, false);
#line 17 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(444, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(500, 43, false);
#line 20 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(543, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(599, 44, false);
#line 23 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.PostCode));

#line default
#line hidden
            EndContext();
            BeginContext(643, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(699, 40, false);
#line 26 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(739, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 32 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(857, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(906, 45, false);
#line 35 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.CustomerID));

#line default
#line hidden
            EndContext();
            BeginContext(951, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1007, 39, false);
#line 38 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1046, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1102, 42, false);
#line 41 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
            EndContext();
            BeginContext(1144, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1200, 43, false);
#line 44 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.PostCode));

#line default
#line hidden
            EndContext();
            BeginContext(1243, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1299, 39, false);
#line 47 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
            EndContext();
            BeginContext(1338, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1394, 67, false);
#line 50 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
           Write(Html.ActionLink("Details", "Details", new {  id=item.CustomerID  }));

#line default
#line hidden
            EndContext();
            BeginContext(1461, 37, true);
            WriteLiteral(" \r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 53 "C:\Users\vpalani2\source\repos\ConnectVehicleWeb\ConnectVehicleWeb\Views\Customer\CustomerDetails.cshtml"
}

#line default
#line hidden
            BeginContext(1501, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ConnectVehicleWeb.Models.Customer>> Html { get; private set; }
    }
}
#pragma warning restore 1591