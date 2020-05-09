using System;
using System.Collections.Generic;

namespace CSharp_Class_12
{
    class Program
    {
        static void Main(string[] args)
        {
            // Előfordulhat, hogy nem szeretnénk, hogy valaki leszármazzon az osztályunkból
            // Ilyenkor egyszerűen használhatjuk a sealed kulcsszót
            // Lásd: Examplev1 és Examplev2

            //--------------------------------------------------

            // Mi történik, ha ezt csinálom?
            Animalv1 animal1 = new Animalv1();
            animal1.Print(); // Azt írja ki, hogy "I am an animal!"

            // És most?
            Dogv1 dog1 = new Dogv1();
            dog1.Print(); // Azt írja ki, hogy "I am a dog!"

            // Na és most? Animal vagy dog?
            Animalv1 animal2 = new Dogv1();
            animal2.Print(); // Azt írja ki, hogy "I am an animal!"

            // Miért tehetjük meg azt, hogy egy Dog-ot egy Animal típusú változóba teszünk és miért írja ki ezt?

            // Az első kérdésre a válasz az, hogy a Dog egy Animal is, hiszen a memóriában egy Dog példánynak van Animal része
            // Ammikor egy Dog példányt egy Animal típusú változóba teszünk, akkor lényegében annyi történik, hogy a Dog részét a példánynak "letakarjuk" (attól még ott van)
            // Bizonyíték:
            //animal2.DogMethod(); // Nem megy

            // Miért animalt ír és nem dog-ot?
            // Mivel letakartuk a Dog-ot, ezért az Animal Print-je hívódik!

            // Innentől érdemes beszélni arról, hogy az osztályok példányainak van statikus és dinamikus típusa!
            // Statikus típus az amit fordításidőben, azaz a kód írása közben látsz a példányból! (leegyszerűsítve ~ a változó létrehozásakor az egyenlőség bal oldala)
            // Tehát az animal2 statikus típusa Animalv1, hiszen ezt látjuk belőle
            // Dinamikus típus az amit futásidőben, azaz a kód futtatása közben látsz a példányból! (leegyszerűsítve ~ a változó létehozásakor az egyenlőség jobb oldala)
            // Tehát az animal2 statikus típusa Dogv1, hiszen ezt látjuk belőle futásidőben
            // Hogyan láthatjuk, hogy tényleg ez a dinamikus típusa? Tegyünk egy töréspontot a változó létrehozása után és nézzük meg mit ír a típusára! Az lesz, hogy Dogv1!

            //--------------------------------------------------

            // Rendben, de most rosszul működik a kutya! Jó lenne ha kutya létére úgy is viselkedne, függetlenül attól, hogy állatként kezeljük!
            // Hiszen gondoljunk bele a következő helyzetbe:

            // Az állatainkat szeretnénk egy listában kezelni, majd végigjárni a listát és meghívni az adott állat megfelelő metódusát
            // A probléma csak az, hogy mivel a kutya és a macska is egy Animalv1 listában van, ezért Animalv1-ként lesznek kezelve, tehát rossz metódus lesz meghívva
            var animals1 = new List<Animalv1>();
            animals1.Add(new Dogv1());
            animals1.Add(new Catv1());

            foreach (var animal in animals1)
            {
               animal.Print();
            }

            // Hogyan javíthatnánk ezt ki?
            // Használjunk polimorfizmust (~több alakúság)
            // Jelöljük meg az ősosztélyban a metódust a virtual kulcsszóval, ezzel jelezzük, hogy ezt a metódust bizony felülírhatják a gyerekek
            // Majd a leszármazottakban az override kulcsszó segítségével jelöljük, hogy felülírjuk a szülő metódusát:
            Animalv2 animal3 = new Dogv2();
            animal3.Print(); // Mostmár az elvárt eredményt írja ki!

            //--------------------------------------------------

            // virtual és override nélkül úgynevezett elrejtés (hide) történik, azaz a leszármazott elrejti az ősosztály metódusát
            // Ezt egyébként a Visual Studio is jelzi nekünk, mivel az elrejtés egy ritkán alkalmazott technika
            // Ha szeretnénk jelezni a Visual Studio felé, hogy a rejtés szándékos, akkor a new kulcsszóval ezt jelezhetjük a leszármazott metódusánál:
            // Lásd: Animalv3 és Dogv3

            // Fontos megjegyezni, hogy a new kulcsszó nem változtat a működésen!

            // Miért ne legyen minden metódus virtual?
            // A működése miatt a virtuális metódusok meghívása lassabb, ezért tényleg csak olyan esetekben alkalmazzuk, amikor szükség van rá

            //--------------------------------------------------

            // Mi van akkor ha meg szeretnénk hívni az ősosztály metódusát a leszármazottban, hiába írtuk felül?
            // Használjuk a base kulcsszót:
            Animalv4 animal4 = new Dogv4();
            animal4.Print();

            //--------------------------------------------------

            // Az imént láttuk, hogy egy kollekcióba elhelyezhetjük a gyerekeket is!
            var animals2 = new List<Animalv2>();
            animals2.Add(new Dogv2());
            animals2.Add(new Catv2());

            foreach (var animal in animals2)
            {
                animal.Print();
            }

            // Ezt hívjuk heterogén kollekciónak!

            // Más módon is hasznosíthatjuk a polimorfizmust! Például:
            // Vannak formáink! Szeretnénk egy olyan metódust amely két formáról megmondja, hogy melyiknek nagyobb a területe!
            // Ahelyett, hogy minden forma kombinációra készítünk egy metódust, immáron nyugodtan készíthetünk egyetlen metódust amely két forma ősosztályt vesz át!
            // Így egyetlen metódussal az összes formát lefedhetjük, hiszen a polimorfizmus miatt a megfelelő terület számító metódus fog meghívódni:
            var biggerShape = WhichOneIsBigger(new Rectangle(2, 3), new Circle(2));

            //--------------------------------------------------

            // Ha a metódusok lehetnek virtuálisak, akkor a tulajdonságok is?
            // Természetesen, viszont figyeljünk arra, hogy csak a teljes tulajdonság lehet virtual! A getter vagy setter külön nem!
            // Lásd: Examplev3 és Examplev4
        }

        static Shape WhichOneIsBigger(Shape shape1, Shape shape2)
        {
            return shape1.CalculateArea() >= shape2.CalculateArea() ? shape1 : shape2;
        }
    }
}
