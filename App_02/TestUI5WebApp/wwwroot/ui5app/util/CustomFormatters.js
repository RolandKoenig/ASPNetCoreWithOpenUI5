// Custom formatters class like the implementation here: 
//   https://help.sap.com/doc/saphelp_uiaddon20/2.05/en-US/0f/8626ed7b7542ffaa44601828db20de/content.htm?no_cache=true

sap.ui.define([], function () {
	"use strict";
    return {
        /**
         * Converts a string representation of a DateTime object to a readably datetime for the user
         * @param {String} sDateTime The DateTime in typical json format (example: "1995-12-17T02:24:00.000")
         */
        jsonDateTime: function (sDateTime) {
            let oJSDate = new Date(sDateTime);
            return oJSDate.toLocaleString();
        }
	};
});