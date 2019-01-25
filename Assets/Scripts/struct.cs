namespace HomeGod.Struct
{
[System.Serializable]
    public struct GasComposition
    {
        public float hydrogen;
        public float oxygen;
        public float carbon;

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

    }
}