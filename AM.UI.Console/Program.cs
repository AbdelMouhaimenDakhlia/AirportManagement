// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;



/*Console.WriteLine("Hello, 4ERPBI2!");
Plane p1 = new Plane();
p1.Capacity = 200; 
p1.PlaneType = PlaneType.Boing; 
p1.ManufactureDate = new DateTime(2018,04,12); 

Console.WriteLine(p1.ToString());

Plane p2 = new Plane(PlaneType.Airbus , 300 , new DateTime(2023,09,28));

Console.WriteLine(p2.ToString());*/

Plane p3 = new Plane 
{ 
    Capacity = 100, 
    PlaneType = PlaneType.Boing,
    PlaneId=1,
    ManufactureDate=DateTime.Now
};

Console.WriteLine(p3.ToString());

Passenger ps = new Passenger
{
    FullName = new FullName
    {
        FirstName = "MoetezBellah",
        LastName = "Fennira"
    },
    EmailAddress = "MoetezBellah.Fennira@esprit.tn"
};

Console.WriteLine(ps.CheckProfile("MoetezBellah", "Fennira", "MoetezBellah.Fennira@esprit.tn"));

Console.WriteLine("Avant UpperFulName:" + ps.FullName.FirstName + " " , ps.FullName.LastName);
ps.UpperFullName();
Console.WriteLine("Apres UpperFulName:" + ps.FullName.FirstName + " " , ps.FullName.LastName);

ps.PassengerType();
Staff sa = new Staff
{

};
sa.PassengerType();

FlightMethods fm = new FlightMethods();
fm.Flights = TestData.listFlights;

foreach (var item in fm.GetFlightDates("Paris"))
    Console.WriteLine(item);
fm.GetFlights("destination", "Paris");

Console.WriteLine("la methode 10 + sans delegues");
fm.ShowFlightDetails(TestData.plane2);
Console.WriteLine("la methode 16 + avec delegues");
fm.FlightDetailsDel(TestData.plane2);

Console.WriteLine("la methode 11");
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2022, 01, 30)));

Console.WriteLine("la methode 12");
Console.WriteLine(fm.DurationAverage("Paris"));

Console.WriteLine("la methode 13");
foreach (var flight in fm.OrderedDurationFlights())
{
    Console.WriteLine(flight);
}

//Console.WriteLine("la methode 14");
//foreach (var passenger in fm.SeniorTravellers(TestData.flight1))
//{
//    Console.WriteLine(passenger);
//}

Console.WriteLine("la methode 15");
fm.DestinationGroupedFlights();


AMContext context = new AMContext();
context.Flights.Add(TestData.flight2);
context.SaveChanges();
Console.WriteLine(context.Flights.First().MyPlane.Capacity);