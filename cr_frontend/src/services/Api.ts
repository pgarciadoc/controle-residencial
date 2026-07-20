import axios from "axios";

// Configuração da instância do Axios.
// Centraliza a comunicação HTTP com a API do backend.
const api = axios.create({
  baseURL: "http://localhost:5231/api",
});

export default api;