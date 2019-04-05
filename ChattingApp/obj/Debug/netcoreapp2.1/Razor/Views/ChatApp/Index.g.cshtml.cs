#pragma checksum "C:\Nirali\Projects\SampleApp_SignalR\ChattingApp\ChattingApp\Views\ChatApp\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a11a51bcbc8fd198ab6cb42cc479214e5c74dedd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ChatApp_Index), @"mvc.1.0.view", @"/Views/ChatApp/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ChatApp/Index.cshtml", typeof(AspNetCore.Views_ChatApp_Index))]
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
#line 1 "C:\Nirali\Projects\SampleApp_SignalR\ChattingApp\ChattingApp\Views\ChatApp\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a11a51bcbc8fd198ab6cb42cc479214e5c74dedd", @"/Views/ChatApp/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07bea8b5b23a4a2979506dbdee9eed99feff8be9", @"/Views/_ViewImports.cshtml")]
    public class Views_ChatApp_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Nirali\Projects\SampleApp_SignalR\ChattingApp\ChattingApp\Views\ChatApp\Index.cshtml"
  
    ViewData["Title"] = "Chat Application ";

#line default
#line hidden
            BeginContext(88, 1658, true);
            WriteLiteral(@"

<div class=""topSpacePanel"" ng-app=""demoChatModule"">
    <div class=""panel panel-default"" ng-controller=""chatAppController"">
        <div class=""panel-heading text-center""><h4>Chat Application</h4></div>
        <div class=""panel-body"">
            <div class=""row"">
                <div class=""col-md-12 text-center"">
                    <span>Chat to {{GetTargetFullName}}</span>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-md-3"">
                    <div class=""vertical-menu"" ng-repeat=""lname in userNameList"">
                        <div>
                            <a style=""cursor:pointer;"" ng-model=""userNameModel"" ng-click=""GetUserNameClick(lname.userName,lname.fullName,lname.userId)"">{{lname.fullName}}</a>
                        </div>
                    </div>
                </div>
                <div class=""col-md-6"" ng-if=""clickOnLink == true"">
                    <input type=""text"" id=""txtMessageInput"" ng-model=""Messa");
            WriteLiteral(@"geInput"" style=""width:100%;"" class=""form-control"" />
                    <br />
                    <div class=""col-md-6"">
                        <ul id=""messagesList"">
                            <li ng-repeat=""mes in receiveMesList"">{{mes.message}}</li>
                        </ul>
                    </div>
                </div>
                <div class=""col-md-1"" ng-if=""clickOnLink == true"">
                    <input type=""button"" value=""Send"" ng-disabled=""btnSendMessage"" ng-click=""onSendBtnClick()"" class=""btn btn-primary"" />
                </div>
            </div>
        </div>
    </div>
</div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1764, 1913, true);
                WriteLiteral(@"

    <script type=""text/javascript"">
        var app = angular.module('demoChatModule', []);
        app.controller('chatAppController', function ($scope, ChatAppService) {

            $scope.userNameList = [];
            $scope.receiveMesList = [];
            $scope.clickOnLink = false;
            GetUserNameLoad();

            $scope.GetTargetUserName = """";
            $scope.GetTargetFullName = """";

            function GetUserNameLoad() {
                ChatAppService.GetUserData().then(function (userDetail) {
                    if (userDetail.data != null) {
                        $scope.userNameList = userDetail.data;
                    }
                });
            }
            function GetReceiverMessage(clickedUser) {
                ChatAppService.ReceiveUserMes(clickedUser).then(function (mesDetails) {
                    if (mesDetails.data != null) {
                        $scope.receiveMesList = mesDetails.data;
                    }
                });
                WriteLiteral(@"
            }

            var connection = new signalR.HubConnectionBuilder().withUrl(""/chatHub"").build();
            $scope.btnSendMessage = true;

           connection.start().then(function () {
                $scope.btnSendMessage = false;
            }).catch(function (err) {
                return console.error(err.toString());
             });

            connection.on(""ReceiveUserMessage"", function (message, senderUser) {
                var msg = message.replace(/&/g, ""&amp;"").replace(/</g, ""&lt;"").replace(/>/g, ""&gt;"");
                var encodedMsg = senderUser.fullName + "" says "" + msg;
                var li = $(""<li></li>"").text(encodedMsg);
                $(""#messagesList"").append(li);
                $(""#txtMessageInput"").val('');

            });

            $scope.onSendBtnClick = function () {
                var getLoginUser = '");
                EndContext();
                BeginContext(3678, 37, false);
#line 89 "C:\Nirali\Projects\SampleApp_SignalR\ChattingApp\ChattingApp\Views\ChatApp\Index.cshtml"
                               Write(Context.Session.GetString("UserName"));

#line default
#line hidden
                EndContext();
                BeginContext(3715, 1198, true);
                WriteLiteral(@"';
                var getMessage = $(""#txtMessageInput"").val();
                  connection.invoke(""DirectMessage"", getMessage, $scope.GetTargetUserName, getLoginUser).catch(function (err) {
                    return console.error(err.toString());
                });
            }

            $scope.GetUserNameClick = function (getClickedUserName, getFullName,getClickUserId) {
                $scope.GetTargetUserName = getClickedUserName;
                $scope.GetTargetFullName = getFullName;
                $scope.clickOnLink = true;
                $('#messagesList li').remove();
                GetReceiverMessage(getClickUserId);
                $(""#txtMessageInput"").val('');
            }

        });

        app.service('ChatAppService', function ($http) {
            this.GetUserData = function () {
                var request = $http.get(""/ChatApp/GetUserList"");
                return request;
            }

            this.ReceiveUserMes = function (receiverUserId) {
  ");
                WriteLiteral("              var request = $http.get(\"/ChatApp/GetUserMessages?userClickId=\" + receiverUserId);\r\n                return request;\r\n            }\r\n        });\r\n    </script>\r\n");
                EndContext();
            }
            );
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