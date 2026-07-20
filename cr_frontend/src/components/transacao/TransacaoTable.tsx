import { Box, IconButton, Paper } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import type { GridColDef } from "@mui/x-data-grid";
import type { Transacao } from "../../types/Transacao";

interface TransacaoTableProps {
    transacoes: Transacao[];
}

export default function TransacaoTable({
    transacoes
}: TransacaoTableProps) {

      const columns: GridColDef[] = [

        {
            field: "pessoaNome",
            headerName: "Pessoa",
            width: 120,
        },

        {
            field: "descricao",
            headerName: "Descrição",
            flex: 1 },

        {
            field: "valor",
            headerName: "Valor",
            width: 120,
            valueFormatter: (value) =>
                Number(value).toLocaleString("pt-BR", {
                    style: "currency",
                    currency: "BRL",
                }),
        },

        {
            field: "tipo",
            headerName: "Tipo",
            width: 120,
            renderCell: (params) =>
                params.value === 0 ? "Receita" : "Despesa"
        },
    ];

    return (
    <Paper elevation={2} sx={{ p: 2 }}>
      <Box sx={{ height: 500, width: "100%" }}>
        <DataGrid
          rows={transacoes}
          columns={columns}
          pageSizeOptions={[5, 10]}
        />
      </Box>
    </Paper>
  );
}