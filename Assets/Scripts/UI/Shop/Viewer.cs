using System;
using System.Collections.Generic;

public class Viewer<T>
{
    private readonly List<T> _items;

    private int _currentIndex;

    public Viewer(List<T> items)
    {
        _items = items ?? throw new ArgumentNullException(nameof(items));
    }

    public T GetNextItem()
    {
        _currentIndex++;

        if (_currentIndex > _items.Count - 1)
            _currentIndex = 0;

        return _items[_currentIndex];
    }

    public T GetPreviosItem()
    {
        _currentIndex--;

        if (_currentIndex < 0)
            _currentIndex = _items.Count - 1;

        return _items[_currentIndex];
    }
}
