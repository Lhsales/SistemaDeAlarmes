#pragma checksum "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Log\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d15e690b59cc36227a88e7fc59617b3b8ba3309"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Log_Index), @"mvc.1.0.view", @"/Views/Log/Index.cshtml")]
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
#line 1 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\_ViewImports.cshtml"
using SistemaDeAlarmes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\_ViewImports.cshtml"
using SistemaDeAlarmes.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d15e690b59cc36227a88e7fc59617b3b8ba3309", @"/Views/Log/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a1dc3fa5170b536966dea8ae627b1542421d8ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Log_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Log>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Log\Index.cshtml"
  
    ViewData["Title"] = "Logs";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 5 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Log\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>

<div class=""card"">
    <div class=""card-body"">
        <table class=""table"">
            <thead>
                <tr>
                    <th>Ação</th>
                    <th>Tabela</th>
                    <th>Descrição</th>
                    <th>Data de criação</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 19 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Log\Index.cshtml"
                 foreach (Log l in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 22 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Log\Index.cshtml"
                       Write(l.Acao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 23 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Log\Index.cshtml"
                       Write(l.Tabela);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 24 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Log\Index.cshtml"
                       Write(l.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 25 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Log\Index.cshtml"
                       Write(l.DataCriacao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 27 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Log\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Log>> Html { get; private set; }
    }
}
#pragma warning restore 1591
