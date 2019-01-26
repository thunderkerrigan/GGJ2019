using System;

namespace HomeGod.Struct
{
    [System.Serializable]
    public struct GasComposition
    {
        public float hydrogen;
        public float oxygen;
        public float carbon;
        public static GasComposition operator +(GasComposition c1, GasComposition c2)
        {
            GasComposition addedGasComposition = new GasComposition();
            float newHydrogen = Math.Max(0,c1.hydrogen + c2.hydrogen);
            float newOxygen = Math.Max(0,c1.oxygen + c2.oxygen);
            float newCarbon = Math.Max(0,c1.carbon + c2.carbon);
            float totalGas = newCarbon + newOxygen + newHydrogen;
            addedGasComposition.hydrogen = newHydrogen*100f/totalGas;
            addedGasComposition.oxygen = newOxygen*100f/totalGas;
            addedGasComposition.carbon = newCarbon*100f/totalGas;
            return addedGasComposition;
        }
        public override string ToString()
        {
            return "GAS:\nHydrogen: " + this.hydrogen + " %\nOxygen: " + this.oxygen + "%\ncarbon: " + this.carbon + "%\n";
        }
    }
    [System.Serializable]
    public struct EnvironmentComposition
    {
        public float water;
        public float gas;
        public float earth;

    }
    [System.Serializable]
    public struct ResourcesComposition
    {
        public EnvironmentComposition environment;
        public GasComposition gases;
        public float naturalResources;

        public static ResourcesComposition operator +(ResourcesComposition c1, ResourcesComposition c2)
        {
            ResourcesComposition newResourcesComposition = new ResourcesComposition();
            newResourcesComposition.environment = c1.environment;
            newResourcesComposition.gases = c1.gases + c2.gases;
            newResourcesComposition.naturalResources = (c1.naturalResources + c2.naturalResources)*1f;
            return newResourcesComposition;
        }
        public override string ToString()
        {
            return "Natural Resources: " + this.naturalResources + " %\n" + this.gases.ToString();
        }
    }
}