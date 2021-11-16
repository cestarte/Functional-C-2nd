Func<int, int, int> divideClunky = (x, y) => x / y;
var divideStreamlined = (int x, int y) => x / y;

Console.WriteLine($"Clunky 10 / 2 = {divideClunky(10, 2)}");
Console.WriteLine($"Streamlined 10 / 2 = {divideStreamlined(10, 2)}");