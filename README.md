# 🤖 Discord Confession Bot 💬

Welcome to the **Discord Confession Bot**! This bot allows users to share their anonymous confessions directly in your Discord server. It's a fun and engaging way to get people talking and interacting within your community!

## 📑 Table of Contents

- [✨ Features](#-features)
- [⚙️ Setup](#%EF%B8%8F-setup)
- [🚀 Usage](#-usage)
- [🔧 Commands](#-commands)

## ✨ Features

- 🔒 **Anonymous Confessions**: Users can share their secrets without revealing their identity.
- 👻 **Ephemeral Replies**: Confessions are acknowledged privately to maintain anonymity.
- 📝 **Message Logging**: Every confession is logged with the user’s name and message content for moderation purposes.
- ⚡ **Quick Setup**: Get the bot running in your server with minimal configuration.
- 🌐 **Guild-Specific Commands**: Slash commands are registered at the guild level for faster deployment and testing.

## ⚙️ Setup

### 🛠️ Prerequisites

Before you start, ensure you have the following:

- 📦 **.NET Core SDK**: [Download and install](https://dotnet.microsoft.com/download) the .NET Core SDK.
- 🔑 **Discord Bot Token**: Obtain your bot token from the [Discord Developer Portal](https://discord.com/developers/applications).

### 📝 Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/yourusername/discord-confession-bot.git
    cd discord-confession-bot
    ```

2. **Configure your bot:**

   - Open the project in your favorite IDE.
   - Set your Discord bot token as an environment variable named `DISCORD_TOKEN`.
   - Replace `your_guild_id_here` in the code with your Discord server's ID.

3. **Build the project:**

    ```bash
    dotnet build
    ```

4. **Run the bot:**

    ```bash
    dotnet run
    ```

🎉 Your bot should now be running and ready to serve your community!

## 🚀 Usage

Once your bot is up and running, users can start using the `/confesar` command to share their anonymous confessions. The bot will acknowledge their confession privately and post it in the server channel.

### 💡 Example

```
/confesar text: I once ate an entire pizza by myself and blamed it on the dog.
```

The bot will post:

```
Anonymous Confession: I once ate an entire pizza by myself and blamed it on the dog.
```

## 🔧 Commands

- `/confesar text:<your_confession>`: Submit an anonymous confession.

### 📝 Logging

Every confession is logged in the console with the username and message text for moderation. This helps ensure responsible use of the bot.
