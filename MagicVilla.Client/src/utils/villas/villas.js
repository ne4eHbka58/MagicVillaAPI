"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.deleteVilla = exports.createVilla = exports.fetchVilla = exports.fetchVillas = void 0;
const ky_1 = __importDefault(require("ky"));
const fetchVillas = async () => {
    try {
        const response = await ky_1.default.get("https://localhost:7116/api/VillaAPI").json();
        return response;
    }
    catch (e) {
        console.log(e);
    }
};
exports.fetchVillas = fetchVillas;
const fetchVilla = async (id) => {
    var _a;
    try {
        const url = `https://localhost:7116/api/UserAPI/${id}`;
        const response = await ky_1.default.get(url);
        const data = await response.json();
        return data;
    }
    catch (error) {
        console.error("Ошибка при запросе виллы:", error);
        // Неизвестная ошибка
        return {
            statusCode: ((_a = error.response) === null || _a === void 0 ? void 0 : _a.status) || 500,
            isSuccess: false,
            result: null,
            errorMessages: ["Неизвестная ошибка"],
        };
    }
};
exports.fetchVilla = fetchVilla;
const createVilla = async (villaData) => {
    var _a;
    try {
        const response = await ky_1.default
            .post("https://localhost:7116/api/VillaAPI", {
            json: villaData,
        })
            .json();
        return response;
    }
    catch (error) {
        return {
            statusCode: ((_a = error.response) === null || _a === void 0 ? void 0 : _a.status) || 500,
            isSuccess: false,
            errorMessages: error,
            result: null,
        };
    }
};
exports.createVilla = createVilla;
const deleteVilla = async (id) => {
    var _a;
    try {
        const response = await ky_1.default
            .delete(`https://localhost:7116/api/VillaAPI/${id}`, {})
            .json();
        return response;
    }
    catch (error) {
        return {
            statusCode: ((_a = error.response) === null || _a === void 0 ? void 0 : _a.status) || 500,
            isSuccess: false,
            errorMessages: error,
            result: null,
        };
    }
};
exports.deleteVilla = deleteVilla;
