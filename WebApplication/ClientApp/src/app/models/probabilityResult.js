"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ProbabilityResult = /** @class */ (function () {
    function ProbabilityResult(isSuccess, errors, probability) {
        this.isSuccess = isSuccess;
        this.errors = errors;
        this.probability = probability;
    }
    ProbabilityResult.Ok = function (probability) { return new ProbabilityResult(true, [], probability); };
    ProbabilityResult.Error = function (errors) { return new ProbabilityResult(false, errors, undefined); };
    return ProbabilityResult;
}());
exports.ProbabilityResult = ProbabilityResult;
//# sourceMappingURL=probabilityResult.js.map