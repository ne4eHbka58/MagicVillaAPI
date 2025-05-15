import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import AuthorizationPage from "./pages/AuthorizationPage";

const App = () => {
  return (
    <Router>
      <div className="app">
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
