import type { TotalPessoa } from "./TotalPessoa";
import type { TotalGeral } from "./TotalGeral";

// Estrutura da resposta retornada pelo endpoint de totais.
export interface TotaisResponse {
    pessoas: TotalPessoa[];
    totalGeral: TotalGeral;
}