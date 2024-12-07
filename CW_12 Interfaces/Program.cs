using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_12_Interfaces
{
    //interface IExample
    //{
    //    int Number { get; }
    //    int Salary { get; set; }
    //    string Text { get; }

    //    string this[int index] { get; }
    //}
    //class ExempleClass : IExample
    //{
    //    public int Number { get; }
    //    public int Salary { get; set; }
    //    public string Text { get; }
    //    public string this[int index]
    //    {
    //        get
    //        {
    //            return "index here";
    //        }
    //    }
    //}

    // inheriting interfaces
    //interface IA
    //{
    //    string A1(int n);
    //}

    //interface IB
    //{
    //    int B1(int n);
    //    void B2();
    //}

    //interface IC : IA, IB
    //{
    //    void C1(int n);
    //}

    //class InherInterface : IC
    //{
    //    public string A1(int n)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int B1(int n)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void B2()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void C1(int n)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //
    //interface IA
    //{
    //    void Show();
    //}
    //interface IB    
    //{
    //    void Show();
    //}
    //interface IC
    //{ 
    //    void Show(); 
    //}
    //class ExplicitRealization : IA, IB, IC
    //{
    //    void IA.Show()
    //    {
    //        Console.WriteLine("Interface IA");
    //    }
    //    void IB.Show()
    //    {
    //        Console.WriteLine("Interface IB");
    //    }
    //    public void Show()
    //    {
    //        Console.WriteLine("Interface IC");
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        ExplicitRealization exemple = new ExplicitRealization();
    //        exemple.Show();//IC

    //        (exemple as IA).Show();//IA

    //        IB ib = new ExplicitRealization();
    //        ib.Show(); // IB


    //        Console.ReadKey();
    //    }
    //}


    class Percon :IComparable, ICloneable
    {
        public string name { get; set; }
        public int age { get; set; }
        public Passport  Passport { get; set; }

        public object Clone()
        {
            // return MemberwiseClone();

            Percon temp = MemberwiseClone() as Percon;
            temp.Passport = new Passport { number = Passport.number, series = Passport.series };
            temp.Passport = Passport.Clone() as Passport;
            return temp;
        }

        public int CompareTo(object obj)
        {
            if (obj is Percon percon)
            {
                return age.CompareTo(percon.age);
            }
            throw new ArgumentException();
        }

        public override string ToString()
        {
            return $"{name} {age} {Passport}";
        }
    }

    class Passport : ICloneable
    {
        public int number { get; set; }
        public string series { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{series} {number}";
        }
    }

    class Room : IEnumerable
    {
        private Percon[] _people;
        public Room()
        {
            _people = new Percon[]
            {
                new Percon {name = "Bob", age = 34, Passport = new Passport{number = 824578, series = "KB"} },
                new Percon {name = "Jane", age = 20, Passport = new Passport{number = 968574, series = "HQ"} },
                new Percon {name = "Jimmy", age = 56, Passport = new Passport{number = 142536, series = "SE"} },
                new Percon {name = "Bill", age = 18, Passport = new Passport{number = 586532, series = "AJ"} }
            };
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //public IEnumerator GetEnumerator()
        //{
        //    return _people.GetEnumerator();
    

        public void Sort()
        {
            Array.Sort(_people);
        }

        public void Sort(IComparer comparer)
        {
            Array.Sort(_people, comparer);
        }
    }
    class ArrayClass: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            IEnumerator enumerator = new MyEnumerator();
            return enumerator;
        }
    }

    internal class MyEnumerator : IEnumerator
    {
        public object Current { get; }
        public bool MoveNext()
        {
            throw new NotImplementedException();
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Room room = new Room();

            //room.Sort();
            //foreach (Percon item in room)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine();

            //IComparer comparer = new NameComparer();
            //room.Sort(comparer);

            //room.Sort(new NameComparer());

            //foreach (Percon item in room)
            //{
            //    Console.WriteLine(item);
            //}

            Percon p1 = new Percon 
            { 
                name = "Jane", 
                age = 20, 
                Passport = new Passport { number = 968574, series = "HQ" }  
            };

            Percon p2 = p1.Clone() as Percon;

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            p2.name = "QQQ";
            p2.age = 99;
            p2.Passport.number = 111111;
            p2.Passport.series = "AA";

            Console.WriteLine(p1);
            Console.WriteLine(p2);



            Console.ReadKey();
        }
    }

    internal class NameComparer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            if (x is Percon p1 && y is Percon p2)
            {
                // return p1.name.CompareTo(p2.name);
                return string.Compare(p1.name,p2.name);
            }
            throw new NotImplementedException();
        }
    }
}
