import React from "react";
import styles from "./AuthPage.module.css";
import AuthorizationForm from "../../components/AuthorizationForm/AuthorizationForm";
const AuthorizationPage = () => {
  return (
    <div className={styles.page}>
      <AuthorizationForm />
    </div>
  );
};

export default AuthorizationPage;
