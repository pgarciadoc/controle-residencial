import { Box, IconButton, Paper } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import type { GridColDef } from "@mui/x-data-grid";
import DeleteIcon from "@mui/icons-material/Delete";
import type { Pessoa } from "../../types/Pessoa";

// Tabela responsável por exibir todas as pessoas cadastradas.
// Utiliza o DataGrid do Material UI para paginação e organização dos dados.
interface PessoaTableProps {
    pessoas: Pessoa[];
    onExcluir: (id: number) => void;
}

export default function PessoaTable({
    pessoas,
    onExcluir,
}: PessoaTableProps) {

      const columns: GridColDef[] = [
        { field: "id", headerName: "ID", width: 80 },
        { field: "nome", headerName: "Nome", flex: 1 },
        { field: "idade", headerName: "Idade", width: 120 },

        {
            field: "acoes",
            headerName: "Ações",
            width: 100,
            sortable: false,
            renderCell: (params) => (
                <IconButton
                    color="error"
                    onClick={() => onExcluir(params.row.id)}
                >
                    <DeleteIcon />
                </IconButton>
            ),
        },
    ];

    return (
    <Paper elevation={2} sx={{ p: 2 }}>
      <Box sx={{ height: 500, width: "100%" }}>
        <DataGrid
          rows={pessoas}
          columns={columns}
          pageSizeOptions={[5, 10]}
        />
      </Box>
    </Paper>
  );
}