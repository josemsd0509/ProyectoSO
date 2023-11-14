#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>



int main(int argc, char *argv[])
{
	MYSQL *conn;
	int err;
	//Estructura para almacenar resultados de cosnulatas
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	//Conexion con el servidor MYSQL
	conn = mysql_init(NULL);
	if(conn==NULL){
		printf("Error al crear la conexion: &u %s\n",mysql_errno(conn),mysql_error(conn));
		exit(1);
	}
	conn=mysql_real_connect (conn,"localhost","root","mysql","bd", 0,NULL,0);
	if(conn == NULL){
	printf ("Error al iniciar la conexion: %u %s\n", mysql_error(conn));
	exit(1);
	}
	
	
	
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9076);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	int i;
	// Bucle infinito
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
		int terminar =0;
		// Entramos en un bucle para atender todas las peticiones de este cliente
		//hasta que se desconecte
		while (terminar ==0)
		{
			// Ahora recibimos la petici?n
			ret=read(sock_conn,peticion, sizeof(peticion));
			printf ("Recibido\n");
			
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			peticion[ret]='\0';
			
			
			printf ("Peticion: %s\n",peticion);
			
			
			char *p = strtok( peticion, "/");
			int codigo =  atoi (p);
	
			
			if (codigo !=0)
			{
				// Ya tenemos el codigo
				printf ("Codigo: %d\n", codigo);
			}
			
			if (codigo ==0) //petici?n de desconexi?n
				terminar=1;
			else if (codigo ==1) 
			{//ELige al ganador de una partida dada
			    p = strtok(NULL,"/");
			    int partida=atoi(p);
				char consulta1[100];
				printf("Todo en orden /n");
			    sprintf(consulta1,"SELECT Jugador.nombre FROM (Jugador,Historial,Partida) WHERE Partida.ID = %d AND Partida.ID=Historial.partida AND Historial.posicion=1 AND Historial.jugador=Jugador.ID", partida);
                 
				err=mysql_query(conn,consulta1);
				if(err!=0){
				printf("Error al consultar la base %u %s\n", mysql_errno(conn),mysql_error(conn));
				exit(1);
				}
				resultado = mysql_store_result (conn);
				row=mysql_fetch_row(resultado);
				if(row==NULL)
				printf("No se ha obtenido datos en la consulta\n");
				else 
				while(row!=NULL){
				printf("El jugador ganador es : %s \n",row[0]);
				sprintf (respuesta,"%s",row[0]);
				row=mysql_fetch_row(resultado);
				}
				
			}
				
				
			 else if (codigo ==2)
			{
			p = strtok(NULL,"/");
			int partida=atoi(p);
			char consulta2[200];
			char sexo[20];
			strcpy(sexo,"hombre");
			
			//Nombre de los jugadores de paritda hombres .
		     printf("partida %d \n",partida);
			//"Escriba el numero de partida\n";
			sprintf(consulta2,"SELECT Jugador.nombre FROM (Partida,Historial,Jugador) WHERE Partida.ID = %d AND Partida.ID = Historial.partida AND Historial.jugador = Jugador.ID AND Jugador.sexo = '%s'" ,partida,sexo);
			err=mysql_query(conn,consulta2);
			if(err!=0)
			{
			printf("Error al consultar la base %u %s\n", mysql_errno(conn),mysql_error(conn));
			exit(1);
			}
			
			resultado = mysql_store_result (conn);
			row=mysql_fetch_row(resultado);
			
			if(row==NULL)
			{printf("No se ha obtenido datos en la consulta\n");
		       strcpy (respuesta,"No hay");}
			
			else
			{ int t;
			  t=0;
			while(row!=NULL){
		  printf("Nombre de jugador en la partida %d que son hombres :%s \n",partida,row[0]);	
		   t++;
			row=mysql_fetch_row(resultado);
		     }
			sprintf(respuesta,"Numero de jugadores en la partida %d que son hombres es :%d \n",partida,t);
			
			}
			}
		     else 
			{   char consulta3[200];
			
				p = strtok( NULL,"/");
				char jugador1[100];
				strcpy(jugador1,p);
			     printf("%s\n" ,jugador1);
				p = strtok( NULL,"/");
				char jugador2[100];
				strcpy (jugador2,p);
				printf("%s\n" ,jugador2);
		
		//En que partidas ha ganado el 'jugador1' y en segundo 'Jugador2'.
		sprintf(consulta3,"SELECT Partida.ID FROM (Partida,Historial,Jugador) WHERE Jugador.nombre = '%s' AND Jugador.ID = Historial.jugador AND Historial.posicion = 1 AND Historial.partida = Partida.ID AND Partida.ID IN (SELECT Partida.ID FROM (Partida,Historial,Jugador) WHERE Jugador.nombre = '%s' AND Jugador.ID = Historial.jugador AND Historial.posicion = 2 AND Historial.partida = Partida.ID)" ,jugador1,jugador2);
				
		err=mysql_query(conn,consulta3);
		if(err!=0){
			printf("Error al consultar la base %u %s\n", mysql_errno(conn),mysql_error(conn));
			exit(1);
		}
		
		resultado = mysql_store_result (conn);
		row=mysql_fetch_row(resultado);
		if(row==NULL)
			printf("No se ha obtenido datos en la consulta\n");
		else 
			{
			while(row!=NULL){
				printf("Jugaron juntos ,%s quedo primero y %s segundo en la partida %s \n",jugador1,jugador2,row[0]);
				sprintf(respuesta,"Jugaron juntos ,%s quedo primero y %s segundo en la partida %s \n",jugador1,jugador2,row[0]);
			row=mysql_fetch_row(resultado);	
		}
			
		}
			 }
				
			if (codigo !=0)
			{
				
				printf ("Respuesta: %s\n", respuesta);
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
			}
		}
		// Se acabo el servicio para este cliente
		close(sock_conn);
	}
		
	
}
