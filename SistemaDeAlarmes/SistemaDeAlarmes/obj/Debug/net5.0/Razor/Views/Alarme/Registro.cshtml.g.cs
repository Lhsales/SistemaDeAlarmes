#pragma checksum "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "517fe5eff09904f6d2b52ad1679397a352f36a3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Alarme_Registro), @"mvc.1.0.view", @"/Views/Alarme/Registro.cshtml")]
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
#nullable restore
#line 1 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
using SistemaDeAlarmes.Models.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"517fe5eff09904f6d2b52ad1679397a352f36a3d", @"/Views/Alarme/Registro.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a1dc3fa5170b536966dea8ae627b1542421d8ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Alarme_Registro : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewModelRegistroAlarme>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString("selected"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-select col-sm-8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Tipo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
  
    ViewData["Title"] = "Alarmes | " + Model.acao;

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 6 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 7 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
 using (Html.BeginForm(FormMethod.Post, new { @class = "form-horizontal" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
Write(Html.HiddenFor(model => model.alarme.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"hidden\" name=\"acao\"");
            BeginWriteAttribute("value", " value=\"", 326, "\"", 345, 1);
#nullable restore
#line 10 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
WriteAttributeValue("", 334, Model.acao, 334, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 11 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\">\r\n        <div class=\"card-body\">\r\n            ");
#nullable restore
#line 14 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
       Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"form-group\">\r\n                <label>Descrição</label>\r\n                ");
#nullable restore
#line 17 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
           Write(Html.EditorFor(model => model.alarme.Descricao, "Descricao", new { htmlAttributes = new { @class = "form-control col-sm-8" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 18 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
           Write(Html.ValidationMessageFor(model => model.alarme.Descricao, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label>Classificação</label>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "517fe5eff09904f6d2b52ad1679397a352f36a3d7807", async() => {
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "517fe5eff09904f6d2b52ad1679397a352f36a3d8087", async() => {
                    WriteLiteral("Selecione um tipo");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 22 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.alarme.Classificacao);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 22 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Html.GetEnumSelectList<ClassificacaoAlarme>();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
#nullable restore
#line 25 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
           Write(Html.ValidationMessageFor(model => model.alarme.Classificacao, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label>Equipamento relacionado</label>\r\n                ");
#nullable restore
#line 29 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
           Write(Html.DropDownList("equipamentoID", Model.equipamentos, htmlAttributes: new { @class = "form-select col-sm-8" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 30 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
           Write(Html.ValidationMessageFor(model => model.alarme.Descricao, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
            <div class=""form-group"">
                <div class=""col-md-offset-2 col-md-10"">
                    <input type=""submit"" value=""Registrar"" class=""btn btn-primary"" />
                </div>
            </div>
        </div>
    </div>
    <div class=""card-footer"">
        ");
#nullable restore
#line 40 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
   Write(Html.ActionLink("Voltar para lista", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 42 "C:\Lua\Projetos\SistemaDeAlarmes\SistemaDeAlarmes\SistemaDeAlarmes\Views\Alarme\Registro.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ViewModelRegistroAlarme> Html { get; private set; }
    }
}
#pragma warning restore 1591
