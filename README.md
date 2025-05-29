# ShellFinder

**ShellFinder** is a simple C# console application to scan a target domain for common shell paths using a customizable wordlist.

## Features

- Fixes and validates input URLs
- Concurrently scans shell paths with a limit of 10 parallel requests
- Colored console output for clear status display
- Easy to extend and customize

## Usage

1. Clone or download this repository.
2. Add your shell paths to a text file (one path per line), e.g. `Wordlists/shells.txt`.
3. Build and run the project.
4. Enter the target domain (with or without scheme).
5. Enter the path to your shell wordlist file.
6. The program scans and prints the results.

## Requirements

- .NET 6.0 SDK or later
- Internet connection

## License

MIT License

