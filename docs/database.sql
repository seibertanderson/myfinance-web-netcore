create database db_myfinance
use db_myfinance

create table plano_contas(
	id int identity(1,1) not null,
	descricao varchar(50) not null,
	tipo char(1) not null,
	primary key(id)
)

create table transacao(
	id bigint identity(1,1) not null,
	data datetime not null,
	valor decimal(18,2) not null,
	tipo char(1) not null,
	historico text null,
	id_plano_conta int not null,
	primary key(id),
	foreign key(id_plano_conta) references plano_contas
)

select * from plano_contas;

insert into plano_contas(descricao, tipo) values('Aluguel', 'D');
insert into plano_contas(descricao, tipo) values('Alimentação', 'D');
insert into plano_contas(descricao, tipo) values('Combustível', 'D');
insert into plano_contas(descricao, tipo) values('Viagem', 'D');
