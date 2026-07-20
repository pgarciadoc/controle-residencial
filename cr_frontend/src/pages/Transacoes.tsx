import { useEffect, useState } from "react";
import { criarTransacao, listarTransacoes } from "../services/transacaoService";
import type { Transacao } from "../types/Transacao";
import { Alert, Box, Button, Snackbar, Typography } from "@mui/material";
import TransacaoTable from "../components/transacao/TransacaoTable";
import TransacaoDialog from "../components/transacao/TransacaoDialog";
import type { Pessoa } from "../types/Pessoa";
import { listarPessoas } from "../services/pessoaService";
import axios from "axios";


export default function Transacoes() {

    const [transacoes, setTransacoes] = useState<Transacao[]>([]);  
    const [openDialog, setOpenDialog] = useState(false);
    const [pessoas, setPessoas] = useState<Pessoa[]>([]);
    const [snackbarOpen, setSnackbarOpen] = useState(false);
    const [snackbarMessage, setSnackbarMessage] = useState("");
    const [snackbarSeverity, setSnackbarSeverity] = useState<"success" | "error">("success");


    useEffect(() => {
        carregarTransacoes();
        carregarPessoas();
    }, []);


    async function carregarTransacoes() {

        const dados = await listarTransacoes();

        setTransacoes(dados);

    }


    async function carregarPessoas() {
        const dados = await listarPessoas();
        setPessoas(dados);
    }


    async function salvarTransacao(
        descricao: string,
        valor: number,
        tipo: number,
        pessoaId: number
    ) {
        try {

            await criarTransacao(
                descricao,
                valor,
                tipo,
                pessoaId
            );

            carregarTransacoes();
            setOpenDialog(false);
            setSnackbarSeverity("success");
            setSnackbarMessage("Transação cadastrada com sucesso!");
            setSnackbarOpen(true);

        }catch (error) {

            if (axios.isAxiosError(error)) {

                setSnackbarMessage(
                    error.response?.data?.mensagem ??
                    "Erro ao cadastrar transação."
                );

            } else {
                console.log(error);
                setSnackbarMessage("Erro inesperado.");
            }

            setSnackbarSeverity("error");
            setSnackbarOpen(true);
        }

    }

    

    return (
    <Box sx={{ width: "100%" }}>

            <Box
                sx={{
                    display: "flex",
                    justifyContent: "space-between",
                    alignItems: "center",
                    mb: 3,
                }}
            >

                <Typography
                    variant="h4"
                    sx={{ fontWeight: 700 }}
                >
                    Transações
                </Typography>

                <Button
                    variant="contained"
                    onClick={() => setOpenDialog(true)}
                >
                    Nova Transação
                </Button>

            </Box>

            <TransacaoTable transacoes={transacoes} />

            <TransacaoDialog
                open={openDialog}
                onClose={() => setOpenDialog(false)}
                pessoas={pessoas}
                onSalvar={salvarTransacao}
            />

            <Snackbar
                open={snackbarOpen}
                autoHideDuration={3000}
                onClose={() => setSnackbarOpen(false)}
            >
                <Alert
                    severity={snackbarSeverity}
                    onClose={() => setSnackbarOpen(false)}
                    sx={{ width: "100%" }}
                >
                    {snackbarMessage}
                </Alert>
            </Snackbar>

        </Box>

    );
}