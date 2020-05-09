using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Class_12
{
    class Catv1 : Animalv1
    {
        public void Print()
        {
            Console.WriteLine("I am a cat!");
        }
    }

    // override kulcsszó a leszármazott metódusán, ezzel jelezve, hogy felülírja
    class Catv2 : Animalv2
    {
        public override void Print()
        {
            Console.WriteLine("I am a cat!");
        }
    }
}
