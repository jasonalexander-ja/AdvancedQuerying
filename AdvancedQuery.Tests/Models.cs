using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedQuery.Tests;

public enum ElementGroupEnum
{
    Other = 0,
    NobleGas = 1,
    AlkalineEarthMetal = 2,
    AlkalineMetal = 3,
    MetalloIdBoron = 4,
    NonmetalCarbon = 5,
    NonmetalPnictogen = 6,
    NonmetalChalcogen = 7,
    Halogen = 8,
    PoorBoron = 9,
    MetalloIdCarbon = 10,
    TransitionMetal = 11,
    MetalloIdPnictogen = 12,
    PoorCarbon = 13,
    MetalloIdChalcogen = 14,
    PoorPnictogen = 15,
    PoorChalcogen = 16
}

public class ElementGroup
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
#pragma warning disable CS8618
    public virtual List<Element> Elements { get; set; }
}

public class Electron
{
    public int ElectronId { get; set; }
    public int Value { get; set; }
    public int ElementId { get; set; }
#pragma warning disable CS8618
    public virtual Element Element { get; set; }
}

public class Element
{
    public int ElementId { get; set; }
    public int GroupId { get; set; }
    public int Position { get; set; }
    public string Name { get; set; } = "";
    public int Number { get; set; }
    public string Small { get; set; } = "";
    public float Molar { get; set; }
#pragma warning disable CS8618
    public virtual List<Electron> Electrons { get; set; }
#pragma warning disable CS8618
    public virtual ElementGroup ElementGroup { get; set; }
}
