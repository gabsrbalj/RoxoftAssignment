using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobilskiIzvještaj
{
    public class Automobil
    {
        public string Naziv;
        public int GodinaProizvodnje { get; set; }

        public double OsnovnaCijena;

        public delegate void NaPromjenuGodineProizvodnjeEventHandler(object sender, EventArgs args);
        // parameters: source of event, args as additional data of event
        public event NaPromjenuGodineProizvodnjeEventHandler NaPromjenuGodineProizvodnje;

        protected virtual void OnNaPromjenuGodineProizvodnje()
        {
            if (NaPromjenuGodineProizvodnje != null)
            {
                NaPromjenuGodineProizvodnje(this, new EventArgs());
            }
        }

       

        public void Starost(int GodinaProizvodnje)
        {
            string TrenutnaGodina = DateTime.Now.Year.ToString();
            int CurrentYear = Convert.ToInt32(TrenutnaGodina);
            int starostAutomobila = CurrentYear - GodinaProizvodnje;
            Console.WriteLine($"Starost automobila je: {starostAutomobila} godina/e.");

            OnNaPromjenuGodineProizvodnje();
        }

        public void UkupnaCijena(double OsnovnaCijena)
        {
            double UkupnaCijenaAutomobila = 0;

            try
            {
                if (OsnovnaCijena <= 70000)
                {
                    UkupnaCijenaAutomobila = OsnovnaCijena * 1.3;
                }
                else if (OsnovnaCijena > 70000 && OsnovnaCijena < 100000)
                {
                    UkupnaCijenaAutomobila = OsnovnaCijena * 1.4;
                }
                else if (OsnovnaCijena >= 100000)
                {
                    UkupnaCijenaAutomobila = OsnovnaCijena * 1.5;
                }
                else
                {
                    Console.WriteLine("Something went wrong...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            };

            Console.WriteLine($"Ukupna cijena automobila je: {UkupnaCijenaAutomobila} eura.");
        }

       
    }
    public class Program
    {
        static void Main(string[] args)
        {

            Automobil autoObj = new Automobil();
            Console.WriteLine("--- Unesite podatke za automobil --- \n");

            Console.WriteLine("1. Unesite naziv automobila:");
            autoObj.Naziv = Console.ReadLine();

            Console.WriteLine("2. Unesite godinu proizvodnje automobila: ");
            autoObj.GodinaProizvodnje = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("3. Unesite osnovnu cijenu proizvoda: ");
            autoObj.OsnovnaCijena = Convert.ToDouble(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("\n--- PODACI UNESENOG AUTOMOBILA ---\n");
            Console.WriteLine("Naziv automobila:" + autoObj.Naziv);
            Console.WriteLine("Godina proizvodnje:" + autoObj.GodinaProizvodnje);
            Console.WriteLine("Osnovna cijena:" + autoObj.OsnovnaCijena + "\n");

            Promjena promjena = new Promjena();
            autoObj.NaPromjenuGodineProizvodnje += promjena.OnNaPromjenuGodineProizvodnje;

            autoObj.Starost(autoObj.GodinaProizvodnje);
            autoObj.UkupnaCijena(autoObj.OsnovnaCijena);

        }

        public class Promjena
        {
            public void OnNaPromjenuGodineProizvodnje(object sender,EventArgs args)
            {
                Console.WriteLine("Godina prozivodnje promijenjena je u  " + ((Automobil)sender).GodinaProizvodnje + " godinu");
            }
        }

       
    }
}
