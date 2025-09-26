# Min Dagboksapp

Detta är en enkel konsolapplikation för att skriva, spara, söka, uppdatera och ta bort dagboksanteckningar. Programmet lagrar anteckningarna i en JSON-fil och erbjuder även en sammanfattningsfunktion.

## Körinstruktioner

1. **Kompilera och kör programmet**  
   Öppna projektet i Visual Studio och tryck på `F5` eller välj __Starta__ för att köra applikationen.

2. **Användning i menyn**  
   När programmet startar visas en meny med följande alternativ:
   - `1. Skriv ny anteckning` – Lägg till en ny dagboksanteckning med datum och text.
   - `2. Lista alla anteckningar` – Visa alla sparade anteckningar.
   - `3. Sök anteckning på datum` – Sök efter en anteckning genom att ange ett datum.
   - `4. Spara till fil` – Spara alla anteckningar till filen `diary.json`.
   - `5. Läs från fil` – Läs in anteckningar från filen.
   - `6. Ta bort anteckning` – Ta bort en anteckning genom att ange datum.
   - `7. Uppdatera anteckning` – Uppdatera texten för en anteckning på ett visst datum.
   - `8. Sammanfatta Min Dagbok` – Visa antal anteckningar samt datum för första och senaste anteckning.
   - `0. Avsluta` – Avsluta programmet.
  
   - 3. **Följ instruktionerna på skärmen**  
   Ange det nummer som motsvarar önskad funktion och följ instruktionerna.

## Reflektion

Under utvecklingen av denna dagboksapp har jag fått öva på att arbeta med listor och ordböcker i C#, samt hantera filinläsning och -skrivning i JSON-format. En utmaning var att hålla listan och ordboken synkroniserade, särskilt vid uppdatering och borttagning av anteckningar. Jag har också lärt mig vikten av tydlig felhantering och användarvänliga meddelanden. Sammanfattningsfunktionen ger en snabb överblick över dagbokens innehåll, vilket är användbart för användaren.

---

*Skapad med Visual Studio 2022 och .NET 9.*
