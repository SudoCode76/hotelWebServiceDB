USE hotelTarea;

CREATE TABLE Habitacion (
    Id_habitacion INT PRIMARY KEY,
    tipo NVARCHAR(20),
    capacidad INT
);

CREATE TABLE Persona (
    Id_persona INT PRIMARY KEY,
    nombre NVARCHAR(50),
    ci NVARCHAR(10)
);

CREATE TABLE Reserva (
    Id_reserva INT PRIMARY KEY,
    Id_habitacion INT,
    Id_persona INT,
    fecha DATE,
    hora_inicio TIME,
    hora_fin TIME,
    FOREIGN KEY (Id_habitacion) REFERENCES Habitacion(Id_habitacion),
    FOREIGN KEY (Id_persona) REFERENCES Persona(Id_persona)
);


-- Insertar datos en la tabla Habitacion
INSERT INTO Habitacion (Id_habitacion, tipo, capacidad)
VALUES
(1, 'Simple', 1),
(2, 'Doble', 2),
(3, 'Suite', 4);

-- Insertar datos en la tabla Persona
INSERT INTO Persona (Id_persona, nombre, ci)
VALUES
(1, 'Juan Pérez', '1234567890'),
(2, 'María González', '0987654321'),
(3, 'Carlos Rodríguez', '1357924680');

-- Insertar datos en la tabla Reserva
INSERT INTO Reserva (Id_reserva, Id_habitacion, Id_persona, fecha, hora_inicio, hora_fin)
VALUES
(1, 1, 1, '2024-02-27', '10:00:00', '12:00:00'),
(2, 2, 2, '2024-02-28', '14:00:00', '16:00:00'),
(3, 3, 3, '2024-03-01', '12:00:00', '14:00:00')


SELECT * FROM Reserva;

SELECT * FROM Reserva
JOIN Habitacion ON Reserva.Id_habitacion = Habitacion.Id_habitacion
WHERE Habitacion.tipo = 'Simple';

INSERT INTO Habitacion (Id_habitacion, tipo, capacidad)
VALUES
(4, 'Simple', 1),
(5, 'Simple', 1),
(6, 'Doble', 2),
(7, 'Suite', 4),
(8, 'Suite', 4);

-- Insertar más datos en la tabla Persona
INSERT INTO Persona (Id_persona, nombre, ci)
VALUES
(4, 'Laura Martínez', '2468135790'),
(5, 'Roberto Pérez', '9876543210'),
(6, 'Ana López', '3579134680'),
(7, 'Diego Rodríguez', '5790246138'),
(8, 'Sofía García', '8024671359');

-- Insertar más datos en la tabla Reserva
INSERT INTO Reserva (Id_reserva, Id_habitacion, Id_persona, fecha, hora_inicio, hora_fin)
VALUES
(4, 3, 4, '2024-03-02', '09:00:00', '11:00:00'),
(5, 2, 5, '2024-03-02', '14:30:00', '16:30:00'),
(6, 4, 6, '2024-03-03', '10:00:00', '12:00:00'),
(7, 5, 7, '2024-03-03', '13:00:00', '15:00:00'),
(8, 6, 8, '2024-03-04', '12:00:00', '14:00:00'),
(9, 7, 1, '2024-03-04', '15:00:00', '17:00:00'),
(10, 8, 2, '2024-03-05', '11:00:00', '13:00:00'),
(11, 1, 3, '2024-03-05', '14:00:00', '16:00:00');