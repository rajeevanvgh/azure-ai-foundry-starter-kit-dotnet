# 📘 azure-ai-foundry-starter-kit-dotnet

A clean, modern, production‑ready starter kit for integrating **Azure AI Foundry** with **.NET 10**, using the latest **Azure.AI.OpenAI 2.x SDK**.

This project provides a **minimal, reliable baseline** for building AI‑powered applications without unnecessary complexity.  
Perfect for learning, prototyping, interviews, and real‑world projects.

---

# 🚀 Features

- ✔️ Modern **Azure AI Foundry** integration  
- ✔️ Clean, reusable **AzureAIChatService**  
- ✔️ **Minimal API** with chat + streaming endpoints  
- ✔️ **Console runner** for quick testing  
- ✔️ Supports **JSON mode**  
- ✔️ Clean architecture (API → Core → Console)  
- ✔️ No augmentation logic (RAG, tools, search) — intentionally minimal  
- ✔️ Easy to extend for future features  

---

# 📁 Repository Structure

```
azure-ai-foundry-starter-kit-dotnet/
│
├── LICENSE
├── .gitignore
├── README.md
├── AzureAIFoundryStarter.sln
│
└── src/
    ├── AzureAIFoundryStarter.Api/          # Minimal API
    ├── AzureAIFoundryStarter.Core/         # Service layer + models
    └── AzureAIFoundryStarter.Console/      # Console test runner
```

---

# ⚙️ Prerequisites

- .NET 10 SDK  
- Azure AI Foundry resource  
- A deployed model (e.g., `gpt-4o-mini`)  
- API key + endpoint from Azure  

---

# 🔧 Configuration

Update your `appsettings.json`:

```json
{
  "AzureAI": {
    "Endpoint": "https://YOUR_RESOURCE_NAME.openai.azure.com/",
    "ApiKey": "YOUR_API_KEY",
    "Deployment": "YOUR_DEPLOYMENT_NAME"
  }
}
```

---

# 🏗️ Creating a Deployment (Required)

Before using the SDK, you **must create a model deployment** in Azure AI Foundry.

### Steps:

1. Go to **Azure AI Foundry portal**  
2. Open your **Project**  
3. Navigate to **Deployments**  
4. Click **+ Deploy Model**  
5. Choose a model (e.g., `gpt-4o-mini`)  
6. Give it a **deployment name**  
7. Use that name in your configuration  

If you skip this step, the SDK will return an error because it cannot call a model without a deployment.

---

# 🧱 Core Service (AzureAIChatService)

This service wraps the Azure AI SDK and provides:

- `AskAsync` → simple chat  
- `AskJsonAsync` → JSON mode  
- `StreamAsync` → streaming responses  

No tools. No augmentation. Clean and minimal.

---

# 🌐 Minimal API Endpoints

### **POST /chat**  
Send a prompt and receive a full response.

### **POST /chat/stream**  
Receive a streamed response (chunked text).

---

# 🧪 Console Runner

A simple console app to test your Azure AI integration:

```
Ask something:
> Hello
AI Response:
Hello! How can I assist you today?
```

---

# 🛠 How to Run

### API
```
cd src/AzureAIFoundryStarter.Api
dotnet run
```

### Console
```
cd src/AzureAIFoundryStarter.Console
dotnet run
```

---

# 📦 NuGet Packages Used

- `Azure.AI.OpenAI`  
- `Azure.Identity`  

---

# ❓ FAQ

### **Do I need to create a deployment in Azure AI Foundry?**  
Yes — the SDK requires a **deployment name**, not just a model name.

### **Why does the model sometimes give outdated information?**  
LLMs do not have real‑time awareness.  
This starter kit intentionally does **not** include:

- Web search  
- RAG  
- Function tools  

These can be added later.

### **Can I extend this starter kit?**  
Absolutely — you can add:

- RAG (Azure AI Search)  
- Function calling  
- Web search tools  
- Date/time tools  
- Prompt Flow integration  
- Logging + retry policies  
- Key Vault integration  

The architecture is designed for easy extension.

---

# 📝 License (MIT)

```
MIT License

Copyright (c) 2025

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

---

# 🙌 Contributions

Feel free to fork, extend, and share improvements.

---
