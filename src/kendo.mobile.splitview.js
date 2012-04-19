(function($, undefined) {
    var kendo = window.kendo,
        ui = kendo.mobile.ui,
        Widget = ui.Widget,
        View = ui.View;

    /**
     * @name kendo.mobile.ui.SplitView.Description
     *
     */
    var SplitView = View.extend(/** @lends kendo.mobile.ui.SplitView.prototype */{
        /**
        * @constructs
        * @extends kendo.mobile.ui.Widget
        * @param {DomElement} element DOM element
        */
        init: function(element, options) {
            var that = this;

            Widget.fn.init.call(that, element, options);
            $.extend(that, options);
            that._layout();
            that._model();
            that._init();
        },

        // Implement view interface
        _layout: function() {
            var that = this,
                element = that.element;

            element.data("kendoView", that).addClass("km-view km-splitview");

            that.transition = element.data(kendo.ns + "transition");
            $.extend(that, { header: [], footer: [], content: element });
        },

        options: {
            name: "SplitView"
        }
    });

    /**
     * @name kendo.mobile.ui.Pane.Description
     *
     */
    var Pane = View.extend(/** @lends kendo.mobile.ui.Pane.prototype */{
        /**
        * @constructs
        * @extends kendo.mobile.ui.Widget
        * @param {DomElement} element DOM element
        */
        init: function(element, options) {
            var that = this;

            Widget.fn.init.call(that, element, options);

            that.element.addClass("km-pane");
        },

        options: {
            name: "Pane"
        }
    });

    ui.plugin(SplitView);
    ui.plugin(Pane);
})(jQuery);
