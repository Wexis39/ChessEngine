# Pure C# Chess Engine & Library

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download)
[![Architecture: OOP](https://img.shields.io/badge/Architecture-Object_Oriented-green.svg)]()

<img width="425" height="446" alt="Board UI 1" src="https://github.com/user-attachments/assets/0dbe7621-342e-43c7-8540-f1f0d72e2198" />

---

## 🎯 Project Overview

This project is a high-performance, fully independent chess engine and library developed from scratch in **pure C#**. Unlike implementations that rely on external libraries or third-party engines, this codebase was built to provide a deep, fundamental understanding of chess logic, board state management, and algorithmic efficiency.

The engine is designed as a library, meaning it can be easily integrated into any C# application—whether you are building a desktop GUI, a terminal-based game, or an AI analysis tool.

## 🏗️ Architectural Philosophy (OOP)

The engine's architecture follows strict **Object-Oriented Programming (OOP)** principles to ensure that the complex nature of chess is broken down into maintainable, readable, and scalable components:

*   **Modular Decomposition:** Core logic is decoupled into specialized classes (e.g., `Board`, `MoveValidator`, `Piece`, `MoveGenerator`). This ensures that changing the evaluation logic does not affect the move generation integrity.
*   **Encapsulation:** The internal state of the board is managed safely, exposing only necessary APIs to the user while maintaining high performance.
*   **Extensibility:** By utilizing interfaces and abstract base classes, developers can easily plug in new evaluation algorithms, search depths, or custom piece movement rules without restructuring the existing codebase.

## 🧠 Core Features & Capabilities

This engine fully supports the standard laws of chess (FIDE rules), ensuring that every game state transition is valid and accurate.

*   **Advanced Move Generation:** Optimized algorithms for generating pseudo-legal and legal moves.
*   **Special Rule Implementation:** 
    *   **Castling:** Complete support for King and Queen-side castling, including state validation for path clearance and check status.
    *   **En Passant:** Precision logic for handling pawn captures "in passing."
    *   **Pawn Promotion:** Full implementation of automated promotion to Queen, Rook, Bishop, or Knight.
*   **Game State Tracking:** Manages castling rights, en passant potential, and draw conditions (including the fifty-move rule).
*   **Performance:** Designed with a low memory footprint, focusing on high-speed execution suitable for recursive search trees.

## 🛠️ Technical Specifications

*   **Language:** C#
*   **Framework:** .NET 8.0
*   **Design Pattern:** Purely native .NET (Zero external dependencies).
*   **Compatibility:** Cross-platform (Windows, Linux, macOS).

## 🚀 Roadmap

- [x] Engine Initialization & Architecture Setup
- [x] Core Move Generation & Validation
- [x] Special Rule Implementation (Castling, En Passant, Promotion)
- [ ] UCI (Universal Chess Interface) Compatibility
- [ ] Real-time Multiplayer Integration (SignalR / TCP/IP)

## 📦 Installation & Usage

To clone and run this repository locally:

```bash
git clone [https://github.com/Wexis39/ChessEngine.git](https://github.com/Wexis39/ChessEngine.git)
cd ChessEngine
dotnet build
```

<img width="345" height="278" alt="Board UI 3" src="https://github.com/user-attachments/assets/4ae822fb-e8f5-4659-a384-f7863b6e4118" />
<img width="404" height="276" alt="Board UI 2" src="https://github.com/user-attachments/assets/5b45ca72-4d66-45ab-a612-df5e6e6c9a9d" />
