﻿using AM.ApplicationCore.domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; }=new List<Flight>();
        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;
        public FlightMethods()
        {
            //FlightDetailsDel = ShowFlightDetails;//les deux delegues eli 3na pointe sur deux methode existant
            //DurationAverageDel = DurationAverage;

            ///methode anonymes : 
            FlightDetailsDel = p =>
            {
                var req = from f in Flights
                          where f.MyPlane == p
                          select f;
                foreach (var f in req)
                {
                    Console.WriteLine("La destination =" + f.Destination + "La date =" + f.FlightDate);
                }
            };
            DurationAverageDel = destination  =>
            {
                var req = from f in Flights
                          where f.Destination == destination
                          select f.EstimatedDuration;
                return req.Average();
            };
        }
        public List<DateTime> GetFlightDates(string Destination)
        {
            List<DateTime> result = new List<DateTime>();
            /*for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].Destination == Destination)
                    result.Add(Flights[i].FlightDate);
            }*/
            /*foreach (Flight f in Flights) 
            {
                if (f.Destination == Destination)
                    result.Add(f.FlightDate);
            }
            return result;*/
            //linq
            /*IEnumerable<DateTime> req = from f in Flights
                                        where f.Destination.Equals(Destination)
                                        select f.FlightDate;
                        return req.ToList();*/
            //lambda
            IEnumerable<DateTime> req = Flights.Where(f => f.Destination == Destination).Select(f => f.FlightDate);
            return req.ToList();
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "destination":
                    foreach (Flight f in Flights)
                    {
                        if(f.Destination == filterValue)
                            Console.WriteLine(f);
                    }
                    break;
                case "FlightDate":
                    foreach(Flight f in Flights)
                    {
                        if(f.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(f);     
                    }
                    break;
                case "FlightId":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightId == int.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
            }
        }

        public void ShowFlightDetails(Plane plane)
        {
            //Linq
            //var req = from f in Flights
            //          where f.MyPlane == plane
            //          select f;
            //foreach (var f in req)
            //{
            //    Console.WriteLine("La destination =" + f.Destination + "La date =" + f.FlightDate);
            //}
            //Lambda
            var req = Flights.Where(f => f.MyPlane == plane).Select(f=>f);
            foreach (var f in req)
            {
                Console.WriteLine("La destination =" + f.Destination + "La date =" + f.FlightDate);
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //Linq
            //var req = from f in Flights
            //          where DateTime.Compare(f.FlightDate, startDate) > 0
            //          && (f.FlightDate - startDate).TotalDays <7
            //          select f;
            //return req.Count();
            //Lambda
            return (Flights.Where(f=> DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays <7))
                .Count();
        }
        public double DurationAverage(string destination)
        {
            //var req = from f in Flights
            //          where f.Destination == destination
            //          select f.EstimatedDuration;
            //return req.Average();
            return Flights.Where(f=>f.Destination==destination).Select(f=>f.EstimatedDuration).Average();
        }
        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var req = from f in Flights
            //          orderby f.EstimatedDuration descending
            //          select f;
            //return req;
            //Lambda
            return Flights.OrderByDescending(f => f.EstimatedDuration);
        }
        //public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        //{
        //    //var req = from p in flight.ListPassenger.OfType<Traveller>()
        //    //          orderby p.BirthDate
        //    //          select p;
        //    //return  req.Take(3);
        //    //Lambda
        //    //var req = flight.ListPassenger.OfType<Traveller>().OrderBy(p => p.BirthDate);
        //    //return req.Take(3);
        //}
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            //var req = from f in Flights
            //          group f by f.Destination;
            //Lambda
            var req = Flights.GroupBy(f => f.Destination);
            foreach (var g in req)
            {
                Console.WriteLine("Destination : " + g.Key);
                foreach (var f in g)
                {
                    Console.WriteLine("Décollage : " + f.FlightDate);
                }
            }
            return req;
        }
    }
}
