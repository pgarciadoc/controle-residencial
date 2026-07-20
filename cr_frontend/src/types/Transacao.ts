// Representa uma transação financeira retornada pelo backend.
export interface Transacao {
    id: number;
    descricao: string;
    valor: number;
    tipo: number;
    pessoaId: number;
}