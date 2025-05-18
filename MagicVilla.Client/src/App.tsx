import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import AuthPage from "./pages/AuthPage/AuthPage";
import VillasPage from "./pages/VillasPage/VillasPage";

const App: React.FC = () => {
  return (
    <div>
      <main>
        <BrowserRouter>
          <Routes>
            <Route path="/auth" element={<AuthPage />} />
            <Route path="/" element={<VillasPage />} />
          </Routes>
        </BrowserRouter>
      </main>
    </div>
  );
};

export default App;
