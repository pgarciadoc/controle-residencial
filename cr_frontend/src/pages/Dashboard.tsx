import { useEffect, useState } from "react";
import { Box, Typography } from "@mui/material";

import DashboardCard from "../components/dashboard/DashboardCard";

import { listarPessoas } from "../services/pessoaService";
import { listarTransacoes } from "../services/transacaoService";
import { listarTotais } from "../services/totaisService";

import type { Pessoa } from "../types/Pessoa";
import type { Transacao } from "../types/Transacao";
import type { TotaisResponse } from "../types/TotaisResponse";
import UltimasTransacoesTable from "../components/dashboard/UltimasTransacoesTable";

export default function Dashboard() {

    const [pessoas, setPessoas] = useState<Pessoa[]>([]);
    const [transacoes, setTransacoes] = useState<Transacao[]>([]);
    const [totais, setTotais] = useState<TotaisResponse | null>(null);

    useEffect(() => {
        carregarDados();
    }, []);

    async function carregarDados() {

        const [pessoasData, transacoesData, totaisData] =
            await Promise.all([
                listarPessoas(),
                listarTransacoes(),
                listarTotais(),
            ]);

        setPessoas(pessoasData);
        setTransacoes(transacoesData);
        setTotais(totaisData);
    }

    if (!totais) {
        return <p>Carregando...</p>;
    }

    return (

        <Box>

            <Typography
                variant="h4"
                sx={{
                    mb: 4,
                    fontWeight: 700,
                }}
            >
                Dashboard
            </Typography>

            <Box
                sx={{
                    display: "flex",
                    gap: 3,
                }}
            >

                <DashboardCard
                    titulo="Pessoas"
                    valor={pessoas.length}
                />

                <DashboardCard
                    titulo="Transações"
                    valor={transacoes.length}
                />

                <DashboardCard
                    titulo="Saldo Líquido"
                    valor={totais.totalGeral.saldoLiquido.toLocaleString(
                        "pt-BR",
                        {
                            style: "currency",
                            currency: "BRL",
                        }
                    )}
                    color={
                        totais.totalGeral.saldoLiquido < 0
                            ? "error.main"
                            : "success.main"
                    }
                />

            </Box>

            <Typography
                variant="h5"
                sx={{
                    mt: 5,
                    mb: 2,
                    fontWeight: 600,
                }}
            >
                Últimas Transações
            </Typography>

            <UltimasTransacoesTable
                transacoes={[...transacoes]
                    .sort((a, b) => b.id - a.id)
                    .slice(0, 5)}
            />

        </Box>

    );
}