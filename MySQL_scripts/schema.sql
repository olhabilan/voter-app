CREATE DATABASE supermarket_code
USE supermarket_code
GO
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
    ("Bazaar")

INSERT INTO code
    (code_value,supermarket_id,purchase_date)
VALUES
    ("m8gyQevl", 4, "2018-04-16 15:03:13")
    ("Rs1bbWNo", 2, "2018-04-16 15:03:13")
    ("xjtFwMAs", 3, "2018-04-16 15:03:13")
    ("oEK5idkk", 0, "2018-04-16 15:03:13")
    ("KmagXEuM", 5, "2018-04-16 15:03:13")
    ("Dojj1nBn", 4, "2018-04-16 15:03:13")
    ("2sz03Atr", 0, "2018-04-16 15:03:13")
    ("iScvugwn", 1, "2018-04-16 15:03:13")
    ("3hfy5i4R", 1, "2018-04-16 15:03:13")
    ("BId7sPqe", 2, "2018-04-16 15:03:13")
    ("pvPsSgJ7", 5, "2018-04-16 15:03:13")
    ("jp4RMqsk", 5, "2018-04-16 15:03:13")
    ("E16dofek", 1, "2018-04-16 15:03:13")
    ("mUkyQGv0", 0, "2018-04-16 15:03:13")
    ("vto8CQb9", 2, "2018-04-16 15:03:13")
    ("5h7lOjqR", 1, "2018-04-16 15:03:13")
    ("Ep12eIrQ", 0, "2018-04-16 15:03:13")
    ("PSIEppli", 3, "2018-04-16 15:03:13")
    ("tcGEaxuI", 5, "2018-04-16 15:03:13")
    ("9VWy5xma", 3, "2018-04-16 15:03:13")
    ("nmgSsXCO", 0, "2018-04-16 15:03:13")
    ("yHKKSVi4", 0, "2018-04-16 15:03:13")
    ("3RJV1eVX", 5, "2018-04-16 15:03:13")