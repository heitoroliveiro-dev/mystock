# Arquitetura do sistema

O sistema seguirá a arquitetura MVC, com as seguintes camadas:

- **Camada de apresentação**: Desenvolvida com HTML, Tailwind CSS e JavaScript, responsável pela interface do usuário e interação.

- **Camada de Aplicação**: Responsável por receber as requisições do usuário, interagir com a camada de domínio e retornar as respostas.

- **Camada de domínio**: Contém a lógica de negócio e as entidades do sistema.

- **Camada de dados**: Responsável pela comunicação com banco de dados, utilizando Entity FrameWork Core para o mapeamento objeto-relacional.

# Tecnologias utilizadas

- **Backend**: C#, ASP.NET Core MVC

- **Banco de dados**: SQLServer

- **ORM**: Entity Framework Core

- **Containerização**: Docker

- **Cloud**: Verificar opções sem custo

- **Frontend**: HTML, TailwindCSS e JavaScript