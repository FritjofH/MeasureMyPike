Installationsguide:

Vad krävs i förväg? En SQL-installation, Visual Studio

1. Klona ner repot
2. Skapa en databas som heter MeasureMyPike
3. Kör MeasureMyPikeModel.edmx.sql och sedan MeasureMyPikeUniqueConstraints.sql. Dessa ligger under \MeasureMyPike\MeasureMyPike\Models\Entity Framework\
4. Nu har du allt uppsatt för att köra igång med kodande och testande

Det som kan stöka är att vi har olika SQL-installationer, där en del har express och andra har "större" installationer.

Standarder:
I våra repository-filer så har vi ett gäng olika metoder. Dessa är för att skapa, uppdatera, ta bort och hämta ut data.
Ordningen på dessa ska vara:
1. Skapa
2. Hämta ut specifikt data
3. Hämta ut all data
4. Uppdatera
5. Ta bort
