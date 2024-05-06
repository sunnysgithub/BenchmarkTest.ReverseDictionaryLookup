using BenchmarkDotNet.Attributes;

namespace BenchmarkTest.ReverseDictionaryLookup;

[MemoryDiagnoser]
public class ReverseDictionaryLookup
{
    private Dictionary<string, string> _dictionary = [];

    [Params(10000, 100000)] 
    public int _size;

    public string _k = string.Empty;
    public string _v = string.Empty;
    
    [GlobalSetup]
    public void Setup()
    {
        int halfsize = _size / 2;
        
        string k = string.Empty;
        string v = string.Empty;
        
        for (int i = 0; i < _size; i++)
        {
            k = Guid.NewGuid().ToString("N");
            v = Guid.NewGuid().ToString("N");
            _dictionary.TryAdd(k,v);

            if (i == halfsize)
            {
                _k = k;
                _v = v;
            }
        }
        
    }
    
    [Benchmark]
    public string? ReverseDictionary()
    {
        var reverseDictionary = new Dictionary<string, string>();
        
        foreach (var keyValuePair in _dictionary)
        {
            reverseDictionary.TryAdd(keyValuePair.Value, keyValuePair.Key);
        }
        
        reverseDictionary.TryGetValue(_v, out string key);

        return key;
    }
    
    [Benchmark]
    public string? ReverseLookup()
    {
        var reverseLookup = _dictionary.ToLookup(x => x.Value, x => x.Key);

        return reverseLookup[_v].FirstOrDefault();
    }
    
    [Benchmark]
    public string? IterateThroughKeyValuePairs()
    {
        foreach (var keyValuePair in _dictionary)
        {
            if (keyValuePair.Value == _v)
            {
                return keyValuePair.Key;
            }
        }

        return default;
    }
    
    [Benchmark]
    public string? IterateThroughKeys()
    {
        foreach (var key in _dictionary.Keys)
        {
            if (_dictionary[key] == _v)
            {
                return key;
            }
        }

        return default;
    }
}