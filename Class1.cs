using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Programm
    {
        
        static void Main(string[] args)
        {
            Light_Car light_car = new Light_Car("Легковая машина", "Ауди", 320);
            Console.WriteLine(light_car.transport);
            Light_Car light_car2 = new Light_Car("Легковая машина", "Форд", 210);
            Speed_of_transport speed_transport = new Speed_of_transport();

            speed_transport = light_car as Speed_of_transport;
            if (light_car is Company)
            {
                Console.WriteLine("GetIt");
            }

            List <Company> list =  new List<Company> { new Light_Car("Легковая машина", "Ауди", 320), new Light_Car("Легковая машина", "Форд", 210) };
            Printer printer = new Printer();
            foreach (Company v in list)
            {
                Console.WriteLine(printer.IAmPrinting(v));

            }

            Cars cars = new Cars();

            Light_Car light_car3 = new Light_Car("Легковая машина", "Шкода", 250);

                cars.ts.Add(light_car);
                cars.ts.Add(light_car2);
                cars.ts.Add(light_car3);

                cars.GetTrans("Форд");
                cars.GetValue();
                cars.GetSpeed(250);

            Controller controller = new Controller();
            controller.GetSpeed(250, cars);





            Console.WriteLine("-----------------------Исключения-----------------------------");

            try
            {
                Light_Car light_car4 = new Light_Car("Грузовая машина", "Мустанг", 320);

            }
            catch(TestException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("-----------------------------------------------------");
            try
            {
                Speed_of_transport speed1 = new Speed_of_transport("Длинная машина", "Жигуль", 80);
            }
            catch(Speed_of_transportException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("У данной машины скорость равна" + ex.Value);
            }

            Console.WriteLine("---------------------------------------------------");

            try
            {
                int y = 0;
                int x = 600;
                Console.WriteLine(x / y);
            }

            catch(DivideByZeroException)
            {
                Console.WriteLine("Учили же в школе-НЕЛЬЗЯ ДЕЛИТЬ НА 0");
            }

            Console.WriteLine("--------------------------------------------------");

            /*y
            {
                Ip ip = new Ip();
                ip.Value = 0;
            }
            catch (MaskException ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            Console.WriteLine("--------------------------------------------------");
            try
            {
                int[] x = new int[3];
                Console.WriteLine(x[100]);

            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Умница");

            }


            Console.WriteLine("--------------------------------------------------");

            try
            {
                Testing.Method1();
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine($"Catch в Main(why) : {ex.Message}");
                Console.WriteLine($"Catch в Main(where) : {ex.TargetSite}");
                Console.WriteLine($"Catch в Main(how to) : {ex.HelpLink}");

            }
            finally
            {
                Console.WriteLine("Умница");
            }

            Console.WriteLine(sqrt(9));
            try
            {
                Console.WriteLine(sqrt(-9));
            }
            catch (AssertException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static int sqrt(int num)
        {
            Assert(num < 0);
            int rez = 0;
            while (rez * rez != num)
            {
                rez++;
            }

            return (rez);
        }

        private static void Assert(bool v)
        {
            if (v)
                throw new AssertException("Недопустимо");
        }
    }
    class Testing
    {
        public static void Method1()
        {
            try
            {
                Method2();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Catch в Method1 : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally в Method1");
            }
        }
        static void Method2()
        {
            try
            {
                int x = 3000;
                int y = x / 0;
            }
            finally
            {
                Console.WriteLine("Блок finally в Method2");
            }
        }
    }



    /*
    interface IUps
    {
        void Break();
        void Sale();
    }
    static void Main(string[] args)
    {

        Car car = new Car(5689, 2009, 102);
        Console.WriteLine(car.ToString());
        Train train = new Train(562, 1992, 3);
        Console.WriteLine(train.ToString());
        Engine engine = new Engine(864318, 1998, 120, 2009);
        Console.WriteLine(engine.ToString());
        Express express = new Express(879, 2020, 6, 360);
        Console.WriteLine(express.ToString());
        express.Death();
        Carriage carriage = new Carriage(622, 1980, 3, 50, 250);
        Console.WriteLine(carriage.ToString());
    }*/

    class Ip
    {
        public int Value
        {
            get { return Value; }
            set
            {
                if (value == 0)
                    throw new MaskException("Ip не может быть нулевым");
            }
        }
    }



    sealed partial class Speed_of_transport
    {
        public void Next()
        {
            sp += 100;
        }
    }

    public class Cars
    {
        public List<object> ts = new System.Collections.Generic.List<object>();

        public void GetTrans(string tr)
        {
            foreach (Company v in ts)
            {
                if (v._cars_company == tr)
                    Console.WriteLine(v._cars_company);
            }
        }

        public void GetValue()
        {
            Console.WriteLine(ts.Count);

        }

        public void GetSpeed(int num)
        {
            string buf;
            for (int i = 0; i < ts.Count; i++)
            {
                buf = Convert.ToString(ts[i]);
                if (buf.Contains(Convert.ToString(num)))
                {
                    Console.WriteLine(buf);
                }
            }

        }
    }

    public class Controller
    {
        public void GetTrans(string tr, Cars cars)
        {
            foreach (Company v in cars.ts)
            {
                if (v._cars_company == tr)
                    Console.WriteLine(v._cars_company);
            }
            
        }

        public void GetValue(Cars cars)
        {
            Console.WriteLine(cars.ts.Count);
        }

        public void GetSpeed (int num, Cars cars)
        {
            string buf;
            for (int i = 0; i<cars.ts.Count; i++)
            {

                buf = Convert.ToString(cars.ts[i]);
                if (buf.Contains(Convert.ToString(num)))
                {
                    Console.WriteLine(buf);
                }
            }
        }
    }


}



