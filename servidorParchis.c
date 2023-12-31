#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>
typedef struct{
 char nombre[20];
 int socket
}Conectado;

typedef struct {
	Conectado conectados[100];
	int num
}ListaConectados;

typedef struct{
	int num;
	int max;
	int ocupado;
	int aceptado[4];
	Conectado jugadores[4]
}Partida;

typedef struct{
 Partida partidas[100];
 int num
}ListaPartidas;

int aceptar=1;
int players=0;
int i=0;
int sockets[100];
ListaConectados listaCon;
ListaPartidas milistaP;
pthread_mutex_t mutex =PTHREAD_MUTEX_INITIALIZER;


void *AtenderCliente (void *socket)
{
char nombre[30];
int n;
int partida;
int sock_conn;
int *s;
s= (int *) socket;
sock_conn= *s;
MYSQL *conn;
int err;
int ret;
int conexion;
char conectados[512];
int j;
int numForm;

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
char peticion[512];
char respuesta[512];
// INICIALITZACIONS
// Obrim el socket
// Fem el bind al port

	int terminar =0;
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar ==0)
	{    int bucle=0;
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
		{
		int dconexion;       
		p = strtok(NULL,"/");
		strcpy(nombre,p);
		pthread_mutex_lock(&mutex);

		 dconexion=Desconectar(&listaCon,nombre);
		 ListadeConectados(&listaCon, conectados);//haz update de la lista
		pthread_mutex_unlock(&mutex);
	
		   if(dconexion==0)
		   {printf("Actualizado\n");
		   terminar=1;}
		   
		   else
			printf("Error en la actualizacion\n");  
			
		
		      
			
		}
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
				sprintf (respuesta,"1/'%s'",row[0]);
				row=mysql_fetch_row(resultado);
			}
				
				printf ("Respuesta: %s\n", respuesta);
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
				
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
			sprintf(respuesta,"2/Numero de jugadores en la partida %d que son hombres es :%d \n",partida,t);
			
			}
			
			printf ("Respuesta: %s\n", respuesta);
			// Enviamos respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		}
		else if (codigo==3)
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
				sprintf(respuesta,"3/Jugaron juntos ,%s quedo primero y %s segundo en la partida %s \n",jugador1,jugador2,row[0]);
				row=mysql_fetch_row(resultado);	
			}

		}			
		
		printf ("Respuesta: %s\n", respuesta);
		// Enviamos respuesta
		write (sock_conn,respuesta, strlen(respuesta));
		}
		else if(codigo==10)
		{p = strtok(NULL,"/");
		 strcpy(nombre,p);
		 int conexion;
		 int pos;
		 pos=PosicionCliente (&listaCon,nombre);
		 if(pos==-1)
		 {
		 printf( "Primera conexion \n");
		 printf("Nuevo jugador conectado %s \n" ,nombre);
		 pthread_mutex_lock(&mutex);
		 conexion = Conectar(&listaCon,nombre,sock_conn);
		 ListadeConectados(&listaCon, conectados);//haz update de la lista
		  pthread_mutex_unlock(&mutex);
			if (conexion==0)
			 
				printf("jugador a�adido correctamente \n");
			else 
				printf("Error al a�adir el jugador \n");
		 }
		 else
		{
			printf("El jugador ya esta conectado \n");
		}
		 
		 printf ("Respuesta: %s\n", respuesta);
		 // Enviamos respuesta
		 write (sock_conn,respuesta, strlen(respuesta));
		}

		else if(codigo==11)
        {
		p = strtok(NULL,"/");
		numForm=atoi(p);
		int n =1;
	
	     printf("Empezando a invitar jugadores \n");
		 char notificacion[200];
		p = strtok(NULL,"/");
		  char anfitrion[30];
		  strcpy(anfitrion,p);
		  p = strtok(NULL,"/");
		  char invitados[100];
		  char jugadores[100];
		  strcpy(invitados,p);  
		  sprintf(jugadores,"%s-%s-", anfitrion,invitados);
          printf("%s \n",jugadores);
		  printf("El anfitrion es %s \n",anfitrion);
		  printf("Esta invitando a %s \n",invitados);

		  
		  partida = AgregarJugador(&milistaP,&listaCon,jugadores);
		  milistaP.partidas[partida].aceptado[0] = 1;
		  sprintf(notificacion, "5/%d/%d/%s", numForm, partida, anfitrion);
		  printf("Notificacion: %s\n", notificacion);
		  while(n<players)
		  {
			  write(milistaP.partidas[partida].jugadores[n].socket,notificacion,strlen(notificacion));
		  n++;
			  
		  }
			
		}
		
		else if(codigo==13)
		{   int nform;
		    char notificacion[100];
		
		     p = strtok(NULL, "/");
	     	nform = atoi(p);
			p = strtok(NULL, "/");
			partida = atoi(p);
			p = strtok(NULL, "/");
			n = atoi(p);
	
			if (n == 1)//n = 1 signifca que el jugador ha aceptado
			{ int i;
			  i=0;
			  sprintf(notificacion, "6/%d/0/%d",nform, partida);
			  
				
				while(strcmp(milistaP.partidas[partida].jugadores[i].nombre, nombre) != 0)
				{
					i=i+1;
					
				}
				milistaP.partidas[partida].aceptado[i] = 1;//el cliente ha aceptado, por lo tanto aceptado = 1;
				
				i=0;
				while (i<4)
				{
					if(milistaP.partidas[partida].aceptado[i] == 1)//se añaden los jugadores que han aceptado la partida
					{
						sprintf(notificacion, "%s/%s", notificacion, milistaP.partidas[partida].jugadores[i].nombre);
						
					}
					i=i+1;
				}
				sprintf(notificacion, "%s/",notificacion);
				printf("respuesta: %s\n", notificacion);
				i = 0;
				while (i<4)
				{
					if (milistaP.partidas[partida].aceptado[n] == 1)//se les envia los jugadoes que han acpetado a todos los jugadores del lobby
					{
						write(milistaP.partidas[partida].jugadores[i].socket, notificacion, strlen(notificacion));
					}
					
					i++;
					
				}
			}
			else
		     {
				sprintf(notificacion, "6/%d/1/%d/%s",nform, partida,nombre);
				printf("Rechazada codigo: %s\n",notificacion);
				write (milistaP.partidas[partida].jugadores[0].socket,notificacion, strlen(notificacion));
				
			}
			
		}
		
		else if(codigo==20)
		{    int n=0;
			p = strtok(NULL,"/");
			int partida=atoi(p);
			p= strtok(NULL,"/");
			int numForm=atoi(p);
			int i=0;
			printf("Preparando partida \n");
	         char notificacion [100];
			sprintf(notificacion, "7/%d/%d/%d", numForm, partida,players);
			printf("Notificacion: %s\n", notificacion);
			while (i<players)
			{       
				if (milistaP.partidas[partida].aceptado[n] == 1)
				{
					sprintf(notificacion, "%s-%s", notificacion, milistaP.partidas[partida].jugadores[i].nombre);}
				n++;
				i++;
	 		}
			sprintf(notificacion, "%s/", notificacion);
		    printf("Notificacion: %s\n", notificacion);
			i=0;
			while(i<players)
			{
				write(milistaP.partidas[partida].jugadores[i].socket,notificacion,strlen(notificacion));
				i++;
				
			}
			
		}
		
		else if(codigo==21)
		{    int n=0;
		p = strtok(NULL,"/");
		int partida=atoi(p);
		p= strtok(NULL,"/");
		int numForm=atoi(p);
		int i=0;
	    char chat[2000];
		p= strtok(NULL,"/");
		strcpy(chat,p);
		char notificacion [100];
		sprintf(notificacion, "8/%d/%s", numForm,chat);
		printf("Notificacion: %s\n", notificacion);
	
		while(i<players)
		{
			write(milistaP.partidas[partida].jugadores[i].socket,notificacion,strlen(notificacion));
			i++;
			
		}
		
		}
		
		if((codigo==10)||(codigo==0))
		{bucle=1;
		char notificacion[200];
		printf("Buscando lista de conectados \n");
		pthread_mutex_lock(&mutex);//no interrumpas
		ListadeConectados(&listaCon, conectados);//haz update de la lista
		pthread_mutex_unlock(&mutex);//molesta de nuevo
		sprintf(notificacion,"4/%s",conectados);
		
		printf("Actualizacion de lista: %s\n", notificacion);
		for (j=0;j<i;j++)//este bucle le enviara la tabla actualizada a todos los conectados.
		{
			write(sockets[j],notificacion,strlen(notificacion));
		}
		}
		
	}
	// Se acabo el servicio para este cliente
	close(sock_conn);
}
	
	
	

int main(int argc, char *argv[])
{   
	IniciarPartida(&milistaP);
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket \n");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9010);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind ");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen \n");
	
	
	pthread_t thread;
	// Bucle para atender a 5 clientes
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		// Crear thead y decirle lo que tiene que hacer
		
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i=i+1;
		
	
}
}



// Nueva creacion
int Conectar (ListaConectados *lista, char Nombre[20], int socket)
{//recibe nombre y socket, añade el nuevo cliente a la lista, devuelve 0 si todo okay, -1 si la lista de clientes esta llena
	if (lista->num == 100)
	{
		return -1;
	}
	else
	{
		strcpy(lista->conectados[lista->num].nombre, Nombre);
		lista->conectados[lista->num].socket = socket;
		lista->num++;
		return 0;
	}
}
int Desconectar (ListaConectados *lista, char Nombre[20])
{//recibe un nombre y lo elimina de la lista de conectados
	int posicion = PosicionCliente(lista, Nombre);
	if (posicion == -1)
	{
		return -1;
	}
	else 
	{
		int i;
		for (i = posicion; i < lista->num-1; i++)
		{   
			lista->conectados[i] = lista->conectados[i+1];
		}
		
		lista->num--;
		return 0;
	}
}

void ListadeConectados(ListaConectados *lista, char conectados[512])
{//guarda en "conectados" la lista de personas que hay conectadas
	int i;
	sprintf(conectados, "%d", lista->num);
	
	for (i=0;i<lista->num;i++)
	{
		sprintf(conectados, "%s/%s", conectados, lista->conectados[i].nombre);
	}
	
	
}
int PosicionCliente (ListaConectados *lista, char nombre[20])
{//recibe un nombre, lo busca en la lista de conectados y devuelve su posicion en la lista
	int i=0;
	int encontrado = 0;
	while (i<lista->num && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre, nombre) == 0)
		{
			encontrado = 1;
		}
		if (!encontrado)
		{
			i++;
		}
	}
	if (encontrado)
		return i;
	else 
		return -1;
}
int AgregarJugador(ListaPartidas *listpart,ListaConectados *listcon, char jugadores[100])
{//recibe 4 jugadores, y los agrega a una partida, devuelve el numero de la partida
	
	int n = 0;
	int j = 0;
	int encontrado = 0;
	char *p;
	
	p = strtok(jugadores, "-");
	
	while (n < 99 && !encontrado)
	{
		if (listpart->partidas[n].ocupado == 0)
		{
			encontrado =1;
			listpart->partidas[n].max = 4;
		}
		else 
			n++;
		
	}
	
	if (encontrado == 1)
	{   
		int bucle=0;
		milistaP.partidas[n].aceptado[0] == 1;
		while ((j < listpart->partidas[n].max)&&(bucle==0))
		{   if(p==NULL)
		    {bucle=1;}
			else 
			{strcpy(listpart->partidas[n].jugadores[j].nombre, p);
			int pos = PosicionCliente(listcon,p);
			listpart->partidas[n].jugadores[j].socket = listcon->conectados[pos].socket;
			printf("socket de %s es %d\n", p, listcon->conectados[pos].socket);
			p = strtok(NULL,"-");
			j++;
		    players++;
			}
		}
		
		return n;
	}
	else 
	{
		return -1;
	}
	
}
int BuscarPartidas(ListaPartidas *l) 
{//encuentra y devuelve el numero de la primera partida vacia que encuentre
	for (int i = 0; i < 500; i++) 
	{
		if (l->partidas[i].ocupado == 0) 
		{
			return i;//numero de partida
		}
	}
	return -1; // no hay partidas disponibles
}

void IniciarPartida(ListaPartidas *l)
{//inicializa la lista de partidas
	int i;
	for (i = 0; i< 99; i++)
	{
		l->partidas[i].ocupado = 0;
	}
}

int partidaSocket(ListaPartidas *l, int socket)
{//encuentra y devuelve el numero de partida de un jugador determinado
	int encontrado = 0;
	int j;
	int i;
	for (i = 0; i<99 && !encontrado;i++)
	{
		for (j = 0; j<4;j++);
		{
			if (l->partidas[i].jugadores[j].socket == socket)
				encontrado = 1;	
		}
	}
	return i;
}




