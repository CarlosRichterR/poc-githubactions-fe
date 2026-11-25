# poc-githubactions-fe

Frontend **Blazor Server** (.NET 8) del POC — mismo patrón de hosting que ECP (`ECP.NET` + `AddServerSideBlazor` / interactive server).

Llama al API `poc-githubactions-be` por HTTP (`Api:BaseUrl`), no embebido en el mismo proceso.

## Correr en local

```bash
# terminal 1 — API
dotnet run --project ../poc-githubactions-be/src/Poc.Api

# terminal 2 — Blazor
dotnet run --project src/Poc.Web
```

- FE: http://localhost:5048  
- API: http://localhost:5080  

## Nota vs ECP

| | ECP | Este POC |
|---|-----|----------|
| Modelo | Blazor Server (netcoreapp3.1) | Blazor Web App Interactive Server (net8) |
| Host UI | `ECP.NET` | `Poc.Web` (repo FE) |
| API negocio | `IDB.ECP.WebApi` (otro proceso) | `Poc.Api` (otro repo) |
