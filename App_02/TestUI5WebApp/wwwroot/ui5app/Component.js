sap.ui.define([
    "sap/ui/core/UIComponent"
 ], function (UIComponent) {
    "use strict";
    return UIComponent.extend("rolandk.de.ui5test.Component", {
        metadata : {
            manifest: "json",
            rootView: "rolandk.de.ui5test.view.App"
        },

        init : function () {
            // call the init function of the parent
            UIComponent.prototype.init.apply(this, arguments);

            var oRouter = this.getRouter();
            oRouter.initialize();
       }
    });
 });