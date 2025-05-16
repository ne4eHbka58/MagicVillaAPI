"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
var jsx_runtime_1 = require("react/jsx-runtime");
var LoginForm_module_css_1 = __importDefault(require("./LoginForm.module.css"));
var LoginForm = function (_a) {
    var setIsRegistering = _a.setIsRegistering;
    var onSubmit = function (event) {
        event.preventDefault();
    };
    var handleSingInClick = function (event) { };
    var handleRegistrationClick = function (event) {
        event.preventDefault();
        setIsRegistering(true);
    };
    return ((0, jsx_runtime_1.jsxs)("form", { className: LoginForm_module_css_1.default.form, onSubmit: onSubmit, children: [(0, jsx_runtime_1.jsx)("h1", { className: LoginForm_module_css_1.default.bigLabel, children: "\u0412\u043E\u0439\u0442\u0438" }), (0, jsx_runtime_1.jsx)("div", { children: (0, jsx_runtime_1.jsx)("input", { className: LoginForm_module_css_1.default.input, placeholder: "\u041B\u043E\u0433\u0438\u043D", name: "LoginField", type: "text" }) }), (0, jsx_runtime_1.jsx)("div", { children: (0, jsx_runtime_1.jsx)("input", { className: LoginForm_module_css_1.default.input, placeholder: "\u041F\u0430\u0440\u043E\u043B\u044C", name: "PasswordField", type: "password" }) }), (0, jsx_runtime_1.jsx)("button", { className: LoginForm_module_css_1.default.button, onClick: handleSingInClick, type: "submit", children: "\u0412\u043E\u0439\u0442\u0438" }), (0, jsx_runtime_1.jsxs)("p", { className: LoginForm_module_css_1.default.label, children: ["\u0415\u0449\u0451 \u043D\u0435\u0442 \u0430\u043A\u043A\u0430\u0443\u043D\u0442\u0430?", " ", (0, jsx_runtime_1.jsx)("a", { className: LoginForm_module_css_1.default.registrationLabel, onClick: handleRegistrationClick, children: "\u0417\u0430\u0440\u0435\u0433\u0438\u0441\u0442\u0440\u0438\u0440\u043E\u0432\u0430\u0442\u044C\u0441\u044F" })] })] }));
};
exports.default = LoginForm;
