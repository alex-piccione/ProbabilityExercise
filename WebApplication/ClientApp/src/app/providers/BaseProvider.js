"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var rxjs_1 = require("rxjs");
var BaseProvider = /** @class */ (function () {
    function BaseProvider() {
        this.apiUrl = location.protocol + "//" + location.host + "/api";
    }
    BaseProvider.prototype.handleError = function (error) {
        if (error)
            return rxjs_1.throwError(error.error.title || error.status + " error" + " " + error.error.detail || "");
        return rxjs_1.throwError("Undefined error: " + String(error));
    };
    return BaseProvider;
}());
exports.BaseProvider = BaseProvider;
//# sourceMappingURL=BaseProvider.js.map