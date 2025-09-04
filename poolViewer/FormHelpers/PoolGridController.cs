using poolViewer.UnsafePoolHandling;

namespace poolViewer.FormHelpers;

internal class PoolGridController
{
    private readonly List<PoolTagInfo> _display = [];
    private Dictionary<(string Tag, PoolType Type), uint> _currentDiffs = new();
    private Dictionary<(string Tag, PoolType Type), uint> _previousDiffs = new();
    private readonly Dictionary<string, Comparison<PoolTagInfo>> _comparer = new()
    {
        [nameof(PoolTagInfo.Tag)]         = (a, b) => string.CompareOrdinal(a.Tag, b.Tag),
        [nameof(PoolTagInfo.Type)]        = (a, b) => a.Type.CompareTo(b.Type),
        [nameof(PoolTagInfo.Allocs)]      = (a, b) => a.Allocs.CompareTo(b.Allocs),
        [nameof(PoolTagInfo.Frees)]       = (a, b) => a.Frees.CompareTo(b.Frees),
        [nameof(PoolTagInfo.Diff)]        = (a, b) => a.Diff.CompareTo(b.Diff),
        [nameof(PoolTagInfo.Bytes)]       = (a, b) => a.Bytes.CompareTo(b.Bytes),
        [nameof(PoolTagInfo.KB)]          = (a, b) => a.KB.CompareTo(b.KB),
        [nameof(PoolTagInfo.B_Alloc)]     = (a, b) => a.B_Alloc.CompareTo(b.B_Alloc),
        [nameof(PoolTagInfo.Source)]      = (a, b) => string.CompareOrdinal(a.Source, b.Source),
        [nameof(PoolTagInfo.Description)] = (a, b) => string.CompareOrdinal(a.Description, b.Description)
    };
    
    // Sorting state per column (property name)
    private readonly Dictionary<string, SortOrder> _columnSortStates = new()
    {
        [nameof(PoolTagInfo.Tag)]         = SortOrder.None,
        [nameof(PoolTagInfo.Type)]        = SortOrder.None,
        [nameof(PoolTagInfo.Allocs)]      = SortOrder.None,
        [nameof(PoolTagInfo.Frees)]       = SortOrder.None,
        [nameof(PoolTagInfo.Diff)]        = SortOrder.None,
        [nameof(PoolTagInfo.Bytes)]       = SortOrder.None,
        [nameof(PoolTagInfo.KB)]          = SortOrder.None,
        [nameof(PoolTagInfo.B_Alloc)]     = SortOrder.None,
        [nameof(PoolTagInfo.Source)]      = SortOrder.None,
        [nameof(PoolTagInfo.Description)] = SortOrder.None
    };

    private readonly PoolDataHandler _poolDataHandler;
    
    public IReadOnlyList<PoolTagInfo> Display => _display;
    
    public PoolGridController(PoolDataHandler poolDataHandler)
    {
        ArgumentNullException.ThrowIfNull(poolDataHandler);
        _poolDataHandler = poolDataHandler;
        // To have data ready.
        UpdateGrid();
    }
    
    public object? GetCellValue(int rowIndex, string columnProperty)
    {
        if (rowIndex < 0 || rowIndex >= _display.Count) return null;
        var item = _display[rowIndex];
        // Map column name to value
        object? value = columnProperty switch
        {
            nameof(PoolTagInfo.Tag)         => item.Tag,
            nameof(PoolTagInfo.Type)        => item.Type,
            nameof(PoolTagInfo.Allocs)      => item.Allocs,
            nameof(PoolTagInfo.Frees)       => item.Frees,
            nameof(PoolTagInfo.Diff)        => item.Diff,
            nameof(PoolTagInfo.Bytes)       => item.Bytes,
            nameof(PoolTagInfo.KB)          => item.KB,
            nameof(PoolTagInfo.B_Alloc)     => item.B_Alloc,
            nameof(PoolTagInfo.Source)      => item.Source,
            nameof(PoolTagInfo.Description) => item.Description,
            _ => null
        };
        
        return value;
    }

    public Color? GetCellColor(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= _display.Count) return null;
        var info = _display[rowIndex];
        return info.Change switch
        {
            ChangeType.Increased => Color.LightGreen,
            ChangeType.Decreased => Color.LightCoral,
            _ => Color.White
        };
    }

    public void UpdateGrid()
    {
        _poolDataHandler.RefreshPoolInfo();
        
        var prev = _previousDiffs;
        var curr = _currentDiffs;

        _currentDiffs.Clear();
        _currentDiffs.EnsureCapacity(_poolDataHandler.PoolTags.Count);

        _display.Clear();
        var src = _poolDataHandler.PoolTags;
        for (int i = 0; i < src.Count; i++)
        {
            var item = src[i];
            var key = (item.Tag, item.Type);

            if (prev.TryGetValue(key, out var prevDiff))
            {
                item.Change = item.Diff > prevDiff
                    ? ChangeType.Increased
                    : item.Diff < prevDiff
                        ? ChangeType.Decreased
                        : ChangeType.None;
            }
            else
            {
                item.Change = ChangeType.None;
            }

            curr[key] = item.Diff;
            _display.Add(item);
        }
        
        _previousDiffs = curr;
        _currentDiffs = prev;

        ApplyActiveSort();
    }
    
    // Toggle sort state for a column; returns new state
    public SortOrder ToggleSort(string columnProperty)
    {
        if (!_columnSortStates.TryGetValue(columnProperty, out var state))
            throw new InvalidOperationException($"Column {columnProperty} not found");
        state = state switch
        {
            SortOrder.None => SortOrder.Ascending,
            SortOrder.Ascending => SortOrder.Descending,
            SortOrder.Descending => SortOrder.None,
            _ => state
        };

        // Clear other columns when a new one becomes active (simple single-column sort model)
        if (state != SortOrder.None)
        {
            foreach (var key in _columnSortStates.Keys)
            {
                _columnSortStates[key] = SortOrder.None;
            }
        }
        
        _columnSortStates[columnProperty] = state;
        
        if (state == SortOrder.None)
        {
            // Rebuild natural order (current underlying order from handler)
            _display.Clear();
            _display.AddRange(_poolDataHandler.PoolTags);
        }
        else
        {
            ApplySort(columnProperty, state);
        }
        return state;
    }

    public SortOrder GetSortState(string columnProperty) => _columnSortStates.GetValueOrDefault(columnProperty, SortOrder.None);

    private void ApplyActiveSort()
    {
        var active = _columnSortStates.FirstOrDefault(kv => kv.Value != SortOrder.None);
        if (!string.IsNullOrEmpty(active.Key))
        {
            ApplySort(active.Key, active.Value);
        }
    }

    private void ApplySort(string columnName, SortOrder order)
    {
        if (order == SortOrder.None)
        {
            // Rebuild list in natural order (current underlying order from handler)
            _display.Clear();
            _display.AddRange(_poolDataHandler.PoolTags);
            return;
        }

        if (!_comparer.TryGetValue(columnName, out var comparison))
            throw new InvalidOperationException($"Column {columnName} not found");

        _display.Sort(comparison);
        if (order == SortOrder.Descending) _display.Reverse();
    }
}