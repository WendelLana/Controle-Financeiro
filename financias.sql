-- TABLE
CREATE TABLE Categoria (
	categoria_id TEXT PRIMARY KEY,
   	nome TEXT NOT NULL UNIQUE,
	cor TEXT DEFAULT '1E1E1E',
	icone TEXT
);
CREATE TABLE Gasto (
	gasto_id TEXT PRIMARY KEY,
   	data DATE DEFAULT (datetime('now','localtime')),
	valor REAL NOT NULL,
	descricao TEXT,
 	categoria_id TEXT,
  	FOREIGN KEY (categoria_id) 
      REFERENCES Categoria (categoria_id) 
         ON DELETE NO ACTION 
         ON UPDATE CASCADE
);
 
-- INDEX
 
-- TRIGGER
 
-- VIEW
 
