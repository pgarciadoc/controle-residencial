import type { TotalPessoa } from "./TotalPessoa";
import type { TotalGeral } from "./TotalGeral";

export interface TotaisResponse {
    pessoas: TotalPessoa[];
    totalGeral: TotalGeral;
}