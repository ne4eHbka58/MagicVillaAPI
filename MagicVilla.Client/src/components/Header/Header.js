"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const jsx_runtime_1 = require("react/jsx-runtime");
const Header_module_css_1 = __importDefault(require("./Header.module.css"));
const react_router_dom_1 = require("react-router-dom");
const Header = ({ name, surname }) => {
    return ((0, jsx_runtime_1.jsx)("div", { className: Header_module_css_1.default.header, children: (0, jsx_runtime_1.jsxs)("ul", { className: Header_module_css_1.default.headerList, children: [(0, jsx_runtime_1.jsxs)("li", { className: Header_module_css_1.default.headerElements, children: [(0, jsx_runtime_1.jsx)(react_router_dom_1.Link, { to: "/", className: Header_module_css_1.default.logo, children: "MagicVilla" }), (0, jsx_runtime_1.jsx)(react_router_dom_1.Link, { to: "/", className: Header_module_css_1.default.grayText, children: "\u0412\u0438\u043B\u043B\u044B" }), (0, jsx_runtime_1.jsx)(react_router_dom_1.Link, { to: "/", className: Header_module_css_1.default.grayText, children: "\u041D\u043E\u043C\u0435\u0440\u0430" })] }), name !== undefined && surname !== undefined ? ((0, jsx_runtime_1.jsxs)("li", { className: Header_module_css_1.default.headerElements, children: [(0, jsx_runtime_1.jsx)("span", { children: surname }), (0, jsx_runtime_1.jsx)("span", { children: name })] })) : ((0, jsx_runtime_1.jsxs)("li", { className: Header_module_css_1.default.headerElements, children: [(0, jsx_runtime_1.jsx)(react_router_dom_1.Link, { to: "/auth?mode=login", className: Header_module_css_1.default.blueText, children: "\u0412\u043E\u0439\u0442\u0438" }), (0, jsx_runtime_1.jsx)(react_router_dom_1.Link, { to: "/auth?mode=register", className: Header_module_css_1.default.blueText, children: "\u0417\u0430\u0440\u0435\u0433\u0438\u0441\u0442\u0440\u0438\u0440\u043E\u0432\u0430\u0442\u044C\u0441\u044F" })] }))] }) }));
};
exports.default = Header;
