# QuoteManager 🧾

QuoteManager is a full-stack portfolio project focused on learning and showcasing modern web development and DevOps skills. The project aims to cover a wide range of technologies, including ASP.NET Core, Angular, Docker, Kubernetes, CI/CD pipelines, cloud integration, testing, and monitoring.

---

## 🚧 Project Status

> **Currently:**  
> ✅ ASP.NET Core Web API initialized (`QuoteManager.API/`)  
> ✅ Project structure set up using Clean Architecture  
> ✅ Database schema defined and initial migration applied (via EF Core & Dockerized SQL Server)  
> ✅ Authentication & Authorization implemented with JWT tokens  
> ✅ Secured API endpoints with role-based authorization  
> ✅ Unit tests for core services (AuthService, QuoteService)  
> ⏳ CI/CD setup with GitHub Actions — _next step_  
> ⏳ Frontend setup (Angular + TypeScript)  

---

## 🔐 Authentication & Authorization

- User registration and login endpoints implemented with JWT-based authentication  
- All quote and quote item endpoints secured using `[Authorize]`  
- Passwords are hashed securely before storing in the database  
- Secrets like JWT key and DB password moved to `.env` file for security

---

## 📁 Structure

QuoteManager/  
├── QuoteManager.API/         # ASP.NET Core Web API backend  
├── QuoteManager.Application/ # Business logic, use cases, interfaces  
├── QuoteManager.Core/        # Domain entities & contracts  
├── QuoteManager.Infrastructure/ # EF Core context, repositories  
├── QuoteManager.Tests/       # Unit & integration tests  
├── README.md                 # Project overview  
└── .gitignore                # Git ignore rules  

---

## 🧠 Purpose

This project serves as:

- A portfolio piece to demonstrate real-world architecture and DevOps knowledge  
- A learning playground for full-stack development  
- A foundation to gradually include advanced technologies  

---

## 📌 Goals (to be developed)

- RESTful API with ASP.NET Core  
- Angular frontend  
- PostgreSQL + EF Core  
- Redis for caching/session  
- RabbitMQ for messaging  
- Docker + Kubernetes  
- CI/CD with GitHub Actions  
- Monitoring (Prometheus + Grafana)  
- Full role-based access control  
- Automated testing (unit + integration)  

---

## 🛠 Technologies (Planned)

- .NET 8 / C#  
- Angular + TypeScript  
- Docker / Kubernetes  
- GitHub Actions  
- Azure  
- Redis / RabbitMQ  
- Prometheus / Grafana  
- Serilog / Swagger / Health Checks  

---

## 📈 Progress Tracking

The README will be updated as development continues.  
Milestones and commits will reflect major stages (e.g., frontend init, CI/CD setup, cloud deploy).  

---

## 📜 License

MIT