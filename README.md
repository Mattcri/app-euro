# API basic con .NET 8.0.3
La presente app consiste en una pequeña web API creada con `Microsoft.Entity.Framework` y la metodología de **FluentAPI**  
Cuenta con las siguientes buenas prácticas de desarrollo de API's
- Models
- DTOs
- Interfaces (contratos para las clases)
- Services
- Controllers
- Context (para conexión de ORM a BBDD)

## Frontend
El frontend de la app esta construido en Vue 3, y se ocupo `Pinia` para centralizar las operaciones en una store (símil a Redux, para controlar el estado de la app de manera más centralizada).
Los detalles técnicos de las tecnologías utilizadas en el front son:
- Vue.js 3
- Pinia store
- Vue-router
- Vuetify UI
- Vite

## Ambiente de desarrollo
La BBDD para desarrollo se encuentra en un servicio de **docker-compose** para leventarla se debe correr el comando:
```bash
docker-compose -f docker-compose.dev.yml up -d
```
> Requisito tener instalado la versión de .NET correspondiente en el equipo
Luego abrir proyecto navegar a backend-api, e instalar dependencias:
```bash
cd backend-api && dotnet restore
```
Posteriormente levantar el servidor de backend
```bash
dotnet run
```
Finalmente abrir otra pestaña de la consola en la raiz del proyecto y entrar al folder frontend para levantar el servidor del front
```bash
cd frontend && npm run dev
```
## Endpoints admitidos
### Autores
|GET|POST|PUT|DELETE|
|--------|--------|--------|--------|
|  /api/authors |    /api/authors    |    /api/authors/{id}    |  /api/authors/{id} |    
|  /api/authors/{id}  |        |        |
> Formato POST
```json
{
  "Rut": "12345678-9",
  "Name": "Diego Navarro",
  "DateOfBirth": "1980-01-01",
  "GenderSex": "Masculino",
  "Email": "ejemplo@gmail.com",
  "City": "Ciudad"
}
```
### Libros
|GET|POST|PUT|DELETE|
|--------|--------|--------|--------|
|  /api/books |    /api/books    |    /api/books/{id}    |  /api/books/{id} |    
|  /api/books/{id}  |        |        |
> Formato POST
```json
{
  "AuthorId": "71064522-0fb7-478b-853d-c589a49dbdd2",
  "Title": "Nuevo Libro",
  "Year": 2024,
  "GenderBook": "Drama",
  "NumPages": 300
}
```

## Screenshots
![image](https://github.com/Mattcri/app-euro/assets/61167254/e519de36-e6b5-4e33-8a4d-0d95a31eaa92)
![image](https://github.com/Mattcri/app-euro/assets/61167254/36d71623-64e6-45fb-91b4-b5b87a0d646f)
![image](https://github.com/Mattcri/app-euro/assets/61167254/895a38e2-8276-49e3-9298-535b5f962e02)
![image](https://github.com/Mattcri/app-euro/assets/61167254/797f26d3-dac6-4acd-8b24-508e952fd602)
![image](https://github.com/Mattcri/app-euro/assets/61167254/1c3fb050-1d6f-49cd-ac73-1de12b530913)
![image](https://github.com/Mattcri/app-euro/assets/61167254/935b7000-edf4-49af-ac3c-d1a4652de642)
![image](https://github.com/Mattcri/app-euro/assets/61167254/89f1360f-6042-4a07-a08d-710e17f0c47a)
