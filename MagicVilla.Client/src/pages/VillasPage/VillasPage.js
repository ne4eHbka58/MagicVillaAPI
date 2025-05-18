"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const jsx_runtime_1 = require("react/jsx-runtime");
const react_router_dom_1 = require("react-router-dom");
const Header_1 = __importDefault(require("../../components/Header/Header"));
const VillasList_1 = __importDefault(require("../../components/VillasList/VillasList"));
const VillasPage = () => {
    var _a;
    const location = (0, react_router_dom_1.useLocation)();
    // const userData = location.state?.user;
    const userData = (_a = location.state) === null || _a === void 0 ? void 0 : _a.user;
    console.log(userData);
    const userName = userData === null || userData === void 0 ? void 0 : userData.name;
    const userSurname = userData === null || userData === void 0 ? void 0 : userData.surname;
    // const [user, setUser] = useState<UserData>({
    //   name: null,
    //   surname: null,
    //   phoneNumber: null,
    //   email: null,
    // });
    // const [searchParams] = useSearchParams();
    // const email = searchParams.get("login");
    // const email = "test@test.ru";
    // useEffect(() => {
    //   const fetchUserFromApi = async (email: string) => {
    //     try {
    //       const userResponse = await fetchUser(email);
    //       if (userResponse.isSuccess && userResponse.result) {
    //         setUser({
    //           name: userResponse.result.name,
    //           surname: userResponse.result.surname,
    //           phoneNumber: userResponse.result.phoneNumber,
    //           email: userResponse.result.email,
    //         });
    //         console.log("Данные получены");
    //       }
    //     } catch (e: any) {
    //       console.log(e);
    //     }
    //   };
    //   if (email) {
    //     fetchUserFromApi(email);
    //   }
    // }, []);
    return ((0, jsx_runtime_1.jsxs)("div", { children: [(0, jsx_runtime_1.jsx)(Header_1.default, { name: userName, surname: userSurname }), (0, jsx_runtime_1.jsx)(VillasList_1.default, {})] }));
};
exports.default = VillasPage;
