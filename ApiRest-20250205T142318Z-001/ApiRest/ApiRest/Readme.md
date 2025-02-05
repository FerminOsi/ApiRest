# API REST - Gestión de Productos

## Descripción
Este proyecto es una API REST desarrollada en **.NET 8** para la gestión de productos. Permite realizar operaciones **CRUD** (Crear, Leer, Actualizar, Eliminar) sobre una lista de productos.

## Requisitos previos
Antes de ejecutar el proyecto, asegúrate de tener instalado:
- [Visual Studio 2022](https://visualstudio.microsoft.com/) con el SDK de **.NET 8**
- [Postman](https://www.postman.com/downloads/) para probar los endpoints

## Instalación y ejecución

1. **Descargar la API**
   - Clona el repositorio o descarga el código fuente.

2. **Abrir el proyecto en Visual Studio**
   - Abre `ApiRest.sln` en Visual Studio 2022.

3. **Ejecutar el servidor**
   - Presiona `Ctrl + F5` o ejecuta el comando:
     ```sh
     dotnet run
     ```
   - La API se ejecutará en `https://localhost:7239/`

## Endpoints

### **1. Obtener todos los productos**
- **Método:** `GET`
- **URL:** `https://localhost:7239/api/productos`
- **Respuesta:**
  ```json
  [
    { "id": 1, "nombre": "Laptop", "precio": 800 },
    { "id": 2, "nombre": "Teléfono", "precio": 500 }
  ]
  ```

### **2. Obtener un producto por ID**
- **Método:** `GET`
- **URL:** `https://localhost:7239/api/productos/1`

### **3. Buscar productos por nombre**
- **Método:** `GET`
- **URL:** `https://localhost:7239/api/productos/buscar?nombre=Laptop`

### **4. Filtrar productos por precio**
- **Método:** `GET`
- **URL:** `https://localhost:7239/api/productos/precio?min=300&max=900`

### **5. Crear un nuevo producto**
- **Método:** `POST`
- **URL:** `https://localhost:7239/api/productos`
- **Body (JSON):**
  ```json
  {
    "nombre": "Tablet",
    "precio": 300
  }
  ```

### **6. Actualizar un producto**
- **Método:** `PUT`
- **URL:** `https://localhost:7239/api/productos/1`
- **Body (JSON):**
  ```json
  {
    "nombre": "Laptop Gamer",
    "precio": 1200
  }
  ```

### **7. Eliminar un producto**
- **Método:** `DELETE`
- **URL:** `https://localhost:7239/api/productos/2`

### **8. Eliminar múltiples productos**
- **Método:** `DELETE`
- **URL:** `https://localhost:7239/api/productos/eliminar-multiples`
- **Body (JSON):**
  ```json
  [1, 3]
  ```

## Pruebas en Postman
1. Abre **Postman**
2. Ingresa la **URL del endpoint** que quieres probar
3. Selecciona el método (`GET`, `POST`, `PUT`, `DELETE`)
4. Si es necesario, agrega un **body en formato JSON**
5. Presiona **Send** y verifica la respuesta

## Despliegue
Para hacer pública la API, puedes desplegarla en:
- **Azure App Services**
- **Docker con contenedor en la nube**
- **Render o Railway (servicios gratuitos)**

---

## Autor
- **Nombre:** [Tu Nombre]
- **Email:** [Tu Email]

