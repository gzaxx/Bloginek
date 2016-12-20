create table if not exists Redirects (
	RedirectId integer primary key autoincrement,
	Deleted bit not null,
	RedirectTo text not null,
	RedirectFrom text not null
)