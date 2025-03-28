import axios from 'axios';

export default function useApi() {
    const api = axios.create({
        baseURL: import.meta.env.VITE_API_URL
    });

    // Interceptores podem ser adicionados aqui
    return api;
}