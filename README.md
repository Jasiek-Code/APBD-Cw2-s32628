# System Wypożyczania Sprzętu (Projekt Obiektowy)


Konsolowa aplikacja obiektowa napisana w języku C# do zarządzania wypożyczeniami sprzętu.
Projekt demonstruje podstawowe zasady programowania obiektowego oraz zasady SOLID, czystą architekturę oraz mechanizmy utrwalania danych.

### Funkcjonalności

* **Konsolowy interfejs użytkownika (UI):** prosta aplikacja konsolowa do interakcji z bazą wypożyczalni.
* **Zapis danych do JSON:** Stan aplikacji jest automatycznie zapisywany i wczytywany przy użyciu `System.Text.Json`.
* **Wstrzykiwanie zależności:** Luźne sprzężenie m. in. pomiędzy warstwą prezentacji a logiką biznesową za pomocą interfejsu `IRentalService`.
* **Zapytania LINQ:** Filtrowanie aktywnych wypożyczeń, zakończonych transakcji oraz obliczanie kar za opóźnienia.
* **Obsługa wyjątków:** Obsługa błędów (try-catch) zapobiegająca zatrzymaniu działania aplikacji.

### Struktura projektu
```
projekt_obiektowy/
│
├── bin/.../Data/     # Automatycznie generowanu plik JSON (rentals.json)
├── src/
    ├── Domain/       # Modele biznesowe (User, Hardware, Rental, Laptop, Projector)
    ├── Services/     # Logika biznesowa i interfejsy (RentalService, IRentalService)
    ├── Repositories/ # Logika utrwalania danych (JsonRentalRepository, IRentalRepository)
    ├── UI/           # Warstwa prezentacji (ConsoleMenu)
    └── Program.cs    # Punkt wejścia aplikacji
```

### Uzasadnienie struktury

Powyższy podział plików i folderów wynika bezpośrednio z zasad SOLID i dobrych praktyk inżynierii oprogramowania. 
Chciałem, aby kod był czytelny, łatwy w utrzymaniu i gotowy na ewentualną rozbudowę.

W projekcie widać wyraźny nacisk na:

* **Pojedynczą odpowiedzialność (SRP):** Klasy nie wchodzą sobie w drogę i mają jedno konkretne zadanie. Na przykład `ConsoleMenu.cs` zajmuje się wyłącznie wyświetlaniem treści i interakcją z użytkownikiem, podczas gdy cała logika biznesowa została oddelegowana do `RentalService.cs`.
* **Luźne sprzężenie (Low Coupling):** Warstwa interfejsu użytkownika nie jest na sztywno spięta z logiką systemu. UI zależy od abstrakcji (interfejsu `IRentalService.cs`), a nie od konkretnej implementacji pod spodem.
* **Wysoką kohezja (High Cohesion):** Klasy są mocno skoncentrowane na swoim celu. Dobrym przykładem jest `RentalService.cs` – wszystkie metody wewnątrz tej klasy (jak `Rent`, `Return` czy operacje zapisu) operują na tej samej, wspólnej kolekcji `_rentals` i dotyczą wyłącznie obsługi wypożyczeń.

### Jak uruchomić

Główna funkcja uruchamiająca aplikacje konsolową została umieszczona w pliku `Program.cs`
>Uwaga! Podczas uruchamiania aplikacji w `bin/.../` utworzy się katalog `Data/`, a w nim plik `rentals.json` służący jako baza danych wszystkich wypożyczeń. Będzię on jednak pusty dlatego w klasie `UI/ConsoleMenu.cs` dodane zostały testowe obiekty np, student, laptop.

