import {
  Drawer,
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Toolbar,
} from "@mui/material";

import DashboardIcon from "@mui/icons-material/Dashboard";
import PeopleIcon from "@mui/icons-material/People";
import PaidIcon from "@mui/icons-material/Paid";
import AssessmentIcon from "@mui/icons-material/Assessment";
import { Link } from "react-router-dom";

// Menu lateral da aplicação.
// Centraliza a navegação entre todas as páginas do sistema.
const drawerWidth = 240;

export default function Sidebar() {
  return (
    <Drawer
      variant="permanent"
      sx={{
        width: drawerWidth,
        flexShrink: 0,
        "& .MuiDrawer-paper": {
          width: drawerWidth,
          boxSizing: "border-box",
        },
      }}
    >
      <Toolbar />

      <List>

        <ListItemButton component={Link} to="/">
          <ListItemIcon>
            <DashboardIcon />
          </ListItemIcon>
          <ListItemText primary="Dashboard" />
        </ListItemButton>

        <ListItemButton component={Link} to="/pessoas">
          <ListItemIcon>
            <PeopleIcon />
          </ListItemIcon>
          <ListItemText primary="Pessoas" />
        </ListItemButton>

        <ListItemButton component={Link} to="/transacoes">
          <ListItemIcon>
            <PaidIcon />
          </ListItemIcon>
          <ListItemText primary="Transações" />
        </ListItemButton>

        <ListItemButton component={Link} to="/totais">
          <ListItemIcon>
            <AssessmentIcon />
          </ListItemIcon>
          <ListItemText primary="Totais" />
        </ListItemButton>

      </List>
    </Drawer>
  );
}