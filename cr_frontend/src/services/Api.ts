import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5231/api",
});

export default api;