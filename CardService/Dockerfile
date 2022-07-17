FROM mcr.microsoft.com/dotnet/aspnet:6.0       
WORKDIR /app           
COPY bin/release/net6.0/publish/ .                                  
ENTRYPOINT ["dotnet", "CardService.dll"] 