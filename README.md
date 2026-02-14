# Omega Sudoku

## Project Overview
Omega Sudoku is a Sudoku Solver written in C#. Its goal is to accept a string representing a sudoku puzzle and display the solution of this puzzle. It is designed to parse, validate, and solve Sudoku puzzles using an efficient algorithm. 

## Features
* **Sudoku Solving:** Implements a backtracking algorithm to solve standard 9x9 Sudoku puzzles.
* **Parsing:** Converts string representations of Sudoku boards into a matrix and back.
* **Advanced Validation:**
    * **Initial Validation:** Checks if the input string representing a Sudoku board is valid in terms of the string length, and invalid characters.
    * **Sudoku Validation:** Checks for duplicate numbers in rows, columns, and submatrices.
* **Console Visualization:** Prints the Sudoku board to the console.
* **Unit Testing:** Comprehensive test suite covering valid boards, invalid strings and boards, and unsolvable puzzles.

## Project Structure
The codebase is organized into modular components:

* `Program.cs`: The entry point of the application. gets an input of a Sudoku expression and shows the solved Sudoku board to the user.
* `SudokuManager.cs`: Combines functions from other classes to find a solution to the Sudoku puzzle, including converting the string and checking its validity.
* `Solver.cs`: Contains the core algorithmic logic using Recursive Backtracking, Bitmasking and MRV to solve the puzzle.
* `ConvertSudoku.cs`: Converts input strings into the 2D arr and vice versa.
* `PrintSudoku.cs`: Responsible for printing the Sudoku board to the console.
### Validation
* `SudokuValidation.cs`: Provides functions to validate that there are no duplicates in rows/columns/blocks.
* `SudokuInitialValidation.cs`: Provides functions to validate that the sudoku string has suitable length, and valid characters.

### Interfaces (`Interfaces` folder)
* `IConvertSudoku.cs`: Defines the contract for parsing input strings and converting them into a structured Sudoku grid and vice versa.
* `IInitialValidation.cs`: Interface for validating the sudoku expression (suitable length, valid characters).
* `IManager.cs`: Defines the flow control of the application, serving as a mediator between the user input, the solver, and the validation logic.
* `ISolver.cs`: Defines the contract for the Sudoku solving algorithm, allowing different solving strategies.
* `IValidation.cs`: Interface for validating the board content (checking for duplicates in rows/columns/blocks).

### Tests (`Omega_Sudoku.Tests`)
* `UnitTestValidSudokus.cs`: Contains tests with valid Sudokus (puzzles with a solution).
* `UnitTestInvalidSudokus.cs`: Contains tests with invalid Sudokus (have duplicates in rows/columns or blocks or don't have a solution).
* `UnitTestInvalidSudokuString.cs`: Contains tests with invalid Sudoku strings (unsuitable length, invalid characters).

## Installation and Usage

### Prerequisites
* .NET SDK (Version 6.0 or higher recommended)
* Visual Studio / VS Code

### Running the Application
1.  Clone the repository:
    ```bash
    git clone https://github.com/ofri315/Omega_Sudoku_CS
    ```
2.  Navigate to the project directory:
    ```bash
    cd Omega_Sudoku
    ```
3.  Run the application:
    ```bash
    dotnet run --project Omega_Sudoku
    ```

### Running Tests
To validate the system integrity and check all test cases:
```bash
dotnet test
