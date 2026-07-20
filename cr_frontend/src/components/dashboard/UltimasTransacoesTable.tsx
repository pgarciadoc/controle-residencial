import { Box, Paper } from "@mui/material";
import { DataGrid, type GridColDef } from "@mui/x-data-grid";
import type { Transacao } from "../../types/Transacao";

// Exibe as últimas transações cadastradas.
// Utilizado exclusivamente no Dashboard como resumo das movimentações recentes.
interface Props {
    transacoes: Transacao[];
}

export default function UltimasTransacoesTable({
    transacoes,
}: Props) {

    const columns: GridColDef[] = [

        {
            field: "pessoaNome",
            headerName: "Pessoa",
            width: 180,
        },

        {
            field: "descricao",
            headerName: "Descrição",
            flex: 1,
        },

        {
            field: "tipo",
            headerName: "Tipo",
            width: 130,
            renderCell: (params) =>
                params.value === 0
                    ? "Receita"
                    : "Despesa",
        },

        {
            field: "valor",
            headerName: "Valor",
            width: 140,

            renderCell: (params) => {
                const ehReceita = params.row.tipo === 0;

                return (
                    <span
                        style={{
                            color: ehReceita ? "#2e7d32" : "#d32f2f",
                            fontWeight: 600,
                        }}
                    >
                        {`${ehReceita ? "+" : "-"}${Number(params.value).toLocaleString(
                            "pt-BR",
                            {
                                style: "currency",
                                currency: "BRL",
                            }
                        )}`}
                    </span>
                );
            },
        },
    ];

    return (

        <Paper
            elevation={2}
            sx={{ mt: 4 }}
        >

            <Box sx={{ height: 380 }}>

                <DataGrid
                    rows={transacoes}
                    columns={columns}
                    pageSizeOptions={[5]}
                    initialState={{
                        pagination: {
                            paginationModel: {
                                pageSize: 5,
                                page: 0,
                            },
                        },
                    }}
                    disableRowSelectionOnClick
                />

            </Box>

        </Paper>

    );
}