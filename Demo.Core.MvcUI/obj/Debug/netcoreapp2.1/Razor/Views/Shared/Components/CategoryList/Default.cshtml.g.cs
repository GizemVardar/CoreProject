#pragma checksum "C:\Users\orcun\Desktop\DemoCoreProject\Demo.Core.MvcUI\Views\Shared\Components\CategoryList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fddbc0683d231183e204cee763c915c5b614c6b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Root_Namespace.Pages.Shared.Components.CategoryList.Views_Shared_Components_CategoryList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CategoryList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/CategoryList/Default.cshtml", typeof(Root_Namespace.Pages.Shared.Components.CategoryList.Views_Shared_Components_CategoryList_Default))]
namespace Root_Namespace.Pages.Shared.Components.CategoryList
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\orcun\Desktop\DemoCoreProject\Demo.Core.MvcUI\Views\_ViewImports.cshtml"
using Root_Namespace;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fddbc0683d231183e204cee763c915c5b614c6b3", @"/Views/Shared/Components/CategoryList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"905534a19a0854b76597a3585060f35736163dd6", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CategoryList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Demo.Core.MvcUI.Models.CategoryListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 28, true);
            WriteLiteral("<div class=\"list-group\">\r\n\r\n");
            EndContext();
#line 4 "C:\Users\orcun\Desktop\DemoCoreProject\Demo.Core.MvcUI\Views\Shared\Components\CategoryList\Default.cshtml"
     foreach(var item in Model.Categories)
    {
        var css = "list-group-item";
        if (item.CategoryID == Model.CurrentCategory)
        {
            css += "active";
        }

#line default
#line hidden
            BeginContext(275, 10, true);
            WriteLiteral("        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 285, "\"", 333, 2);
            WriteAttributeValue("", 292, "/product/index?/category=", 292, 25, true);
#line 11 "C:\Users\orcun\Desktop\DemoCoreProject\Demo.Core.MvcUI\Views\Shared\Components\CategoryList\Default.cshtml"
WriteAttributeValue("", 317, item.CategoryID, 317, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 334, "\"", 346, 1);
#line 11 "C:\Users\orcun\Desktop\DemoCoreProject\Demo.Core.MvcUI\Views\Shared\Components\CategoryList\Default.cshtml"
WriteAttributeValue("", 342, css, 342, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(347, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(349, 17, false);
#line 11 "C:\Users\orcun\Desktop\DemoCoreProject\Demo.Core.MvcUI\Views\Shared\Components\CategoryList\Default.cshtml"
                                                                    Write(item.CategoryName);

#line default
#line hidden
            EndContext();
            BeginContext(366, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 12 "C:\Users\orcun\Desktop\DemoCoreProject\Demo.Core.MvcUI\Views\Shared\Components\CategoryList\Default.cshtml"
    }

#line default
#line hidden
            BeginContext(379, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Demo.Core.MvcUI.Models.CategoryListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591