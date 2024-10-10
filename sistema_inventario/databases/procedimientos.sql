DELIMITER //

CREATE PROCEDURE registrar_producto(
    IN p_nombre VARCHAR(100),
    IN p_cantidad INT,
    IN p_precio DECIMAL(10, 2),
    IN p_categoria VARCHAR(50)
)
BEGIN
    DECLARE codigo_generado VARCHAR(10);
    DECLARE codigo_existe INT DEFAULT 1;

    -- Bucle para generar un código único
    WHILE codigo_existe = 1 DO
        -- Generar un código aleatorio de 5 caracteres
        SET codigo_generado = CONCAT(
            CHAR(FLOOR(65 + (RAND() * 26))), -- Letra aleatoria (A-Z)
            CHAR(FLOOR(65 + (RAND() * 26))), -- Letra aleatoria (A-Z)
            FLOOR(1000 + (RAND() * 9000))    -- Número aleatorio de 4 dígitos
        );

        -- Verificar si el código ya existe en la tabla
        SELECT COUNT(*) INTO codigo_existe
        FROM productos
        WHERE codigo = codigo_generado;
    END WHILE;

    -- Insertar el nuevo producto con el código generado
    INSERT INTO productos (codigo, nombre, cantidad, precio, categoria)
    VALUES (codigo_generado, p_nombre, p_cantidad, p_precio, p_categoria);

END //

DELIMITER ;
