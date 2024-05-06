# Reverse Dictionary Lookup

A simple benchmark test to compare the different types of reverse looking up a dictionary

## Run

```
    $ dotnet run -p BenchmarkTest.ReverseDictionaryLookup.csproj -c Release
```

## Results

| Method                      | _size  | Mean         | Error      | StdDev     | Gen0      | Gen1      | Gen2     | Allocated  |
|---------------------------- |------- |-------------:|-----------:|-----------:|----------:|----------:|---------:|-----------:|
| ReverseDictionary           | 10000  |  1,165.64 us |  11.772 us |  10.436 us |  515.6250 |  515.6250 | 193.3594 |   942175 B |
| ReverseLookup               | 10000  |  3,159.54 us |  62.604 us |  93.703 us |  242.1875 |  117.1875 |  66.4063 |  1142447 B |
| IterateThroughKeyValuePairs | 10000  |     24.67 us |   0.273 us |   0.242 us |         - |         - |        - |          - |
| IterateThroughKeys          | 10000  |    190.01 us |   3.201 us |   2.994 us |         - |         - |        - |          - |
| ReverseDictionary           | 100000 |  8,608.89 us | 157.604 us | 147.423 us |  671.8750 |  578.1250 | 500.0000 |  8453382 B |
| ReverseLookup               | 100000 | 46,091.24 us | 897.563 us | 960.382 us | 1916.6667 | 1000.0000 | 500.0000 | 10897890 B |
| IterateThroughKeyValuePairs | 100000 |    557.00 us |   8.914 us |   8.338 us |         - |         - |        - |        1 B |
| IterateThroughKeys          | 100000 |  2,763.60 us |  50.595 us |  44.852 us |         - |         - |        - |        3 B |

## Lesson Learned

Iterate through KeyValuePairs