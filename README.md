# TCPClientServer
Client/Server komunikator (Win Forms) stworzony na cele projektu zaliczeniowego z zajęć Programowania Zaawansowane na uczelni WSB.

## Jak odpalić?
  W projekcie są dwa podprojekty, które można skompilować:
  * TCPServer01.exe - aplikacja, w której wybieramy IP i port nasłuchiwania (serwer)
  * TCPClient01.exe - aplikacja, w której wybieramy IP i port serwera (klient)
 
## Jak przetestować?
  Należy najpierw uruchomić serwer, wybrać z listy IP i podać port, na którym aplikacja może nasłuchiwać. Za pomocą klawisza "Start Server" uruchomić serwer. Następnie włączyć klienta (lub kilka), wybrać IP i port serwera i kliknąć "Start Client". Klient i serwer mogą wysyłać do siebie kumunikaty.
 
## Opis działania
  Aplikacja wykorzystuje własnego autorstwa bibliotekę opartą na TcpListener i TcpClient. Pozwala na uruchomienie serwera, który nasłuchuje na danym porcie i pozwala przesyłać/odbierać komunikaty do/od klienta. Posiada własną obsługę zdarzeń, która umożliwia łatwiejszą integrację z różnymi typami aplikacji (moja wykorzystuje WinForms). Serwer zapisuje do bazy danych wszelkiego rodzaju logi (przesłane komunikaty, informacje o podłączeniu/odłączeniu klienta) wykorzystując Entity Framework.

## TODO
  ### Dorobić:
  * możliwość wysyłania wiadomości do innych klientów
  * możliwość wysyłania plików
