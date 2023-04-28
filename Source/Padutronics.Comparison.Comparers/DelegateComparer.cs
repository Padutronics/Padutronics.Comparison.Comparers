using System;
using System.Collections.Generic;

namespace Padutronics.Comparison.Comparers;

public sealed class DelegateComparer<T> : IComparer<T>
{
    private readonly Func<T?, T?, int> compareMethod;

    public DelegateComparer(Func<T?, T?, int> compareMethod)
    {
        this.compareMethod = compareMethod;
    }

    public int Compare(T? x, T? y)
    {
        return compareMethod(x, y);
    }
}