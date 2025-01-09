# Ferramentas alternativas ao Redis
---
## Memcached (Enyim Memcached):
_Documentação: https://github.com/enyim/EnyimMemcached?tab=readme-ov-file_
- Usado comummente para guardar queries ou respostas HTTP

- Prós
	- Somente suporta strings
	- Puramente existente em RAM e sem persistencia
	- Performance similar
	- Facil de aplicar e leve
	
- Cons
	- Limite de 1mb para cada valor com problemas em valores maiores
	- Precisará ser feita a instação de um servidor memcached
	- Será necessária modificação em todas as chamadas das chaves redis que desejar-mos modificar
	- Lento


## Hazelcast (Hazelcast .NET )
_Documentação: https://hazelcast.github.io/hazelcast-csharp-client/latest/doc/index.html_

- Usado geralmente em soluções com a necessidade de processamento de grande volume de dados

- Prós
	- Focado para sistemas distribuidos e processamento de dados de grande volume
	
- Cons
	- Menos performático na maioria das ações CRUD
	- Bem mais complexo
	- Imagem de docker da db pesada (42mb)

## Aerospike (Aerospike C# Client Package)
_Documentação: https://aerospike.com/apidocs/csharp/html/N_Aerospike_Client.htm_
- Database NoSQL focada em processamento multi-thread

	- Prós
		- Focado para sistemas distribuidos e processamento de dados de grande volume
		- Performance similar ao Redis
		
	- Cons
		- Pouca documentação
		- Bem mais complexo


---
### Fontes:
https://anthonyaje.github.io/file/An_empirical_evaluation_of_Memcached_Redis_and_Aerospike_kvstore_Anthony_Eswar.pdf

https://aerospike.com/compare/redis-vs-aerospike/

https://stackoverflow.com/questions/10558465/memcached-vs-redis	