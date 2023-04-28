using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Padutronics.Comparison.Comparers;

public sealed class DelegateEqualityComparer<T> : IEqualityComparer<T>
{
    private static readonly Func<T, int> DefaultGetHashCodeMethod = @object => HashCode.Combine(@object);

    private readonly Func<T?, T?, bool> equalsMethod;
    private readonly Func<T, int> getHashCodeMethod;

    public DelegateEqualityComparer(Func<T?, T?, bool> equalsMethod) :
        this(equalsMethod, DefaultGetHashCodeMethod)
    {
    }

    public DelegateEqualityComparer(Func<T?, T?, bool> equalsMethod, Func<T, int> getHashCodeMethod)
    {
        this.equalsMethod = equalsMethod;
        this.getHashCodeMethod = getHashCodeMethod;
    }

    public bool Equals(T? x, T? y)
    {
        return equalsMethod(x, y);
    }

    public int GetHashCode([DisallowNull] T obj)
    {
        return getHashCodeMethod(obj);
    }
}