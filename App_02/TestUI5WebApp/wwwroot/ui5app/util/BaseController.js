sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"rolandk/de/ui5test/util/CustomFormatters"
], function (Controller, CustomFormatters) {
    "use strict";
        return Controller.extend("rolandk.de.ui5test.util.BaseController", {

            formatters: CustomFormatters,

            getRouter: function () {
                return sap.ui.core.UIComponent.getRouterFor(this);
            },
    });
});