CREATE TABLE IF NOT EXISTS Posts (
	PostId integer primary key AUTOINCREMENT,
	Active bit not null,
	Deleted bit not null,
	Url text not null,
	Title text not null,
	SubTitle text null,
	Content text not null,
	Preview text not null,
	DateCreated text not null,
	DatePublished text null
)