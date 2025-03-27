# eShop

## Table of Contents

### Getting Started
- [Introduction](#-introduction)
- [Features](#-features)
- [Future Plans](#-future-plans)
- [System Requirements](#%EF%B8%8F-system-requirements)
- [Installation](#-installation)
- [Usage](#-usage)
- [Screenshots](#-screenshots)
- [FAQs](#-faqs)

### Technical Details
- [Diagrams](#-diagrams)
- [Framework](#%EF%B8%8F-framework)
- [Dependencies](#-dependencies)
- [API Documentation](#-api-documentation)
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

Welcome to the eShop project! This application is a brand management system designed to help manage and display brand information. Users can create, update, delete, and search brands through an easy-to-use interface. This project implements pagination for displaying brands, with options for adding or modifying brand details and features an efficient search mechanism.

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

#1. Database diagram
![eShop_Db_Diagram](https://github.com/user-attachments/assets/5f060eeb-eee2-4a9d-9176-65d52399030e)


<br>

## 🛠️ Framework

This project is built using [Your Framework Name].

| Project       | Framework     | Folder structure  |
| ------------- |:-------------:| -----------------:|
| BuisnessLogic | .NET 8.0      | FBF               |
| DataAcess     | .NET 8.0      | FBF               |
| Presentation  | .NET 8.0      | FBT               |

<br>

## 📚 Dependencies

This project depends on the following libraries:

### Nuget Packages

| Package                                 | Creator   | Version |   Project  |
|:----------------------------------------|:---------:|:-------:|:----------:|
| Microsoft.EntityFrameworkCore           | Microsoft | `8.0.10`| DataAccess |
| Microsoft.EntityFrameworkCore.SqlServer | Microsoft | `8.0.10`| DataAccess |
| Microsoft.EntityFrameworkCore.Tools     | Microsoft | `8.0.10`| DataAccess |
<br>

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
- Add Product
- Fix bug pagination bug

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
  - **Status**: To be improved in future updates.

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


<br>

## 🤝 Contributing

Thank you for your interest in contributing! At this time, we are not accepting contributions. We appreciate your understanding and support.

<br>

## 🔗 Acknowledgments

- **[ASP.NET Core](link)**: For providing the framework and tools used to build this application.
- **[Entity Framework Core](link)**: For ORM and database management.
- **Bootstrap**: For the responsive design and styling.

<br>

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

<br>

## 📫 Contact

Inquiries - [support@eShop.com](email@email.com)

Project Link: [eShop GitHub](https://github.com/LH-Hansen/eShop)

