import api from "./Api";
import type { TotaisResponse } from "../types/TotaisResponse";

// Responsável por consultar os totais financeiros.
// Consome o endpoint que retorna os totais por pessoa e o total geral.

export async function listarTotais() {
    const response = await api.get<TotaisResponse>("/Totais");
    return response.data;
}