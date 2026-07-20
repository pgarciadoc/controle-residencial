import { Box } from "@mui/material";
import Header from "./Header";
import Sidebar from "./Sidebar";

// Estrutura principal da interface.
// Define o layout compartilhado utilizado por todas as páginas.
type LayoutProps = {
  children: React.ReactNode;
};

export default function Layout({ children }: LayoutProps) {
  return (
    <Box sx={{ display: "flex", minHeight: "100vh" }}>
      <Sidebar />

      <Box sx={{ flexGrow: 1 }}>
        <Header />

        <Box
          component="main"
          sx={{
            p: 4,
            backgroundColor: "#f5f5f5",
            minHeight: "calc(100vh - 64px)",
          }}
        >
          {children}
        </Box>
      </Box>
    </Box>
  );
}