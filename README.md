#Recursos usados:
.Net Core SDK 5.0
RabbitMQ instalado
Masstransit
Masstransit.RabbitMQ
Masstransit.AspNetCore

#OrderPublisher => Web Api gera uma reserva de passagem enviando para o RabbitMQ

#OrderConsumer => Consume a Fila do RabbitMQ

#Share.Model => Define o contrato de mensagem definida pela classe Ticket

URL para acessar o RabbitMQ => http://localhost:15672/

obs: Clique na Solution com o botao direito e defina Multiple startup projects :
 OrderConsumer => Start
 OrderPublisher => Start
 
Start a aplicação 
 
Preencha os campos necessarios no swagger (try out e depois execute)

Va até o RabbitMQ e note que a fila foi publicada e consumida
 

