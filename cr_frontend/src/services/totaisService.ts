import api from "./Api";
import type { TotaisResponse } from "../types/TotaisResponse";

export async function listarTotais() {
    const response = await api.get<TotaisResponse>("/Totais");
    return response.data;
}