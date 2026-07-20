import api from "./Api";
import type { Transacao } from "../types/Transacao";

// Responsável pelas operações relacionadas às transações.
// Encapsula as chamadas à API para manter a separação entre interface e comunicação HTTP.

export async function listarTransacoes() {
    const response = await api.get<Transacao[]>("/Transacoes");
    return response.data;
}

export async function criarTransacao(
    descricao: string,
    valor: number,
    tipo: number,
    pessoaId: number
) {
    const response = await api.post("/Transacoes", {
        descricao,
        valor,
        tipo,
        pessoaId
    });

    return response.data;
}
