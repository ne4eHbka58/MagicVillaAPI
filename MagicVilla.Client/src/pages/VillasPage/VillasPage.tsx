import React, { useEffect, useState } from "react";
import { useLocation, useSearchParams } from "react-router-dom";
import Header from "../../components/Header/Header";
import VillasList from "../../components/VillasList/VillasList";
import { fetchUser } from "../../utils/users/users";

interface UserData {
  name?: string;
  surname?: string;
  phoneNumber?: string;
  email?: string;
}

const VillasPage = () => {
  const location = useLocation();
  // const userData = location.state?.user;
  const userData = location.state?.user as UserData | undefined;
  console.log(userData);

  const userName = userData?.name;
  const userSurname = userData?.surname;
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

  return (
    <div>
      <Header name={userName} surname={userSurname} />
      <VillasList />
    </div>
  );
};

export default VillasPage;
