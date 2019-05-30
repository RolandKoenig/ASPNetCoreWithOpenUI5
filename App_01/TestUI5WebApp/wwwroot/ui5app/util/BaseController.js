sap.ui.define([
	"sap/ui/core/mvc/Controller",
    'sap/m/Button',
    'sap/m/Text',
    'sap/m/Dialog'
], function (Controller, Button, Text, Dialog) {
    "use strict";
        return Controller.extend("rolandk.de.ui5test.util.BaseController", {

        getRouter: function () {
            return sap.ui.core.UIComponent.getRouterFor(this);
        },
    });
});