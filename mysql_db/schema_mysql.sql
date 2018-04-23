CREATE DATABASE IF NOT EXISTS supermarket_code;
USE supermarket_code;
#GO;
CREATE TABLE IF NOT EXISTS supermarket
(
    supermarket_id int NOT NULL AUTO_INCREMENT,
    supermarket_name CHAR(30) NOT NULL,
    PRIMARY KEY (supermarket_id)
);

CREATE TABLE IF NOT EXISTS code
(
    code_id int NOT NULL AUTO_INCREMENT,
    code_value CHAR(30) NOT NULL,
    supermarket_id int NOT NULL,
    purchase_date datetime NOT NULL,
    is_used BOOLEAN NOT NULL,
    PRIMARY KEY (code_id),
    FOREIGN KEY(supermarket_id) references supermarket(supermarket_id)
);

INSERT INTO supermarket
    (supermarket_name)
VALUES
    ("Green Land"),
    ("Favourite shop"),
    ("Family market"),
    ("Cheap-village"),
    ("Grandmother trade"),
    ("Bazaar");

INSERT INTO code
    (code_value,supermarket_id,purchase_date)
VALUES
    ("Dr7FTfqU", 1, "2018-04-16 16:18:33"),
    ("0vB2pIq5", 2, "2018-04-16 16:18:33"),
    ("VsqjLAA7", 3, "2018-04-16 16:18:33"),
    ("YEC4mdyX", 4, "2018-04-16 16:18:33"),
    ("Bekk5Agv", 2, "2018-04-16 16:18:33"),
    ("mmwQRZAi", 6, "2018-04-16 16:18:33"),
    ("kHLRYeSr", 5, "2018-04-16 16:18:33"),
    ("cOJoa0yJ", 3, "2018-04-16 16:18:33"),
    ("YBpKtZ6J", 3, "2018-04-16 16:18:33"),
    ("dPV6veeU", 4, "2018-04-16 16:18:33"),
    ("okLAyFlm", 2, "2018-04-16 16:18:33"),
    ("EqZNFQ28", 5, "2018-04-16 16:18:33"),
    ("dbkshbm7", 6, "2018-04-16 16:18:33"),
    ("GvlNHGmC", 4, "2018-04-16 16:18:33"),
    ("olddG9KP", 3, "2018-04-16 16:18:33"),
    ("76GCUVrQ", 2, "2018-04-16 16:18:33"),
    ("EdsyemrZ", 3, "2018-04-16 16:18:33"),
    ("hV7WqFKN", 4, "2018-04-16 16:18:33"),
    ("RYVST8o2", 6, "2018-04-16 16:18:33"),
    ("PjYJGieb", 1, "2018-04-16 16:18:33"),
    ("kDsh79d3", 1, "2018-04-16 16:18:33"),
    ("zSBYTAMs", 1, "2018-04-16 16:18:33"),
    ("fNxoXxO4", 3, "2018-04-16 16:18:33"),
    ("VcXuGKgg", 2, "2018-04-16 16:18:33"),
    ("8CKhDr45", 1, "2018-04-16 16:18:33");