
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBattle.PointWar.Server.Interfaces
{
    public interface ICodeBattle<T>
    {
        T Create(T player);
        T Get(int id);
        List<T> Get();
        void Update(int id ,T player);
        void Remove(T player);
        void Remove(int ID);
    }
}
