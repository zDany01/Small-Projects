# 📂 Small Projects

A collection of C# utility scripts and mini-applications. This repository serves as a sandbox for testing ideas and storing useful tools for game launchers and system management.

> ⚠️ **Disclaimer: Provided As-Is**
> These projects were developed as **"on-demand" solutions** to solve specific, immediate problems. They do **not** include strict input validation, robust error handling, or security checks.
>
> Please be aware that these tools are provided **"as-is"** without any warranty. Users should not expect enterprise-grade stability or safeguards against incorrect usage.

## 🛠️ Technologies
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

## 📚 Project List

| Project Name | Description |
| :--- | :--- |
| **[BraveForwarder](#braveforwarder)** | Forwards command-line arguments directly to the Brave browser. |
| **[FlipperMibo](#flippermibo-flippertest)** | Converts bin dumps into Flipper Zero NFC files. |
| **[GameDateFix](#gamedatefix)** | Launches a process with a modified system date (useful for GOG). |
| **[GOGAdminBypass](#gogadminbypass)** | Launches games that require Admin privileges without triggering UAC prompts. |
| **[SteamStartBypasser](#steamstartbypasser)** | Launches Steam games via ID and tracks execution time. |

---

## 🚀 Usage & Documentation

### BraveForwarder
A simple utility to forward any passed arguments directly to the Brave browser executable.

### FlipperMibo (FlipperTest)
Converts a binary dump file into a format compatible with Flipper Zero NFC.

* **Argument 1:** `Bin file path` (The path to the source dump file)

### GameDateFix
Starts a game making it seem like it started in the past. It also waits for the process to exit to close the program, making it suitable for use as a wrapper in launchers like GOG Galaxy.

* **Argument 1:** `64 bit flag` (Set `1` for 64-bit, `0` for 32-bit)
* **Argument 2:** `Executable Path` (Path to the game .exe)
* **Argument 3:** `Dateback` (Number of years to rewind)
* **Argument 4:** `Timeout` (Seconds to wait, optional)

### GOGAdminBypass
A launcher designed to start games that strictly require Administrator privileges.

* **Argument 1:** `FilePath` (Path to the executable)
* **Argument 2:** `WorkingDirectory` (Optional, defaults to executable folder)

### SteamStartBypasser
Starts a game using its Steam AppID and remains active while the game is running. This is primarily used to allow GOG Galaxy 2.0 to correctly track playtime for Steam games.

* **Argument 1:** `Steam Game ID` (Found in the game's store URL or shortcut)
* **Argument 2:** `Process Name` (The name of the game's executable process)
* **Argument 3:** `Timeout` (Seconds to wait before giving up detection)

## 🤝 Contributing
Feel free to open an issue if you find a bug or want to suggest an improvement for any of the scripts.

## 📄 License
This repository is open source.