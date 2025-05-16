import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import AuthorizationPage from "./pages/AuthPage/Authorization";

const App = () => {
  return (
    <Router>
      <div>
        <main>
          <Routes>
            <Route path="/" element={<AuthorizationPage />} />
          </Routes>
        </main>
      </div>
    </Router>
  );
};

export default App;
