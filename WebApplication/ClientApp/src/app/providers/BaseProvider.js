"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var rxjs_1 = require("rxjs");
var BaseProvider = /** @class */ (function () {
    function BaseProvider() {
        this.apiUrl = location.protocol + "//" + location.host + "/api";
    }
    //protected handleError<T>(error: any): Observable<T> {
    BaseProvider.prototype.handleError = function (error) {
        if (error)
            if (error.status == 500)
                return rxjs_1.throwError(error.error.title || "500 error");
            else
                return rxjs_1.throwError(error.error.title || "Eror " + error.status + ": " + String(error));
        return rxjs_1.throwError("Undefined error");
    };
    return BaseProvider;
}());
exports.BaseProvider = BaseProvider;
//# sourceMappingURL=BaseProvider.js.map