Installationsguide:

Vad krävs i förväg? En SQL-installation, Visual Studio, Github-konto, Github-tillägget för Visual Studio

1. Klona ner repot genom Github-tillägget i Team Explorer
2. Skapa en databas som heter MeasureMyPike
3. Kör MeasureMyPikeModel.edmx.sql och sedan MeasureMyPikeUniqueConstraints.sql. Dessa ligger under \MeasureMyPike\MeasureMyPike\Models\Entity Framework\
4. Se till att allt bygger
5. Nu har du allt uppsatt för att köra igång med kodande och testande

För att köra igång front-end:

1. Gå in i foldern MeasureMyPike.Web/App/MeasureMyPike
2. Ta bort mappen node_modules om den redan finns
3. Skriv "npm install" i cmd, där du står i tidigare nämnda mapp
4. När installationen är klar skriv "npm start"
5. Kör igång backend genom play-knappen i visual studio
6. Öppna upp gui't 

Det som kan stöka är att vi har olika SQL-installationer, där en del har express och andra har "större" installationer.

Standarder:
I våra repository-filer så har vi ett gäng olika metoder. Dessa är för att skapa, uppdatera, ta bort och hämta ut data.
Ordningen på dessa ska vara:
1. Skapa
2. Hämta ut specifikt data
3. Hämta ut all data
4. Uppdatera
5. Ta bort
