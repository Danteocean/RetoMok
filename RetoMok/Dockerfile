FROM microsoft/iis as base

FROM microsoft/dotnet-framework:4.7.2-sdk AS build
WORKDIR /src
COPY ["NetFrameworkDemo.csproj", "NetFrameworkDemo/"]
RUN dotnet restore "NetFrameworkDemo/NetFrameworkDemo.csproj"
WORKDIR "/src/NetFrameworkDemo"
COPY . .
RUN dotnet build "NetFrameworkDemo.csproj" -c Release -o \app

FROM build AS publish
RUN dotnet publish "NetFrameworkDemo.csproj" -c Release -o \publish

FROM base AS final
WORKDIR /inetpub/wwwroot
COPY --from=publish \publish .