import api from "./Api";
import type { Pessoa } from "../types/Pessoa";

// Responsável pelas requisições relacionadas ao cadastro de pessoas.
// Centraliza todas as chamadas HTTP para o endpoint de pessoas.
export async function listarPessoas() {
    const response = await api.get<Pessoa[]>("/Pessoas");
    return response.data;
}

export async function criarPessoa(nome: string, idade: number) {
    const response = await api.post("/Pessoas", {
        nome,
        idade,
    });

    return response.data;
}

export async function excluirPessoa(id: number) {
    await api.delete(`/Pessoas/${id}`);
}