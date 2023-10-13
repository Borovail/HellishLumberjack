using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Interfaces
{
    public interface IPoolable
    {

        event EventHandler<IPoolable> OnObjectDeactivation;
        public GameObject GetGameObject();

        void ObjectDeactivation();
    }
}
