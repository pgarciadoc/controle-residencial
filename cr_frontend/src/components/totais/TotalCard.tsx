import { Card, CardContent, Typography } from "@mui/material";

// Card reutilizável utilizado para apresentar indicadores financeiros.
// Destaca visualmente receitas, despesas e saldo líquido.
interface Props {
    titulo: string;
    valor: number;
}
export default function TotalCard({ titulo, valor }: Props) {

    return (
        <Card
            sx={{
                flex: 1,
                borderRadius: 3,
                boxShadow: 3,
            }}
        >
            <CardContent>

                <Typography
                    variant="subtitle2"
                    color="text.secondary"
                >
                    {titulo}
                </Typography>

                <Typography
                    variant="h4"
                    sx={{
                        fontWeight: 700,
                        mt: 1,
                        color: valor < 0 ? "error.main" : "success.main",
                    }}
                >
                    {valor.toLocaleString("pt-BR", {
                        style: "currency",
                        currency: "BRL",
                    })}
                </Typography>

            </CardContent>
        </Card>
    );
}