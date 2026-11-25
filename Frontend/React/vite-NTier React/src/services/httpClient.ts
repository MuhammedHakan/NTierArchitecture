import axios from 'axios';

const httpClient = axios.create({
  baseURL: 'http://localhost:5199/api',
  headers: {
    'Content-Type': 'application/json',
  },
});

// Response interceptor – hata loglama
httpClient.interceptors.response.use(
  (response) => response,
  (error) => {
    console.error('API Hatası:', error.response?.data || error.message);
    return Promise.reject(error);
  }
);

export default httpClient;
