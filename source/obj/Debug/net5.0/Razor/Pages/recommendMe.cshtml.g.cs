#pragma checksum "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffb2e41e9839a01d647fbcf7c1d16ad4a46c0390"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Hypercorrect.Pages.Pages_recommendMe), @"mvc.1.0.razor-page", @"/Pages/recommendMe.cshtml")]
namespace Hypercorrect.Pages
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
#line 1 "C:\Users\hp\Desktop\TAMAMI\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hp\Desktop\TAMAMI\Pages\_ViewImports.cshtml"
using Hypercorrect;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hp\Desktop\TAMAMI\Pages\_ViewImports.cshtml"
using Hypercorrect.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffb2e41e9839a01d647fbcf7c1d16ad4a46c0390", @"/Pages/recommendMe.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"640ef8087da0bd8c6ac7fdfc988adc278059ce17", @"/Pages/_ViewImports.cshtml")]
    public class Pages_recommendMe : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background: linear-gradient(to bottom, #0f0c29, #302b63, #24243e); margin-top: 20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffb2e41e9839a01d647fbcf7c1d16ad4a46c03903743", async() => {
                WriteLiteral(@"
    <title>My Recommendations</title>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <link rel=""stylesheet"" href=""https://www.w3schools.com/w3css/4/w3.css"">
    <link rel=""stylesheet"" href=""https://www.w3schools.com/lib/w3-theme-black.css"">
    <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Roboto"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<style>
    html,
    body,
    h1,
    h2,
    h3,
    h4,
    h5,
    h6 {
        font-family: ""Roboto"", sans-serif;
    }

    body {
        background: linear-gradient(to bottom, #0f0c29, #302b63, #24243e);
    }

    .w3-sidebar {
        z-index: 3;
        width: 250px;
        top: 43px;
        bottom: 0;
        height: inherit;
    }

    .checked {
        color: orange;
    }

    .logo {
        display: inline-block;
        vertical-align: top;
        width: 35px;
        height: 35px;
        margin-right: 0px;
    }

    .bn48 {
        background: linear-gradient(90deg, #c7a0cf, #c52d28);
        background-size: auto;
        background-clip: border-box;
        -webkit-background-clip: text;
        background-clip: text;
        background-size: 300% 300%;
        -webkit-text-fill-color: transparent;
    }

    .container {
        max-width: unset;
        margin: auto;
        padding: 0;
        padding-top: 20px;
        paddin");
            WriteLiteral("g-left: 60px;\r\n        padding-right: 60px;\r\n    }\r\n</style>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffb2e41e9839a01d647fbcf7c1d16ad4a46c03906359", async() => {
                WriteLiteral(@"

    <!--<div class=""w3-top"">
        <div class=""w3-bar w3-white w3-wide w3-padding w3-card"">
            <img class=""logo"" src=""logo.jpeg"" style=""width: 30px; height:30px; left: 10px; top: 10px; position: absolute;"">
            <a href=""homepage.html"" class=""w3-bar-item w3-button"" style=""padding-left: 30px;"">HYPERCOR<b><u>REC</u></b>T</a>-->
    <!-- Float links to the right. Hide them on small screens -->
    <!--<div class=""w3-right w3-hide-small"">
                <a href=""papersyoulike.html"" class=""w3-bar-item w3-button"">Recommend Me</a>
                <a href=""favorites.html"" class=""w3-bar-item w3-button"">Favorites</a>
                <a href=""profile.html"" class=""w3-bar-item w3-button"">Profile</a>
                <a href=""homepage.html"" class=""w3-bar-item w3-button"">Log out</a>
            </div>j
        </div>
    </div>-->
    <!-- Main content: shift it to the right by 250 pixels when the sidebar is visible -->
    <div class=""w3-main"">
        <h2 style=""color: white; font-fami");
                WriteLiteral("ly: Oxygen, sans-serif\"><u>My Recommendations</u></h2> <br><br><br>\r\n");
#nullable restore
#line 88 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
         if (Model.new_paper_list != null && Model.new_paper_list.Count() > 0)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
             for (int i = 0; i < Model.new_paper_list.Count; i++)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                <div class=""w3-row w3-padding-16"">
                    <!-- <h1 style=""color: white;"">HYPERCOR<b><u>REC</u></b>T</h1> -->


                    <div class=""w3-twothird w3-container"">
                        <a style=""color: white; font-size: 23px;""");
                BeginWriteAttribute("href", " href=\"", 3300, "\"", 3429, 3);
                WriteAttributeValue("", 3307, "/paperDetail?paperId=", 3307, 21, true);
#nullable restore
#line 97 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
WriteAttributeValue("", 3328, (Model !=null&& Model.new_paper_list!=null) ? Model.new_paper_list[i].Id : -1, 3328, 80, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3408, "&selectedPageNumber=0", 3408, 21, true);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 97 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
                                                                                                                                                                                               Write(Html.DisplayFor(model => model.new_paper_list[i].Title));

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n                        <p style=\"color: white; font-family: \'Roboto\', sans-serif;\">\r\n                            ");
#nullable restore
#line 99 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
                       Write(Model.new_paper_list[i].Abstract);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
                WriteLiteral("                        </p>\r\n                    </div>\r\n                    <div class=\"w3-third w3-container\">\r\n                        <p class=\"w3-border w3-padding-large w3-padding-16 w3-center\">\r\n\r\n");
#nullable restore
#line 106 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
                             if (Model.new_paper_list[i].PublishedDate != null)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <i class=\"fa fa-calendar\" style=\"font-size:16px;color: white;\">\r\n                                    ");
#nullable restore
#line 109 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
                               Write(Model.new_paper_list[i].PublishedDate.Value.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </i> ");
#nullable restore
#line 110 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
                                     }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <i class=\"fa fa-calendar\" style=\"font-size:16px;color: white;\">\r\n                                    There is No Date in DB\r\n                                </i>");
#nullable restore
#line 115 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <!--<a style=\"font-size:14px;\" href=\"");
#nullable restore
#line 116 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
                                                            Write(Model.new_paper_list[i].GithubUrl);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"""><i class=""fa fa-github "" style=""background-color: #fff !important; font-size: 2em!important; ""></i> </a>
                            <button style=""font-size:24px;color:red""><i class=""fa fa-file-pdf-o""></i></button>-->
                            <a class=""btn btn-primary btn-sm""");
                BeginWriteAttribute("href", " href=\"", 4956, "\"", 4997, 1);
#nullable restore
#line 118 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
WriteAttributeValue("", 4963, Model.new_paper_list[i].GithubUrl, 4963, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> github</a>\r\n                            <a class=\"btn btn-primary btn-sm\"");
                BeginWriteAttribute("href", " href=\"", 5073, "\"", 5111, 1);
#nullable restore
#line 119 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
WriteAttributeValue("", 5080, Model.new_paper_list[i].PdfUrl, 5080, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> pdf</a>\r\n                            <!--<u>Model.db_cosine_similarities[i].Similarity</u>-->\r\n\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n                <p style=\"color:red\">Similarity Rate= ");
#nullable restore
#line 125 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
                                                 Write(Model.new_paper_list[i].Similarity);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n");
                WriteLiteral("                <hr size=\"10\" />\r\n");
#nullable restore
#line 128 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"

            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 129 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
             

        }
        else
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <br />\r\n            <h2 style=\"color: white; font-family: Oxygen, sans-serif\"><u>There are no Recommendations</u></h2> <br><br><br>\r\n");
#nullable restore
#line 136 "C:\Users\hp\Desktop\TAMAMI\Pages\recommendMe.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

        <!--<footer id=""myFooter"">-->
        <!-- <div class=""w3-container w3-theme-l2 w3-padding-32"">
            <h4>HYPERCORRECT</h4>
        </div> -->
        <!--<div class=""w3-container w3-theme-grey"" style=""left: 0%; position: absolute; width: 100%;"">
                <img class=""logo"" src=""logo2.png"" style=""width: 30px; height:30px; left: 3%; top: 8px; position: absolute;"">
                <p style=""color: white; padding-left: 55px;"">HYPERCORRECT</a></p>
            </div>
        </footer>-->
        <!-- END MAIN -->

    </div>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hypercorrect.Pages.recommendMeModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hypercorrect.Pages.recommendMeModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Hypercorrect.Pages.recommendMeModel>)PageContext?.ViewData;
        public Hypercorrect.Pages.recommendMeModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
