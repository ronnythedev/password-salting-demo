# Password Salting Demo

## Overview
This project demonstrates best practices for secure password storage using `BCrypt` hashing and salting. 

Built as a C# console application, it shows how to securely handle user registration and authentication without storing plaintext passwords.

It's a companion to [my post](https://ronnydelgado.com), where I dive deeper into the why and how.

## Features
- User registration with secure password hashing
- Login authentication against hashed passwords
- Automatic salt generation and secure storage
- Password validation with minimum length requirements
- Console-based user interface for easy interaction

## Technical Details
- Built with .NET 9.0
- Uses `BCrypt.Net` for industry-standard password hashing
- Demonstrates proper exception handling for security operations
- Shows case-insensitive username comparison
- In-memory user storage (for demonstration purposes)

## Getting Started
1. Clone the repository
2. Ensure you have the .NET 9.0 SDK installed
3. Build the project: `dotnet build`
4. Run the application: `dotnet run`

## Security Considerations
This demo implements:
- Password hashing with salt (using `BCrypt`)
- Minimum password length validation
- Basic input validation
- Protection against common credential storage vulnerabilities

## Educational Purpose
This project is designed for educational purposes to demonstrate:
- Why password salting is essential
- How to implement secure password storage
- The basics of user authentication flow

## Future Improvements
- Add password strength requirements (special characters, numbers, etc.)
- Implement secure password input masking
- Add persistent storage for user accounts
- Add password reset functionality
- Implement rate limiting for login attempts

## License
[MIT License](LICENSE)
