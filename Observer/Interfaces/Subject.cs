using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern.Interfaces
{
    public interface ISubject
    {
        int State { get; }
        void Subscribe(IObject observer);

        void Unsubscribe(IObject observer);

        void Notify();
    }
}
