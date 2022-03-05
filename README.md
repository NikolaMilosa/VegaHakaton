## VEGA HAKATON API
---
Načini pokretanja aplikacije:
- Standardni način (Visual studio, Postgres)
- Docker-compose (Docker)
---
## Standardni način
Neophodne stvari za pokretanje aplikacije su Visual studio 2022 i PostgreSql. Nakon instaliranja Visual studia (ako je instalirana 2022 verzija), neophodno je proveriti kroz Visual Studio Installer da li je instaliran dotnet 5 runtime. Ako nije neophodno je instalirati ga.

Nakon instaliranja svih neophodnih programa, potrebno je postaviti vrednosti određenih **environment promenljivih**
| Naziv promenljive | Značenje | Vrednost |
| :---: | :---: | :---: |
| DB_PATH | connection string za bazu, neophodno je zameniti vrednost username i password na ono što je korisnik postavio pri instaliranju i podešavanju postgresa | host=localhost; port=5432; database=VegaDB; username=postgres; password=postgres  
| DB_PROVIDER | u koliko bude neophodno podržati više database providera, za sada jedina mogućnost postgres | postgres

Nakon podešavanja environment promenljivih neophodno je restartovati Visual Studio. Nakon restartovanja pokrenuti aplikaciju sa F5 ili pritiskom na dugme 'IIS Express'

---
## Docker-compose
U koliko korisnik ne želi da podešava Visual Studio i/ili postgresql omogućena je opcija pokretanja preko docker-compose. Neophodno je instalirati docker. Nakon toga, pokretanjem komande
```
docker-compose up
```
će se pokrenuti aplikacija na portu 8088. Kada se aplikacija podigne, na sledećem [linku](http://localhost:8088/swagger) će se otvoriti swagger preko kojeg se može interagovati sa API-jem.

---
## Testovi
Za aplikaciju je napisano i nekoliko testova prilikom rada. U koliko korisnik želi da pokrene testove to može uraditi na dva načina:
- Kroz konzolu
    ```
    dotnet test ServicesTests/ && dotnet test HandlersTests/
    ```
    
- Kroz visual studio

    View > Test Explorer
    
    Nakon toga će se otvoriti prozor sa pronađenim testovima. Desnim klikom na bilo koji skup i klikom na zeleno 'Run' dugme se testovi pokreću.

