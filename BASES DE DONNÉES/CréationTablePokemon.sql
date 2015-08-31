CREATE TABLE Attacks
  (
    ID          NUMBER NOT NULL ,
    Name        NUMBER ,
    Type        VARCHAR(10) ,
    Damage      NUMBER ,
    Healing     NUMBER ,
    Attack      NUMBER ,
    Defense     NUMBER ,
    Speed       NUMBER ,
    Price       NUMBER ,
    Description VARCHAR(200)
  ) ;
ALTER TABLE Attacks ADD CONSTRAINT Attacks_PK PRIMARY KEY ( ID ) ;

CREATE TABLE Items
  (
    ID          NUMBER NOT NULL ,
    Name        VARCHAR(30) ,
    Damage      NUMBER ,
    Healing     NUMBER ,
    Attack      NUMBER ,
    Defense     NUMBER ,
    Speed       NUMBER ,
    Price       NUMBER ,
    Description VARCHAR(200)
  ) ;
ALTER TABLE Items ADD CONSTRAINT Items_PK PRIMARY KEY ( ID ) ;

CREATE TABLE Monsters
  (
    ID             NUMBER NOT NULL ,
    Name           VARCHAR(30) NOT NULL ,
    PokeType       VARCHAR (6) NOT NULL ,
    BaseHP         NUMBER NOT NULL ,
    BaseAtt        NUMBER NOT NULL ,
    BaseDef        NUMBER NOT NULL ,
    BaseSpeed      NUMBER NOT NULL ,
    Default_Attack VARCHAR(30) ,
    Front_Sprite BLOB ,
    Back_Sprite BLOB ,
    Price NUMBER
  ) ;
ALTER TABLE Monsters ADD CONSTRAINT Monsters_PK PRIMARY KEY ( ID ) ;

CREATE TABLE Monsters_Attacks
  (
    "Player's_Monster_ID" NUMBER NOT NULL ,
    "Player's_Attacks_ID" NUMBER NOT NULL
  ) ;
ALTER TABLE Monsters_Attacks ADD CONSTRAINT ".._PK" PRIMARY KEY ( "Player's_Monster_ID" ) ;

CREATE TABLE "Player's Attacks"
  (
    ID                    NUMBER NOT NULL ,
    "ID_Player's_Monster" NUMBER NOT NULL ,
    ID_Attack             NUMBER NOT NULL
  ) ;
ALTER TABLE "Player's Attacks" ADD CONSTRAINT "Player's Attacks_PK" PRIMARY KEY ( ID_Attack, "ID_Player's_Monster", ID ) ;

CREATE TABLE "Player's Items"
  (
    ID       NUMBER NOT NULL ,
    Id_Item  NUMBER NOT NULL ,
    Username VARCHAR(30) NOT NULL ,
    Party    CHAR (1) ,
    Quantity NUMBER
  ) ;
ALTER TABLE "Player's Items" ADD CONSTRAINT "Player's Items_PK" PRIMARY KEY ( Id_Item, Username, ID ) ;

CREATE TABLE "Player's Monsters"
  (
    ID         NUMBER NOT NULL ,
    Id_Monster NUMBER NOT NULL ,
    Username   VARCHAR(30) NOT NULL ,
    Lvl    NUMBER ,
    Exp        NUMBER ,
    Party      CHAR (1)
  ) ;
ALTER TABLE "Player's Monsters" ADD CONSTRAINT "Player's Monsters_PK" PRIMARY KEY ( Id_Monster, Username, ID ) ;

CREATE TABLE Players
  (
    Username        VARCHAR(30) NOT NULL ,
    Password        VARCHAR(30) ,
    Division        VARCHAR(30) ,
    "Ranked Points" NUMBER ,
    Money           NUMBER ,
    Email           VARCHAR(30) ,
    Wins            NUMBER ,
    Games_Played    NUMBER
  ) ;
ALTER TABLE Players ADD CONSTRAINT Players_PK PRIMARY KEY ( Username ) ;

ALTER TABLE "Player's Attacks" ADD CONSTRAINT "Player's Attacks_Attacks_FK" FOREIGN KEY ( ID_Attack ) REFERENCES Attacks ( ID ) ;

ALTER TABLE "Player's Attacks" ADD CONSTRAINT "Player's_Attacks_FK" FOREIGN KEY ( ID ) REFERENCES Monsters_Attacks ( "Player's_Monster_ID" ) ;

ALTER TABLE "Player's Items" ADD CONSTRAINT "Player's Items_Items_FK" FOREIGN KEY ( Id_Item ) REFERENCES Items ( ID ) ;

ALTER TABLE "Player's Items" ADD CONSTRAINT "Player's Items_Players_FK" FOREIGN KEY ( Username ) REFERENCES Players ( Username ) ;

ALTER TABLE "Player's Monsters" ADD CONSTRAINT "Player's_MonstersFK" FOREIGN KEY ( ID ) REFERENCES Monsters_Attacks ( "Player's_Monster_ID" ) ;

ALTER TABLE "Player's Monsters" ADD CONSTRAINT "Player's Monsters_Monsters_FK" FOREIGN KEY ( Id_Monster ) REFERENCES Monsters ( ID ) ;

ALTER TABLE "Player's Monsters" ADD CONSTRAINT "Player's Monsters_Players_FK" FOREIGN KEY ( Username ) REFERENCES Players ( Username ) ;

