# Requisitos e funcionalidades

O sistema de gestão de estoque e pedidos será uma aplicação web, desenvolvida em arquitetura MVC utilizando ASP.NET Core. As funcionalidades principais serão:

### 1. Módulo de produtos

- **Cadastro de produtos**: Permitir o registro de novos produtos com informaçoes como nome, marca, descricão, preço de compra, preço de venda, quantidade em estoque e unidade de medida.

- **Listagem de produtos**: Exibir uma lista de todos os produtos cadastrados com opção de busca e filtragem.

- **Edição de produtos**: Possibilitar a alteração das informações de produtos existentes.

- **Exclusão de produtos**: Permitir a remoção de produtos do sistema.

# 2. Módulo de Estoque

- **Entrada de estoque**: Registrar a entrada de produtos no estoque, aumentando a quantidade disponível.

- **Saída de estoque**: Registrar a saída de produtos no estoque, diminuindo a quantidade disponível.

- **Consulta de estoque**: Visualizar o nível de estoque de cada produto.

- **Alertas de estoque mínimo**: Notificar quando a quantidade de um produto atingir um nível mínimo predefinido.

# 3. Módulo de Clientes

- **Cadastro de clientes**: Permitir o registro de clientes, com campos como Nome/Razão Social, CPF/CNPJ, telefone, e-mail, endereço completo e observações.

- **Edição de clientes**: Possibilitar a alteração das informações de um cliente já cadastrado.

- **Listagem de clientes**: Exibir uma lista de todos os clientes com opção de busca por filtros com nome, CPF/CNPJ ou código do cliente.

- **Exclusão e arquivamento de clientes inativos**: Permitir arquivamento de clientes sem excluir permanentemente os dados, para manter o histórico de pedidos e orçamentos.

- **Histórico de interações**: Mostrar pedidos e orçamentos vinculados ao cliente, com visualização rápida do histórico.

# 4. Módulo de Orçamentos

- **Criação de orçamentos**: Gerar orçamentos vinculados a um cliente, selecionando produtos, quantidades e valores. Incluir validade do orçamento e campo de observação.

- **Edição de orçamentos**: Permitir alterações em orçametos não faturados (itens, quantidades, valores e observações).

- **Listagem de orçamentos**: Exibir todos os orçamentos com filtros por status (aberto, aprovado, vencido, convertido em pedido), cliente e datas.

- **Conversão para pedido**: Orçamentos aprovados podem ser convertidos em pedidos automaticamente, mantendo os dados e gerando um novo registro no módulo de pedidos.

- **Cancelamento e expiração**: Permitir o cancelamento manual ou expiração automática após o prazo de validade, sem afetar o histórico.

- **Alertas de vencimento**: Emitir alertas de orçamentos próximos ao vencimento.

- **Exportar**: Possibilitar a exportação do orçamento em PDF com layout profissional.

# 5. Módulo de Pedidos

- **Criação de pedidos**: Registrar novos pedidos, associando, clientes, produtos e suas quantidades.

- **Listagem de pedidos**: Exibir uma lista de todos os pedidos, com opções de busca e filtragem por status (pendente, concluído, cancelado).

- **Edição de pedidos**: Permitir alteração de pedidos existentes (adicionar/remover proutos, alterar quantidades).

- **Cancelamento de pedidos**: Possibilitar o cancelamento de pedidos.

- **Atualizar status do pedido**: Alterar o status de um pedido.

# 6. Módulo de Usuário e autenticação

- **Login**: Autenticar usuários no sstema

- **Gerenciamento básico de usuários**: Cadastro de novos usuários (apenas para fins didáticos, a princípio sem funcionalidades avançadas de permissão).