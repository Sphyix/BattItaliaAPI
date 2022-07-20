using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattItaliaAPI.Models
{
    public class Enums
    {
        public enum Role
        {
            User = 0,
            Mod = 1,
            Admin = 2,
        }

        public enum Difficolta
        {
            Facile = 0,
            Medio = 1,
            Difficile = 2,
        }

        public enum StatoOrder
        {
            Assegnato = 0,
            AttesaCliente = 1,
            DaPreventivare = 2,
            DaTestare = 3,
            DaEseguire = 4,
            Finito = 5,
        }
    }
}