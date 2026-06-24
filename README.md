# Pure C# Chess Engine & Library

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)

A lightweight, high-performance, and fully independent chess engine and library built from scratch using pure C#. This project aims to combine robust software engineering principles with deep chess logic, completely free of external dependencies.

> ⚠️ **Project Status: Work in Progress (WIP)**  
> This project is in its early development stages. I am currently focusing on core board representations and basic piece movement logic.

---

## 🎯 Project Overview

The ultimate goal of this project is to build a self-contained chess engine capable of move generation, evaluation, and search algorithms, developed purely in C#. 

Once the core engine architecture is complete, the roadmap includes integrating real-time multiplayer capabilities using **SignalR** or **TCP/IP** networks to allow two players to compete seamlessly.

## 🛠️ Key Architectural Focus

To ensure the engine is both maintainable and capable of handling deep search trees, the development adheres strictly to high-level software engineering paradigms:

*   **Object-Oriented Programming (OOP) & Clean Code:** Every component is decoupled into highly readable, single-responsibility classes and methods to prevent technical debt as the engine complexity grows.
*   **Advanced Data Structures & Algorithms:** Efficient board representation (such as bitboards or optimized arrays) and move-generation algorithms are at the heart of this project.
*   **Performance Optimization:** Since computational speed is critical for chess engines, execution time and memory footprint are continuously analyzed and optimized right from the first line of code.

## 🚀 Roadmap

- [x] Project Initialization & Architecture Setup
- [/] Basic Piece Movement Logic (In Progress)
- [ ] Legal Move Generation & Validation
- [ ] Board Evaluation & Search Algorithms (Minimax / Alpha-Beta Pruning)
- [ ] UCI (Universal Chess Interface) Compatibility
- [ ] Real-time Multiplayer Integration (SignalR / TCP/IP)

## 📦 Requirements & Installation

- **Environment:** .NET 8.0 SDK (or higher)
- **IDE:** Visual Studio, VS Code, or JetBrains Rider

To clone and run this repository locally:

```bash
git clone [https://github.com/YOUR_USERNAME/YOUR_REPO_NAME.git](https://github.com/YOUR_USERNAME/YOUR_REPO_NAME.git)
cd YOUR_REPO_NAME
dotnet build
