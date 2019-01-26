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
            addedGasComposition.hydrogen = c1.hydrogen + c2.hydrogen;
            addedGasComposition.oxygen = c1.oxygen + c2.oxygen;
            addedGasComposition.carbon = c1.carbon + c2.carbon;
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
            newResourcesComposition.naturalResources = c1.naturalResources + c2.naturalResources;
            return newResourcesComposition;
        }
        public override string ToString()
        {
            return "Natural Resources: " + this.naturalResources + " %\n" + this.gases.ToString();
        }
    }
}