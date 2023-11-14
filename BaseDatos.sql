DROP DATABASE IF EXISTS bd;
CREATE DATABASE bd;
use bd;

CREATE TABLE Jugador (
ID INT PRIMARY KEY NOT NULL,
nombre TEXT,
sexo  TEXT,
edad INT,
puntos INT

)ENGINE = InnoDB;

CREATE TABLE Partida (
ID INT PRIMARY KEY NOT NULL,
ganador INT,
dobles INT,
num_jugadores INT,
turnos INT
)ENGINE = InnoDB;

CREATE TABLE Historial (
jugador INT NOT NULL,
partida INT NOT NULL,
posicion INT,
FOREIGN KEY (jugador) REFERENCES Jugador(ID),
FOREIGN KEY (partida) REFERENCES Partida(ID)
)ENGINE = InnoDB;

INSERT INTO Jugador values (1,'Juan','hombre',19,2);
INSERT INTO Jugador values (2,'Jose','hombre',25,1);
INSERT INTO Jugador values (3,'Andrea','mujer',30,1);

INSERT INTO Partida values (1,1,4,3,27);
INSERT INTO Partida values (2,3,11,3,93);
INSERT INTO Partida values (3,3,4,3,32);
INSERT INTO Partida values (4,1,7,3,40);

INSERT INTO Historial values (1,1,1);
INSERT INTO Historial values (2,1,3);
INSERT INTO Historial values (3,1,2);

INSERT INTO Historial values (1,2,2);
INSERT INTO Historial values (2,2,1);
INSERT INTO Historial values (3,2,3);

INSERT INTO Historial values (1,3,3);
INSERT INTO Historial values (2,3,2);
INSERT INTO Historial values (3,3,1);

INSERT INTO Historial values (1,4,1);
INSERT INTO Historial values (2,4,2);
INSERT INTO Historial values (3,4,3);


SELECT Jugador.nombre FROM Jugador WHERE ID=1;
SELECT Jugador.nombre FROM Jugador WHERE Jugador.sexo = 'hombre' AND Jugador.puntos=0;

-- Dame al jugador que quedo en segundo lugar en la partida 3.
SELECT Jugador.nombre FROM Jugador,Historial,Partida WHERE 
Partida.ID=3 AND 
Partida.ID=Historial.partida AND
Historial.posicion=2 AND 
Historial.jugador=Jugador.ID;

-- En que partidas ha ganado el 'Juan' y en segundo 'Jose'.
SELECT Partida.ID FROM Partida,Historial,Jugador WHERE 
Jugador.nombre='Juan'AND
Jugador.ID=Historial.jugador AND
Historial.posicion=1 AND
Historial.partida=Partida.ID AND
Partida.ID IN (SELECT Partida.ID FROM Partida,Historial,Jugador WHERE
Jugador.nombre='Jose'AND
Jugador.ID=Historial.jugador AND
Historial.posicion=2 AND
Historial.partida=Partida.ID);


-- Nombre de los jugadores de la paritda 3 que son hombres.
SELECT Jugador.nombre FROM Partida,Historial,Jugador WHERE
Partida.ID=3 AND
Partida.ID=Historial.partida AND
Historial.jugador=Jugador.ID AND
Jugador.sexo='hombre';






 

