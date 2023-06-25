using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern.Interfaces
{
    public interface IObject
    {
        ISubject Subject { get; set; }
        void Update();
    }
}
