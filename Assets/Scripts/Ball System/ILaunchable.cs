using UnityEngine;
namespace Ball
{
    public interface ILaunchable
    {
        void Launch(Vector3 force);
    }
}