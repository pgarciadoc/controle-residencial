import { BrowserRouter, Routes, Route } from "react-router-dom";

import Layout from "../components/layout/Layout";

import Dashboard from "../pages/Dashboard";
import Pessoas from "../pages/Pessoas";
import Transacoes from "../pages/Transacoes";
import Totais from "../pages/Totais";

export default function AppRoutes() {
    return (
        <BrowserRouter>
            <Layout>
                <Routes>
                    <Route path="/" element={<Dashboard />} />
                    <Route path="/pessoas" element={<Pessoas />} />
                    <Route path="/transacoes" element={<Transacoes />} />
                    <Route path="/totais" element={<Totais />} />
                </Routes>
            </Layout>
        </BrowserRouter>
    );
}