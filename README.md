# Controle Financeiro
Projeto de Controle de Finanças Pessoais com registro de gastos (saída) e ganhos (entrada), além do cadastro de categorias para rápida identificação de cada registro. Também conta com gráficos para visualizações dinâmicas do registros do sistema.

## Requisitos atendidos
* Uso do banco de dados SQLite para persistência de dados.
* Utilização do padrão de arquitetura em camadas, MVC.
* Criação de categorias para os gastos.
* Lançamento de gastos com os seguintes dados: data, valor, descrição e categoria.
* Visualização do total de gastos por mês.
* Visualização do total de gastos por categoria do mês.
* Edição das categorias cadastradas.
* Edição ou exclusão dos gastos lançados.
* Cadastro de cor e ícone para categoria.
* Gráfico no formato de pizza para a visualização dos gastos por categoria e mês.
* Gráfico no formato de barras verticais para comparação dos gastos entre meses e categoria.
* Gráfico de linha que permita a visualização dos gastos por dia.

## Manual de Usuário
### Como cadastrar uma categoria
1. Clique em “Categoria” e acesse a interface de categoria
2. Clique em “Cadastrar” 
3. Preencha o formulário da janela que abriu
4. Clique em “Confirmar” para cadastrar a categoria

### Como editar uma categoria
1. Clique em “Categoria” e acesse a interface de categoria
2. Clique em “Editar” no registro que deseja realizar modificações
3. Na nova janela, edite as informações necessárias
4. Clique em “Confirmar” e suas alterações serão salvas

### Como remover uma categoria
1. Clique em “Categoria” e acesse a interface de categoria
2. Clique em “Remover” no registro que deseja deletar

### Como cadastrar um registro de Entrada/Saída
1. Clique na seção que deseja cadastrar um registro (Entrada ou Saída)
2. Clique no botão do canto superior direito “Cadastrar”
3. Preencha as informações na janela de cadastro
4. Clique em “Confirmar” para cadastrar o registro

### Como editar um registro de Entrada/Saída
1. Clique na seção que deseja alterar um registro (Entrada ou Saída)
2. Clique no botão “Editar” ao lado direito do registro que deseja editar
3. Modifique as informações que deseja na janela de edição
4. Clique em “Confirmar” para salvar as alterações

### Como remover um registro de Entrada/Saída
1. Clique na seção que deseja remover um registro (Entrada ou Saída)
2. Clique em “Remover” no registro que deseja deletar

### Como visualizar os gráficos
1. Clique em “Gráficos” e acesse a interface de gráficos
2. Clique no tipo de gráfico que deseja visualizar
   - Pizza: entradas (ganhos) e saídas (gastos) por categoria ou mês neste ano
   - Barra: soma de gastos por categoria em cada mês do ano atual 
   - Linha: soma dos gastos em cada dia ao longo do ano
3. Escolha o filtro desejado, se necessário
