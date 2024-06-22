using IdleNumbers.Engine;
using IdleNumbers.Numbers;

Console.WriteLine("Hello, World!");
//Test des calculs de nombres
var nbr1 = new ClassicNumber(17);
var nbr2 = new ClassicNumber(13);
var big = new BiggerNumber(5, 5);
var test = 100;
var nbr3 = OperationsFactory.Multiply(nbr1, nbr2);
Console.WriteLine(nbr3);
nbr3 = OperationsFactory.Multiply(nbr3, big);
Console.WriteLine(nbr3);