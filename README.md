# System Wypożyczania Sprzętu (Projekt Obiektowy)


Konsolowa aplikacja obiektowa napisana w języku C# do zarządzania wypożyczeniami sprzętu (np. dla studentów).
Projekt demonstruje podstawowe zasady programowania obiektowego oraz SOLID, czystą architekturę oraz mechanizmy utrwalania danych.

### Funkcjonalności

* **Konsolowy interfejs użytkownika (UI):** prosta aplikacja konsolowa do interakcji z bazą wypożyczalni.
* **Zapis danych do JSON:** Stan aplikacji jest automatycznie zapisywany i wczytywany przy użyciu `System.Text.Json`.
* **Wstrzykiwanie zależności:** Luźne powiązanie (loose coupling) między warstwą prezentacji a logiką biznesową za pomocą interfejsu `IRentalService`.
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

Powyższa struktura powstała w celu zachowania zasad SOLID oraz dobrych praktyk programowania. Zadbano o zasady pojedynczej odpowiedzialności 
m.in. ConsoleMenu.cs zajmuje się wyłącznie interakcją z użytkownikiem, a także każda klasa odpowiada za jeden spójny fragment domeny. 
Warstwa ConsoleMenu.cs zależy od abstrakcji (IRentalService), a nie od konkretnych implementacji. Zadbałem również o wysoką kohezję; klasy są mocno skoncentrowane na swoim zadaniu m.in. w klasie `RentalService` 
– wszystkie metody wewnątrz tej klasy `(Rent, Return, SaveData)` operują na tej samej kolekcji `_rentals` i dotyczą wyłącznie jednego tematu: obsługi wypożyczeń.

### Jak uruchomić

Główna funkcja uruchamiająca aplikacje konsolową została umieszczona w pliku `Program.cs`
>Uwaga! Podczas uruchamiania aplikacji w `bin/.../` utworzy się katalog `Data/`, a w nim plik `rentals.json` służący jako baza danych wszystkich wypożyczeń. Będzię on jednak pusty dlatego w klasie `UI/ConsoleMenu.cs` dodane zostały testowe obiekty np, student, laptop.

