using static System.Math;
using System.Linq;

var unsorted = Sorting.RandomNumbers();
Console.WriteLine("Before");
unsorted.Output();

var sorted = unsorted.Quicksort();
Console.WriteLine("After");
sorted.Output();


static class Sorting
{
  public static IEnumerable<int> Quicksort(this IEnumerable<int> list)
  {
    if (!list.Any()) return new List<int>();

    var pivot = list.First();
    var remaining = list.Skip(1);

    var less = remaining.Where(x => x <= pivot);
    var more = remaining.Where(x => x > pivot);

    return less.Quicksort()
      .Concat(new List<int> { pivot })
      .Concat(more.Quicksort());
  }

  public static IEnumerable<int> RandomNumbers()
  {
    var rand = new Random();
    return Enumerable.Range(1, 5)
      .Select(x => rand.Next(20))
      .ToList();
  }

  public static void Output(this IEnumerable<int> self)
  {
    foreach (var item in self)
    {
      Console.Write($"{item} ");
    }
    Console.WriteLine();
  }
}