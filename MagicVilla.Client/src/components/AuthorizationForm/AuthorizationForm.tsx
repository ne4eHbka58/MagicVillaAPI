import React, { forwardRef, useRef, useState, useEffect } from "react";
import styles from "./AuthorizationForm.module.css";
import LoginForm from "../LoginForm/LoginForm";
import RegistrationForm from "../RegistrationForm/RegistrationForm";

const AuthorizationForm = () => {
  const [isRegistering, setIsRegistering] = useState(false);

  useEffect(() => {
    console.log(isRegistering);
  }, []);

  const handleToggleForm = () => {
    setIsRegistering(!isRegistering);
  };

  const onSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
  };

  return (
    <div>
      {isRegistering ? (
        <RegistrationForm setIsRegistering={setIsRegistering} />
      ) : (
        <LoginForm setIsRegistering={setIsRegistering} />
      )}
    </div>
  );
};

export default AuthorizationForm;
