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
> ⏳ Frontend setup (Angular + TypeScript) — _next step_

---

## 🔐 Authentication & Authorization

- User registration and login endpoints implemented with JWT-based authentication  
- Secured all quote and quote item API endpoints using role-based authorization  
- Passwords are hashed securely before storing in the database  

---

## 📁 Structure

QuoteManager/  
├── QuoteManager.API/        # ASP.NET Core Web API backend  
├── QuoteManager.Core/       # Domain entities & business logic  
├── QuoteManager.Infrastructure/ # EF Core, DB context, and persistence layer  
├── QuoteManager.Tests/      # Backend tests  
├── README.md                # Project readme  
└── .gitignore               # Git ignore rules

---

## 🧠 Purpose

This project will serve as:

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