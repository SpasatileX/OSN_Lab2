using System;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            MLContext mlContext = new MLContext();
            string dataPath = "../../../data.csv";
            var data = mlContext.Data.LoadFromTextFile<CustomerData>(dataPath, hasHeader: true, separatorChar: ',');
            var pipeline = mlContext.Transforms.Concatenate("Features", "Balance", "BalanceFrequency", "Purchases", "OneOffPurchases", "InstallmentsPurchases", "CashAdvance", "PurchasesFrequency", "OneOffPurchasesFrequency", "PurchasesInstallmentsFrequency", "CashAdvanceFrequency", "CashAdvanceTrx", "PurchasesTrx", "CreditLimit", "Payments", "MinimumPayments", "PrcFullPayment", "Tenure")
                .Append(mlContext.Transforms.NormalizeMinMax("Features"))
                .Append(mlContext.Clustering.Trainers.KMeans("Features", numberOfClusters: 3));

            var model = pipeline.Fit(data);
            var predictions = model.Transform(data);
            var metrics = mlContext.Clustering.Evaluate(predictions, scoreColumnName: "Score", featureColumnName: "Features");

            Console.WriteLine($"NMI: {metrics.NormalizedMutualInformation:F2}");
            Console.WriteLine($"Davies-Bouldin Index: {metrics.DaviesBouldinIndex:F2}");
        }
    }

    public class CustomerData
    {
        [LoadColumn(1)]
        public float Balance { get; set; }
        [LoadColumn(2)]
        public float BalanceFrequency { get; set; }
        [LoadColumn(3)]
        public float Purchases { get; set; }
        [LoadColumn(4)]
        public float OneOffPurchases { get; set; }
        [LoadColumn(5)]
        public float InstallmentsPurchases { get; set; }
        [LoadColumn(6)]
        public float CashAdvance { get; set; }
        [LoadColumn(7)]
        public float PurchasesFrequency { get; set; }
        [LoadColumn(8)]
        public float OneOffPurchasesFrequency { get; set; }
        [LoadColumn(9)]
        public float PurchasesInstallmentsFrequency { get; set; }
        [LoadColumn(10)]
        public float CashAdvanceFrequency { get; set; }
        [LoadColumn(11)]
        public float CashAdvanceTrx { get; set; }
        [LoadColumn(12)]
        public float PurchasesTrx { get; set; }
        [LoadColumn(13)]
        public float CreditLimit { get; set; }
        [LoadColumn(14)]
        public float Payments { get; set; }
        [LoadColumn(15)]
        public float MinimumPayments { get; set; }
        [LoadColumn(16)]
        public float PrcFullPayment { get; set; }
        [LoadColumn(17)]
        public float Tenure { get; set; }
    }
}
