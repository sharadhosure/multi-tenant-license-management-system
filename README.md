# Multi-Tenant License Management System

## Overview

This repository contains a **microservices-based, multi-tenant license management system** built using **ASP.NET Core**.  
The focus of this solution is **clean architecture, tenant isolation, security, and production-aligned design**, rather than full feature depth.

The project is structured to demonstrate how such a system would be designed, scaled, and maintained in a real enterprise or government SaaS environment.



# Key Features

- Microservices architecture
- JWT-based authentication and authorization
- Tenant isolation using TenantId (tenant-per-row strategy)
- Role-based access control (Admin, Reviewer, Agency User)
- CQRS pattern for core license workflows
- Background job for license expiry handling
- ASP.NET MVC frontend for role-based dashboards



# Architecture Overview

## Components

- *API Gateway
  - Entry point for clients
  - Issues JWT tokens
  - Centralizes authentication

- *License Service
  - Core business logic
  - License apply / approve workflow
  - CQRS implementation
  - Tenant-aware data handling

- *Document Service
  - Handles document-related operations
  - Isolated from core business logic

- *Notification Service
  - Designed for asynchronous notifications
  - Keeps non-critical processing out of request flow

- *Web Application (ASP.NET MVC)
  - Role-based dashboards
  - Integrates with backend services via APIs



# Multi-Tenancy Strategy

*Approach: Tenant-per-row

## How it Works
- Every core table includes a `TenantId`
- `TenantId` is derived from JWT claims
- Tenant context is resolved per request using a `TenantProvider`
- All data access is filtered by `TenantId`

This ensures tenant isolation is enforced **server-side**, not based on client input.



# Authentication & Authorization

- JWT-based authentication
- Role-based authorization using claims

# Roles
- Admin
- Reviewer
- AgencyUser

Authorization is enforced at:
- API controller level
- MVC controller level


# CQRS Implementation

CQRS is applied to the **License Service** where it provides clarity and separation of concerns.

# Commands
- ApplyLicense

# Queries
- GetLicensesByTenant (extensible)

The implementation is intentionally lightweight and avoids unnecessary complexity such as event sourcing.



# Background Processing

The License Service includes a background job that:
- Periodically checks for license expiry
- Updates license status accordingly

Implemented using `IHostedService`.

---

# Project Structure

src/
├── ApiGateway/
├── LicenseService/
│ ├── Controllers/
│ ├── Commands/
│ ├── Data/
│ ├── Infrastructure/
│ └── BackgroundJobs/
├── DocumentService/
├── NotificationService/
└── WebApp/