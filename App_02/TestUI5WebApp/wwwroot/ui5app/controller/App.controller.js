sap.ui.define([
	"rolandk/de/ui5test/util/BaseController",
    'sap/ui/Device'
 ], function(BaseController, Device) {
	"use strict";
      return BaseController.extend("rolandk.de.ui5test.controller.App",
		{
            _bExpanded: true,
            _sLastDevice: "",

            onInit: function() {

	            Device.media.attachHandler(function (oDevice) {

                    if (oDevice.name === "Phone") {
                        // Do not handle phone device

                    } else if(this._sLastDevice !== oDevice.name) {
                        this._sLastDevice = oDevice.name;

                        if ((oDevice.name === "Tablet" && this._bExpanded) ||
	                        (oDevice.name === "Desktop" && !this._bExpanded)) {

	                        this.onSideNavButtonPress();
                        }
                    }
                    
                }.bind(this));
            },

            onSideNavButtonPress: function () {
                let oToolPage = this.byId("app");
                this._bExpanded = !oToolPage.getSideExpanded();
                oToolPage.setSideExpanded(this._bExpanded);
            },

            onItemSelect: function (oEvent) {
	            let oItem = oEvent.getParameter('item');
	            let sKey = oItem.getKey();

		        if (Device.system.phone) {
			        this.onSideNavButtonPress();
                }

		        this.getRouter().navTo(sKey);
            },
		});
});