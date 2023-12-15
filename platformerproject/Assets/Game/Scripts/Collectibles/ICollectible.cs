using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface är en C# klass som fungerar som ett sorts kontrakt som andra klasser kan följa för att säkerställa att de tillhandahåller en viss funktionalitet.
//Detta är bra att utnyttja när man har många collectibles, som i vårt fall coins, health pick up.
//Interfaces kan bara utföras som public och är oftast tomma för att man använder funktionaliteten i andra scripts som ärver interfacet.
public interface ICollectible
{
        void Collect();
}
