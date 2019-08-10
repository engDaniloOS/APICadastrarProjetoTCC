# APICadastrarProjetoTCC

#elemento - Termo genérico que deve ser substituído por aluno, professor ou projeto
	
#POST	api/elemento	=> registra um novo elemento no banco a partir de um json enviado no corpo da requisição. Json: model.

#GET 	api/elemento	=> lista todos os elementos registrados e ativos no banco;

#GET 	api/elemento/id/{id}	=> busca um determinado elemento a partir do seu id. id: int.

#GET 	api/elemento/buscar/{filtro}	=> busca um elemento por Nome ou Registro que corresponda exatamente ao filtro

#GET 	api/elemento/filtrar/{filtro}	=> busca elementos que contenham o filtro.

#PUT 	api/elemento/atualizar	=> atualiza um elemento no banco de acordo com o json enviado no corpo da requisição. Json: model.

#DELETE	api/elemento/excluir	=> exclui um elemento do banco a partir do id enviado no corpo da requisição. id: int.
	
