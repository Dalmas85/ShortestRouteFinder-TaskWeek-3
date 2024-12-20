# ShortestRouteFinder

## Uppgift 3

**Mål**: 

Applikationen ska läsa in en lista över rutter från en JSON-fil, där varje rutt har en startpunkt, destination och avstånd. 
Den ska sortera listan efter avstånd (kortaste rutt först alt längsta först) med minst två olika sorteringsalgoritmer (t ex Bubble Sort och Quick Sort). 
Användaren ska kunna välja sorterings algoritm.

Resultatet visas sedan i GUI.

**Förbättringar (Nice to have)**:

Utvärdering: Utöka input data och visa beräkningstiden för varje vald algoritm.


**Komponenter**:

- **Model**: 

  Representerar en rutt och hanterar datan från JSON-filen.
  
- **ViewModel**: 

  Innehåller logiken för att sortera listan och uppdatera vyn.
  
- **View**: 

  WPF-gränssnittet som visar rutter i en lista och låter användaren välja en sorteringsmetod.


Hej Alejandro!
  
  Lagt upp Uppgiften till ett nytt Repository,puschar uppdateringar vartefter. Mejlar när jag anser mig klar eller om jag kör fast helt.

  /Jonas J

  Uppdatering!

  Hej Alejandro! 
  
  jag har läst ditt mail idag söndag,har ändrat i Properties för json filen EuropeRoutes.json. Har pushat detta till Develop branch här på GIT HUB.

  Testade att clona mitt Repository och öppna det i Visual Studio då blev det exeception error igen, men när jag laddade ner programmmet som zip fil och packade upp det och körde så då fungerade det.

  /Jonas
  
## Uppgift 3

15:41 2024-11-15

Godkänd. Klarat sorterings algoritmen.

## Anmärkningar

1. Följer inte MVVM

	View är enbart för användargränsnnitet. Ingen logik under View

	private void OnSortButtonClick(object sender, RoutedEventArgs e)
	{
		** Enbart kod som har med UI **
		** All logik ska kan utföras utanför view.
	}


3. Bra med felhantering. Säkerställer element selekterad i comboboxar när man väljer "Sort Routes".
	
	Något att tänka på: Om ingenting är valt, så kan knappen "Sort Routes" deaktiveras, 
	och aktiveras när det finns förutsättningar att utföra komandot. 
  På så sätt kommer användaren att få bättre flöde i arbete utan att behöva trycka bort extra fönster.
  Att disabla knappar när det inte finns tillräklig med info, är mer eller mindre standard. 
	
4. Bra att försöka ta tid för algoritmerna. Vissa gärna i samma fönster (t ex en label). 
   
/Alejandro
