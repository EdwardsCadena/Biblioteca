create database biblioteca1;


-- Create Author table
CREATE TABLE Author (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL
);

-- Create Book table
CREATE TABLE Book (
    Id SERIAL PRIMARY KEY,
    Title VARCHAR(200) NOT NULL,
    AuthorId INT NOT NULL,
    FOREIGN KEY (AuthorId) REFERENCES Author(Id) ON DELETE CASCADE
);
INSERT INTO Author (Name) VALUES ('Gabriel García Márquez');
INSERT INTO Author (Name) VALUES ('J.K. Rowling');
INSERT INTO Author (Name) VALUES ('Stephen King');

INSERT INTO Book (Title, AuthorId) VALUES ('Cien años de soledad', 1);
INSERT INTO Book (Title, AuthorId) VALUES ('El amor en los tiempos del cólera', 1);
INSERT INTO Book (Title, AuthorId) VALUES ('Crónica de una muerte anunciada', 1);
INSERT INTO Book (Title, AuthorId) VALUES ('El otoño del patriarca', 1);
INSERT INTO Book (Title, AuthorId) VALUES ('Memoria de mis putas tristes', 1);

INSERT INTO Book (Title, AuthorId) VALUES ('Harry Potter y la piedra filosofal', 2);
INSERT INTO Book (Title, AuthorId) VALUES ('Harry Potter y la cámara secreta', 2);
INSERT INTO Book (Title, AuthorId) VALUES ('Harry Potter y el prisionero de Azkaban', 2);
INSERT INTO Book (Title, AuthorId) VALUES ('Harry Potter y el cáliz de fuego', 2);
INSERT INTO Book (Title, AuthorId) VALUES ('Harry Potter y la Orden del Fénix', 2);

INSERT INTO Book (Title, AuthorId) VALUES ('It', 3);
INSERT INTO Book (Title, AuthorId) VALUES ('El resplandor', 3);
INSERT INTO Book (Title, AuthorId) VALUES ('Cementerio de animales', 3);
INSERT INTO Book (Title, AuthorId) VALUES ('Carrie', 3);
INSERT INTO Book (Title, AuthorId) VALUES ('Misery', 3);