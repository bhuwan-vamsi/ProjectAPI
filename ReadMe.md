## 📁 Project Structure

This .NET Web API project follows a clean and maintainable architecture. Below is an overview of each folder and its purpose:

---

### 📂 `Controllers/`

**Purpose:**  
Contains API controllers that handle HTTP requests and route them to appropriate services.

**Example:**  
`InventoryController.cs` – Handles inventory-related endpoints (GET, POST, PUT, DELETE).

---

### 📂 `Models/`

**Purpose:**  
Defines core domain entities that represent the database tables using EF Core.

**Example:**  
`Item.cs` – Represents an inventory item with properties like `Id`, `Itemname`, `Price`, and `Quantity`.

---

### 📂 `DTOs/` (Data Transfer Objects)

**Purpose:**  
Contains lightweight objects used to send and receive data via API without exposing internal entities.

**Examples:**
- `ItemDto.cs` – Returned to clients when fetching item data.
- `CreateItemDto.cs` – Used for creating new items via the API.

---

### 📂 `Mappings/`

**Purpose:**  
Holds AutoMapper profiles which configure mappings between entities and DTOs.

**Example:**  
`ItemProfile.cs` – Maps between `Item`, `ItemDto`, and `CreateItemDto`.

---

### 📂 `Services/`

**Purpose:**  
Contains business logic classes that process data and interact with repositories.

**Example:**  
`ItemService.cs` – Manages item-related operations like retrieving, adding, updating, and deleting.

---

### 📂 `Repositories/`

**Purpose:**  
Implements the Repository Pattern to separate data access logic from the rest of the application.

**Examples:**
- `IItemRepository.cs` – Interface defining methods for item operations.
- `ItemRepository.cs` – Implements the interface using Entity Framework Core.

---

### 📂 `Data/`

**Purpose:**  
Contains the Entity Framework database context.

**Example:**  
`AppDbContext.cs` – Manages database access and mappings to models like `Item`.

---

### 📂 `Extensions/`

**Purpose:**  
Provides extension methods for configuring services in `Program.cs`.

**Example:**  
`ServiceCollectionExtensions.cs` – Registers repositories and services for dependency injection.

---

### 📄 `Program.cs`

**Purpose:**  
The main entry point of the application. Sets up services, middleware (e.g., CORS, Swagger), and runs the API.

---

## 🧪 Optional Future Folders

| Folder         | Purpose                                         |
|----------------|-------------------------------------------------|
| `Validators/`  | Contains custom validation logic (e.g., FluentValidation) |
| `Middleware/`  | Contains custom middleware for logging, auth, etc. |
| `Tests/`       | Unit and integration test projects              |

---

## ✅ Summary

This structure supports separation of concerns and clean architecture principles:

- ✅ Controllers handle incoming requests.
- ✅ Services process business logic.
- ✅ Repositories access the database.
- ✅ DTOs ensure secure data transfer.
- ✅ Mappings (AutoMapper) simplify transformations between layers.

