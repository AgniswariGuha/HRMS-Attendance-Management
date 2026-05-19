# HRMS Attendance & Leave Management System

## Project Overview

A web-based Attendance & Leave Calculation module developed using ASP.NET Core MVC.

The system calculates employee working hours and determines leave deduction based on attendance duration.

This project was developed as part of an HRMS assignment.

---

# Features

## Employee Features

- Employee Login & Registration
- Daily Check-In
- Daily Check-Out
- Attendance Tracking
- Working Hours Calculation
- Leave Deduction Calculation
- Attendance History Dashboard

---

## HR Features

- HR Dashboard
- View All Employee Attendance
- Filter Attendance Records
- View Working Hours
- View Attendance Status
- View Leave Deduction Summary

---

# Attendance Rules

| Working Hours            | Status   | Leave Deduction |
| ------------------------ | -------- | --------------- |
| >= 8 Hours               | Present  | 0               |
| >= 4 Hours and < 8 Hours | Half Day | 0.5             |
| < 4 Hours                | Absent   | 1               |

---

# Technologies Used

## Backend

- ASP.NET Core MVC (.NET 10)
- Entity Framework Core

## Frontend

- HTML
- CSS
- Bootstrap
- jQuery

## Database

- SQLite

---

# Project Architecture

```text
Controllers
Models
Views
Data
wwwroot
```

---

# UI Features

- Modern Pastel Theme
- Responsive Dashboard
- HR Summary Cards
- Status Badges
- Hero Sections
- Modern Table Design

---

# Database Tables

## Users

Stores:

- Employee Details
- HR Details

## Attendances

Stores:

- Check-In Time
- Check-Out Time
- Working Hours
- Attendance Status
- Leave Deduction

---

# Setup Instructions

## Clone Repository

```bash
git clone YOUR_GITHUB_REPOSITORY_URL
```

---

## Restore Packages

```bash
dotnet restore
```

---

## Run Migration

```bash
dotnet ef database update
```

---

## Run Project

```bash
dotnet run
```

---

# Default Route

```text
/Auth/Login
```

---

# Demo Credentials

## HR Login

Email:

```text
hr@test.com
```

Password:

```text
123456
```

---

## Employee Login

Email:

```text
emp@test.com
```

Password:

```text
123456
```

---

# Hosting

The project is deployed using:

- Render
- Docker
- SQLite

# Author

AGNISWARI GUHA

ASP.NET Core Developer
