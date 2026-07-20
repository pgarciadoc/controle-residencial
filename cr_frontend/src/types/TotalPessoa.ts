// Estrutura contendo os totais financeiros de uma pessoa.
export interface TotalPessoa {
    pessoaId: number;
    nome: string;
    totalReceitas: number;
    totalDespesas: number;
    saldo: number;
}