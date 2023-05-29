FROM node:14.1-alpine AS builder

WORKDIR /reactApp

#Copiar os arquivos de origem
COPY package.json .
COPY package-lock.json .

# Instalar as dependencias
RUN npm install --legacy-peer-deps

#Copiar tudo e fazer a build
COPY . .
RUN npm run build

# Estágio de produção
FROM nginx:alpine

# Copie os arquivos buildados para o diretório do servidor nginx
COPY --from=builder /reactApp/build /usr/share/nginx/html

EXPOSE 80

#Usa porta dinamica
CMD ["nginx", "-g", "daemon off;"]
