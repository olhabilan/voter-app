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
    (code_value,supermarket_id,purchase_date,is_used)
VALUES
    ("Dr7FTfqU", 1, "2018-04-16 16:18:33", false),
    ("0vB2pIq5", 2, "2018-04-16 16:18:33", false),
    ("VsqjLAA7", 3, "2018-04-16 16:18:33", false),
    ("YEC4mdyX", 4, "2018-04-16 16:18:33", false),
    ("Bekk5Agv", 2, "2018-04-16 16:18:33", false),
    ("mmwQRZAi", 6, "2018-04-16 16:18:33", false),
    ("kHLRYeSr", 5, "2018-04-16 16:18:33", false),
    ("cOJoa0yJ", 3, "2018-04-16 16:18:33", false),
    ("YBpKtZ6J", 3, "2018-04-16 16:18:33", false),
    ("dPV6veeU", 4, "2018-04-16 16:18:33", false),
    ("okLAyFlm", 2, "2018-04-16 16:18:33", false),
    ("EqZNFQ28", 5, "2018-04-16 16:18:33", false),
    ("dbkshbm7", 6, "2018-04-16 16:18:33", false),
    ("GvlNHGmC", 4, "2018-04-16 16:18:33", false),
    ("olddG9KP", 3, "2018-04-16 16:18:33", false),
    ("76GCUVrQ", 2, "2018-04-16 16:18:33", false),
    ("EdsyemrZ", 3, "2018-04-16 16:18:33", false),
    ("hV7WqFKN", 4, "2018-04-16 16:18:33", false),
    ("RYVST8o2", 6, "2018-04-16 16:18:33", false),
    ("PjYJGieb", 1, "2018-04-16 16:18:33", false),
    ("kDsh79d3", 1, "2018-04-16 16:18:33", false),
    ("zSBYTAMs", 1, "2018-04-16 16:18:33", false),
    ("fNxoXxO4", 3, "2018-04-16 16:18:33", false),
    ("VcXuGKgg", 2, "2018-04-16 16:18:33", false),
    ("8CKhDr45", 1, "2018-04-16 16:18:33", false);