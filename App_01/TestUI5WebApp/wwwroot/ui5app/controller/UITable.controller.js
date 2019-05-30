sap.ui.define([
	"rolandk/de/ui5test/util/BaseController",
    "sap/ui/model/json/JSONModel",
    "sap/ui/model/odata/OperationMode"
], function(BaseController) {
	"use strict";
	return BaseController.extend("rolandk.de.ui5test.controller.UITable",
		{
			onInit: function() {
				// Adding service to the odata model
				var oModel = new sap.ui.model.odata.v4.ODataModel({
					serviceUrl: "/odata/",
					synchronizationMode: "None",
					operationMode: "Server"
				});

				var oView = this.getView();
				oView.setModel(oModel);
			},
		});
});