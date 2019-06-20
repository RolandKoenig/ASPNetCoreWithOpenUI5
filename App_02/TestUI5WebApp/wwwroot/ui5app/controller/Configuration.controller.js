sap.ui.define([
    "rolandk/de/ui5test/util/BaseController",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageToast"
], function (BaseController, JSONModel, MessageToast) {
	"use strict";
	return BaseController.extend("rolandk.de.ui5test.controller.Configuration",
        {
            onInit: function () {
	            let oModel = new JSONModel();
	            oModel.loadData("/api/configuration");

	            let oView = this.getView();
	            oView.setModel(oModel);

                // Enables automatic property validation on the ui
                //  see https://help.sap.com/doc/saphelp_uiaddon20/2.05/en-US/91/f0652b6f4d1014b6dd926db0e91070/content.htm?no_cache=true
                sap.ui.getCore().getMessageManager().registerObject(oView, true);
            },

            onApplyClick: function() {
                let oView = this.getView();
                let oModel = oView.getModel();

                let oData = oModel.getData();
                let sData = JSON.stringify(oData);
                jQuery.ajax({
                    type: "PUT",
                    contentType: "application/json",
                    data: sData,
                    url: "/api/configuration",
                    dataType: "json",
                    success: function() {
	                    MessageToast.show("Saved", {
		                    duration: 3000,
		                    width: "80%"
	                    });
                    },
                    error: function() {
	                    MessageToast.show("Error!", {
		                    duration: 3000,
		                    width: "80%"
	                    });
                    }
                });
            },

            /**
             * Resets all data to the state at the backend
             */
            onResetClick: function() {
	            let oModel = new sap.ui.model.json.JSONModel();
	            oModel.loadData("/api/configuration");

	            let oView = this.getView();
	            oView.setModel(oModel);
            }
		});
});