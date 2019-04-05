#pragma checksum "C:\Nirali\Projects\SampleApp_SignalR\ChattingApp\ChattingApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18ae1f3c5c4f9c66eacf639e8403875087cdad9a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Nirali\Projects\SampleApp_SignalR\ChattingApp\ChattingApp\Views\_ViewImports.cshtml"
using ChattingApp;

#line default
#line hidden
#line 2 "C:\Nirali\Projects\SampleApp_SignalR\ChattingApp\ChattingApp\Views\_ViewImports.cshtml"
using ChattingApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18ae1f3c5c4f9c66eacf639e8403875087cdad9a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07bea8b5b23a4a2979506dbdee9eed99feff8be9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Nirali\Projects\SampleApp_SignalR\ChattingApp\ChattingApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 1209, true);
            WriteLiteral(@"

<div class=""panel panel-default topSpacePanel"" ng-app=""demoChatModule"">
    <div class=""panel-body"" ng-controller=""demoChatController"">
        <div class=""row"">
            <div class=""col-md-5"">
                <div class=""form-group"">
                    <label>User Name:</label>
                    <input type=""text"" id=""txtUserInput"" ng-model=""UserInput"" class=""form-control"" />
                </div>
            </div>
            <div class=""col-md-5"">
                <div class=""form-group"">
                    <label>Message:</label>
                    <input type=""text"" id=""txtMessageInput"" ng-model=""MessageInput"" class=""form-control"" />
                </div>
            </div>
            <div class=""col-md-2"" style=""margin-top:22px;"">
                <div class=""form-group"">
                    <input type=""button"" id=""sendButton"" ng-disabled=""btnSendMessage"" ng-click=""onSendBtnClick()"" value=""Send Message"" class=""btn btn-primary"" />
                </div>
            </div");
            WriteLiteral(">\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-6\">\r\n                <ul id=\"messagesList\"></ul>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1272, 1386, true);
                WriteLiteral(@"
    <script type=""text/javascript"">

        var app = angular.module('demoChatModule', []);
        app.controller('demoChatController', function ($scope) {

            var connection = new signalR.HubConnectionBuilder().withUrl(""/chatHub"").build();
            $scope.btnSendMessage = true;

            connection.on(""ReceiveMessage"", function (user, message) {
                debugger;
                var msg = message.replace(/&/g, ""&amp;"").replace(/</g, ""&lt;"").replace(/>/g, ""&gt;"");
                var encodedMsg = user + "" says "" + msg;
                var li = $(""<li></li>"").text(encodedMsg);
                $(""#messagesList"").append(li);
                $(""#txtUserInput"").val('');
                $(""#txtMessageInput"").val('');
            });

            connection.start().then(function () {
                $scope.btnSendMessage = false;
            }).catch(function (err) {
                return console.error(err.toString());
            });

            $scope.onSendBtnC");
                WriteLiteral(@"lick = function () {

                var getUserName = $scope.UserInput;
                var getMessage = $scope.MessageInput;

                connection.invoke(""SendMessagge"", getUserName, getMessage).catch(function (err) {
                    return console.error(err.toString());
                });

            }

        });
    </script>

");
                EndContext();
            }
            );
            BeginContext(2661, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
