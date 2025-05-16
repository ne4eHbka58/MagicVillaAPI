"use strict";
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
var jsx_runtime_1 = require("react/jsx-runtime");
var react_1 = require("react");
var RegistrationForm_module_css_1 = __importDefault(require("./RegistrationForm.module.css"));
var PhoneInput_1 = __importDefault(require("../PhoneInput/PhoneInput"));
var checkValidity_1 = require("../../utils/checkValidity");
var RegistrationForm = function (_a) {
    var setIsRegistering = _a.setIsRegistering;
    var _b = (0, react_1.useState)({
        surname: "",
        name: "",
        phone: "",
        email: "",
        password: "",
        confirmPassword: "",
    }), formData = _b[0], setFormData = _b[1];
    var _c = (0, react_1.useState)({
        surname: "",
        name: "",
        phone: "",
        email: "",
        password: "",
        confirmPassword: "",
    }), errors = _c[0], setErrors = _c[1];
    var handleBlur = function (e) {
        var _a;
        var _b = e.target, name = _b.name, value = _b.value;
        setFormData(__assign(__assign({}, formData), (_a = {}, _a[name] = value, _a)));
    };
    var onSubmit = function (event) {
        event.preventDefault();
        console.log(formData);
        var isValid = true;
        var newErrors = {
            surname: "",
            name: "",
            phone: "",
            email: "",
            password: "",
            confirmPassword: "",
        }; // объект с текстом ошибок
        // Валидация фамилии
        var surnameValidation = (0, checkValidity_1.validateString)(formData.surname, {
            required: true,
            minLength: 3,
            maxLength: 30,
        });
        if (!surnameValidation.isValid) {
            newErrors.surname = surnameValidation.errorMessage;
            isValid = false;
        }
        // Валидация имени
        var nameValidation = (0, checkValidity_1.validateString)(formData.name, {
            required: true,
            minLength: 3,
            maxLength: 30,
        });
        if (!nameValidation.isValid) {
            newErrors.name = nameValidation.errorMessage;
            isValid = false;
        }
        // Валидация номера телефона
        var phoneValidation = (0, checkValidity_1.validateString)(formData.phone, {
            required: true,
            pattern: /^\+7\s\(\d{3}\)\s\d{3}-\d{2}-\d{2}$/,
        });
        if (!phoneValidation.isValid) {
            newErrors.phone = phoneValidation.errorMessage;
            isValid = false;
        }
        // Валидация почты
        var emailValidation = (0, checkValidity_1.validateString)(formData.email, {
            required: true,
            pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
            minLength: 3,
            maxLength: 30,
        });
        if (!emailValidation.isValid) {
            newErrors.email = emailValidation.errorMessage;
            isValid = false;
        }
        // Валидация пароля
        var passwordValidation = (0, checkValidity_1.validateString)(formData.password, {
            required: true,
            minLength: 3,
            maxLength: 30,
        });
        if (!passwordValidation.isValid) {
            newErrors.password = passwordValidation.errorMessage;
            isValid = false;
        }
        // Валидация подтверждения пароля
        var confirmPasswordValidation = (0, checkValidity_1.validatePasswords)(formData.password, formData.confirmPassword);
        if (!confirmPasswordValidation.isValid) {
            newErrors.confirmPassword = confirmPasswordValidation.errorMessage;
            isValid = false;
        }
        setErrors(newErrors);
        if (isValid) {
            console.log("Form Data:", formData);
        }
    };
    var handleRegisterClick = function (event) { };
    var handleSignInClick = function (event) {
        event.preventDefault();
        setIsRegistering(false);
    };
    return ((0, jsx_runtime_1.jsxs)("form", { className: RegistrationForm_module_css_1.default.form, onSubmit: onSubmit, children: [(0, jsx_runtime_1.jsx)("h1", { className: RegistrationForm_module_css_1.default.bigLabel, children: "\u0417\u0430\u0440\u0435\u0433\u0438\u0441\u0442\u0440\u0438\u0440\u043E\u0432\u0430\u0442\u044C\u0441\u044F" }), (0, jsx_runtime_1.jsxs)("div", { children: [(0, jsx_runtime_1.jsx)("input", { className: RegistrationForm_module_css_1.default.input, placeholder: "\u0424\u0430\u043C\u0438\u043B\u0438\u044F", name: "surname", type: "text", onBlur: handleBlur }), errors.surname && (0, jsx_runtime_1.jsx)("div", { className: RegistrationForm_module_css_1.default.error, children: errors.surname })] }), (0, jsx_runtime_1.jsxs)("div", { children: [(0, jsx_runtime_1.jsx)("input", { className: RegistrationForm_module_css_1.default.input, placeholder: "\u0418\u043C\u044F", name: "name", type: "text", onBlur: handleBlur }), errors.name && (0, jsx_runtime_1.jsx)("div", { className: RegistrationForm_module_css_1.default.error, children: errors.name })] }), (0, jsx_runtime_1.jsxs)("div", { children: [(0, jsx_runtime_1.jsx)(PhoneInput_1.default, { className: RegistrationForm_module_css_1.default.input, onBlur: handleBlur }), errors.phone && (0, jsx_runtime_1.jsx)("div", { className: RegistrationForm_module_css_1.default.error, children: errors.phone })] }), (0, jsx_runtime_1.jsxs)("div", { children: [(0, jsx_runtime_1.jsx)("input", { className: RegistrationForm_module_css_1.default.input, placeholder: "\u041F\u043E\u0447\u0442\u0430", name: "email", type: "text", onBlur: handleBlur }), errors.email && (0, jsx_runtime_1.jsx)("div", { className: RegistrationForm_module_css_1.default.error, children: errors.email })] }), (0, jsx_runtime_1.jsxs)("div", { children: [(0, jsx_runtime_1.jsx)("input", { className: RegistrationForm_module_css_1.default.input, placeholder: "\u041F\u0430\u0440\u043E\u043B\u044C", name: "password", type: "password", onBlur: handleBlur }), errors.password && ((0, jsx_runtime_1.jsx)("div", { className: RegistrationForm_module_css_1.default.error, children: errors.password }))] }), (0, jsx_runtime_1.jsxs)("div", { children: [(0, jsx_runtime_1.jsx)("input", { className: RegistrationForm_module_css_1.default.input, placeholder: "\u041F\u043E\u0432\u0442\u043E\u0440\u0438\u0442\u0435 \u043F\u0430\u0440\u043E\u043B\u044C", name: "confirmPassword", type: "password", onBlur: handleBlur }), errors.confirmPassword && ((0, jsx_runtime_1.jsx)("div", { className: RegistrationForm_module_css_1.default.error, children: errors.confirmPassword }))] }), (0, jsx_runtime_1.jsx)("button", { className: RegistrationForm_module_css_1.default.button, onClick: handleRegisterClick, type: "submit", children: "\u0417\u0430\u0440\u0435\u0433\u0438\u0441\u0442\u0440\u0438\u0440\u043E\u0432\u0430\u0442\u044C\u0441\u044F" }), (0, jsx_runtime_1.jsxs)("p", { className: RegistrationForm_module_css_1.default.label, children: ["\u0423\u0436\u0435 \u0437\u0430\u0440\u0435\u0433\u0438\u0441\u0442\u0440\u0438\u0440\u043E\u0432\u0430\u043D\u044B?", " ", (0, jsx_runtime_1.jsx)("a", { className: RegistrationForm_module_css_1.default.registrationLabel, onClick: handleSignInClick, children: "\u0412\u043E\u0439\u0442\u0438" })] })] }));
};
exports.default = RegistrationForm;
