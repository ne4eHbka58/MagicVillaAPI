import React, { forwardRef, useRef } from "react";
import styles from "./AuthorizationForm.module.css";

const AuthorizationForm = () => {
  return (
    <div>
      <form className={styles.form}>
        <h2>Войти</h2>
        <input placeholder="Введите логин" />
        <br />
        <input placeholder="Введите пароль" />
        <br />
        <button>Войти</button>
        <h5 className={styles.registration}>Зарегистрироваться</h5>
      </form>
    </div>
  );
};

export default AuthorizationForm;
