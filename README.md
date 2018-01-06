# CS322 Projekat - Luka Kotur 2399

Ovo je projekat iz predmeta CS322-Programiranje u c#. Radi se o ASP.NET Core aplikaciji za menadzment video kluba.

---

Koriscene tehnologije: 
- ASP.NET Core 2.0
- Entity Framework (SQL database)
- Bootstrap v4 za frontend (sa jquery data tabelama i date pickerima zbog lakseg koriscenja formi za unos)

## Instrukcije za pokretanje aplikacije

---

Da biste pokrenuli aplikaciju, morate da klonirate ovaj github repozitorijum. Kada to uradite potrebno je uraditi nekoliko koraka kako bi ovaj projekat mogao da se uspesno pokrene.

Koraci neophodni za pokretanje aplikacije

- Potrebno je skinuti [SQL Server Management Studia](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms), konektovati se na `` (LocalDB)\MSSQLLocalDB `` i pokrenuti fajl `` BazaSql/CS322-Projekat-DBDataScript.sql `` preko [SSMS](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) i izvrsiti ponudjeni query. On ce napraviti potrebnu bazu podataka i popuniti je sa nekim podacima za lakse testiranje rada aplikacije.
- Nakon toga mozete otvoriti program preko [Visual Studia](https://www.visualstudio.com/)
- Nakon otvaranja programa u Visual studiu, mozete da ga startujete i otvorice vam se pocetna stranica.
- Podaci za login kako bi se pristupilo svim funkcionalnostima aplikacije su: username: admin, password: Admin123!

Nakon obavljanja ovih koraka, aplikacija ce biti pokrenuta na vasem racunaru.


## Nekoliko slika aplikacije 

![Katalog-Iznajmljeno i rezervisano](https://xoepwq.bn1303.livefilestore.com/y4m0HHnJ7-PPCmYGPtVgzW21je-0y4WfXVB-BhvopK0NY6Qe9cgG2T_shYhjuMBsCJC-kIC_aGNPL4tYpqYl1D7tAg8y1tVFDieAi48J6ggqMYl9PqAZt__WSitHFAaTHKQYCoKdnpjOJqKGgBn4pOYif39Gzkp3_GAqwqd5z7Lk52SSuLf23nC8fjJhXn-FgnMse6klZde2Gn7CmOXNa6QiA?width=660&height=358&cropmode=none)
![Lista clanova](https://wuepwq.bn1303.livefilestore.com/y4msz5NPrhcxz_QmR0lTCoNCUgKVHzsbojZ5PiUk3QxSm5vFrMEiMu7WUK-byVo7VhxwQ4quY-E3zznvKO5LE7i0cormFjm_vYRKky2IxLJm5c3EK1xNFKR-Cv9ZUzVdo_NbvDKORShlbwo18zxgb23dLlbWfXtos0BvP-tT4a8f3_gsBRgwqtMeYllA5O8bSLJ3Fn25CuOiyE-zH1rM851Uw?width=660&height=358&cropmode=none)
![Katalog](https://veepwq.bn1303.livefilestore.com/y4mycS88-TRWfhGaltYeWQeHM-BgzwzrXI4XsiJo40-97ITuGkPKk1PRM7xlwM-ZBsXnHA2TpCJx4LIG92oM81MJvDYcQG_4d9oAGT74AaQsfuSQXvaJsPPUdg9qx0saknZDpLo3r1aoSkGAjEROOHoEIkx-R4D7VwrLRkSqij_THw432Jys7N4WWpOIhw-b9xr2Ibyn8t1iYn8fTrj4KFDhA?width=660&height=358&cropmode=none)
![Katalog-Detail](https://wpepwq.bn1303.livefilestore.com/y4mdvKEWzisBrcg5UcGNIXjbxe_FxYdQ5w_VsTftF4CsBh3g6wbfL9gIS4aZYcJ2_nMVJ04GSubjtmDWlXR1SVCssXnVBpez7wjIqniopMTjKk0m0HWpBOySRcGh0v6nB9HPjphjFDB42kKdb6Kda8pkA241KW1K1vs0Jr7ltLtFMKRUlK5JNiNE6veaYGQt55y6HUvdZQMPMEJZioM7xliXQ?width=660&height=358&cropmode=none)