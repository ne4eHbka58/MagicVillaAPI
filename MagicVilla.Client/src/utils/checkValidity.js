"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.validatePasswords = exports.validateString = void 0;
var validateString = function (value, rules) {
    if (rules.required && !value) {
        return {
            isValid: false,
            errorMessage: "Это поле обязательно для заполнения.",
        };
    }
    if (rules.minLength && value.length < rules.minLength) {
        return {
            isValid: false,
            errorMessage: "\u0412 \u044D\u0442\u043E\u043C \u043F\u043E\u043B\u0435 \u0434\u043E\u043B\u0436\u043D\u043E \u0431\u044B\u0442\u044C \u043D\u0435 \u043C\u0435\u043D\u0435\u0435 ".concat(rules.minLength, " \u0441\u0438\u043C\u0432\u043E\u043B\u043E\u0432."),
        };
    }
    if (rules.maxLength && value.length > rules.maxLength) {
        return {
            isValid: false,
            errorMessage: "\u0412 \u044D\u0442\u043E\u043C \u043F\u043E\u043B\u0435 \u0434\u043E\u043B\u0436\u043D\u043E \u0431\u044B\u0442\u044C \u043D\u0435 \u0431\u043E\u043B\u0435\u0435 ".concat(rules.maxLength, " \u0441\u0438\u043C\u0432\u043E\u043B\u043E\u0432."),
        };
    }
    if (rules.pattern && !rules.pattern.test(value)) {
        return { isValid: false, errorMessage: "Неверный формат поля." };
    }
    return { isValid: true, errorMessage: "" };
};
exports.validateString = validateString;
var validatePasswords = function (value1, value2) {
    if (value1 !== value2) {
        return { isValid: false, errorMessage: "Пароли не совпадают." };
    }
    return { isValid: true, errorMessage: "" };
};
exports.validatePasswords = validatePasswords;
