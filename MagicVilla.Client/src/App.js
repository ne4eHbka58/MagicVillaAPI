import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import AuthorizationPage from "./pages/AuthPage/Authorization";
import VillasPage from "./pages/VillasPage/VillasPage";

const App = () => {
  return (
    <Router>
      <div>
        <main>
          <Routes>
            <Route path="/auth" element={<AuthorizationPage />} />
            <Route path="/" element={<VillasPage />} />
          </Routes>
        </main>
      </div>
    </Router>
  );
};

export default App;
