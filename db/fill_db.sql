use Mag

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbSales')) BEGIN
 drop table tbSales
END
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbAgents')) BEGIN
 drop table tbAgents
END
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'tbInsuranceTypes')) BEGIN
 drop table tbInsuranceTypes
END

-- ********* Create tables *************

go
create table tbAgents
(
[id] int identity(1, 1),
[name] varchar(200) not null,
[patronym] varchar(200),
[surname] varchar(200) not null,
[regDate] datetime not null,
[isAdmin] bit,

constraint PK_AgentId primary key([id])
)

go
create table tbInsuranceTypes
(
[id] int identity(1, 1),
[name] varchar(200) not null unique,

constraint PK_InsuranceTypeId primary key([id])
)

go
create table tbSales
(
[id] int identity(1, 1),
[agentId] int not null,
[reportCode] varchar(50) not null,
[createDate] datetime not null,
[insuranceTypeId] int not null,
[contractsNumber] int default(1),
[premium] float not null,
[paymentsNumber] int default(1),
[paidSum] float not null,
[feePercent] float not null,
[comment] varchar(300),
[addFeePercent] float,

constraint PK_SaleId primary key([id]),
constraint PK_SaleAgent foreign key(agentId) references tbAgents([id]),
constraint PK_SaleInsuranceType foreign key(insuranceTypeId) references tbInsuranceTypes([id])

)

-- +++++++++ Filling tables with info ++++++++++++ --
insert into tbAgents([name],[surname],[regdate],[isadmin])
values ('Roman', 'Smith', '2014/03/05', 1)
insert into tbAgents
([name],[surname],[regdate],[isadmin])
values ('John', 'Richie', '2014/06/01', 0)

insert into tbInsuranceTypes([name])
values ('Type1')
insert into tbInsuranceTypes([name])
values ('Type2')

insert into tbSales
([agentId],[reportCode],[createDate],[insuranceTypeId],[contractsNumber],
[premium],[paymentsNumber],[paidSum],[feePercent],[addFeepercent])
values(1,'BBB234987','2014/07/23',1,1,2300,1,2300,10,5)
insert into tbSales
([agentId],[reportCode],[createDate],[insuranceTypeId],[contractsNumber],
[premium],[paymentsNumber],[paidSum],[feePercent],[addFeepercent])
values(2,'AAA234876','2014/07/24',2,1,3500,1,3500,10,5)