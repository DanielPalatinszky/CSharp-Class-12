using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Class_12
{
    class Dogv1 : Animalv1
    {
        public void Print()
        {
            Console.WriteLine("I am a dog!");
        }

        public void DogMethod()
        {

        }
    }

    // override kulcsszó a leszármazott metódusán, ezzel jelezve, hogy felülírja
    class Dogv2 : Animalv2
    {
        public override void Print()
        {
            Console.WriteLine("I am a dog!");
        }

        public void DogMethod()
        {

        }
    }

    // A new kulcsszóval jelezzük, hogy szándékos az elrejtés
    class Dogv3 : Animalv3
    {
        public new void Print()
        {

        }
    }

    // A base kulcsszó segítségével meghívhatjuk az ős metódusát is
    class Dogv4 : Animalv4
    {
        public override void Print()
        {
            base.Print();

            Console.WriteLine("I am a dog!");
        }
    }
}
