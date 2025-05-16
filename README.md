# eShop

## Table of Contents

### Getting Started
- [Introduction](#-introduction)
- [Features](#-features)
- [Future Plans](#-future-plans)
- [System Requirements](#%EF%B8%8F-system-requirements)
- [Installation](#-installation)
- [Usage](#-usage)
- [FAQs](#-faqs)

### Technical Details
- [Diagrams](#-diagrams)
- [Framework](#%EF%B8%8F-framework)
- [Dependencies](#-dependencies)
- [API DOcumentation](#-api-documentation)
- [Versioning & Changelog](#-versioning-and-changelog)
- [TODO](#-todo-list)
- [Known Issues](#-known-issues)
- [Contributing](#-contributing)
- [Acknowledgments](#-acknowledgments)
- [License](#-license)
- [Contact](#-contact)

<br>

# Getting Started

<br>

## 📘 Introduction

Welcome to the eShop project!
This application is a complete e-commerce platform that includes a backend brand management system and a separate web frontend.
Users can manage brands, products, categories, and reviews. The backend provides a REST API while the web app offers a user-friendly UI using modern web technologies.

<br>

## 🌟 Features

[List the key features of your project.]

- **Create, Update, Delete**: Create, Update, Delete Brands: Manage your brand list with full CRUD functionality.
- **Pagination**: Easily navigate through the list of brands without overwhelming the user interface.
- **Search**: Find brands quickly with a built-in search feature that filters the brand list.
- **Responsive Design**: The interface adjusts to different screen sizes, making it suitable for desktops, tablets, and mobile devices.
- **Data validation**: Ensures that users input valid data when creating or updating brands.

<br>

## 🚀 Future Plans

We have several exciting features and improvements planned for the upcoming versions of eShop:

- **Shop Funtionality**: Implement a comprehensive store features, like products, orders and checkoput.
- **User authentication**: Add role-based authentication to secure brand management.

<br>

## 🖥️ System requirements

| **Category**          | **Requirements**                                                              |
|-----------------------|-------------------------------------------------------------------------------|
| **Operating System**   | - Windows 10 or later <br> - macOS 10.15 (Catalina) or later <br> - Ubuntu 18.04+ |
| **Processor**          | 2 GHz dual-core or higher                                                     |
| **Memory**             | 4 GB RAM (8 GB recommended)                                                   |
| **Storage**            | 500 MB of available space (depends on project size)                           |
| **Software**           | - .NET 8.0 <br> - SQL Server or SQLite |
| **Additional Tools**   | - Git (for version control) <br> - Docker (optional, for containerized setup) |

<br>

## 📦 Installation

### Windows

To install the project, clone the repository and install the necessary dependencies:

```bash
git clone https://github.com/LH-Hansen/eshop.git
cd eshop
dotnet restore
dotnet build
```

<br>

## 📖 Usage

[This is how you run and use the application]

### Running the application
```bash
dotnet run
```

* After running the application, navigate to http://localhost:5000/brand in your browser to access the brand management system.

### Eample commands and features

Here’s an example of how you can use the application for specific tasks:

- **Creating a Brand**: Use the form to input the brand name and description, then click the "Create Brand" button.
- **Updating a Brand**: Modify an existing brand’s name or description, then click the "Update" button.
- **Deleting a Brand**: Click the "Delete" button next to a brand to remove it.

<br>

## ❓ FAQs

### 1. What is this project about?
This prject is an ecomerse shop built from the ground up.

### 2. How do I install the project?
To install the project, follow the instructions in the [Installation](#-installation) section.

### 3. How can I contribute to this project?
We welcome contributions! Please check the [Contributing](#-contributing) section for guidelines.

### 4. What are the system requirements?
The project requires [list any specific requirements like OS, software, etc.].

### 5. How do I report bugs or issues?
You can report bugs by opening an issue in the [GitHub repository](link-to-repo/issues).

### 6. Where can I find more information?
For more detailed documentation, visit [link to documentation or website].

### 7. Is there a community for this project?
Yes! Join our community on [link to community platform, e.g., Discord, Slack, etc.].

<br>

# Technical Details

<br>

## 📊 Diagrams

This section provides visual representations of the project architecture and workflows.
### 1. Database diagram
![eShop_Db_Diagram](https://github.com/user-attachments/assets/5f060eeb-eee2-4a9d-9176-65d52399030e)


<br>

## 🛠️ Framework

This project is built using .NET 8.0.

| **Project**           | **Framework**  | **Folder Structure**                         |
|-----------------------|:--------------:|----------------------------------------------:|
| **eShop.Repository**   | .NET 8.0       | `eShop.Repository`<br>- `Entities`<br>- `Repositories`<br>- `Data` |
| **eShop.Service**      | .NET 8.0       | `eShop.Service`<br>- `Services`<br>- `DTO` <br>- `Mapping`<br>-|
| **eShop.API**          | .NET 8.0       | `eShop.API`<br>- `Controllers` <br>- `Program.cs` |
| **eShop.Tests**        | .NET 8.0       | `eShop.Tests`<br>- `UnitTests`<br>- `IntegrationTests`<br>- |


<br>

## 📚 Dependencies

This project depends on the following libraries:

### Nuget Packages

| Package                                 | Creator   | Version |   Project  |
|:----------------------------------------|:---------:|:-------:|:----------:|
| [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)          | Microsoft | `9.0.3` | eShop.Repository |
| [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer) | Microsoft | `9.0.3` | eShop.Repository |
| [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools)     | Microsoft | `9.0.3` | eShop.Repository |
| [Microsoft.EntityFrameworkCore.Configuration](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Configuration)     | Microsoft | `9.0.3` | eShop.Repository |
| [FluentAssertions](https://www.nuget.org/packages/FluentAssertions)                        | Dennis Doomen, Jonas Nyrup, Xceed | `8.2.0`| eShop.Test |
| [Moq](https://www.nuget.org/packages/Moq)                                     | Daniel Cazzulino, kzu | `4.20.72`| eShop.Test |
<br>

## API Docuemntation

# API Endpoints Documentation

## Product Endpoints

| **HTTP Method** | **Route**                     | **Description**                                      | **Parameters**                    | **Request Body**       | **Response**                               |
|-----------------|-------------------------------|------------------------------------------------------|-----------------------------------|------------------------|--------------------------------------------|
| `GET`           | `/products`                   | Get all products                                     | None                              | None                   | `200 OK` with list of `ProductDto`         |
| `GET`           | `/products/search/{ProductName}`| Get paginated products by product name               | `ProductName` (string)            | None                   | `200 OK` with list of `ProductDto`         |
| `GET`           | `/products/{id}`               | Get product by ID                                    | `id` (int)                        | None                   | `200 OK` with `ProductDto`                 |
| `GET`           | `/products/brand/{brandId}`    | Get products by brand ID                             | `brandId` (int)                   | None                   | `200 OK` with list of `ProductUpsertDto`  |
| `POST`          | `/products`                   | Add a new product                                    | None                              | `ProductUpsertDto`     | `201 Created` with `ProductUpsertDto`      |
| `PUT`           | `/products/{id}`               | Update an existing product                           | `id` (int)                        | `ProductUpsertDto`     | `204 No Content`                          |
| `DELETE`        | `/products/{id}`               | Delete a product                                     | `id` (int)                        | None                   | `204 No Content`                          |


## Brand Endpoints

| **HTTP Method** | **Route**                     | **Description**                                      | **Parameters**                    | **Request Body**       | **Response**                               |
|-----------------|-------------------------------|------------------------------------------------------|-----------------------------------|------------------------|--------------------------------------------|
| `GET`           | `/brands`                     | Get all brands                                       | None                              | None                   | `200 OK` with list of `BrandDto`           |
| `GET`           | `/brands/{name}`              | Get paginated brands by name                         | `name` (string)                   | None                   | `200 OK` with list of `BrandDto`           |
| `GET`           | `/brands/{id}`                | Get brand by ID                                      | `id` (int)                        | None                   | `200 OK` with `BrandDto`                   |
| `POST`          | `/brands`                     | Add a new brand                                      | None                              | `BrandDto`             | `201 Created` with `BrandDto`              |
| `PUT`           | `/brands/{id}`                | Update an existing brand                             | `id` (int)                        | `BrandDto`             | `204 No Content`                          |
| `DELETE`        | `/brands/{id}`                | Delete a brand                                       | `id` (int)                        | None                   | `204 No Content`                          |

## Review Endpoints

| **HTTP Method** | **Route**                     | **Description**                                      | **Parameters**                    | **Request Body**       | **Response**                               |
|-----------------|-------------------------------|------------------------------------------------------|-----------------------------------|------------------------|--------------------------------------------|
| `GET`           | `/reviews`                    | Get all reviews                                      | None                              | None                   | `200 OK` with list of `ReviewDto`          |
| `GET`           | `/reviews/{id}`               | Get review by ID                                     | `id` (int)                        | None                   | `200 OK` with `ReviewDto`                  |
| `GET`           | `/reviews/byProduct/{productId}`| Get reviews by product ID                            | `productId` (int)                 | None                   | `200 OK` with list of `ReviewDto`    
| `POST`          | `/reviews`                    | Add a new review                                     | None                              | `ReviewUpsertDto`      | `201 Created` with `ReviewUpsertDto`       |
| `PUT`           | `/reviews/{id}`               | Update an existing review                            | `id` (int)                        | `ReviewUpsertDto`      | `204 No Content`                          |
| `DELETE`        | `/reviews/{id}`               | Delete a review                                      | `id` (int)                        | None                   | `204 No Content`                          |
      |

## Category Endpoints

| **HTTP Method** | **Route**                     | **Description**                                      | **Parameters**                    | **Request Body**       | **Response**                               |
|-----------------|-------------------------------|------------------------------------------------------|-----------------------------------|------------------------|--------------------------------------------|
| `GET`           | `/categories`                 | Get all categories                                   | None                              | None                   | `200 OK` with list of `CategoryDto`        |
| `GET`           | `/categories/{name}`          | Get paginated categories by name                     | `name` (string)                   | None                   | `200 OK` with list of `CategoryDto`        |
| `GET`           | `/categories/{id}`            | Get category by ID                                   | `id` (int)                        | None                   | `200 OK` with `CategoryDto`                |
| `POST`          | `/categories`                 | Add a new category                                   | None                              | `CategoryDto`          | `201 Created` with `CategoryDto`           |
| `PUT`           | `/categories/{id}`            | Update an existing category                          | `id` (int)                        | `CategoryDto`          | `204 No Content`                          |
| `DELETE`        | `/categories/{id}`            | Delete a category                                    | `id` (int)                        | None                   | `204 No Content`                          |



## SubCategory Endpoints

| **HTTP Method** | **Route**                     | **Description**                                      | **Parameters**                    | **Request Body**       | **Response**                               |
|-----------------|-------------------------------|------------------------------------------------------|-----------------------------------|------------------------|--------------------------------------------|
| `GET`           | `/subcategories/{id}`          | Get subcategory by ID                                | `id` (int)                        | None                   | `200 OK` with `SubCategoryDto`             |
| `GET`           | `/subcategories/search`        | Get paginated subcategories by name                  | `page` (int), `pageSize` (int), `searchTerm` (string) | None | `200 OK` with list of `SubCategoryDto` |
| `POST`          | `/subcategories`               | Add a new subcategory                                | None                              | `SubCategoryDto`       | `201 Created` with `SubCategoryDto`        |
| `PUT`           | `/subcategories/{id}`          | Update an existing subcategory                       | `id` (int)                        | `SubCategoryDto`       | `204 No Content`                          |
| `DELETE`        | `/subcategories/{id}`          | Delete a subcategory                                 | `id` (int)                        | None                   | `204 No Content`                          |

---

### Notes:
- All POST, PUT, and DELETE requests expect the respective DTOs in the request body (`ProductUpsertDto`, `BrandDto`, `CategoryDto`, etc.).
- The `id` parameters refer to the specific identifier for products, brands, categories, reviews, or subcategories.
- Pagination for GET requests with search functionality can be controlled with `page`, `pageSize`, and `searchTerm` parameters.




## 📋 Versioning and Changelog

### Current Version

Current version: `0.2.0`

<br>

This project follows [Semantic Versioning](https://semver.org/) for version control. The versioning format is `MAJOR.MINOR.PATCH`.

- **MAJOR** version when you make incompatible API changes,
- **MINOR** version when you add functionality in a backwards-compatible manner, and
- **PATCH** version when you make backwards-compatible bug fixes.

### Changelog

#### [Unreleased]

#### [0.4.0] - 2025-04-10
- Added unit tests
- Added API with endpoints

#### [0.3.0] - 2025-04-09
- Added Product, Reviews, Category, Subcategory.
- Implemented endpoints with CRUD functionality.

### [0.3.0] - 2025-03-27
- Added CRUD unitTest for Brand.
- changed Brand search feature to uncapitalized search, and sorting alphabetically.

#### [0.2.0] - 2025-03-27
- Initial alpha release with basic CRUD functionality for Brand.

#### [0.1.0] - 2024-10-21
- Models have been created.

- For more details, see the [CHANGELOG](CHANGELOG.md).

<br>

## 🐞 Known Issues

- **Issue 1**: Pagination does not work.
  - **Workaround**: None currently, will be addressed in future updates.

- **Issue 2**: Search functionality is case-sensitive.
  - **Status**: Has been fixed.

If you encounter any other issues not listed here, please feel free to report them!

<br>

## ✅ TODO List

### [HIGH] Critical Tasks
- [ ] Improve error handeling for brand management
- [ ] Implement better pagination system for datasets.
- [ ] Implement other model, like product orders and more

### [MEDIUM] Important Features
- [ ]  Add user authentication.
- [ ]  Add advanced search filters.

### [LOW] Enhancements
- [ ] Improve UI design.
- [x] Remove casesensitivity in search


<br>

## 🤝 Contributing

Thank you for your interest in contributing! At this time, we are not accepting contributions. We appreciate your understanding and support.

<br>

## 🔗 Acknowledgments

- **[ASP.NET Core](link)**: For providing the framework and tools used to build this application.
- **[Entity Framework Core](link)**: For ORM and database management.
- **[Bootstrap](https://getbootstrap.com/)**: For the responsive design and styling.
- **[FluentAssertions](https://www.nuget.org/packages/FluentAssertions)**: For providing a more readable and fluent way to write assertions in unit tests.
- **[Moq](https://www.nuget.org/packages/Moq)**: For helping create mock objects for unit testing and verifying interactions.

<br>

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

<br>

## 📫 Contact

Inquiries - [support@eShop.com](email@email.com)

Project Link: [eShop GitHub](https://github.com/LH-Hansen/eShop)

