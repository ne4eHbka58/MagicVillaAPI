"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
var jsx_runtime_1 = require("react/jsx-runtime");
var RegistrationForm_module_css_1 = __importDefault(require("./RegistrationForm.module.css"));
var PhoneInput_1 = __importDefault(require("../PhoneInput/PhoneInput"));
var RegistrationForm = function (_a) {
    var setIsRegistering = _a.setIsRegistering;
    var onSubmit = function (event) {
        event.preventDefault();
    };
    var handleRegisterClick = function (event) { };
    var handleSignInClick = function (event) {
        event.preventDefault();
        setIsRegistering(false);
    };
    return ((0, jsx_runtime_1.jsxs)("form", { className: RegistrationForm_module_css_1.default.form, onSubmit: onSubmit, children: [(0, jsx_runtime_1.jsx)("h1", { className: RegistrationForm_module_css_1.default.bigLabel, children: "\u0417\u0430\u0440\u0435\u0433\u0438\u0441\u0442\u0440\u0438\u0440\u043E\u0432\u0430\u0442\u044C\u0441\u044F" }), (0, jsx_runtime_1.jsx)("div", { children: (0, jsx_runtime_1.jsx)("input", { className: RegistrationForm_module_css_1.default.input, placeholder: "\u0424\u0430\u043C\u0438\u043B\u0438\u044F", name: "SurnameField", type: "text" }) }), (0, jsx_runtime_1.jsx)("div", { children: (0, jsx_runtime_1.jsx)("input", { className: RegistrationForm_module_css_1.default.input, placeholder: "\u0418\u043C\u044F", name: "NameField", type: "text" }) }), (0, jsx_runtime_1.jsx)("div", { children: (0, jsx_runtime_1.jsx)(PhoneInput_1.default, { className: RegistrationForm_module_css_1.default.input }) }), (0, jsx_runtime_1.jsx)("div", { children: (0, jsx_runtime_1.jsx)("input", { className: RegistrationForm_module_css_1.default.input, placeholder: "\u041B\u043E\u0433\u0438\u043D", name: "LoginField", type: "text" }) }), (0, jsx_runtime_1.jsx)("div", { children: (0, jsx_runtime_1.jsx)("input", { className: RegistrationForm_module_css_1.default.input, placeholder: "\u041F\u0430\u0440\u043E\u043B\u044C", name: "PasswordField", type: "password" }) }), (0, jsx_runtime_1.jsx)("div", { children: (0, jsx_runtime_1.jsx)("input", { className: RegistrationForm_module_css_1.default.input, placeholder: "\u041F\u043E\u0432\u0442\u043E\u0440\u0438\u0442\u0435 \u043F\u0430\u0440\u043E\u043B\u044C", name: "SecondPasswordField", type: "password" }) }), (0, jsx_runtime_1.jsx)("button", { className: RegistrationForm_module_css_1.default.button, onClick: handleRegisterClick, type: "submit", children: "\u0417\u0430\u0440\u0435\u0433\u0438\u0441\u0442\u0440\u0438\u0440\u043E\u0432\u0430\u0442\u044C\u0441\u044F" }), (0, jsx_runtime_1.jsxs)("p", { className: RegistrationForm_module_css_1.default.label, children: ["\u0423\u0436\u0435 \u0437\u0430\u0440\u0435\u0433\u0438\u0441\u0442\u0440\u0438\u0440\u043E\u0432\u0430\u043D\u044B?", " ", (0, jsx_runtime_1.jsx)("a", { className: RegistrationForm_module_css_1.default.registrationLabel, onClick: handleSignInClick, children: "\u0412\u043E\u0439\u0442\u0438" })] })] }));
};
exports.default = RegistrationForm;
