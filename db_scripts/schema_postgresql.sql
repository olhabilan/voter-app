CREATE DATABASE poll_result;
USE poll_result;
GO;
CREATE TABLE IF NOT EXISTS result
(
    supermarket_id int NOT NULL AUTO_INCREMENT,
    supermarket_name CHAR(30) NOT NULL,
    avg_price_score float,
    avg_service_score float,
    avg_overall_score float,
    PRIMARY KEY (supermarket_id)
);

