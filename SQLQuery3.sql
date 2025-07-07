use SistemaAcceso; 

use SistemaAcceso;
SELECT * FROM UsuariosResidentes;
INSERT INTO Invitados (nombre, apellido_paterno, apellido_materno, tipo_invitacion, codigo, fecha_validez, estado, id_residente)
VALUES 
('Carlos', 'Ramírez', 'Vega', 'Unica', 'INV123CARLOS', '2025-07-10', 'Válido', 1),
('Fernanda', 'López', 'Gómez', 'por fecha', 'INV456FER', '2025-07-15', 'Válido', 1),
('Jorge', 'Martínez', 'Santos', 'recurrente', 'INV789JORGE', '2025-07-12', 'Pendiente', 1),
('Valeria', 'Díaz', 'Ríos', 'Unica', 'INV321VAL', '2025-07-09', 'Válido', 1);

SELECT * FROM Invitados;





