import {
    Button,
    Dialog,
    DialogActions,
    DialogContent,
    DialogTitle,
    Stack,
    TextField,
    FormControl,
    InputLabel,
    Select,
    MenuItem,
} from "@mui/material";

import { useState } from "react";
import type { Pessoa } from "../../types/Pessoa";


interface TransacaoDialogProps {

    
    open: boolean;
    onClose: () => void;
    pessoas: Pessoa[];

    onSalvar: (
        descricao: string,
        valor: number,
        tipo: number,
        pessoaId: number
    ) => void;
}



export default function TransacaoDialog({
    open,
    onClose,
    onSalvar,
    pessoas,

}: TransacaoDialogProps) {

    const [descricao, setDescricao] = useState("");
    const [valor, setValor] = useState("");
    const [tipo, setTipo] = useState("");
    const [pessoaId, setPessoaId] = useState("");

    function limparFormulario() {
        setDescricao("");
        setValor("");
        setTipo("");
        setPessoaId("");
    }

    return (

        <Dialog
            open={open}
            onClose={onClose}
            fullWidth
            maxWidth="sm"
        >

            <DialogTitle>
                Nova Transação
            </DialogTitle>

            <DialogContent>

            <Stack spacing={2} sx={{ mt: 1 }}>

                <TextField
                    label="Descrição"
                    value={descricao}
                    onChange={(e) => setDescricao(e.target.value)}
                    fullWidth
                />

                <TextField
                    label="Valor"
                    type="number"
                    value={valor}
                    onChange={(e) => setValor(e.target.value)}
                    fullWidth
                />

                <FormControl fullWidth>

                    <InputLabel>Tipo</InputLabel>

                    <Select
                        value={tipo}
                        label="Tipo"
                        onChange={(e) => setTipo(e.target.value)}
                    >
                        <MenuItem value="1">Receita</MenuItem>

                        <MenuItem value="0">Despesa</MenuItem>
                    </Select>

                </FormControl>

                <FormControl fullWidth>

                    <InputLabel>Pessoa</InputLabel>

                        <Select
                            value={pessoaId}
                            label="Pessoa"
                            onChange={(e) => setPessoaId(e.target.value)}
                        >
                            {pessoas.map((pessoa) => (
                                <MenuItem
                                    key={pessoa.id}
                                    value={pessoa.id}
                                >
                                    {pessoa.nome}
                                </MenuItem>
                            ))}
                        </Select>

                </FormControl>

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
                     onClick={() => {
                        console.log({
                            descricao,
                            valor,
                            tipo,
                            pessoaId
                        });

                        onSalvar(
                            
                            descricao,
                            Number(valor),
                            Number(tipo),
                            Number(pessoaId)
                        )
                    }}
                >
                    Salvar
                </Button>

            </DialogActions>

        </Dialog>
    );
}