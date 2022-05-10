
using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicAPI
    {
        public static LogicAPI CreateAPI(DataAbstractAPI dataAbstractAPI = default(DataAbstractAPI))
        {
            return new Box(dataAbstractAPI);
        }

    }
}