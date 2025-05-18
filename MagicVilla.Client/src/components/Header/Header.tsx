import React, { useEffect } from "react";
import styles from "./Header.module.css";
import { Link } from "react-router-dom";

const Header = ({ name, surname }: { name?: string; surname?: string }) => {
  return (
    <div className={styles.header}>
      <ul className={styles.headerList}>
        <li className={styles.headerElements}>
          <Link to="/" className={styles.logo}>
            MagicVilla
          </Link>
          <Link to="/" className={styles.grayText}>
            Виллы
          </Link>
          <Link to="/" className={styles.grayText}>
            Номера
          </Link>
        </li>
        {name !== undefined && surname !== undefined ? (
          <li className={styles.headerElements}>
            <span>{surname}</span>
            <span>{name}</span>
          </li>
        ) : (
          <li className={styles.headerElements}>
            <Link to="/auth?mode=login" className={styles.blueText}>
              Войти
            </Link>
            <Link to="/auth?mode=register" className={styles.blueText}>
              Зарегистрироваться
            </Link>
          </li>
        )}
      </ul>
    </div>
  );
};

export default Header;
