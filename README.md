# API basic con .NET 8.0.3
La presente app consiste en una pequeña web API creada con `Microsoft.Entity.Framework` y la metodología de **FluentAPI**  
Cuenta con las siguientes buenas prácticas de desarrollo de API's
- Models
- DTOs
- Interfaces (contratos para las clases)
- Services
- Controllers
- Context (para conexión de ORM a BBDD)

## Ambiente de desarrollo
La BBDD para desarrollo se encuentra en un servicio de **docker-compose** para leventarla se debe correr el comando:
```bash
docker-compose -f docker-compose.dev.yml up -d
```
> Requisito tener instalado la versión de .NET correspondiente en el equipo
Luego abrir proyecto navegar a backend-api, y instalar dependencias:
```bash
cd backend-api && dotnet restore
```
Posteriormente levantar el servidor
```bash
dotnet run
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
![image](https://github.com/Mattcri/app-euro/assets/61167254/797f26d3-dac6-4acd-8b24-508e952fd602)
![image](https://github.com/Mattcri/app-euro/assets/61167254/1c3fb050-1d6f-49cd-ac73-1de12b530913)
![image](https://github.com/Mattcri/app-euro/assets/61167254/935b7000-edf4-49af-ac3c-d1a4652de642)
![image](https://github.com/Mattcri/app-euro/assets/61167254/89f1360f-6042-4a07-a08d-710e17f0c47a)
