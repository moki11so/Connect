# MoSo Worker Implementation

REL: [Beitrag von wortfilter.de](https://wortfilter.de/datenleck-modern-solution-loesung-kostenlos-open-sorce-fuer-euch/)

Unvollständig, an einem Sonntag runtergehackt.

Dies ist eine Beispielimplementation, wie man die jüngsten Sicherheitsprobleme der MoSo.Connect-Schnittstelle durch einfachste Mittel beheben kann.

Das Beispiel enthält einen Großteil der Client-Implementation (Ordner: Client) und einen Ansatz des Servers (Ordner: Api).

Beide Projekte teilen sich den Shared-Bereich, wo Dto-Objekte abgelegt sind. Der Server erstellt anhand der definierten Controller automatisch eine OpenAPI-Dokumentation. 

## Client

Die OpenAPI-Dokumentation wird mit NSwagStudio und der vorgefertigten Konfiguration `client.nswag` im Client als Service `IClient` und als Implementation `Client` generiert.

Der Client arbeitet als 'Worker Service'. Die grundlegende Idee ist, dass dieser in Windows als Dienst angelegt werden soll und alle 10 Minuten einen Durchlauf initiiert (`TimedWorker`).

Der `TimedWorker` holt sich über Dependency-Injection (LightInject) den `EntryWorker` (S: `IWorkerService`), welcher den Abgleich initiiert. 

Der `EntryWorker` prüft und aktiviert die Lizenz, sendet Meta-Daten (`InitializeWorker`), holt sich die aktiven Plattformen und startet zu jeder Plattform den `PlatformWorkerService`.

Der `PlatformWorkerService` holt sich vom Server die Information, welche Funktionen die Plattform unterstützt und führt entsprechend Funktionen in weiteren Diensten aus.

### Technik

Abhängigkeiten werden über Deependency-Injection aufgelöst und grundsätzlich nur über Interface abgebildet. Als ServiceContainer wird LightInject verwendet.

Logging, Fehlerreportung usw. findet über `ILogger<T>` statt. Muss abgebrochen werden, wird NICHT `Environment.Exit` verwendet, sondern eine Ausnahme geworfen (`throw new Exception()`). Die Ausnahme wird spätestens im `TimedWorker` gefangen und geloggt. Logging-Reporting ist noch nicht gelöst. Das macht man auch nicht Synchron, weil gerade wenn der API-Dienst nicht erreichbar ist, bringt es garnichts. Ich empfehle hier irgendwas mit Windows EventLog und zusätzlich eine Queue, die beim Start des EntryWorkers verschickt wird.

Kommunikation mit der Api findet über REST-ähnliche Aufrufe statt. Der Service `IClient` und die Implementation `Client` wird nicht von Hand bearbeitet, sondern mit NSwagStudio generiert. Die Konfiguration liegt bei. Es werden keine DTOs erzeugt, da diese im Shared zu liegen haben.

## Api

Die API ist weniger entwickelt. Hier trennt sich die Spreu vom Weizen, denn bis hierhin ist alles generisch und für jede Plattform gleich. Ich empfehle hinter der API eine abstrakte Schicht zu verwenden und NICHT für jede Plattform riesige if/elseif-Blöcke! das macht euch den Code kaputt und sorgt für Fehler!

Zur Autentifizierung habe ich die `ApiKeyMiddleware` angelegt. Die prüft auf die Kopfzeile `X-MoSo-Authorization`, wo der Lizenzschlüssel rein fliegen soll. Da muss geprüft werden, aktuell prüft der auf '1234'.


## Sicherheit / Qualität / Schlusswort

Grundsätzlich gibt es immernoch einige Punkte, die im Ablauf zu bemängeln sind. 

Ich bin jedoch schon froh, wenn kein direkter Zugriff auf die Datenbank mehr erfolgt! 

Die Qualität des Codes ist grundsätzlich besser, als vorher. Durch Atomarisierung werden Gottklassen vermieden. Sortierung, Benennung und Prefixe sind eindeutiger (Vorher zum Beispiel: Billing für Zahlungsart oder Get anstatt Count oder Get und nichts wurde zurückgegeben).
Anstatt großer Arrays werden nun Objekte an allen Stellen zurückgegeben und zur Identifizierung zum Beispiel Aufträge, wird die Plattform und die externe Auftragsnummer (von der Plattform) herangezogen.

Die Lizenz wird einmalig im Einstiegspunkt initialisiert.

Die Services sind größtenteils nicht sortiert, das sollte man noch nach Schicht oder Bereich erledigen.

Die API sollte hinter einem Reverse-Proxy betrieben werden.

## Last but not least:

Im Grunde wollen wir alle nur eines: Sicherheit der Gesamtdaten. Klar kann es vorkommen, dass ein Lizenzschlüssel übernommen wird. Dann sind aber nicht ALLE Nutzer betroffen und es lässt sich nurnoch auf begrenzt Daten zugreifen. In Zukunft sollte das allerdings über ein sichereres Verfahren gelöst werden.

Sollte es Probleme, Anregungen oder Fragen mit der Implementation geben, darf gerne eine Em ail an mich gesendet werden.
