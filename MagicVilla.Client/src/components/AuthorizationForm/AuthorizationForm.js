"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
var jsx_runtime_1 = require("react/jsx-runtime");
var react_1 = require("react");
var LoginForm_1 = __importDefault(require("../LoginForm/LoginForm"));
var RegistrationForm_1 = __importDefault(require("../RegistrationForm/RegistrationForm"));
var AuthorizationForm = function () {
    var _a = (0, react_1.useState)(false), isRegistering = _a[0], setIsRegistering = _a[1];
    (0, react_1.useEffect)(function () {
        console.log(isRegistering);
    }, []);
    var handleToggleForm = function () {
        setIsRegistering(!isRegistering);
    };
    var onSubmit = function (event) {
        event.preventDefault();
    };
    return ((0, jsx_runtime_1.jsx)("div", { children: isRegistering ? ((0, jsx_runtime_1.jsx)(RegistrationForm_1.default, { setIsRegistering: setIsRegistering })) : ((0, jsx_runtime_1.jsx)(LoginForm_1.default, { setIsRegistering: setIsRegistering })) }));
};
exports.default = AuthorizationForm;
