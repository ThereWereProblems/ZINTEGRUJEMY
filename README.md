# ZINTEGRUJEMY

Aplikacja .NET Core API została napisana przy użyciu .NET 7. Projekt został podzielony na warstwy, aby dobrze wykorzystać wzorce Clean Architecture, Mediator i CQRS.

### Jedne z ważniejszych bibliotek wykorzystanych w projekcie:
* MediatR
* FluentValidation 
* AutoMapper
* EntityFrameworkCore wraz z rozszerzeniem do danych zbiorczych.

### Opis do wykonanego zadania
* Task 1 - aplikacja pobiera pliki i zapisuje w folderze **@wwwroot/files/**. Założyłem, że pliki za każdym razem mają być nadpisywane, a baza danych nie zawiera żadnych rekordów, w przeciwnym razie konieczne jest dodanie np. daty do nazwy pobranego pliku i sprawdzanie istnienia danych w bazie przed ich dodaniem. Dane z plików są filtrowawne przed dodaniem do bazy danych. Uszkodzone dane takie jak niepełne wiersze lub dane liczbowe z literką O zamiast cyfry 0 są pomijane. Aby uniknąć błędów podczas zapisywania danych przez uszkodzone dane tabele nie posiadają kluczy obcych. Jeśli aplikacja ma odpowiadać tylko i wyłącznie za funkcjinalność zawartą w tasku 2, możliwe jest zmiejszenie właściwości obiektów bazy danych w skutek czemu zapobiegnięcie przechowywania nadmiarowych danych w bazie.
* Task 2 - endpoint odpowiada za wyszukanie danych produktu w trzech tabelach i o ile te istnieją połączenia ich w zwracany obiekt.
