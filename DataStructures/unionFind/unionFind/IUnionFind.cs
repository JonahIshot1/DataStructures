using System;
using System.Collections.Generic;
using System.Text;

namespace unionFind
{
    interface IUnionFind<T>
    {
        // Returns the set that p belongs to
        int Find(T p);

        // Connects p and q — returns true if successful, false otherwise
        bool Union(T p, T q);

        // Returns true if p and q are connected, false otherwise
        bool AreConnected(T p, T q);
    }
}
