import React, { forwardRef, useRef, useState } from "react";
import styles from "./RegistrationForm.module.css";
import PhoneInput from "../PhoneInput/PhoneInput";

interface RegistrationFormProps {
  setIsRegistering: React.Dispatch<React.SetStateAction<boolean>>;
}

const RegistrationForm: React.FC<RegistrationFormProps> = ({
  setIsRegistering,
}) => {
  const onSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
  };

  const handleRegisterClick = (
    event: React.MouseEvent<HTMLButtonElement>
  ) => {};

  const handleSignInClick = (event: React.MouseEvent<HTMLAnchorElement>) => {
    event.preventDefault();
    setIsRegistering(false);
  };

  return (
    <form className={styles.form} onSubmit={onSubmit}>
      <h1 className={styles.bigLabel}>Зарегистрироваться</h1>
      <div>
        <input
          className={styles.input}
          placeholder="Фамилия"
          name="SurnameField"
          type="text"
        />
      </div>
      <div>
        <input
          className={styles.input}
          placeholder="Имя"
          name="NameField"
          type="text"
        />
      </div>
      <div>
        <PhoneInput className={styles.input} />
      </div>
      <div>
        <input
          className={styles.input}
          placeholder="Логин"
          name="LoginField"
          type="text"
        />
      </div>
      <div>
        <input
          className={styles.input}
          placeholder="Пароль"
          name="PasswordField"
          type="password"
        />
      </div>
      <div>
        <input
          className={styles.input}
          placeholder="Повторите пароль"
          name="SecondPasswordField"
          type="password"
        />
      </div>
      <button
        className={styles.button}
        onClick={handleRegisterClick}
        type="submit"
      >
        Зарегистрироваться
      </button>
      <p className={styles.label}>
        Уже зарегистрированы?{" "}
        <a className={styles.registrationLabel} onClick={handleSignInClick}>
          Войти
        </a>
      </p>
    </form>
  );
};

export default RegistrationForm;
