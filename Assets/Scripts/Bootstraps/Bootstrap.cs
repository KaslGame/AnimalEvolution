using System.Collections;
using UnityEngine;

namespace Bootstraps
{
    public abstract class Bootstrap : MonoBehaviour
    {
        public abstract IEnumerator Load();
    }
}
