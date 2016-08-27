using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctuckz.NedDo.Core
{
    public abstract class Builder<T>
    {
        protected Builder()
        {
        }

        public virtual void OnBeforeBuild()
        {
        }

        public virtual void OnAfterBuild()
        {
        }

        public T Build()
        {
            OnBeforeBuild();
            T obj = CreateObject();
            OnAfterBuild();
            return obj;
        }

        protected abstract T CreateObject();
    }
}
