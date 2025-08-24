
# Whac-A-Mole Game in C# (WinForms)

This is a simple **Whac-A-Mole** game implemented using **C# WinForms**. Players try to click on the moles as they randomly appear in the holes to earn points within a limited time. The game also supports difficulty settings, a countdown timer, and a score board.

## Features

- Random mole appearances
- Click to score points
- Difficulty levels: Easy, Normal, Hard
- Countdown timer (default 30 seconds)
- Real-time score display
- Simple GUI using Windows Forms


## Getting Started

### Prerequisites

- Windows OS
- Visual Studio(Community or higher)
- .NET Framework (4.7.2 or later recommended)

### Installation

1. Clone the repository
2. Open `WhacAMole.sln` in Visual Studio.
3. Build and run the project.

### Usage

1. Choose a difficulty level (Easy, Normal, Hard) from the dropdown.
2. Click the **Start Game** button.
3. Click on the moles (`🐹`) as they appear to score points.
4. The game ends when the timer reaches 0 seconds, and your score is displayed.

## Customization

* You can adjust the **game duration** by modifying `timeLeft` in `Form1.cs`.
* You can modify the **mole appearance interval** by changing the difficulty timer intervals.

