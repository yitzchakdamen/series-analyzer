
---

````markdown

# Number Series Analyzer - C# Console Project

## 📌 Overview
This is a beginner-level C# console application that allows users to input a series of positive numbers and perform various operations on the series through an interactive menu.  
The application demonstrates the use of control structures, lists, input validation, loops, and simple data processing algorithms.

---

## ⚙️ Features

- ✅ Input a new series of numbers (replaces the current series).
- 🔢 Display the series in:
  - The original order.
  - Reversed order.
  - Sorted order (ascending).
- 📊 Perform data analysis:
  - Find the **Maximum** value.
  - Find the **Minimum** value.
  - Calculate the **Average**.
  - Count the number of elements.
  - Calculate the **Sum** of the series.
- 🚪 Exit the application.

---

## 🚀 How to Run

### Option 1: From Command Line

1. Compile the program:
   ```bash
   csc Program.cs
````

2. Run it:

   ```bash
   Program.exe
   ```

3. You can also provide initial values as command-line arguments:

   ```bash
   Program.exe 4.5 2 3
   ```

### Option 2: Using Visual Studio / Rider

1. Open the project in your IDE.
2. Set `Program.cs` as the startup file.
3. Run the program using `Start` or `F5`.

---

## 🧪 Input Format

* Input numbers separated by **spaces** or **commas**.

* Example:

  ```
  10, 20, 30
  ```

* Only **positive numbers** are accepted.

* At least **3 numbers** must be entered.

---

## 📂 Project Structure

* `MainProgram()` — Initializes the system and loops through the menu.
* `SeriesManagement()` — Handles input from user or command-line.
* `MenuManagement()` — Displays the menu and handles choices.
* Utility Methods:

  * `ReversedOrder()`
  * `SortLest()` (Selection sort)
  * `MaxValue()`, `MinValue()`, `Average()`, etc.
  * `Display()`, `ActionMessage()`, `PrintProgress()`

---

## 🎓 Educational Goals

This project was created as a **first C# project** in a programming course.
It helps students understand:

* Structuring console applications.
* Handling user input and validation.
* Using `List<T>` and basic data structures.
* Writing and organizing methods.
* Building simple logic-driven menus.

---

## 🧠 Future Improvements

* Allow saving/loading series from files.
* Add support for negative numbers (optional).
* Improve input parser to handle invalid separators.
* Add UI using Windows Forms / WPF in advanced versions.

---

## 📌 Author

* Developed as part of an introductory course in C#.
* Student Project – Educational Purpose Only.

```

