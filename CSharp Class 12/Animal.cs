using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Class_12
{
    class Animalv1
    {
        public void Print()
        {
            Console.WriteLine("I am an animal!");
        }
    }

    // virtual kulcsszó az ös metódusán, ezzel jelezve, hogy a leszármazott felülírhatja
    class Animalv2
    {
        public virtual void Print()
        {
            Console.WriteLine("I am an animal!");
        }
    }

    class Animalv3
    {
        public void Print()
        {

        }
    }

    class Animalv4
    {
        public virtual void Print()
        {
            Console.WriteLine("I am an animal!");
        }
    }
}
