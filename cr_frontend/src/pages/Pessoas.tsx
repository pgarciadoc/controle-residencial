import { Box, Button, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import PessoaTable from "../components/pessoa/PessoaTable";
import PessoaDialog from "../components/pessoa/PessoaDialog";
import type { Pessoa } from "../types/Pessoa";
import { Snackbar, Alert } from "@mui/material";
import {
    listarPessoas,
    criarPessoa,
    excluirPessoa,
} from "../services/pessoaService";

// Página responsável pelo gerenciamento de pessoas.
// Permite cadastrar, listar e excluir pessoas cadastradas.

export default function Pessoas() {
  const [pessoas, setPessoas] = useState<Pessoa[]>([]);
  const [openDialog, setOpenDialog] = useState(false);

  const [snackbarOpen, setSnackbarOpen] = useState(false);
  const [snackbarMessage, setSnackbarMessage] = useState("");

  const [snackbarSeverity, setSnackbarSeverity] = useState<
    "success" | "error"
    >("success");

  async function carregarPessoas() {
    try {
      const dados = await listarPessoas();
      setPessoas(dados);
    } catch (error) {
      console.error("Erro ao carregar pessoas:", error);
    }
  }

  async function excluir(id: number) {

    if (!window.confirm("Deseja realmente excluir esta pessoa?")) {
        return;
    }

    try {

        await excluirPessoa(id);

        const dados = await listarPessoas();
        setPessoas(dados);

        setSnackbarSeverity("success");
        setSnackbarMessage("Pessoa excluída com sucesso!");
        setSnackbarOpen(true);

    } catch {

        setSnackbarSeverity("error");
        setSnackbarMessage("Erro ao excluir pessoa.");
        setSnackbarOpen(true);

    }
  }

  async function salvarPessoa(nome: string, idade: number) {
    try {

        await criarPessoa(nome, idade);

        setSnackbarMessage("Pessoa cadastrada com sucesso!");
        setSnackbarOpen(true);

        setOpenDialog(false);

        carregarPessoas();

        setOpenDialog(false);

        carregarPessoas();

    } catch (error) {
        setSnackbarMessage("Erro ao cadastrar pessoa.");
        setSnackbarOpen(true);
    }
  }

  useEffect(() => {
    carregarPessoas();
  }, []);

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
          Pessoas
        </Typography>

        <Button
          variant="contained"
          onClick={() => setOpenDialog(true)}
        >
          Nova Pessoa
        </Button>
      </Box>

      <PessoaTable
        pessoas={pessoas}
        onExcluir={excluir}
      />

       <PessoaDialog
            open={openDialog}
            onClose={() => setOpenDialog(false)}
            onSalvar={salvarPessoa}
            onErro={(mensagem) => {
                setSnackbarSeverity("error");
                setSnackbarMessage(mensagem);
                setSnackbarOpen(true);
            }}
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