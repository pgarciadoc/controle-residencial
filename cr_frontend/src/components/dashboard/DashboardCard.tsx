import { Card, CardContent, Typography } from "@mui/material";

interface DashboardCardProps {
    titulo: string;
    valor: string | number;
    color?: string;
}

export default function DashboardCard({
    titulo,
    valor,
    color = "text.primary",
}: DashboardCardProps) {

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
                        mt: 2,
                        fontWeight: 700,
                        color,
                    }}
                >
                    {valor}
                </Typography>

            </CardContent>

        </Card>
    );
}