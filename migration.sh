dotnet tool install --global dotnet-ef
dotnet ef database update -p src\\CaseStudy.Product.Infra -s src\\CaseStudy.Product.API
sleep 5m 