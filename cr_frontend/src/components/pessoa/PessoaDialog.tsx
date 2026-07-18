import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  Stack,
  TextField,
} from "@mui/material";
import { useState } from "react";

interface PessoaDialogProps {
    open: boolean;
    onClose: () => void;
    onSalvar: (nome: string, idade: number) => void;
    onErro: (mensagem: string) => void;
}

export default function PessoaDialog({
    open,
    onClose,
    onSalvar,
    onErro
}: PessoaDialogProps) {

    function limparFormulario() {
        setNome("");
        setIdade("");
    }

    function handleSalvar() {

        if (!nome.trim()) {
            onErro("Informe o nome.");
            return;
        }

        if (Number(idade) < 0) {
            onErro("A idade deve ser maior ou igual a zero.");
            return;
        }

        if (!Number(idade)) {
            onErro("Informe a idade.");
            return;
        }

        onSalvar(nome, Number(idade));

        limparFormulario();

    }



const [nome, setNome] = useState("");
const [idade, setIdade] = useState("");

  return (
    <Dialog
      open={open}
      onClose={onClose}
      fullWidth
      maxWidth="sm"
    >
      <DialogTitle>Nova Pessoa</DialogTitle>

      <DialogContent>

        <Stack spacing={2} sx={{ mt: 1 }}>

            <TextField
                label="Nome"
                fullWidth
                value={nome}
                onChange={(e) => setNome(e.target.value)}
            />

            <TextField
                label="Idade"
                type="number"
                fullWidth
                value={idade}
                onChange={(e) => setIdade(e.target.value)}
            />

        </Stack>

      </DialogContent>

      <DialogActions>

        <Button
            onClick={() => {
                limparFormulario();
                onClose();
            }}
        >
            Cancelar
        </Button>
        
        <Button
            variant="contained"
            onClick={handleSalvar}
        >
            Salvar
        </Button>

      </DialogActions>

    </Dialog>
  );
}