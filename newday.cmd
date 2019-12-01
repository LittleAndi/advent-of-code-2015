dotnet new console -n %1
cd tests
dotnet new xunit -n %1tests
cd %1tests
dotnet add reference ../../%1/%1.csproj
dotnet add package Shouldly --version 4.0.0-beta0002
dotnet restore
git add .
git commit -m "Add %1"
