using Microsoft.ML.Data;

namespace Lab2_var3;
public class WaterQualityPrediction
{
    [ColumnName("PredictedLabel")]
    public bool Potability { get; set; }
}