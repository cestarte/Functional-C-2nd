Product p = new(false);
Order o = new(10, p);
Address a = new("jp");
Console.WriteLine(Vat(a, o));

UsAddress usa = new("ma");
Console.WriteLine(Vat(usa, o));

static decimal Vat(Address address, Order order)
   => address switch
   {
     UsAddress(var state) => VatByRate(RateByState(state), order),
     ("de") _ => DeVat(order),
     (var country) _ => VatByRate(RateByCountry(country), order),
   };


static decimal VatByRate(decimal rate, Order order)
   => order.NetPrice * rate;

static decimal DeVat(Order order)
   => order.NetPrice * (order.Product.IsFood ? 0.08m : 0.2m);

static decimal RateByCountry(string country)
   => country switch
   {
     "it" => 0.22m,
     "jp" => 0.08m,
     _ => throw new ArgumentException($"Missing rate for {country}")
   };

static decimal RateByState(string state)
   => state switch
   {
     "ca" => 0.1m,
     "ma" => 0.0625m,
     "ny" => 0.085m,
     _ => throw new ArgumentException($"Missing rate for {state}")
   };

record Product(bool IsFood);
record Order(decimal NetPrice, Product Product);
record Address(string Country);
record UsAddress(string State) : Address("us");


