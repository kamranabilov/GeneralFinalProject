#pragma checksum "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcc12b5bb33d0ce4804e25226ff4074ee98efdd4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
#line 1 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\_ViewImports.cshtml"
using FianlProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\_ViewImports.cshtml"
using FianlProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcc12b5bb33d0ce4804e25226ff4074ee98efdd4", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bac18c83759d217635662195c9303629c2695427", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "removecartitem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cart-remove-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("cart-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "default", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "AZ", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("shipping-calculator"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
  
    ViewData["Title"] = "Index";


#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
  
    decimal totalprice = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Main start -->

<main>
    <section>
        <div class=""about"">
            <div class=""container"">
                <div class=""row g-4"">
                    <div class=""col-sm-12 g-4"">
                        <div class=""about-title"">
                            <span>
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fcc12b5bb33d0ce4804e25226ff4074ee98efdd48361", async() => {
                WriteLiteral("Home ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </span>
                            >
                            <span> Cart</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class=""cartt"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fcc12b5bb33d0ce4804e25226ff4074ee98efdd410134", async() => {
                WriteLiteral(@"
                        <table class=""shop_cart responsive table-bordered"" cellspacing=""0"" data-id=""10389"">
                            <thead>
                                <tr>
                                    <th class=""product-remove""></th>
                                    <th class=""product-thumbnail""></th>
                                    <th class=""product-name"">
                                        Product
                                    </th>
                                    <th class=""product-price"">
                                        Price
                                    </th>
                                    <th class=""product-quantity"">
                                        Quantity
                                    </th>
                                    <th class=""product-subtotal"">
                                        Subtotal
                                    </th>
                                </tr>
                           ");
                WriteLiteral(" </thead>\r\n                            <tbody class=\"cart-items text-center\">\r\n");
#nullable restore
#line 56 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
                                foreach(var item in layoutService.ShowBasket().Result.BasketItems)
                               {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <span style=\"display:none\">");
#nullable restore
#line 58 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
                                                           Write(totalprice += item.Furniture.Price * item.Quantity);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                    <tr id=\"yith-wcwl-row-1322\" data-row-id=\"1322\">\r\n                                        <td class=\"removeitem remove\">\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fcc12b5bb33d0ce4804e25226ff4074ee98efdd412464", async() => {
                    WriteLiteral("\r\n                                                <span style=\"background-color:#fff; color:red; border-radius: 100%;\">X</span>\r\n                                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
                                                                                                   WriteLiteral(item.Furniture.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                        </td>
                                        <td class=""product-thumbnail"">
                                            <a href=""#"">
                                                <img width=""300"" height=""300""");
                BeginWriteAttribute("src", " src=\"", 3078, "\"", 3123, 2);
                WriteAttributeValue("", 3084, "assets/image/shop/", 3084, 18, true);
#nullable restore
#line 67 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
WriteAttributeValue("", 3102, item.Furniture.Image, 3102, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                                                 class=\"attachment-woocommerce_thumbnail size-woocommerce_thumbnail\"");
                BeginWriteAttribute("alt", "\r\n                                                 alt=\"", 3242, "\"", 3298, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                            </a>
                                        </td>
                                        <td class=""product-name"">
                                            <a href=""#"">
                                               ");
#nullable restore
#line 74 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
                                          Write(item.Furniture.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </a>
                                        </td>
                                        <td class=""product-price"">
                                            <span class=""Price-amount amount"">
                                                $");
#nullable restore
#line 79 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
                                            Write(item.Furniture.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                            </span>\r\n                                        </td>\r\n                                        <td class=\"product-quantity\" >\r\n                                            <a data-id=\"");
#nullable restore
#line 83 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
                                                   Write(item.Furniture.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" style=\"cursor:pointer;\" class=\"down\" id=\"downbtn\"><i class=\"fas fa-chevron-left\"></i></a>\r\n                            <span class=\"inp-value\" style=\"cursor:pointer;\">");
#nullable restore
#line 84 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
                                                                       Write(item.Quantity);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                            <a data-id=\"");
#nullable restore
#line 85 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
                                                   Write(item.Furniture.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""" style=""cursor:pointer;"" class=""up"" id=""upbtn""><i class=""fas fa-chevron-right""></i></a>
                                        </td>
                                        <td class=""product-subtotal"" data-title=""Subtotal"">
                                            <span style=""font-size: 1.25rem;
    font-weight: 500;"">
                                                $
                                                <span style=""font-size: 1.25rem;
    font-weight: 500;""> <span data-id=""");
#nullable restore
#line 92 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
                                  Write(item.Furniture.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" class=\"money-t\"> ");
#nullable restore
#line 92 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
                                                                        Write((item.Quantity * item.Furniture.Price).ToString("f0"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></span>\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 95 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
                               }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <tr>
                                    <td colspan=""6"" class=""actions"">
                                        <div class=""coupon"">
                                            <label for=""coupon_code"">Coupon:</label>
                                            <input type=""text"" name=""coupon_code"" class=""input-text""
                                                   id=""coupon_code""");
                BeginWriteAttribute("value", " value=\"", 5585, "\"", 5593, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Coupon code"">
                                            <button type=""submit"" class=""button"" name=""apply_coupon""
                                                    value=""Apply coupon"">
                                                Apply coupon
                                            </button>
                                        </div>
                                        <a class=""button"" style=""cursor:pointer;"" name=""update_cart"" value=""Update cart""
                                                aria-disabled=""false"">
                                            Update cart
                                        </a>
                                        <input type=""hidden"">
                                        <input type=""hidden"" value=""/marketov2/furniture/cart/"">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    <div class=""cart-collaterals"">
                        <div class=""cart_totals calculated_shipping"">
                            <h2>Cart totals</h2>
                            <table cellspacing=""0"" class=""shop_table shop_table_responsive table"">
                                <tbody class=""text-center"">
");
            WriteLiteral(@"                                    <tr class=""shipping-total"" style=""border-width:thin;"">
                                        <th style=""padding-top:65px;"">Shipping</th>
                                        <td class=""ship text-center"">
                                            <ul id=""shipping_method"" class=""ship-method"">
                                                <li>
                                                    <input type=""hidden""");
            BeginWriteAttribute("value", " value=\"", 7847, "\"", 7855, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                                    <label for=""shipping_method_0_free_shipping2"">
                                                        Free
                                                        shipping
                                                    </label>
                                                </li>
                                            </ul>
                                            <p>
                                                Shipping to <strong>Baku</strong>
                                            </p>
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fcc12b5bb33d0ce4804e25226ff4074ee98efdd424718", async() => {
                WriteLiteral(@"
                                                <a class=""csta"" href=""#"" style=""text-decoration:none;"">
                                                    Change address <i class=""fa-solid fa-car-side""></i>
                                                </a>
                                                <section class=""calculator-form d-none"">
                                                    <p class=""form-row"" id=""calc_shipping_country_field"">
                                                        <select name=""calc_shipping_country""
                                                                id=""calc_shipping_country"" class=""border-0"">
                                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fcc12b5bb33d0ce4804e25226ff4074ee98efdd425721", async() => {
                    WriteLiteral("Select a country");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fcc12b5bb33d0ce4804e25226ff4074ee98efdd427015", async() => {
                    WriteLiteral("Azerbajan");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                                        </select>
                                                        <a href=""#"" class=""buttonA"">Update</a>
                                                    </p>
                                                </section>
                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        </td>
                                    </tr>
                                    <tr class=""order-total"">
                                        <th style=""padding-top:21px;"">Total</th>
                                        <td data-title=""Total"">
                                            <span style=""font-size:2rem;"">
                                                $
                                                <span style=""font-size:2rem;"" class=""total_price""> <span>");
#nullable restore
#line 168 "F:\1.1.FinalProject\FianlProject\FianlProject\Views\Cart\Index.cshtml"
                                                                                                    Write(totalprice.ToString("f0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></span>
                                            </span>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div class=""proceedd"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fcc12b5bb33d0ce4804e25226ff4074ee98efdd431096", async() => {
                WriteLiteral("\r\n                                    Send to checkout\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
</main>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
<script>
    $(document).ready(function () {


        $(document).on(""click"", "".down"", function (e) {
            e.preventDefault();
            var id = $(this).attr(""data-id"")
            var total = document.querySelector("".total_price"")
            var money = document.querySelectorAll("".money-t"")
            var quantity = document.querySelector("".inp-value"")

            $.ajax({
                url: ""/cart/decrease"",
                data: {
                    id: id
                },
                type: ""post"",
                datatype: ""json"",
                success: function (data) {
                    money.forEach(mon => {
                        if (id == mon.getAttribute(""data-id"")) {
             ");
            WriteLiteral(@"               mon.innerHTML = data.price
                        }
                    })
                    total.innerHTML = `${data.totalPrice}`
                    quantity.innerHTML = `${data.Quantity}`

                }
            })

        })


        $(document).on(""click"", "".up"", function (e) {
            e.preventDefault();
            var id = $(this).attr(""data-id"")

            var total = document.querySelector("".total_price"")
            var money = document.querySelectorAll("".money-t"")
            console.log(id)
            $.ajax({
                url: ""/cart/increase"",
                data: {
                    id: id
                },
                type: ""post"",
                datatype: ""json"",
                success: function (data) {
                    money.forEach(mon => {
                        if (id == mon.getAttribute(""data-id"")) {
                            mon.innerHTML = data.price
                            console.log(data.price)");
            WriteLiteral(@"
                        }
                    })
                    total.innerHTML = `${data.totalPrice}`

                }
            })

        })


    })

</script>
<script src=""//cdn.jsdelivr.net/npm/sweetalert2@11""></script>
<script>
    $("".cart-remove-btn"").click(function (e) {
        e.preventDefault()
        console.log($(this).attr(""href""))
        Swal.fire({
            title: 'Are you sure?',
            text: ""You won't be able to revert this!"",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                var link = $(this).attr(""href"");
                fetch(link).then(response => response.json()).then(data => {
                    if (data.status == 200) {
                        location.reload(true)
                    } else {
      ");
            WriteLiteral(@"                  Swal.fire(
                            'Not found!',
                            'Your file can not be deleted.',
                            'Failed'
                        )
                    }
                });
            }
        })
    })
</script>

<!-- main end -->

");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public FianlProject.Services.LayoutService layoutService { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
