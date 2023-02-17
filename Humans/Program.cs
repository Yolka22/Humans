using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans
{



    internal class Program
    {
        public delegate int MathDelegate(int val1);

        public static int Prem(int val1)
        {
            return (val1*120)/100;
        }


        interface IInfo
        {
            void Info();

        }

        abstract public class Human : IInfo
        {

            protected Human(string name,int age) {
            
                Name = name;
                Age = age;

            }


            protected Human()
            {
                Console.WriteLine("Введите имя");
                Name = Console.ReadLine();
                Console.WriteLine("Введите возраст");
                Age = Convert.ToInt32(Console.ReadLine());

            }

            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private int age;

            public int Age
            {
                get { return age; }
                set { age = value; }
            }

            public abstract void Info();

        }


        class Boss : Human
        {
            private int experience;

            public int Experience
            {
                get { return experience; }
                set { experience = value; }
            }


            List<Worker> workers = new List<Worker>();

            public Boss(string name, int age, int expirience) : base(name, age)
            {

                Experience = expirience;
            }

            public override void Info()
            {

                Console.WriteLine("Имя босса " + Name);
                Console.WriteLine("Возраст " + Age);
                Console.WriteLine("Стаж " + Experience);

            }

            public void Show_Workers()
            {

                Console.WriteLine("Все работники под руководством " + Name);
                for (int i = 0; i < workers.Count; i++)
                {
                    workers[i].Info();
                }
            }

            public void Add()
            {
                string choose;
                Console.WriteLine("Какого работника хотите добавить? Coder,Project Manager");
                choose = Console.ReadLine();

                choose = choose.ToLower();

                switch (choose)
                {

                    case "coder":

                        Coder coder = new Coder();
                        workers.Add(coder);

                        break;


                    case "project manager":

                        Project_Manager manager = new Project_Manager();
                        workers.Add(manager);
                        break;


                }

                

        }


            public void Set_Prem()
            {
                MathDelegate prem = Prem;
                string name;
                Console.WriteLine("введите имя кому начислить премию");
                name = Console.ReadLine();

                for (int i = 0; i < workers.Count; i++)
                {
                    if (workers[i].Name==name)
                    {
                        workers[i].Salary = prem(workers[i].Salary);
                    }
                }

                
                

            }

}


        public class Worker : Human
        {
            private string sphere;

            public string Sphere
            {
                get { return sphere; }
                set { sphere = value; }
            }


            private int salary;

            public int Salary
            {
                get { return salary; }
                set { salary = value; }
            }


            public Worker(string name, int age, string sphere) : base(name, age)
            {
                Sphere = sphere;

            }

            public Worker() : base()
            {
                Console.WriteLine("Введите зарплату");
                Salary = Convert.ToInt32(Console.ReadLine());
            }

            public override void Info()
            {

                Console.WriteLine("Имя " + Name);
                Console.WriteLine("Возрвст " + Age);
                Console.WriteLine("Сфера деятельности " + Sphere);
                Console.WriteLine("Зарплата " + Salary);

            }

            public static bool operator ==(Worker obj1, Worker obj2)
            {
                if (obj1.Sphere==obj2.Sphere)
                {
                    return true;
                }

                return false;
            }

            public static bool operator !=(Worker obj1, Worker obj2)
            {
                if (obj1.Sphere != obj2.Sphere)
                {
                    return true;
                }

                return false;
            }


        }



        class Coder : Worker
        {
            public Coder() : base() {

                Sphere = "Coder";

            }
        }

        class Project_Manager : Worker
        {
            public Project_Manager() : base()
            {

                Sphere = "Project_Manager";

            }
        }


        


        static void Main(string[] args)
        {

            Boss boss = new Boss("Tom",32,4);

            boss.Add();
            boss.Add();
            boss.Info();
            boss.Show_Workers();
            boss.Set_Prem();
            boss.Show_Workers();

            Console.ReadLine();
        }
    }
}
