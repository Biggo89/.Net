using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestMapper;

namespace TestMapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            Persona p = new Persona()
            {
                Name = "Mario",
                Surname = "Rossi",
                Son = new List<Figlio>() {
                    new Figlio() { Name="Figlio" , Surname = "Rossi" },
                    new Figlio() { Name ="Figlio1", Surname = "Rossi" }
                },
                Parent = new Genitore()
                {
                    Name = "Genitore",
                    Surname = "Rossi"
                }
            };
            Persona1 p1 = new Persona1() { Name ="Ciccio" , Temp = "ciao" };

            Mapper.Initialize(cfg => cfg.CreateMap<Persona1, Persona>());
            Mapper.Map<Persona1, Persona>(p1,p);
        }
    }
    public class Persona
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Genitore Parent { get; set; }
        public List<Figlio> Son { get; set; }
    }
    public class Genitore
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class Figlio
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class Persona1
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Genitore Parent { get; set; }
        public List<Figlio> Son { get; set; }
        public string Temp { get; set; }
    }
}
