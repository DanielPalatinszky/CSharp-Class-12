using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Class_12
{
    // sealed: megtiltja, hogy leszármazzanak belőle
    sealed class Examplev1
    {
    }

    // Nem megy
    /*class Examplev2 : Examplev1
    {

    }*/

    // virtual tulajdonság
    class Examplev3
    {
        public virtual int Test { get; set; }
    }

    // override-olt tulajdonság
    class Examplev4 : Examplev3
    {
        public override int Test { get => base.Test; set => base.Test = value; }
    }
}
