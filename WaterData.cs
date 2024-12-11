using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_var3;

public class WaterData
{
    [LoadColumn(0)]
    public float pH { get; set; } 

    [LoadColumn(1)]
    public float Hardness { get; set; } 

    [LoadColumn(2)]
    public float Solids { get; set; }

    [LoadColumn(3)]
    public float Chloramines { get; set; } 

    [LoadColumn(4)]
    public float Sulfate { get; set; } 

    [LoadColumn(5)]
    public float Conductivity { get; set; }

    [LoadColumn(6)]
    public float Organic_carbon { get; set; } 

    [LoadColumn(7)]
    public float Trihalomethanes { get; set; } 

    [LoadColumn(8)]
    public float Turbidity { get; set; } 

    [LoadColumn(9)]
    public bool Potability { get; set; } 
}
