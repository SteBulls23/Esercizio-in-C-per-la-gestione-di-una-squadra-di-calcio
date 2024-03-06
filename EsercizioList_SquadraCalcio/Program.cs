namespace EsercizioList_SquadraCalcio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> giocatori = new List<string>() { "Buongiorno", "Jordan", "Ricci", "Ronaldo" };
            List<string> numeriMaglie = new List<string>() { "3", "23", "8", "7" };
            List<int> minutiGiocati = new List<int>() { 80, 40, 65, 90 };

            bool cicla = true;
            char scelta = ' ';

            do
            {
                opzioniDisponibili();
                Console.WriteLine("Scegli un'opzione tra quelle disponibili nel menù!");
                scelta = Convert.ToChar(Console.ReadLine());
                if (scelta == 'I')
                {
                    Console.WriteLine();
                    inserisciGiocatore(giocatori, numeriMaglie, minutiGiocati);
                }
                else if (scelta == 'P')
                {
                    Console.WriteLine();
                    incrementaMinutaggio(giocatori, minutiGiocati);
                }
                else if (scelta == 'R')
                {
                    Console.WriteLine();
                    ricercaGiocatorePerNome(giocatori, numeriMaglie, minutiGiocati);
                }
                else if (scelta == 'N')
                {
                    Console.WriteLine();
                    ricercaGiocatorePerNumeroMaglia(giocatori, numeriMaglie, minutiGiocati);
                }
                else if (scelta == 'C')
                {
                    Console.WriteLine();
                    cancellaGiocatore(giocatori, numeriMaglie, minutiGiocati);
                }
                else if (scelta == 'M')
                {
                    modificaInfoGiocatore(giocatori, numeriMaglie, minutiGiocati);
                }
                else if (scelta == 'V')
                {
                    Console.WriteLine();
                    visualizzaGiocatori(giocatori, numeriMaglie, minutiGiocati);
                }
                else if (scelta == 'U')
                {
                    Console.WriteLine();
                    cicla = false;
                    Console.WriteLine("Grazie per aver usato questo programma!");
                }
                else
                {
                    Console.WriteLine("ERRORE! L'opzione che hai scelto non è disponibile tra quelle presenti nel menù");
                }
            
            } while (cicla);
        }

        public static void opzioniDisponibili()
        {
            Console.WriteLine("--------------------SCEGLI UN'OPZIONE--------------------");
            Console.WriteLine("1) Premi 'I' per inserire un nuovo giocatore in squadra!");
            Console.WriteLine("2) Premi 'P' per incrementare il numero di minuti giocati di un determinato giocatore!");
            Console.WriteLine("3) Premi 'R' per ricercare un giocatore, della squadra, per cognome!");
            Console.WriteLine("4) Premi 'N' per ricercare un giocatore, della squadra, per numero di maglia!");
            Console.WriteLine("5) Premi 'C' per cancellare un giocatore dalla squadra!");
            Console.WriteLine("6) Premi 'M' per modificare le informazioni relative a un giocatore!");
            Console.WriteLine("7) Premi 'V' per visualizzare tutti i calciatori della squadra con le relative caratteristiche!");
            Console.WriteLine("8) Premi 'U' per uscire dal programma!");
            Console.WriteLine("--------------------FINE DELLE OPZIONI--------------------");
            Console.WriteLine();
        }

        public static void opzioniModificaGiocatore()
        {
            Console.WriteLine("---------------SCEGLI UN'OPZIONE---------------");
            Console.WriteLine("1) Premi '1' se vuoi modificare il cognome del giocatore!");
            Console.WriteLine("2) Premi '2' se vuoi modificare il numero di maglia del giocatore!");
            Console.WriteLine("3) Premi '3' se vuoi modificare il minutaggio del giocatore!");
            Console.WriteLine("4) Premi '4' se vuoi modificare tutte e 3 le informazioni del giocatore!");
            Console.WriteLine("---------------FINE DELLE OPZIONI---------------");
            Console.WriteLine();
        }

        public static void inserisciGiocatore(List<string> giocatori, List<string> numeriMaglie, List<int> minutiGiocati)
        {
            Console.WriteLine("Scrivi il cognome del giocatore che vuoi inserire nella squadra!");
            string cognomeGiocatore = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Scrivi il numero di maglia di {0}!", cognomeGiocatore);
            string numeroMaglia = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Scrivi il numero di minuti giocati da {0}!", cognomeGiocatore);
            int minutaggio = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("In che posizione della lista vuoi inserire {0}?", cognomeGiocatore);
            int posizione = Convert.ToInt32(Console.ReadLine());

            if (posizione < giocatori.Count() && numeriMaglie.Contains(numeroMaglia) == false)
            {
                giocatori.Insert(posizione, cognomeGiocatore);
                numeriMaglie.Insert(posizione, numeroMaglia);
                minutiGiocati.Insert(posizione, minutaggio);
                Console.WriteLine("Giocatore inserito con successo!");
            }
            else
            {
                Console.WriteLine("ERRORE! La posizione in cui vuoi inserire il tuo nome è superiore alla lunghezza totale della lista oppure il numero di maglia che hai assegnato a {0} non è più disponibile! Assegnagli un altro numero!", cognomeGiocatore);
            }
        }

        public static void incrementaMinutaggio(List<string> giocatori, List<int> minutiGiocati)
        {
            Console.WriteLine("Scrivi il cognome del giocatore a cui vuoi incrementare il minutaggio!");
            string cognomeGiocatore = Console.ReadLine();
            
            Console.WriteLine();

            if (giocatori.Contains(cognomeGiocatore) == true)
            {
                int index = giocatori.IndexOf(cognomeGiocatore);
                
                Console.WriteLine("Di quanto vuoi incrementare il minutaggio di {0}?", cognomeGiocatore);
                int incremento = Convert.ToInt32(Console.ReadLine());
                
                int minutaggioIncrementato = minutiGiocati[index] + incremento;
                minutiGiocati[index] = minutaggioIncrementato;
                
                Console.WriteLine("Il minutaggio di {0} è stato incrementato con successo!", cognomeGiocatore);
            }
            else
            {
                Console.WriteLine("ERRORE! Il giocatore a cui stai cercando di incrementare il minutaggio non è presente nella lista!");
            }
        }

        public static void ricercaGiocatorePerNome(List<string> giocatori, List<string> numeriMaglie, List<int> minutiGiocati)
        {
            Console.WriteLine("Scrivi il cognome del giocatore che desideri cercare nella lista!");
            string cognomeGiocatore = Console.ReadLine();

            if (giocatori.Contains(cognomeGiocatore) == true)
            {
                int index = giocatori.IndexOf(cognomeGiocatore);

                Console.WriteLine("{0} è presente nella lista, alla posizione {1} della lista. Ha il numero {2} e il suo minutaggio a partita è di {3} minuti!", cognomeGiocatore, index, numeriMaglie[index], minutiGiocati[index]);
            }
            else
            {
                Console.WriteLine("ERRORE! Il giocatore che stai cercando non è presente nella lista!");
            }
        }

        public static void ricercaGiocatorePerNumeroMaglia(List<string> giocatori, List<string> numeriMaglie, List<int> minutiGiocati)
        {
            Console.WriteLine("Scrivi il numero di maglia del giocatore che vuoi cercare nella lista!");
            string numeroMaglia = Console.ReadLine();

            if (numeriMaglie.Contains(numeroMaglia) == true)
            {
                int index = numeriMaglie.IndexOf(numeroMaglia);

                Console.WriteLine("{0} è presente nella lista e il giocatore che ha il {1} è {2}. Egli si trova alla posizione {3} e il suo minutaggio a partita è di {4} minuti!", numeroMaglia, numeroMaglia, giocatori[index], index, minutiGiocati[index]);
            }
            else
            {
                Console.WriteLine("ERRORE! Il numero di maglia che stai cercando non è presente nella lista!");
            }
        }

        public static void cancellaGiocatore(List<string> giocatori, List<string> numeriMaglie, List<int> minutiGiocati)
        {
            Console.WriteLine("Scrivi il cognome del giocatore che vuoi cancellare dalla squadra!");
            string cognomeGiocatore = Console.ReadLine();

            if (giocatori.Contains(cognomeGiocatore) == true)
            {
                int index = giocatori.IndexOf(cognomeGiocatore);

                giocatori.Remove(cognomeGiocatore);
                numeriMaglie.Remove(numeriMaglie[index]);
                minutiGiocati.Remove(minutiGiocati[index]);

                Console.WriteLine("Il giocatore è stato cancellato dalla lista con successo!");
            }
            else
            {
                Console.WriteLine("ERRORE! Il giocatore che stai cercando di cancellare non è presente nella lista!");
            }
        }

        public static void modificaInfoGiocatore(List<string> giocatori, List<string> numeriMaglia, List<int> minutiGiocati)
        {
            Console.WriteLine("Scrivi il cognome del giocatore del quale vuoi modificare le informazioni!");
            string cognomeGiocatore = Console.ReadLine();

            Console.WriteLine("Quali informazioni di {0} vuoi modificare?", cognomeGiocatore);

            Console.WriteLine();

            opzioniModificaGiocatore();

            char scelta = ' ';

            if (giocatori.Contains(cognomeGiocatore) == true)
            {
                int index = giocatori.IndexOf(cognomeGiocatore);

                Console.WriteLine("Scegli un'opzione tra quelle disponibili nel menù!");
                scelta = Convert.ToChar(Console.ReadLine());

                if (scelta == '1')
                {
                    Console.WriteLine("Scrivi il cognome che vuoi inserire al posto di {0}!", cognomeGiocatore);
                    string nuovoCognome = Console.ReadLine();

                    giocatori[index] = nuovoCognome;

                    Console.WriteLine("Il cognome è stato modificato con successo!");
                }
                else if (scelta == '2')
                {
                    Console.WriteLine("Scrivi il nuovo numero di maglia di {0}!", cognomeGiocatore);
                    string nuovoNumeroMaglia = Console.ReadLine();

                    if (numeriMaglia.Contains(nuovoNumeroMaglia) == false)
                    {
                        numeriMaglia[index] = nuovoNumeroMaglia;

                        Console.WriteLine("Il numero di maglia di {0} è stato modificato con successo!", cognomeGiocatore);
                    }
                    else
                    {
                        Console.WriteLine("ERRORE! Il numero di maglia che hai assegnato a {0} non è più disponibile! Assegnagli un'altro numero!", cognomeGiocatore);
                    }
                }
                else if (scelta == '3')
                {
                    Console.WriteLine("Scrivi il nuovo numero di minuti giocati da {0}!", cognomeGiocatore);
                    int nuovoMinutaggio = Convert.ToInt32(Console.ReadLine());

                    minutiGiocati[index] = nuovoMinutaggio;

                    Console.WriteLine("Il minutaggio di {0} è stato modificato con successo!", cognomeGiocatore);
                }
                else if (scelta == '4')
                {
                    Console.WriteLine("Scrivi il cognome che vuoi inserire al posto di {0}!", cognomeGiocatore);
                    string nuovoCognome = Console.ReadLine();

                    Console.WriteLine("Scrivi il numero di maglia di {0}!", nuovoCognome);
                    string nuovoNumeroMaglia = Console.ReadLine();

                    Console.WriteLine("Scrivi il numero di minuti giocati da {0}!", nuovoCognome);
                    int nuovoMinutaggio = Convert.ToInt32(Console.ReadLine());

                    if (numeriMaglia.Contains(nuovoNumeroMaglia) == false)
                    {
                        giocatori[index] = nuovoCognome;
                        numeriMaglia[index] = nuovoNumeroMaglia;
                        minutiGiocati[index] = nuovoMinutaggio;

                        Console.WriteLine("Il giocatore è stato modificato con successo!");
                    }
                    else
                    {
                        Console.WriteLine("ERRORE! Il numero di maglia che hai assegnato a {0} non è più disponibile! Assegnagli un'altro numero!", nuovoCognome);
                    }
                }
                else
                {
                    Console.WriteLine("L'opzione che hai scelto non è tra quelle disponibili nel menù!");
                }
            }
            else
            {
                Console.WriteLine("ERRORE! Il giocatore del quale stai cercando di modificare le informazioni non è presente nella lista!");
            }
        }

        public static void visualizzaGiocatori(List<string> giocatori, List<string> numeriMaglie, List<int> minutiGiocati)
        {
            Console.WriteLine("Ecco a voi la rosa completa della squadra(per ogni giocatore è associato il numero di maglia e il numero di minuti giocati a partita)!");
            
            Console.WriteLine();
            
            Console.WriteLine("La lista completa dei giocatori della squadra:");
            foreach(string cognomeGiocatore in giocatori)
            {
                Console.Write(cognomeGiocatore);
                if (cognomeGiocatore != giocatori[giocatori.Count() - 1])
                {
                    Console.Write(", ");
                }
            }
            
            Console.WriteLine();
            
            Console.WriteLine("La lista completa dei numeri di maglia dei giocatori:");
            foreach(string numeroMaglia in numeriMaglie)
            {
                Console.Write(numeroMaglia);
                if (numeroMaglia != numeriMaglie[numeriMaglie.Count() - 1])
                {
                    Console.Write(", ");
                }
            }
            
            Console.WriteLine();
            
            Console.WriteLine("La lista completa dei minuti giocati, a partita, da un giocatore:");
            foreach(int minutaggio in minutiGiocati)
            {
                Console.Write(minutaggio);
                if (minutaggio != minutiGiocati[minutiGiocati.Count() - 1])
                {
                    Console.Write(", ");
                }
            }
            
            Console.WriteLine();
        }
    }
}
