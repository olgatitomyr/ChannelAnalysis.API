#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ChannelAnalysis.API/ChannelAnalysis.API.csproj", "ChannelAnalysis.API/"]
RUN dotnet restore "ChannelAnalysis.API/ChannelAnalysis.API.csproj"
RUN dotnet dev-certs https
COPY . .
WORKDIR "/src/ChannelAnalysis.API"
RUN dotnet build "ChannelAnalysis.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChannelAnalysis.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
ENTRYPOINT ["dotnet", "ChannelAnalysis.API.dll", "--urls=http://0.0.0.0:5001;https://0.0.0.0:5002"]