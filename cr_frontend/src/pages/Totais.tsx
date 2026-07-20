import { useEffect, useState } from "react";
import { listarTotais } from "../services/totaisService";
import type { TotaisResponse } from "../types/TotaisResponse";
import TotalCard from "../components/totais/TotalCard";
import Box from "@mui/material/Box";

export default function Totais() {

    const [dados, setDados] = useState<TotaisResponse | null>(null);

    useEffect(() => {
        carregarTotais();
    }, []);

    async function carregarTotais() {
        const response = await listarTotais();
        setDados(response);
    }

    if (!dados) {
        return <p>Carregando...</p>;
    }

    return (
            <Box
        sx={{
            display: "flex",
            gap: 3,
            mb: 4,
        }}
    >

        <TotalCard
            titulo="Receitas"
            valor={dados.totalGeral.totalReceitas}
        />

        <TotalCard
            titulo="Despesas"
            valor={dados.totalGeral.totalDespesas}
        />

        <TotalCard
            titulo="Saldo Líquido"
            valor={dados.totalGeral.saldoLiquido}
        />

    </Box>
    
    );
}