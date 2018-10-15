# todo-api

Permite realizar get, post, put e delete de uma lista de tarefas.  
Além dos dados de título, descrição, e status, a API também gerência das datas de cada ação tomada.  
Para remover um item da lista mas mantém o histórico, pode-se utilizar o endpoint remove/id.  
A API foi criada em .NET Core com EF Core e hospedada no servidor da Amazon.  
Link: todoapi.us-west-2.elasticbeanstalk.com/api/todo  
O banco de dados utilizado é o SQL Server, também armazenado em um RDS da Amazon.  
Utiliza o tipo básico de autenticação de endpoint(login: admin/admin).  
