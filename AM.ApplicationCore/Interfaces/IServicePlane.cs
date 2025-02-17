﻿using AM.ApplicationCore.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane
    {
        public IEnumerable<Passenger> GetPassengers(Plane plane);
        public bool Getcapacity(Flight flight, int n);
        public IEnumerable<Traveller> GetTravellers(Plane plane, DateTime date);
        public int getnbrTravellers(DateTime starDate, DateTime endDate);
    }
}
