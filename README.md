# MovieProjectDHAUZ

--Applicação em donet 6.0

--Clonar projeto

--Entrar na pasta do projeto pelo terminal (cd .\MovieProjectDHAUZ\)

--dotnet run

--É possível encontrar a documentação das controllers na rota > https://localhost:7104/swagger/index.html

##ENDPOINTS

  POST - Create a new movie 
  
  PUT/:Id - Edit a movie
  
  DELETE/:Id - Remove a movie
  
  GET - List all movies
  
  O parâmetro GetDetailsImdbToEmptyFilds caso seja selecionado true e não for inserida nenhuma informação manual, irá inserir: Nome, Description, Genre, RealeseDate baseado nos dados do retorno do OMDB.
  
  Caso o mesmo esteja false, tera que preencher todas as informações.
  
