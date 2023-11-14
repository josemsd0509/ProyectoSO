
#include <mysql.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>
int main(int argc, char **argv) {
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
	// Dame al jugador que quedo en 1 lugar en el numero de partida que pregunte
	
	
	
	
	
	
	
	int partida;
	printf("Escribe el numero de la partida que quieres saber el gandor\n");
	scanf("%d",&partida);
	
	char consulta1[100];
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
	printf("Jugador : %s \n",row[0]);
	row=mysql_fetch_row(resultado);
}
	
	
	
	
	
	
	
	
	
	char consulta2[100];
	char sexo[20];
	int partidaid;
	
	//Nombre de los jugadores de paritda x segun su sexo.
	printf("Para saber jugadores hombres o mujeres de una partida\n");
	printf("Escriba el numero de partida\n");
	scanf("%d",&partidaid);
	printf("Escriba el sexo hombre o mujer\n");
	scanf("%s",sexo);
	sprintf(consulta2,"SELECT Jugador.nombre FROM Partida,Historial,Jugador WHERE Partida.ID=%d AND Partida.ID=Historial.partida AND Historial.jugador=Jugador.ID AND Jugador.sexo='%s'" ,partidaid,sexo);
	err=mysql_query(conn,consulta2);
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
		printf("Nombre de jugador en la partida %d que es %s :%s \n",partidaid,sexo,row[0]);
		row=mysql_fetch_row(resultado);
	
	}
	
	
	
	
	
	
	
	
	
	
		
		char consulta3[100];
		char jugador1[20];
		char jugador2[20];
	
		
		//En que partidas ha ganado el 'jugador1' y en segundo 'Jugador2'.
		printf("Para saber la partida/s en la que dos jugadores quedaron primero y otro segundo\n");
		printf("Escriba el nombre del jugador que quedo primero en la partida que quiere\n");
		scanf("%s",jugador1);
		printf("Escriba el nombre del jugador que quedo primero en la partida que quiere\n");
		scanf("%s",jugador2);
		
		sprintf(consulta3,"SELECT Partida.ID FROM (Partida,Historial,Jugador) WHERE Jugador.nombre='%s' AND Jugador.ID=Historial.jugador AND Historial.posicion=1 AND Historial.partida=Partida.ID AND Partida.ID IN (SELECT Partida.ID FROM Partida,Historial,Jugador WHERE Jugador.nombre='%s'AND Jugador.ID=Historial.jugador AND Historial.posicion=2 AND Historial.partida=Partida.ID)" ,jugador1,jugador2);
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
			while(row!=NULL){
			printf("Jugaron juntos , %s quedo primero y %s segundo en la partida %s \n",jugador1,jugador2,row[0]);
			row=mysql_fetch_row(resultado);
			
		}		
		
		
		
		
		
		
		
		
		
	mysql_close(conn);
	exit(0);
}

