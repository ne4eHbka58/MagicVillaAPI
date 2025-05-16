import React, { forwardRef, useRef, useState } from "react";
import styles from "./LoginForm.module.css";

interface LoginFormProps {
  setIsRegistering: React.Dispatch<React.SetStateAction<boolean>>;
}

const LoginForm: React.FC<LoginFormProps> = ({ setIsRegistering }) => {
  const onSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
  };

  const handleSingInClick = (event: React.MouseEvent<HTMLButtonElement>) => {};

  const handleRegistrationClick = (
    event: React.MouseEvent<HTMLAnchorElement>
  ) => {
    event.preventDefault();
    setIsRegistering(true);
  };

  return (
    <form className={styles.form} onSubmit={onSubmit}>
      <h1 className={styles.bigLabel}>Войти</h1>
      <div>
        <input
          className={styles.input}
          placeholder="Почта"
          name="EmailField"
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
      <button
        className={styles.button}
        onClick={handleSingInClick}
        type="submit"
      >
        Войти
      </button>
      <p className={styles.label}>
        Ещё нет аккаунта?{" "}
        <a
          className={styles.registrationLabel}
          onClick={handleRegistrationClick}
        >
          Зарегистрироваться
        </a>
      </p>
    </form>
  );
};

export default LoginForm;
