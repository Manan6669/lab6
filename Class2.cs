using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
   enum Cars_of_company
    {
        Ford_Mondeo,
        Skoda_Slavia = 8,
        Audi_Q9
 

    }

    struct Fuel
    {
        public string value; 
    }

   public abstract class Company
    {
        Cars_of_company car = Cars_of_company.Audi_Q9;
        Fuel fuel = new Fuel();
        public void SetFuel(int x)
        {
            fuel.value += x;
            fuel.value += ", ";
        }

        private string transport;
        public virtual string _transport { get { return transport; } set { transport = value; } }

        private string cars_company;
        public virtual string _cars_company { get { return cars_company; } set { cars_company = value; } }
        public abstract bool DoClone();

        public Company (string Transport, string Car)
        {
            _transport = Transport;
            cars_company = Car;

            switch(Car)
            {
                case "FAudi_Q9":
                    { 
                        car = Cars_of_company.Audi_Q9;
                    }
                    break;

                case "Ford_Mondeo":
                    {
                        car = Cars_of_company.Ford_Mondeo;
                    }
                    break;

                case "Skoda_Slavia":
                    {
                        car = Cars_of_company.Skoda_Slavia;
                    }
                    break;
            }

        }

        public Company(string Transport)
        {
            transport = Transport;
            cars_company = null;
        }
        public Company()
        {
            transport = null;
            cars_company = null;
        }
    }

    public class Light_Car : Company
    {
        private int speed;
        public int _speed { get { return speed; } set
            {
                if (value > 900)
                    throw new TestException("Вы че откуда такая скорость");
            }

                }

        public virtual string transport { get { return (_transport + ""); } set { _transport = value; } }
        public virtual string cars_company { get { return ("" + _cars_company); } set { _cars_company = value; } }


        public override bool DoClone()
        {
            return false;

        }
         public Light_Car(string Transport, string Cars_of_company, int Speed )
        {
            _transport = Transport;
            _cars_company = Cars_of_company;
            _speed = Speed;
        }

        public Light_Car()
        { }

        public override string ToString()
        {
            string rez = this._transport + this._cars_company + this._speed;
            return rez;
        }
    }

    sealed partial class Speed_of_transport : Light_Car
    {
        private int sp;
        public int _sp { get { return sp; } set
            {
                if (value > 1000)
                    throw new Speed_of_transportException("Too much большая скорость вы че", value);

            }
        }

        public Speed_of_transport(string Transport, string Cars_of_company, int Speed ):base(Transport, Cars_of_company, Speed) { }
        public Speed_of_transport():base()
        {
            sp = 123;
        }
        public override string ToString()
        {
            string rez = this._transport + this._cars_company + this._speed;
            return rez;
        }
    }

    interface IClonable
    {
        bool DoClone();
    }

    public class Printer
    {
        public string IAmPrinting(Company someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(Light_Car someobj)
        {
            return someobj.ToString();
        }
       
    }
}


































//IClonable IEnumerable перебор эл IEnumerator переб объекты ч-з фореач ICompareble сравнение для выясн порядка IComparer сравн лбъектов им б афт Idisposable мех для освобождения  IEquatable<T>ср на равенство Проверка на равество по знач