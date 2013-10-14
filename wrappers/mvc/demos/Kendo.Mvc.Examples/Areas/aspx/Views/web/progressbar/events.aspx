﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/aspx/Views/Shared/Web.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div class="configuration k-widget k-header" style="width: 300px">
    <span class="infoHead">Information</span>
    <p>
        This example shows how to handle events triggered by Kendo UI ProgressBar.
    </p>
</div>
<div style="width: 45%">
    <div class="demo-section">
        <%= Html.Kendo().ProgressBar()
              .Name("progressBar")
              .Min(0)
              .Max(10)
              .Type(ProgressBarType.Percent)
              .Animation(a => a.Duration(400))
              .Events(events => events
                .Start("onStart")
                .Change("onChange")
                .Complete("onComplete")
              )
        %>
    <button id="startProgress" class="k-button">Start</button>
    </div>
</div>

<div class="demo-section" style="margin-top: 50px;">
    <h3 class="title">Console log
    </h3>
    <div class="console"></div>
</div>

<script>
    function onStart(e) {
        kendoConsole.log("Start event :: value is " + e.value);
    }

    function onChange(e) {
        kendoConsole.log("Change event :: value is " + e.value);
    }

    function onComplete(e) {
        kendoConsole.log("Complete event :: value is " + e.value);
    }

    $("#startProgress").click(function () {
        var pb = $("#progressBar").data("kendoProgressBar");

        var interval = setInterval(function () {
            if (pb.value() < 10) {
                pb.value(pb.value() + 1);
            } else {
                clearInterval(interval);
            }
        }, 400);
    });
</script>

</asp:Content>