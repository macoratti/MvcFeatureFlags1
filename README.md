# MvcFeatureFlags

Os sinalizadores de recursos (Feature Flags) são uma técnica que permite controlar o comportamento do seu aplicativo em tempo de execução,
permitindo introduzir, testar e ativar ou desativar novos recursos com segurança, sem a necessidade de implantações frequentes de código

Para usar este recurso temos que incluir o pacote nuget

dotnet add package Microsoft.FeatureManagement.AspNetCore  

Install-Package
Microsoft.FeatureManagement.AspNetCore  


e na classe Program.cs
adicionar o gerenciador de recursos ao contêiner de serviços da aplicação

builder.Services.AddFeatureManagement();

vai Procurar pela seção ‘FeatureManagement’ no arquivo appsettings.json

"FeatureManagement":{
   "CreateProduct":false,
   "DeleteProduct":false
}
builder.Services.AddFeatureManagement(Configuration.GetSection("MyFeatureFlags"));

Procura pela seção ‘MinhaFeatureFlags’ no arquivo appsettings.json

“MinhaFeatureFlags":{
      "CreateProduct":false,
      "DeleteProduct":false
}
