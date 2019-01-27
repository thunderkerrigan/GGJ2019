using UnityEngine;

namespace HomeGod.Interface
{
    public interface IConsummable {
        void lifeCycling();
        void populate(Species newSpecies);
    }
    
    public interface IClickable {
        void onClick();
    }
}