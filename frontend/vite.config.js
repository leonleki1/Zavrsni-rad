import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

export default defineConfig({
  plugins: [react()],
  build: {
    outDir: 'wwwroot', // Postavi izlazni direktorij za build
  },
  server: {
    open: true,
  },
});
  